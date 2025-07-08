namespace HSMAPP
{
    partial class SendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMail));
            this.label1 = new System.Windows.Forms.Label();
            this.lblpatientname = new System.Windows.Forms.Label();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTosender = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmessage = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsendmail = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblform12 = new System.Windows.Forms.Label();
            this.lblSelectedFile = new System.Windows.Forms.Label();
            this.lblattachedfile = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkuplaod = new System.Windows.Forms.CheckBox();
            this.chktwoforms = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsubject = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient Name";
            // 
            // lblpatientname
            // 
            this.lblpatientname.AutoSize = true;
            this.lblpatientname.Location = new System.Drawing.Point(38, 78);
            this.lblpatientname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpatientname.Name = "lblpatientname";
            this.lblpatientname.Size = new System.Drawing.Size(140, 20);
            this.lblpatientname.TabIndex = 1;
            this.lblpatientname.Text = "Company Name";
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMsg.Location = new System.Drawing.Point(126, 39);
            this.lblErrorMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(50, 20);
            this.lblErrorMsg.TabIndex = 6;
            this.lblErrorMsg.Text = "error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "To";
            // 
            // txtTosender
            // 
            this.txtTosender.Location = new System.Drawing.Point(127, 117);
            this.txtTosender.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTosender.Name = "txtTosender";
            this.txtTosender.Size = new System.Drawing.Size(701, 26);
            this.txtTosender.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 183);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Attached File";
            // 
            // txtmessage
            // 
            this.txtmessage.Location = new System.Drawing.Point(134, 308);
            this.txtmessage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.Size = new System.Drawing.Size(596, 111);
            this.txtmessage.TabIndex = 12;
            this.txtmessage.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 295);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Message";
            // 
            // btnsendmail
            // 
            this.btnsendmail.Location = new System.Drawing.Point(51, 447);
            this.btnsendmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnsendmail.Name = "btnsendmail";
            this.btnsendmail.Size = new System.Drawing.Size(88, 33);
            this.btnsendmail.TabIndex = 14;
            this.btnsendmail.Text = "Send Mail";
            this.btnsendmail.UseVisualStyleBackColor = true;
            this.btnsendmail.Click += new System.EventHandler(this.btnsendmail_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblform12);
            this.panel1.Controls.Add(this.lblSelectedFile);
            this.panel1.Controls.Add(this.lblattachedfile);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.chkuplaod);
            this.panel1.Controls.Add(this.chktwoforms);
            this.panel1.Location = new System.Drawing.Point(171, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 66);
            this.panel1.TabIndex = 15;
            // 
            // lblform12
            // 
            this.lblform12.AutoSize = true;
            this.lblform12.Location = new System.Drawing.Point(20, 32);
            this.lblform12.Name = "lblform12";
            this.lblform12.Size = new System.Drawing.Size(0, 20);
            this.lblform12.TabIndex = 8;
            // 
            // lblSelectedFile
            // 
            this.lblSelectedFile.AutoSize = true;
            this.lblSelectedFile.Location = new System.Drawing.Point(20, 47);
            this.lblSelectedFile.Name = "lblSelectedFile";
            this.lblSelectedFile.Size = new System.Drawing.Size(0, 20);
            this.lblSelectedFile.TabIndex = 6;
            // 
            // lblattachedfile
            // 
            this.lblattachedfile.AutoSize = true;
            this.lblattachedfile.Location = new System.Drawing.Point(309, 32);
            this.lblattachedfile.Name = "lblattachedfile";
            this.lblattachedfile.Size = new System.Drawing.Size(95, 20);
            this.lblattachedfile.TabIndex = 5;
            this.lblattachedfile.Text = "lblatached";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(333, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // chkuplaod
            // 
            this.chkuplaod.AutoSize = true;
            this.chkuplaod.Checked = true;
            this.chkuplaod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkuplaod.Location = new System.Drawing.Point(312, 12);
            this.chkuplaod.Name = "chkuplaod";
            this.chkuplaod.Size = new System.Drawing.Size(22, 21);
            this.chkuplaod.TabIndex = 3;
            this.chkuplaod.UseVisualStyleBackColor = true;
            this.chkuplaod.CheckedChanged += new System.EventHandler(this.chkuplaod_CheckedChanged);
            // 
            // chktwoforms
            // 
            this.chktwoforms.AutoSize = true;
            this.chktwoforms.Location = new System.Drawing.Point(23, 12);
            this.chktwoforms.Name = "chktwoforms";
            this.chktwoforms.Size = new System.Drawing.Size(198, 24);
            this.chktwoforms.TabIndex = 0;
            this.chktwoforms.Text = " Forms only( 1 && 2)";
            this.chktwoforms.UseVisualStyleBackColor = true;
            this.chktwoforms.CheckedChanged += new System.EventHandler(this.chktwoforms_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Subject";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtsubject
            // 
            this.txtsubject.Location = new System.Drawing.Point(130, 254);
            this.txtsubject.Name = "txtsubject";
            this.txtsubject.Size = new System.Drawing.Size(596, 26);
            this.txtsubject.TabIndex = 17;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(640, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(320, 28);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(195, 70);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(276, 28);
            this.comboBox2.TabIndex = 20;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtsubject);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnsendmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtmessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTosender);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.lblpatientname);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Blue;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendMail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblpatientname;
        private System.Windows.Forms.Label lblErrorMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTosender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtmessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnsendmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsubject;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chktwoforms;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkuplaod;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblform12;
        private System.Windows.Forms.Label lblSelectedFile;
        private System.Windows.Forms.Label lblattachedfile;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}