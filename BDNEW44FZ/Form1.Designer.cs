namespace BDNEW44FZ
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dt = new System.Windows.Forms.DataGridView();
            this.закупкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.реестровыйНомерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеЗаказчикаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.иННЗаказчикаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеИсполнителяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.иННИсполнителяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаОпределенияПоставщикаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаЗаключенияКонтрактаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерКонтрактаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ценаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.объектЗакупкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.способОпределенияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.срокДействияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодПозицииКТРУОКПД2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статусВыполненияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.основаниеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.измененияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visibleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.рИЦDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.городDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.иННDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статусDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фирмаС1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.рИЦКОНТРАКТЫ1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.newBD44DataSet = new BDNEW44FZ.NewBD44DataSet();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.рИЦКОНТРАКТЫ1TableAdapter = new BDNEW44FZ.NewBD44DataSetTableAdapters.РИЦКОНТРАКТЫ1TableAdapter();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.рИЦКОНТРАКТЫ1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newBD44DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(27, 280);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(586, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Загружено";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Обработано/Всего";
            // 
            // dt
            // 
            this.dt.AutoGenerateColumns = false;
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.закупкиDataGridViewTextBoxColumn,
            this.реестровыйНомерDataGridViewTextBoxColumn,
            this.наименованиеЗаказчикаDataGridViewTextBoxColumn,
            this.иННЗаказчикаDataGridViewTextBoxColumn,
            this.наименованиеИсполнителяDataGridViewTextBoxColumn,
            this.иННИсполнителяDataGridViewTextBoxColumn,
            this.датаОпределенияПоставщикаDataGridViewTextBoxColumn,
            this.датаЗаключенияКонтрактаDataGridViewTextBoxColumn,
            this.номерКонтрактаDataGridViewTextBoxColumn,
            this.ценаDataGridViewTextBoxColumn,
            this.объектЗакупкиDataGridViewTextBoxColumn,
            this.способОпределенияDataGridViewTextBoxColumn,
            this.срокДействияDataGridViewTextBoxColumn,
            this.кодПозицииКТРУОКПД2DataGridViewTextBoxColumn,
            this.статусВыполненияDataGridViewTextBoxColumn,
            this.основаниеDataGridViewTextBoxColumn,
            this.измененияDataGridViewTextBoxColumn,
            this.visibleDataGridViewCheckBoxColumn,
            this.рИЦDataGridViewTextBoxColumn,
            this.городDataGridViewTextBoxColumn,
            this.иННDataGridViewTextBoxColumn,
            this.статусDataGridViewTextBoxColumn,
            this.фирмаС1DataGridViewTextBoxColumn,
            this.contractIDDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.placingDataGridViewTextBoxColumn});
            this.dt.DataSource = this.рИЦКОНТРАКТЫ1BindingSource;
            this.dt.Location = new System.Drawing.Point(27, 41);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(586, 214);
            this.dt.TabIndex = 4;
            // 
            // закупкиDataGridViewTextBoxColumn
            // 
            this.закупкиDataGridViewTextBoxColumn.DataPropertyName = "№ закупки";
            this.закупкиDataGridViewTextBoxColumn.HeaderText = "№ закупки";
            this.закупкиDataGridViewTextBoxColumn.Name = "закупкиDataGridViewTextBoxColumn";
            // 
            // реестровыйНомерDataGridViewTextBoxColumn
            // 
            this.реестровыйНомерDataGridViewTextBoxColumn.DataPropertyName = "Реестровый номер";
            this.реестровыйНомерDataGridViewTextBoxColumn.HeaderText = "Реестровый номер";
            this.реестровыйНомерDataGridViewTextBoxColumn.Name = "реестровыйНомерDataGridViewTextBoxColumn";
            // 
            // наименованиеЗаказчикаDataGridViewTextBoxColumn
            // 
            this.наименованиеЗаказчикаDataGridViewTextBoxColumn.DataPropertyName = "Наименование заказчика";
            this.наименованиеЗаказчикаDataGridViewTextBoxColumn.HeaderText = "Наименование заказчика";
            this.наименованиеЗаказчикаDataGridViewTextBoxColumn.Name = "наименованиеЗаказчикаDataGridViewTextBoxColumn";
            // 
            // иННЗаказчикаDataGridViewTextBoxColumn
            // 
            this.иННЗаказчикаDataGridViewTextBoxColumn.DataPropertyName = "ИНН заказчика";
            this.иННЗаказчикаDataGridViewTextBoxColumn.HeaderText = "ИНН заказчика";
            this.иННЗаказчикаDataGridViewTextBoxColumn.Name = "иННЗаказчикаDataGridViewTextBoxColumn";
            // 
            // наименованиеИсполнителяDataGridViewTextBoxColumn
            // 
            this.наименованиеИсполнителяDataGridViewTextBoxColumn.DataPropertyName = "Наименование исполнителя";
            this.наименованиеИсполнителяDataGridViewTextBoxColumn.HeaderText = "Наименование исполнителя";
            this.наименованиеИсполнителяDataGridViewTextBoxColumn.Name = "наименованиеИсполнителяDataGridViewTextBoxColumn";
            // 
            // иННИсполнителяDataGridViewTextBoxColumn
            // 
            this.иННИсполнителяDataGridViewTextBoxColumn.DataPropertyName = "ИНН исполнителя";
            this.иННИсполнителяDataGridViewTextBoxColumn.HeaderText = "ИНН исполнителя";
            this.иННИсполнителяDataGridViewTextBoxColumn.Name = "иННИсполнителяDataGridViewTextBoxColumn";
            // 
            // датаОпределенияПоставщикаDataGridViewTextBoxColumn
            // 
            this.датаОпределенияПоставщикаDataGridViewTextBoxColumn.DataPropertyName = "Дата определения поставщика";
            this.датаОпределенияПоставщикаDataGridViewTextBoxColumn.HeaderText = "Дата определения поставщика";
            this.датаОпределенияПоставщикаDataGridViewTextBoxColumn.Name = "датаОпределенияПоставщикаDataGridViewTextBoxColumn";
            // 
            // датаЗаключенияКонтрактаDataGridViewTextBoxColumn
            // 
            this.датаЗаключенияКонтрактаDataGridViewTextBoxColumn.DataPropertyName = "Дата заключения контракта";
            this.датаЗаключенияКонтрактаDataGridViewTextBoxColumn.HeaderText = "Дата заключения контракта";
            this.датаЗаключенияКонтрактаDataGridViewTextBoxColumn.Name = "датаЗаключенияКонтрактаDataGridViewTextBoxColumn";
            // 
            // номерКонтрактаDataGridViewTextBoxColumn
            // 
            this.номерКонтрактаDataGridViewTextBoxColumn.DataPropertyName = "Номер контракта";
            this.номерКонтрактаDataGridViewTextBoxColumn.HeaderText = "Номер контракта";
            this.номерКонтрактаDataGridViewTextBoxColumn.Name = "номерКонтрактаDataGridViewTextBoxColumn";
            // 
            // ценаDataGridViewTextBoxColumn
            // 
            this.ценаDataGridViewTextBoxColumn.DataPropertyName = "Цена";
            this.ценаDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.ценаDataGridViewTextBoxColumn.Name = "ценаDataGridViewTextBoxColumn";
            // 
            // объектЗакупкиDataGridViewTextBoxColumn
            // 
            this.объектЗакупкиDataGridViewTextBoxColumn.DataPropertyName = "Объект закупки";
            this.объектЗакупкиDataGridViewTextBoxColumn.HeaderText = "Объект закупки";
            this.объектЗакупкиDataGridViewTextBoxColumn.Name = "объектЗакупкиDataGridViewTextBoxColumn";
            // 
            // способОпределенияDataGridViewTextBoxColumn
            // 
            this.способОпределенияDataGridViewTextBoxColumn.DataPropertyName = "Способ определения";
            this.способОпределенияDataGridViewTextBoxColumn.HeaderText = "Способ определения";
            this.способОпределенияDataGridViewTextBoxColumn.Name = "способОпределенияDataGridViewTextBoxColumn";
            this.способОпределенияDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // срокДействияDataGridViewTextBoxColumn
            // 
            this.срокДействияDataGridViewTextBoxColumn.DataPropertyName = "Срок действия";
            this.срокДействияDataGridViewTextBoxColumn.HeaderText = "Срок действия";
            this.срокДействияDataGridViewTextBoxColumn.Name = "срокДействияDataGridViewTextBoxColumn";
            this.срокДействияDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // кодПозицииКТРУОКПД2DataGridViewTextBoxColumn
            // 
            this.кодПозицииКТРУОКПД2DataGridViewTextBoxColumn.DataPropertyName = "код позиции КТРУ/ОКПД2";
            this.кодПозицииКТРУОКПД2DataGridViewTextBoxColumn.HeaderText = "код позиции КТРУ/ОКПД2";
            this.кодПозицииКТРУОКПД2DataGridViewTextBoxColumn.Name = "кодПозицииКТРУОКПД2DataGridViewTextBoxColumn";
            // 
            // статусВыполненияDataGridViewTextBoxColumn
            // 
            this.статусВыполненияDataGridViewTextBoxColumn.DataPropertyName = "Статус Выполнения";
            this.статусВыполненияDataGridViewTextBoxColumn.HeaderText = "Статус Выполнения";
            this.статусВыполненияDataGridViewTextBoxColumn.Name = "статусВыполненияDataGridViewTextBoxColumn";
            this.статусВыполненияDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // основаниеDataGridViewTextBoxColumn
            // 
            this.основаниеDataGridViewTextBoxColumn.DataPropertyName = "Основание";
            this.основаниеDataGridViewTextBoxColumn.HeaderText = "Основание";
            this.основаниеDataGridViewTextBoxColumn.Name = "основаниеDataGridViewTextBoxColumn";
            // 
            // измененияDataGridViewTextBoxColumn
            // 
            this.измененияDataGridViewTextBoxColumn.DataPropertyName = "Изменения";
            this.измененияDataGridViewTextBoxColumn.HeaderText = "Изменения";
            this.измененияDataGridViewTextBoxColumn.Name = "измененияDataGridViewTextBoxColumn";
            // 
            // visibleDataGridViewCheckBoxColumn
            // 
            this.visibleDataGridViewCheckBoxColumn.DataPropertyName = "visible";
            this.visibleDataGridViewCheckBoxColumn.HeaderText = "visible";
            this.visibleDataGridViewCheckBoxColumn.Name = "visibleDataGridViewCheckBoxColumn";
            // 
            // рИЦDataGridViewTextBoxColumn
            // 
            this.рИЦDataGridViewTextBoxColumn.DataPropertyName = "РИЦ";
            this.рИЦDataGridViewTextBoxColumn.HeaderText = "РИЦ";
            this.рИЦDataGridViewTextBoxColumn.Name = "рИЦDataGridViewTextBoxColumn";
            // 
            // городDataGridViewTextBoxColumn
            // 
            this.городDataGridViewTextBoxColumn.DataPropertyName = "Город";
            this.городDataGridViewTextBoxColumn.HeaderText = "Город";
            this.городDataGridViewTextBoxColumn.Name = "городDataGridViewTextBoxColumn";
            // 
            // иННDataGridViewTextBoxColumn
            // 
            this.иННDataGridViewTextBoxColumn.DataPropertyName = "ИНН";
            this.иННDataGridViewTextBoxColumn.HeaderText = "ИНН";
            this.иННDataGridViewTextBoxColumn.Name = "иННDataGridViewTextBoxColumn";
            // 
            // статусDataGridViewTextBoxColumn
            // 
            this.статусDataGridViewTextBoxColumn.DataPropertyName = "Статус";
            this.статусDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.статусDataGridViewTextBoxColumn.Name = "статусDataGridViewTextBoxColumn";
            // 
            // фирмаС1DataGridViewTextBoxColumn
            // 
            this.фирмаС1DataGridViewTextBoxColumn.DataPropertyName = "Фирма с 1%";
            this.фирмаС1DataGridViewTextBoxColumn.HeaderText = "Фирма с 1%";
            this.фирмаС1DataGridViewTextBoxColumn.Name = "фирмаС1DataGridViewTextBoxColumn";
            // 
            // contractIDDataGridViewTextBoxColumn
            // 
            this.contractIDDataGridViewTextBoxColumn.DataPropertyName = "contractID";
            this.contractIDDataGridViewTextBoxColumn.HeaderText = "contractID";
            this.contractIDDataGridViewTextBoxColumn.Name = "contractIDDataGridViewTextBoxColumn";
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "startDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "startDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "endDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "endDate";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            // 
            // placingDataGridViewTextBoxColumn
            // 
            this.placingDataGridViewTextBoxColumn.DataPropertyName = "placing";
            this.placingDataGridViewTextBoxColumn.HeaderText = "placing";
            this.placingDataGridViewTextBoxColumn.Name = "placingDataGridViewTextBoxColumn";
            // 
            // рИЦКОНТРАКТЫ1BindingSource
            // 
            this.рИЦКОНТРАКТЫ1BindingSource.DataMember = "РИЦКОНТРАКТЫ1";
            this.рИЦКОНТРАКТЫ1BindingSource.DataSource = this.newBD44DataSet;
            // 
            // newBD44DataSet
            // 
            this.newBD44DataSet.DataSetName = "NewBD44DataSet";
            this.newBD44DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Обновить БД";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(159, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Обновить скаченное";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(493, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Контракты";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // рИЦКОНТРАКТЫ1TableAdapter
            // 
            this.рИЦКОНТРАКТЫ1TableAdapter.ClearBeforeFill = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(354, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Открыть БД";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 326);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "Госзакупки - Контракты"; 
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.рИЦКОНТРАКТЫ1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newBD44DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ProgressBar progressBar1;
        private NewBD44DataSet newBD44DataSet;
        private System.Windows.Forms.BindingSource рИЦКОНТРАКТЫ1BindingSource;
        private NewBD44DataSetTableAdapters.РИЦКОНТРАКТЫ1TableAdapter рИЦКОНТРАКТЫ1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn закупкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn реестровыйНомерDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеЗаказчикаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn иННЗаказчикаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеИсполнителяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn иННИсполнителяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаОпределенияПоставщикаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаЗаключенияКонтрактаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерКонтрактаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ценаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn объектЗакупкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn способОпределенияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn срокДействияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодПозицииКТРУОКПД2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусВыполненияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn основаниеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn измененияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn visibleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn рИЦDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn городDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn иННDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фирмаС1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placingDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
    }
}

