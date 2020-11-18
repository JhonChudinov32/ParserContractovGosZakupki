using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDNEW44FZ
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rICDataSet.РИЦКОНТРАКТЫ". При необходимости она может быть перемещена или удалена.
            this.рИЦКОНТРАКТЫTableAdapter.Fill(this.rICDataSet.РИЦКОНТРАКТЫ);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
            Form1 MyForm1 = new Form1();
            MyForm1.ShowDialog();
            Close();
        }
    }
}
