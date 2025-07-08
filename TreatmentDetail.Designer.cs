namespace HSMAPP
{
    partial class TreatmentDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtsrno = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txttotalamount = new System.Windows.Forms.TextBox();
            this.txtamt = new System.Windows.Forms.TextBox();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.dpvistdate = new System.Windows.Forms.DateTimePicker();
            this.txtcandidatename = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtbillno = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboxbillyear = new System.Windows.Forms.ComboBox();
            this.cboxbillmonth = new System.Windows.Forms.ComboBox();
            this.lblerrormsg = new System.Windows.Forms.Label();
            this.cboxdoctor = new System.Windows.Forms.ComboBox();
            this.cboxcustomer = new System.Windows.Forms.ComboBox();
            this.dpbilldate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cboxbillyear);
            this.panel1.Controls.Add(this.cboxbillmonth);
            this.panel1.Controls.Add(this.lblerrormsg);
            this.panel1.Controls.Add(this.cboxdoctor);
            this.panel1.Controls.Add(this.cboxcustomer);
            this.panel1.Controls.Add(this.dpbilldate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1304, 898);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button3);
            this.panel5.Location = new System.Drawing.Point(1000, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(249, 38);
            this.panel5.TabIndex = 27;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(57, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 30);
            this.button3.TabIndex = 22;
            this.button3.Text = "Modify";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(869, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 34);
            this.button4.TabIndex = 26;
            this.button4.Text = "Delete BillNo";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(740, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 41);
            this.button2.TabIndex = 25;
            this.button2.Text = "Edit BillNo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.txtsrno);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txttotalamount);
            this.panel2.Controls.Add(this.txtamt);
            this.panel2.Controls.Add(this.txtdesc);
            this.panel2.Controls.Add(this.dpvistdate);
            this.panel2.Controls.Add(this.txtcandidatename);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnSaveChanges);
            this.panel2.Controls.Add(this.btnDeleteRow);
            this.panel2.Location = new System.Drawing.Point(36, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1239, 702);
            this.panel2.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(718, 173);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 32);
            this.button5.TabIndex = 18;
            this.button5.Text = "Edit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridView2);
            this.panel6.Location = new System.Drawing.Point(15, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1221, 122);
            this.panel6.TabIndex = 17;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1206, 121);
            this.dataGridView2.TabIndex = 17;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Location = new System.Drawing.Point(15, 224);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1209, 465);
            this.panel4.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1189, 495);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // txtsrno
            // 
            this.txtsrno.Location = new System.Drawing.Point(71, 142);
            this.txtsrno.Name = "txtsrno";
            this.txtsrno.Size = new System.Drawing.Size(47, 26);
            this.txtsrno.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 20);
            this.label12.TabIndex = 13;
            this.label12.Text = "SrNo";
            // 
            // txttotalamount
            // 
            this.txttotalamount.Location = new System.Drawing.Point(964, 132);
            this.txttotalamount.Name = "txttotalamount";
            this.txttotalamount.Size = new System.Drawing.Size(88, 26);
            this.txttotalamount.TabIndex = 12;
            this.txttotalamount.Text = "0";
            // 
            // txtamt
            // 
            this.txtamt.Location = new System.Drawing.Point(759, 135);
            this.txtamt.Name = "txtamt";
            this.txtamt.Size = new System.Drawing.Size(85, 26);
            this.txtamt.TabIndex = 11;
            this.txtamt.Text = "0";
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(123, 176);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(461, 26);
            this.txtdesc.TabIndex = 10;
            // 
            // dpvistdate
            // 
            this.dpvistdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpvistdate.Location = new System.Drawing.Point(518, 136);
            this.dpvistdate.Name = "dpvistdate";
            this.dpvistdate.Size = new System.Drawing.Size(135, 26);
            this.dpvistdate.TabIndex = 9;
            // 
            // txtcandidatename
            // 
            this.txtcandidatename.Location = new System.Drawing.Point(181, 139);
            this.txtcandidatename.Name = "txtcandidatename";
            this.txtcandidatename.Size = new System.Drawing.Size(266, 26);
            this.txtcandidatename.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(854, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Total Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(688, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(456, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Date";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(606, 171);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(92, 36);
            this.btnSaveChanges.TabIndex = 2;
            this.btnSaveChanges.Text = "Add ";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(819, 171);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(100, 36);
            this.btnDeleteRow.TabIndex = 3;
            this.btnDeleteRow.Text = "Delete";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtbillno);
            this.panel3.Location = new System.Drawing.Point(105, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(167, 40);
            this.panel3.TabIndex = 22;
            // 
            // txtbillno
            // 
            this.txtbillno.Location = new System.Drawing.Point(13, 6);
            this.txtbillno.Name = "txtbillno";
            this.txtbillno.Size = new System.Drawing.Size(136, 26);
            this.txtbillno.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(554, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 42);
            this.button1.TabIndex = 17;
            this.button1.Text = "Add BillNo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboxbillyear
            // 
            this.cboxbillyear.FormattingEnabled = true;
            this.cboxbillyear.Location = new System.Drawing.Point(664, 53);
            this.cboxbillyear.Name = "cboxbillyear";
            this.cboxbillyear.Size = new System.Drawing.Size(80, 28);
            this.cboxbillyear.TabIndex = 20;
            // 
            // cboxbillmonth
            // 
            this.cboxbillmonth.FormattingEnabled = true;
            this.cboxbillmonth.Location = new System.Drawing.Point(496, 53);
            this.cboxbillmonth.Name = "cboxbillmonth";
            this.cboxbillmonth.Size = new System.Drawing.Size(71, 28);
            this.cboxbillmonth.TabIndex = 19;
            // 
            // lblerrormsg
            // 
            this.lblerrormsg.AutoSize = true;
            this.lblerrormsg.ForeColor = System.Drawing.Color.Red;
            this.lblerrormsg.Location = new System.Drawing.Point(101, 17);
            this.lblerrormsg.Name = "lblerrormsg";
            this.lblerrormsg.Size = new System.Drawing.Size(0, 20);
            this.lblerrormsg.TabIndex = 18;
            // 
            // cboxdoctor
            // 
            this.cboxdoctor.FormattingEnabled = true;
            this.cboxdoctor.Location = new System.Drawing.Point(834, 50);
            this.cboxdoctor.Name = "cboxdoctor";
            this.cboxdoctor.Size = new System.Drawing.Size(196, 28);
            this.cboxdoctor.TabIndex = 15;
            // 
            // cboxcustomer
            // 
            this.cboxcustomer.FormattingEnabled = true;
            this.cboxcustomer.Location = new System.Drawing.Point(99, 50);
            this.cboxcustomer.Name = "cboxcustomer";
            this.cboxcustomer.Size = new System.Drawing.Size(287, 28);
            this.cboxcustomer.TabIndex = 14;
            // 
            // dpbilldate
            // 
            this.dpbilldate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpbilldate.Location = new System.Drawing.Point(402, 98);
            this.dpbilldate.Name = "dpbilldate";
            this.dpbilldate.Size = new System.Drawing.Size(133, 26);
            this.dpbilldate.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(750, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Doctor ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Customer ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(587, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bill Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bill Month";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bill No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bill Date";
            // 
            // TreatmentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1335, 956);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "TreatmentDetail";
            this.Text = "Treatment Detail";
            this.Load += new System.EventHandler(this.TreatmentDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxdoctor;
        private System.Windows.Forms.ComboBox cboxcustomer;
        private System.Windows.Forms.DateTimePicker dpbilldate;
        private System.Windows.Forms.TextBox txtbillno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblerrormsg;
        private System.Windows.Forms.TextBox txtamt;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.DateTimePicker dpvistdate;
        private System.Windows.Forms.TextBox txtcandidatename;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttotalamount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtsrno;
        private System.Windows.Forms.ComboBox cboxbillyear;
        private System.Windows.Forms.ComboBox cboxbillmonth;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button3;
    }
}