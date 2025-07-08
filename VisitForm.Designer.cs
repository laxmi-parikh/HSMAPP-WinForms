namespace HSMAPP
{
    partial class VisitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.print_doc = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblerrormsg = new System.Windows.Forms.Label();
            this.cboxbillyear = new System.Windows.Forms.ComboBox();
            this.cboxbillmonth = new System.Windows.Forms.ComboBox();
            this.cboxdoctor = new System.Windows.Forms.ComboBox();
            this.cboxcustomer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.txtsrno1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtdescription1 = new System.Windows.Forms.TextBox();
            this.txttotalamt = new System.Windows.Forms.TextBox();
            this.txtname1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtamt1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dpicker1 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblerrormsg);
            this.panel1.Controls.Add(this.cboxbillyear);
            this.panel1.Controls.Add(this.cboxbillmonth);
            this.panel1.Controls.Add(this.cboxdoctor);
            this.panel1.Controls.Add(this.cboxcustomer);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 84);
            this.panel1.TabIndex = 1;
            // 
            // lblerrormsg
            // 
            this.lblerrormsg.AutoSize = true;
            this.lblerrormsg.ForeColor = System.Drawing.Color.Red;
            this.lblerrormsg.Location = new System.Drawing.Point(39, 4);
            this.lblerrormsg.Name = "lblerrormsg";
            this.lblerrormsg.Size = new System.Drawing.Size(0, 20);
            this.lblerrormsg.TabIndex = 29;
            // 
            // cboxbillyear
            // 
            this.cboxbillyear.FormattingEnabled = true;
            this.cboxbillyear.Location = new System.Drawing.Point(731, 31);
            this.cboxbillyear.Name = "cboxbillyear";
            this.cboxbillyear.Size = new System.Drawing.Size(80, 28);
            this.cboxbillyear.TabIndex = 28;
            // 
            // cboxbillmonth
            // 
            this.cboxbillmonth.FormattingEnabled = true;
            this.cboxbillmonth.Location = new System.Drawing.Point(563, 31);
            this.cboxbillmonth.Name = "cboxbillmonth";
            this.cboxbillmonth.Size = new System.Drawing.Size(71, 28);
            this.cboxbillmonth.TabIndex = 27;
            // 
            // cboxdoctor
            // 
            this.cboxdoctor.FormattingEnabled = true;
            this.cboxdoctor.Location = new System.Drawing.Point(901, 28);
            this.cboxdoctor.Name = "cboxdoctor";
            this.cboxdoctor.Size = new System.Drawing.Size(196, 28);
            this.cboxdoctor.TabIndex = 26;
            // 
            // cboxcustomer
            // 
            this.cboxcustomer.FormattingEnabled = true;
            this.cboxcustomer.Location = new System.Drawing.Point(166, 28);
            this.cboxcustomer.Name = "cboxcustomer";
            this.cboxcustomer.Size = new System.Drawing.Size(287, 28);
            this.cboxcustomer.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(817, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Doctor ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Customer ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(654, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Bill Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Bill Month";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1125, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 33);
            this.button2.TabIndex = 31;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Controls.Add(this.button4);
            this.panel7.Controls.Add(this.comboBox1);
            this.panel7.Controls.Add(this.dateTimePicker2);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.label20);
            this.panel7.Location = new System.Drawing.Point(31, 181);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1176, 701);
            this.panel7.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtsrno1);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtdescription1);
            this.panel2.Controls.Add(this.txttotalamt);
            this.panel2.Controls.Add(this.txtname1);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtamt1);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.dpicker1);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(20, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1133, 627);
            this.panel2.TabIndex = 28;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(38, 113);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1057, 477);
            this.dataGridView2.TabIndex = 15;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 20);
            this.label13.TabIndex = 13;
            this.label13.Text = "SrNo";
            // 
            // txtsrno1
            // 
            this.txtsrno1.Location = new System.Drawing.Point(100, 18);
            this.txtsrno1.Name = "txtsrno1";
            this.txtsrno1.Size = new System.Drawing.Size(47, 26);
            this.txtsrno1.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(164, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 20);
            this.label17.TabIndex = 1;
            this.label17.Text = "Name";
            // 
            // txtdescription1
            // 
            this.txtdescription1.Location = new System.Drawing.Point(128, 52);
            this.txtdescription1.Name = "txtdescription1";
            this.txtdescription1.Size = new System.Drawing.Size(317, 26);
            this.txtdescription1.TabIndex = 10;
            // 
            // txttotalamt
            // 
            this.txttotalamt.Location = new System.Drawing.Point(980, 22);
            this.txttotalamt.Name = "txttotalamt";
            this.txttotalamt.Size = new System.Drawing.Size(88, 26);
            this.txttotalamt.TabIndex = 12;
            this.txttotalamt.Text = "0";
            // 
            // txtname1
            // 
            this.txtname1.Location = new System.Drawing.Point(232, 18);
            this.txtname1.Name = "txtname1";
            this.txtname1.Size = new System.Drawing.Size(231, 26);
            this.txtname1.TabIndex = 8;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(578, 47);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 36);
            this.button6.TabIndex = 3;
            this.button6.Text = "Delete";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(476, 52);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 36);
            this.button5.TabIndex = 2;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 20);
            this.label16.TabIndex = 5;
            this.label16.Text = "Description";
            // 
            // txtamt1
            // 
            this.txtamt1.Location = new System.Drawing.Point(770, 18);
            this.txtamt1.Name = "txtamt1";
            this.txtamt1.Size = new System.Drawing.Size(85, 26);
            this.txtamt1.TabIndex = 11;
            this.txtamt1.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(493, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 20);
            this.label18.TabIndex = 4;
            this.label18.Text = "Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(861, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 20);
            this.label14.TabIndex = 7;
            this.label14.Text = "Total Amount";
            // 
            // dpicker1
            // 
            this.dpicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpicker1.Location = new System.Drawing.Point(543, 16);
            this.dpicker1.Name = "dpicker1";
            this.dpicker1.Size = new System.Drawing.Size(135, 26);
            this.dpicker1.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(699, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 20);
            this.label15.TabIndex = 6;
            this.label15.Text = "Amount";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(502, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 42);
            this.button4.TabIndex = 27;
            this.button4.Text = "Edit Treatment Detail";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(85, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 28);
            this.comboBox1.TabIndex = 26;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(354, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(133, 26);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(280, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 20);
            this.label19.TabIndex = 5;
            this.label19.Text = "Bill Date";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(26, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 20);
            this.label20.TabIndex = 4;
            this.label20.Text = "Bill No";
            // 
            // VisitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1330, 901);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Name = "VisitForm";
            this.Text = "VisitForm";
            this.Load += new System.EventHandler(this.VisitForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Drawing.Printing.PrintDocument print_doc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboxbillyear;
        private System.Windows.Forms.ComboBox cboxbillmonth;
        private System.Windows.Forms.ComboBox cboxdoctor;
        private System.Windows.Forms.ComboBox cboxcustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtsrno1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtdescription1;
        private System.Windows.Forms.TextBox txttotalamt;
        private System.Windows.Forms.TextBox txtname1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtamt1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dpicker1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblerrormsg;
    }
}