using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BDNEW44FZ
{
    public partial class Form1 : Form
    {
        SqlConnection mainConnection = new SqlConnection(@"Data Source=DPO-STAT1\SQLEXPRESS;Initial Catalog=NewBD44;Integrated Security=True");
        string[] spisok_reg = { "Adygeja_Resp", "Altaj_Resp", "Altajskij_kraj", "Amurskaja_obl", "Arkhangelskaja_obl", "Astrakhanskaja_obl", "Bajkonur_g", "Bashkortostan_Resp", "Belgorodskaja_obl", "Brjanskaja_obl", "Burjatija_Resp", "Chechenskaja_Resp", "Cheljabinskaja_obl", "Chukotskij_AO", "Chuvashskaja_Resp", "Dagestan_Resp", "Evrejskaja_Aobl", "Ingushetija_Resp", "Irkutskaja_obl", "Ivanovskaja_obl", "Jamalo-Neneckij_AO", "Jaroslavskaja_obl", "Kabardino-Balkarskaja_Resp", "Kaliningradskaja_obl", "Kalmykija_Resp", "Kaluzhskaja_obl", "Kamchatskij_kraj", "Karachaevo-Cherkesskaja_Resp", "Karelija_Resp", "Kemerovskaja_obl", "Khabarovskij_kraj", "Khakasija_Resp", "Khanty-Mansijskij_AO-Jugra_AO", "Kirovskaja_obl", "Komi_Resp", "Kostromskaja_obl", "Krasnodarskij_kraj", "Krasnojarskij_kraj", "Krim_Resp", "Kurganskaja_obl", "Kurskaja_obl", "Leningradskaja_obl", "Lipeckaja_obl", "Magadanskaja_obl", "Marij_El_Resp", "Mordovija_Resp", "Moskovskaja_obl", "Moskva", "Murmanskaja_obl", "Neneckij_AO", "Nizhegorodskaja_obl", "Novgorodskaja_obl", "Novosibirskaja_obl", "Omskaja_obl", "Orenburgskaja_obl", "Orlovskaja_obl", "Penzenskaja_obl", "Permskij_kraj", "Primorskij_kraj", "Pskovskaja_obl", "Rjazanskaja_obl", "Rostovskaja_obl", "Sakha_Jakutija_Resp", "Sakhalinskaja_obl", "Samarskaja_obl", "Sankt-Peterburg", "Saratovskaja_obl", "Sevastopol_g", "Severnaja_Osetija-Alanija_Resp", "Smolenskaja_obl", "Stavropolskij_kraj", "Sverdlovskaja_obl", "Tambovskaja_obl", "Tatarstan_Resp", "Tjumenskaja_obl", "Tomskaja_obl", "Tulskaja_obl", "Tverskaja_obl", "Tyva_Resp", "Udmurtskaja_Resp", "Uljanovskaja_obl", "Vladimirskaja_obl", "Volgogradskaja_obl", "Vologodskaja_obl", "Voronezhskaja_obl", "Zabajkalskij_kraj" };
        string[] papki = { "/contracts/currMonth/", "/contracts/prevMonth/" };
        public class FTP
        {
            private System.Net.NetworkCredential _credentials;
            public FTP(string _FTPUser, string _FTPPass)
            {
                SetCredentials(_FTPUser, _FTPPass);
            }
            public List<string> GetDirectory(string ftpPath)
            {
                List<string> ret = new List<string>();
                try
                {
                    FtpWebRequest _request = (FtpWebRequest)WebRequest.Create(ftpPath);
                    _request.KeepAlive = false;
                    _request.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;
                    _request.Credentials = _credentials;

                    FtpWebResponse _response = (FtpWebResponse)_request.GetResponse();
                    System.IO.Stream responseStream = _response.GetResponseStream();
                    System.IO.StreamReader _reader = new System.IO.StreamReader(responseStream);
                    string FileData = _reader.ReadToEnd();
                    string[] Lines = FileData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string l in Lines)
                        ret.Add(l);
                    _reader.Close();
                    _response.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Directory Fetch Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return ret;
            }
            private void SetCredentials(string _FTPUser, string _FTPPass)
            {
                _credentials = new System.Net.NetworkCredential(_FTPUser, _FTPPass);
            }
        }
        public Form1()
        {
            InitializeComponent();

            Application.DoEvents();
        }
        public void Loadfiles(string[] FileNames)
        {
            progressBar1.Maximum = FileNames.Length;
            progressBar1.Value = progressBar1.Value + 1;
            double gg = progressBar1.Maximum / 100D;
            double percent = progressBar1.Value / gg;
            Application.DoEvents();
            label2.Text = "Обработано/Всего : " + progressBar1.Value.ToString() + "/" + progressBar1.Maximum.ToString();
            label1.Text = $"Загружено { string.Format("{0:0.##}", percent)}%";
        }
        public void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                double receive = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = receive / total * 100;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
                label1.Text = $"Загружено { string.Format("{0:0.##}", percentage)}%";
        }
        public void LoadfilesZ(string[] FileNames)
        {
            progressBar1.Maximum = FileNames.Length;
            progressBar1.Value = progressBar1.Value + 1;
            double gg = progressBar1.Maximum / 100D;
            double percent = progressBar1.Value / gg;
            Application.DoEvents();
            label2.Text = "Обработано/Всего : " + progressBar1.Value.ToString() + "/" + progressBar1.Maximum.ToString();
            label1.Text = $"Загружено { string.Format("{0:0.##}", percent)}%";
        }
        public void FileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            for (int pap = 0; pap <= papki.GetUpperBound(0); pap++)
            {
                try
                {
                    string[] filenames = Directory.GetFiles(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap]);
                    foreach (string file in filenames)
                    {
                        Loadfiles(filenames);
                        if (File.ReadAllBytes(file).Length > 22L)
                        {
                            string folder = @"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + "извлечено/";
                            System.Diagnostics.Process p = new System.Diagnostics.Process();
                            p.StartInfo.FileName = @"C:\Program Files\WinRAR\WinRAR.exe";
                            p.StartInfo.Arguments = string.Format("x -o+ \"{0}\" \"{1}\"", file, folder);
                            p.EnableRaisingEvents = true;
                            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            p.Start();
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string[] files = Directory.GetFiles(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + "извлечено/", "contract_*.xml");
                Parser(files);
            }
            MessageBox.Show("Обновление Завешено");
        }
       /* private DataTable CreateTable()
        {
            //создаём таблицу

            DataTable dt = new DataTable();
            //создаём три колонки
            DataColumn contractID = new DataColumn("contractID", typeof(String));
            DataColumn purchaseNumber = new DataColumn("purchaseNumber", typeof(String));
            DataColumn contractRegNum = new DataColumn("contractRegNum", typeof(String));
            DataColumn customerFullName = new DataColumn("customerFullName", typeof(String));
            DataColumn customerINN = new DataColumn("customerINN", typeof(String));
            DataColumn supplierFullName = new DataColumn("supplierFullName", typeof(String));
            DataColumn supplierINN = new DataColumn("supplierINN", typeof(String));

            DataColumn protocolDate = new DataColumn("protocolDate", typeof(String));
            DataColumn signDate = new DataColumn("signDate", typeof(String));
            DataColumn number = new DataColumn("number", typeof(String));
            DataColumn startDate = new DataColumn("startDate", typeof(String));
            DataColumn endDate = new DataColumn("endDate", typeof(String));

            DataColumn KTRUcode = new DataColumn("KTRUcode", typeof(String));
            DataColumn price = new DataColumn("price", typeof(String));
            DataColumn modificationReasonName = new DataColumn("modificationReasonName", typeof(String));

            DataColumn placing = new DataColumn("placing", typeof(String));
            DataColumn contractSubject = new DataColumn("contractSubject", typeof(String));
            DataColumn currentContractStage = new DataColumn("currentContractStage", typeof(String));
            DataColumn contractExecution = new DataColumn("contractExecution", typeof(String));

            //добавляем колонки в таблицу


            dt.Columns.Add(contractID);
            dt.Columns.Add(purchaseNumber);
            dt.Columns.Add(contractRegNum);
            dt.Columns.Add(customerFullName);
            dt.Columns.Add(customerINN);
            dt.Columns.Add(supplierFullName);
            dt.Columns.Add(supplierINN);
            dt.Columns.Add(protocolDate);
            dt.Columns.Add(signDate);
            dt.Columns.Add(number);
            dt.Columns.Add(startDate);
            dt.Columns.Add(endDate);
            dt.Columns.Add(KTRUcode);
            dt.Columns.Add(price);
            dt.Columns.Add(modificationReasonName);
            dt.Columns.Add(placing);
            dt.Columns.Add(contractSubject);
            dt.Columns.Add(currentContractStage);
            dt.Columns.Add(contractExecution);

            return dt;
        }
        private DataTable CreateTable2()
        {
            DataTable dt = new DataTable();
            //создаём три колонки

            DataColumn regNum = new DataColumn("regNum", typeof(String));
            DataColumn publishDate = new DataColumn("publishDate", typeof(String));
            DataColumn currentContractStage = new DataColumn("currentContractStage", typeof(String));

            //добавляем колонки в таблицу
            dt.Columns.Add(regNum);
            dt.Columns.Add(publishDate);
            dt.Columns.Add(currentContractStage);

            return dt;
        }
        private DataTable CreateTable3()
        {
            DataTable dt = new DataTable();
            //создаём три колонки
            DataColumn cancelledProcedureId = new DataColumn("cancelledProcedureId", typeof(String));
            DataColumn regNum = new DataColumn("regNum", typeof(String));
            DataColumn cancelDate = new DataColumn("cancelDate", typeof(String));
            DataColumn reason = new DataColumn("reason", typeof(String));

            //добавляем колонки в таблицу

            dt.Columns.Add(cancelledProcedureId);
            dt.Columns.Add(regNum);
            dt.Columns.Add(cancelDate);
            dt.Columns.Add(reason);

            return dt;

        }
        private DataTable CreateTable4()
        {
            DataTable dt = new DataTable();
            //создаём три колонки
            DataColumn regNum = new DataColumn("regNum", typeof(String));
            DataColumn cancelDate = new DataColumn("cancelDate", typeof(String));
            DataColumn documentBase = new DataColumn("documentBase", typeof(String));
            DataColumn number = new DataColumn("number", typeof(String));
            DataColumn CregNum = new DataColumn("CregNum", typeof(String));
            DataColumn signName = new DataColumn("signName", typeof(String));
            DataColumn currentContractStage = new DataColumn("currentContractStage", typeof(String));
            //добавляем колонки в таблицу

            dt.Columns.Add(regNum);
            dt.Columns.Add(cancelDate);
            dt.Columns.Add(documentBase);
            dt.Columns.Add(number);
            dt.Columns.Add(CregNum);
            dt.Columns.Add(signName);
            dt.Columns.Add(currentContractStage);

            return dt;

        }*/
        private void Parser(string[] file)
        {
                //Код парсера
                try
                {
                    XmlDocument xDoc = new XmlDocument();
                    foreach (string fil in file)
                    {
                    String attr ="";
                    String attr0 = "";
                    String attr1 = "";
                    String attr2 = "";
                    String attr3 = "";
                    String attr4 = "";
                    String attr41 = "";
                    String attr42 = "";
                    String attr5 = "";
                    String attr6 = "";
                    String attr7 = "";
                    String attr8 = "";
                    String attr9 = "";
                    String attr10 = "";
                    String attr11 = "";
                    String attr12 = "";
                    String attr13 = "";
                    String attr14 = "";
                    String attr15 = "";
                    String attr16 = "";
                    String attr161 = "";
                    Application.DoEvents();
                        LoadfilesZ(file);
                        if (fil.Length > 0)
                        {
                          
                            xDoc.Load(fil);

                            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xDoc.NameTable);
                            namespaceManager.AddNamespace("q", "http://zakupki.gov.ru/oos/types/1");
                            namespaceManager.AddNamespace("s", "http://zakupki.gov.ru/oos/common/1");
                            namespaceManager.AddNamespace("p", "http://zakupki.gov.ru/oos/EPtypes/1");
                            namespaceManager.AddNamespace("n", "http://zakupki.gov.ru/oos/base/1");

                            if (xDoc.SelectSingleNode("//q:id", namespaceManager) != null)
                            {
                                attr0 = xDoc.SelectSingleNode("//q:id", namespaceManager).InnerText;
                                
                            }
                            if (xDoc.SelectSingleNode("//q:foundation/q:fcsOrder/q:order/q:notificationNumber", namespaceManager) != null)
                            {
                                attr = xDoc.SelectSingleNode("//q:foundation/q:fcsOrder/q:order/q:notificationNumber", namespaceManager).InnerText;
                              
                            }
                            else if (xDoc.SelectSingleNode("//q:foundation/q:oosOrder/q:order/q:notificationNumber", namespaceManager) != null)
                            {
                                attr = xDoc.SelectSingleNode("//q:foundation/q:oosOrder/q:order/q:notificationNumber", namespaceManager).InnerText;
                               
                            }
                            else if (xDoc.SelectSingleNode("//q:notificationNumber", namespaceManager) != null)
                            {
                                attr = xDoc.SelectSingleNode("//q:notificationNumber", namespaceManager).InnerText;
                               
                            }
                            else attr = "-";

                            if (xDoc.SelectSingleNode("//q:regNum", namespaceManager) != null)
                            {
                                attr1 = xDoc.SelectSingleNode("//q:regNum", namespaceManager).InnerText;
                                
                            }
                            else attr1 = "-";

                            if (xDoc.SelectSingleNode("//q:customer/q:fullName", namespaceManager) != null)
                            {
                                attr2 = xDoc.SelectSingleNode("//q:customer/q:fullName", namespaceManager).InnerText;
                               
                            }
                            else attr2 = "-";

                            if (xDoc.SelectSingleNode("//q:customer/q:inn", namespaceManager) != null)
                            {
                                attr3 = xDoc.SelectSingleNode("//q:customer/q:inn", namespaceManager).InnerText;
                                
                            }
                            else attr3 = "-";

                            if (xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:legalEntityRF/q:fullName", namespaceManager) != null)
                            {
                                attr4 = xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:legalEntityRF/q:fullName", namespaceManager).InnerText;

                            }
                            else if (xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:individualPersonRF/q:lastName", namespaceManager) != null && xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:individualPersonRF/q:firstName", namespaceManager) != null && xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:individualPersonRF/q:middleName", namespaceManager) != null)
                            {
                                attr4 = xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:individualPersonRF/q:lastName", namespaceManager).InnerText;
                                attr41 = xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:individualPersonRF/q:firstName", namespaceManager).InnerText;
                                attr42 = xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:individualPersonRF/q:middleName", namespaceManager).InnerText;
                                attr4  = "ИП" + " " + attr4 + " " + attr41 + " " + attr42;
                            }
                            else attr4 = "-"; 

                            if (xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:legalEntityRF/q:INN", namespaceManager) != null)
                            {
                                attr5 = xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:legalEntityRF/q:INN", namespaceManager).InnerText;
                                
                            }
                            else if (xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:individualPersonRF/q:INN", namespaceManager) != null)
                            {
                                attr5 = xDoc.SelectSingleNode("//q:suppliers/q:supplier/q:individualPersonRF/q:INN", namespaceManager).InnerText;
                             
                            }
                            else attr5 = "-";

                            if (xDoc.SelectSingleNode("//q:protocolDate", namespaceManager) != null)
                            {
                                attr6 = xDoc.SelectSingleNode("//q:protocolDate", namespaceManager).InnerText;
                              
                            }
                            else attr6 = "-";

                            if (xDoc.SelectSingleNode("//q:signDate", namespaceManager) != null)
                            {
                                attr7 = xDoc.SelectSingleNode("//q:signDate", namespaceManager).InnerText;
                              
                            }
                            else attr7 = "-";

                            if (xDoc.SelectSingleNode("//q:number", namespaceManager) != null)
                            {
                                attr8 = xDoc.SelectSingleNode("//q:number", namespaceManager).InnerText;
                               
                            }
                            else attr8 = "-";

                            if (xDoc.SelectSingleNode("//q:startDate", namespaceManager) != null)
                            {
                                attr9 = xDoc.SelectSingleNode("//q:startDate", namespaceManager).InnerText;
                                
                            }
                            else attr9 = "-";

                            if (xDoc.SelectSingleNode("//q:endDate", namespaceManager) != null)
                            {
                                attr10 = xDoc.SelectSingleNode("//q:endDate", namespaceManager).InnerText;
                                
                            }
                            else attr10 = "-";

                            if (xDoc.SelectSingleNode("//q:products/q:product/q:OKPD2/q:code", namespaceManager) != null)
                            {
                                attr11 = xDoc.SelectSingleNode("//q:products/q:product/q:OKPD2/q:code", namespaceManager).InnerText;
                               
                            }
                            else if (xDoc.SelectSingleNode("//q:KTRU/q:code", namespaceManager) != null)
                            {
                                attr11 = xDoc.SelectSingleNode("//q:KTRU/q:code", namespaceManager).InnerText;
                               
                            }
                            else attr11 = "-";

                            if (xDoc.SelectSingleNode("//q:price", namespaceManager) != null)
                            {
                                attr12 = xDoc.SelectSingleNode("//q:price", namespaceManager).InnerText;
                                
                            }
                            else attr12 = "-";

                            if (xDoc.SelectSingleNode("//q:modification/q:errorCorrection/q:description", namespaceManager) != null)
                            {
                                attr13 = xDoc.SelectSingleNode("//q:modification/q:errorCorrection/q:description", namespaceManager).InnerText;
                                
                            }
                            else if (xDoc.SelectSingleNode("//q:modification/q:contractChange/q:reason/q:name", namespaceManager) != null)
                            {
                                attr13 = xDoc.SelectSingleNode("//q:modification/q:contractChange/q:reason/q:name", namespaceManager).InnerText;
                               
                            }
                            else attr13 = "-";

                            if (xDoc.SelectSingleNode("//q:foundation/q:fcsOrder/q:order/q:placing", namespaceManager) != null)
                            {
                                attr14 = xDoc.SelectSingleNode("//q:foundation/q:fcsOrder/q:order/q:placing", namespaceManager).InnerText;
                               
                            }
                            else if (xDoc.SelectSingleNode("//q:foundation/q:oosOrder/q:order/q:placing", namespaceManager) != null)
                            {
                                attr14 = xDoc.SelectSingleNode("//q:foundation/q:oosOrder/q:order/q:placing", namespaceManager).InnerText;
                                
                            }
                            else attr14 = "-";

                            if (xDoc.SelectSingleNode("//q:contractSubject", namespaceManager) != null)
                            {
                                attr15 = xDoc.SelectSingleNode("//q:contractSubject", namespaceManager).InnerText;
                                
                            }
                            else attr15 = "-";

                            if (xDoc.SelectSingleNode("//q:currentContractStage", namespaceManager) != null)
                            {
                                attr16 = xDoc.SelectSingleNode("//q:currentContractStage", namespaceManager).InnerText;
                              
                            }
                            else attr16 = "-";

                            if (xDoc.SelectSingleNode("//q:foundation/q:fcsOrder/q:order/q:singleCustomer/q:reason/q:name", namespaceManager) != null)
                            {
                                attr161 = xDoc.SelectSingleNode("//q:foundation/q:fcsOrder/q:order/q:singleCustomer/q:reason/q:name", namespaceManager).InnerText;
                              
                            }
                            else if (xDoc.SelectSingleNode("//q:foundation/q:oosOrder/q:order/q:singleCustomer/q:reason/q:name", namespaceManager) != null)
                            {
                                attr161 = xDoc.SelectSingleNode("//q:foundation/q:oosOrder/q:order/q:singleCustomer/q:reason/q:name", namespaceManager).InnerText;
                               
                            }
                            else attr161 = "-";

                            int m = 0;
                            SqlCommand SqlProv = new SqlCommand(@"SELECT COUNT(purchaseNumber) As CountTabNum FROM dbo.Contract WHERE [purchaseNumber]= '" + attr + "' ", mainConnection);
                            mainConnection.Open();
                            m = (Int32)(SqlProv.ExecuteScalar());
                            mainConnection.Close();


                            if (m == 0)
                            {

                                // подключение к БД
                                mainConnection.Open();
                                // внесение данных в БД
                                SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.Contract(contractID,purchaseNumber,contractRegNum,customerFullName,customerINN,supplierFullName,supplierINN,protocolDate,signDate,number,startDate,endDate,KTRUcode,price,modificationReasonName,currentContractStage,placing,contractSubject,contractExecution) VALUES (@attr0,@attr,@attr1,@attr2,@attr3,@attr4,@attr5,@attr6,@attr7,@attr8,@attr9,@attr10,@attr11,@attr12,@attr13,@attr16,@attr14,@attr15,@attr161) 
                                                                             ", mainConnection);
                                cmd.Parameters.AddWithValue("@attr0", attr0);
                                cmd.Parameters.AddWithValue("@attr", attr);
                                cmd.Parameters.AddWithValue("@attr1", attr1);
                                cmd.Parameters.AddWithValue("@attr2", attr2);
                                cmd.Parameters.AddWithValue("@attr3", attr3);
                                cmd.Parameters.AddWithValue("@attr4", attr4);
                                cmd.Parameters.AddWithValue("@attr5", attr5);
                                cmd.Parameters.AddWithValue("@attr6", attr6);
                                cmd.Parameters.AddWithValue("@attr7", attr7);
                                cmd.Parameters.AddWithValue("@attr8", attr8);
                                cmd.Parameters.AddWithValue("@attr9", attr9);
                                cmd.Parameters.AddWithValue("@attr10", attr10);
                                cmd.Parameters.AddWithValue("@attr11", attr11);
                                cmd.Parameters.AddWithValue("@attr12", attr12);
                                cmd.Parameters.AddWithValue("@attr13", attr13);
                                cmd.Parameters.AddWithValue("@attr14", attr14);
                                cmd.Parameters.AddWithValue("@attr15", attr15);
                                cmd.Parameters.AddWithValue("@attr16", attr16);
                                cmd.Parameters.AddWithValue("@attr161", attr161);


                                cmd.ExecuteNonQuery();

                                //добавляем новую запись в таблицу
                               
                                mainConnection.Close();

                            }

                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
                mainConnection.Close();
            
        }
        /*  private void Parser1(string[] file)
          {
              DataTable ReadXml1()
              {
                  DataTable dt2 = null;
                  //Код парсера
                  try
                  {
                      dt2 = CreateTable2();
                      DataRow newRow1 = null;
                      XmlDocument xDoc = new XmlDocument();


                      string attr17;
                      string attr18;
                      string attr181;

                      foreach (string fil in file)
                      {

                          if (fil.Length > 0)
                          {
                              newRow1 = dt2.NewRow();
                              //loadfiles();
                              xDoc.Load(fil);
                              XmlNamespaceManager namespaceManager1 = new XmlNamespaceManager(xDoc.NameTable);
                              namespaceManager1.AddNamespace("q", "http://zakupki.gov.ru/oos/types/1");
                              namespaceManager1.AddNamespace("s", "http://zakupki.gov.ru/oos/common/1");
                              namespaceManager1.AddNamespace("p", "http://zakupki.gov.ru/oos/EPtypes/1");
                              namespaceManager1.AddNamespace("n", "http://zakupki.gov.ru/oos/base/1");

                              if (xDoc.SelectSingleNode("//q:regNum", namespaceManager1) != null)
                              {
                                  attr17 = xDoc.SelectSingleNode("//q:regNum", namespaceManager1).InnerText;
                                  newRow1["regNum"] = attr17;
                              }
                              else newRow1["regNum"] = '-';

                              if (xDoc.SelectSingleNode("//q:publishDate", namespaceManager1) != null)
                              {
                                  attr18 = xDoc.SelectSingleNode("//q:publishDate", namespaceManager1).InnerText;
                                  newRow1["publishDate"] = attr18;
                              }
                              if (xDoc.SelectSingleNode("//q:currentContractStage", namespaceManager1) != null)
                              {
                                  attr181 = xDoc.SelectSingleNode("//q:currentContractStage", namespaceManager1).InnerText;
                                  newRow1["currentContractStage"] = attr181;
                              }
                              else newRow1["currentContractStage"] = '-';

                              int m = 0;
                              SqlCommand SqlProv = new SqlCommand(@"SELECT COUNT(regNum) As CountTabNum FROM dbo.ContractProcedure WHERE [regNum]= '" + newRow1["regNum"] + "' ", mainConnection);
                              mainConnection.Open();
                              m = (Int32)(SqlProv.ExecuteScalar());
                              mainConnection.Close();


                              if (m == 0)
                              {

                                  // подключение к БД
                                  mainConnection.Open();
                                  // внесение данных в БД
                                  SqlCommand cmd1 = new SqlCommand(@"INSERT INTO dbo.ContractProcedure(regNum,publishDate,currentContractStage) VALUES (@attr17,@attr18,@attr181) 
                                                                               ", mainConnection);

                                  cmd1.Parameters.AddWithValue("@attr17", newRow1["regNum"]);
                                  cmd1.Parameters.AddWithValue("@attr18", newRow1["publishDate"]);
                                  cmd1.Parameters.AddWithValue("@attr181", newRow1["currentContractStage"]);


                                  cmd1.ExecuteNonQuery();

                                  //добавляем новую запись в таблицу
                                  dt2.Rows.Add(newRow1);
                                  mainConnection.Close();
                              }

                          }
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
                  return dt2;
              }
              {
                  dt.DataSource = ReadXml1();
                  mainConnection.Close();
              }
          }
          private void Parser2(string[] file)
          {
              DataTable ReadXml2()
              {
                  DataTable dt3 = null;
                  //Код парсера
                  try
                  {
                      dt3 = CreateTable3();
                      DataRow newRow2 = null;
                      XmlDocument xDoc = new XmlDocument();
                      string attr19;
                      string attr20;
                      string attr21;
                      string attr22;
                      foreach (string fil in file)
                      {
                          if (fil.Length > 0)
                          {
                              newRow2 = dt3.NewRow();

                              xDoc.Load(fil);
                              XmlNamespaceManager namespaceManager1 = new XmlNamespaceManager(xDoc.NameTable);
                              namespaceManager1.AddNamespace("q", "http://zakupki.gov.ru/oos/types/1");
                              namespaceManager1.AddNamespace("s", "http://zakupki.gov.ru/oos/common/1");
                              namespaceManager1.AddNamespace("p", "http://zakupki.gov.ru/oos/EPtypes/1");
                              namespaceManager1.AddNamespace("n", "http://zakupki.gov.ru/oos/base/1");

                              if (xDoc.SelectSingleNode("//q:cancelledProcedureId", namespaceManager1) != null)
                              {
                                  attr19 = xDoc.SelectSingleNode("//q:cancelledProcedureId", namespaceManager1).InnerText;
                                  newRow2["cancelledProcedureId"] = attr19;
                              }
                              else newRow2["cancelledProcedureId"] = '-';

                              if (xDoc.SelectSingleNode("//q:regNum", namespaceManager1) != null)
                              {
                                  attr20 = xDoc.SelectSingleNode("//q:regNum", namespaceManager1).InnerText;
                                  newRow2["regNum"] = attr20;
                              }
                              else newRow2["regNum"] = '-';

                              if (xDoc.SelectSingleNode("//q:cancelDate", namespaceManager1) != null)
                              {
                                  attr21 = xDoc.SelectSingleNode("//q:cancelDate", namespaceManager1).InnerText;
                                  newRow2["cancelDate"] = attr21;
                              }
                              else newRow2["cancelDate"] = "-";

                              if (xDoc.SelectSingleNode("//q:reason", namespaceManager1) != null)
                              {
                                  attr22 = xDoc.SelectSingleNode("//q:reason", namespaceManager1).InnerText;
                                  newRow2["reason"] = attr22;
                              }
                              else newRow2["reason"] = '-';

                              int m = 0;
                              SqlCommand SqlProv = new SqlCommand(@"SELECT COUNT(regNum) As CountTabNum FROM dbo.ContractProcedureCancel WHERE [regNum]= '" + newRow2["regNum"] + "' ", mainConnection);
                              mainConnection.Open();
                              m = (Int32)(SqlProv.ExecuteScalar());
                              mainConnection.Close();


                              if (m == 0)
                              {

                                  // подключение к БД
                                  mainConnection.Open();
                                  // внесение данных в БД
                                  SqlCommand cmd2 = new SqlCommand(@"INSERT INTO dbo.ContractProcedureCancel(cancelledProcedureId,regNum,cancelDate,reason) VALUES (@attr19,@attr20,@attr21,@attr22) ", mainConnection);

                                  cmd2.Parameters.AddWithValue("@attr19", newRow2["cancelledProcedureId"]);
                                  cmd2.Parameters.AddWithValue("@attr20", newRow2["regNum"]);
                                  cmd2.Parameters.AddWithValue("@attr21", newRow2["cancelDate"]);
                                  cmd2.Parameters.AddWithValue("@attr22", newRow2["reason"]);


                                  cmd2.ExecuteNonQuery();

                                  //добавляем новую запись в таблицу
                                  dt3.Rows.Add(newRow2);
                                  mainConnection.Close();
                              }

                          }
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
                  return dt3;
              }
              {
                  dt.DataSource = ReadXml2();
                  mainConnection.Close();
              }
          }
          private void Parser3(string[] file)
          {
              DataTable ReadXml3()
              {
                  DataTable dt4 = null;
                  //Код парсера
                  try
                  {
                      dt4 = CreateTable4();
                      DataRow newRow3 = null;
                      XmlDocument xDoc = new XmlDocument();
                      string attr23;
                      string attr24;
                      string attr25;
                      string attr26;
                      string attr27;
                      string attr28;
                      string attr29;
                      foreach (string fil in file)
                      {
                          if (fil.Length > 0)
                          {
                              newRow3 = dt4.NewRow();
                              xDoc.Load(fil);
                              XmlNamespaceManager namespaceManager1 = new XmlNamespaceManager(xDoc.NameTable);
                              namespaceManager1.AddNamespace("q", "http://zakupki.gov.ru/oos/types/1");
                              namespaceManager1.AddNamespace("s", "http://zakupki.gov.ru/oos/common/1");
                              namespaceManager1.AddNamespace("p", "http://zakupki.gov.ru/oos/EPtypes/1");
                              namespaceManager1.AddNamespace("n", "http://zakupki.gov.ru/oos/base/1");
                              if (xDoc.SelectSingleNode("//q:regNum", namespaceManager1) != null)
                              {
                                  attr23 = xDoc.SelectSingleNode("//q:regNum", namespaceManager1).InnerText;
                                  newRow3["regNum"] = attr23;
                              }
                              else newRow3["regNum"] = '-';
                              if (xDoc.SelectSingleNode("//q:cancelDate", namespaceManager1) != null)
                              {
                                  attr24 = xDoc.SelectSingleNode("//q:cancelDate", namespaceManager1).InnerText;
                                  newRow3["cancelDate"] = attr24;
                              }
                              else newRow3["cancelDate"] = '-';
                              if (xDoc.SelectSingleNode("//q:documentBase", namespaceManager1) != null)
                              {
                                  attr25 = xDoc.SelectSingleNode("//q:documentBase", namespaceManager1).InnerText;
                                  newRow3["documentBase"] = attr25;
                              }
                              else newRow3["documentBase"] = "-";
                              if (xDoc.SelectSingleNode("//q:contractPrintFormInfo/q:number", namespaceManager1) != null)
                              {
                                  attr26 = xDoc.SelectSingleNode("//q:contractPrintFormInfo/q:number", namespaceManager1).InnerText;
                                  newRow3["number"] = attr26;
                              }
                              else newRow3["number"] = '-';
                              if (xDoc.SelectSingleNode("//q:contractPrintFormInfo/q:customer/q:regNum", namespaceManager1) != null)
                              {
                                  attr27 = xDoc.SelectSingleNode("//q:contractPrintFormInfo/q:customer/q:regNum", namespaceManager1).InnerText;
                                  newRow3["CregNum"] = attr27;
                              }
                              else newRow3["CregNum"] = '-';
                              if (xDoc.SelectSingleNode("//q:contractPrintFormInfo/q:signName", namespaceManager1) != null)
                              {
                                  attr28 = xDoc.SelectSingleNode("//q:contractPrintFormInfo/q:signName", namespaceManager1).InnerText;
                                  newRow3["signName"] = attr28;
                              }
                              else newRow3["signName"] = "-";
                              if (xDoc.SelectSingleNode("//q:currentContractStage", namespaceManager1) != null)
                              {
                                  attr29 = xDoc.SelectSingleNode("//q:currentContractStage", namespaceManager1).InnerText;
                                  newRow3["currentContractStage"] = attr29;
                              }
                              else newRow3["currentContractStage"] = '-';
                              int m = 0;
                              SqlCommand SqlProv = new SqlCommand(@"SELECT COUNT(regNum) As CountTabNum FROM dbo.ContractCancel WHERE [regNum]= '" + newRow3["regNum"] + "' ", mainConnection);
                              mainConnection.Open();
                              m = (Int32)(SqlProv.ExecuteScalar());
                              mainConnection.Close();
                              if (m == 0)
                              {
                                  // подключение к БД
                                  mainConnection.Open();
                                  // внесение данных в БД
                                  SqlCommand cmd3 = new SqlCommand(@"INSERT INTO dbo.ContractCancel(regNum,cancelDate,documentBase,number,CregNum,signName,currentContractStage) VALUES (@attr23,@attr24,@attr25,@attr26,@attr27,@attr28,@attr29) ", mainConnection);
                                  cmd3.Parameters.AddWithValue("@attr23", newRow3["regNum"]);
                                  cmd3.Parameters.AddWithValue("@attr24", newRow3["cancelDate"]);
                                  cmd3.Parameters.AddWithValue("@attr25", newRow3["documentBase"]);
                                  cmd3.Parameters.AddWithValue("@attr26", newRow3["number"]);
                                  cmd3.Parameters.AddWithValue("@attr27", newRow3["CregNum"]);
                                  cmd3.Parameters.AddWithValue("@attr28", newRow3["signName"]);
                                  cmd3.Parameters.AddWithValue("@attr29", newRow3["currentContractStage"]);
                                  cmd3.ExecuteNonQuery();
                                  //добавляем новую запись в таблицу
                                  dt4.Rows.Add(newRow3);
                                  mainConnection.Close();
                              }
                          }
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
                  return dt4;
              }
              {
                  dt.DataSource = ReadXml3();
                  mainConnection.Close();
              }
          }*/
        private void Button2_Click(object sender, EventArgs e)
        {
            FTP ftp = new FTP("free", "free");
            int pap;
            int index;
            for (pap = 0; pap <= papki.GetUpperBound(0); pap++)
            {
                try
                {

                    SqlCommand SqlProv;

                    if (Directory.Exists(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap]))
                    {
                        Directory.Delete(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap], true);
                        Directory.CreateDirectory(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap]);
                        Directory.CreateDirectory(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + "извлечено/");
                    }
                    else
                    {
                        Directory.CreateDirectory(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap]);
                        Directory.CreateDirectory(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + "извлечено/");
                    }


                    for (index = 0; index <= spisok_reg.GetUpperBound(0); index++)
                    {
                        for (pap = 0; pap <= papki.GetUpperBound(0); pap++)
                        {
                            string S = "";
                            int n;
                            // проверяются загружены ли новые архивы за последние n дней
                            for (n = -30; n <= 0; n++)
                            {

                                var nD = DateTime.Today.AddDays(n);
                                S = nD.ToString("yyyyMMdd");
                                /// MessageBox.Show(S);
                                List<string> regions = ftp.GetDirectory("ftp://ftp.zakupki.gov.ru/fcs_regions/" + spisok_reg[index] + papki[pap]);

                                foreach (string filename in regions)
                                {
                                    if (filename.Contains(S))
                                    {

                                        int k = 0;
                                        SqlCommand SqlCom;
                                        SqlProv = new SqlCommand("SELECT COUNT(Name) As CountTabNum FROM dbo.Files WHERE [Name]='" + filename + "'", mainConnection);
                                        mainConnection.Open();
                                        k = (Int32)SqlProv.ExecuteScalar();
                                        mainConnection.Close();
                                        if (k == 0)
                                        {

                                            SqlCom = new SqlCommand("INSERT INTO [Files] ([Name], [Date]) VALUES ('" + filename + "','" + DateTime.Now.ToString("dd.MM.yyyy") + " " + DateTime.Now.ToString("HH:mm:ss") + "')", mainConnection);
                                            mainConnection.Open();
                                            SqlCom.ExecuteNonQuery();
                                            mainConnection.Close();
                                            //   Application.DoEvents();
                                            WebClient wc = new WebClient
                                            {
                                                BaseAddress = @"ftp://ftp.zakupki.gov.ru/fcs_regions/",
                                                Credentials = new NetworkCredential("free", "free")
                                            };
                                            // wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileCompleted);
                                            // wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                                            wc.DownloadFile(new Uri(@"ftp://ftp.zakupki.gov.ru/fcs_regions/" + spisok_reg[index] + papki[pap] + filename), @"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + filename);

                                            if (File.ReadAllBytes(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + filename).Length > 22L)
                                            {

                                                System.Diagnostics.Process p = new System.Diagnostics.Process();
                                                p.StartInfo.FileName = @"C:\Program Files\WinRAR\WinRAR.exe";
                                                p.StartInfo.Arguments = string.Format("x -o+ \"{0}\" \"{1}\"", @"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + filename, @"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + "извлечено/");
                                                p.EnableRaisingEvents = true;
                                                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                                p.Start();

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string[] files = Directory.GetFiles(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + "извлечено/", "contract_*.xml");
                Parser(files);
                MessageBox.Show("Обновление Завешено");
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            for (int pap = 0; pap <= papki.GetUpperBound(0); pap++)
            {
               /* try
               {
                    string[] filenames = Directory.GetFiles(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap]);
                    foreach (string file in filenames)
                    {
                        Loadfiles(filenames);
                        if (File.ReadAllBytes(file).Length > 22L)
                        {
                            string folder = @"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + "извлечено/";
                            System.Diagnostics.Process p = new System.Diagnostics.Process();
                            p.StartInfo.FileName = @"C:\Program Files\WinRAR\WinRAR.exe";
                            p.StartInfo.Arguments = string.Format("x -o+ \"{0}\" \"{1}\"", file, folder);
                            p.EnableRaisingEvents = true;
                            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            p.Start();
                            // string[] files = Directory.GetFiles(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + "извлечено/", "contract_*.xml");
                            //  Parser(files);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }*/
                string[] files = Directory.GetFiles(@"X:\DUS\PravOtnosh\Чудинов\" + papki[pap] + "извлечено/", "contract_*.xml");
                Parser(files);
             }
            MessageBox.Show("Обновление Завешено");
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Form2 MyForm2 = new Form2();
            MyForm2.ShowDialog();
            Close();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "newBD44DataSet.РИЦКОНТРАКТЫ1". При необходимости она может быть перемещена или удалена.
            this.рИЦКОНТРАКТЫ1TableAdapter.Fill(this.newBD44DataSet.РИЦКОНТРАКТЫ1);
        }
    }
}

