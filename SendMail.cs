using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Security;
using System.Windows.Forms;


namespace HSMAPP
{
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
            if (LogIn.Loginfo.UserID > 0)
            {
                getCompany();

            }
        }
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        string smtphost= ConfigurationManager.AppSettings["host"];
        string fromAddress= ConfigurationManager.AppSettings["from"];
        int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
        string username = ConfigurationManager.AppSettings["userName"];
        string password = ConfigurationManager.AppSettings["password"];
        private void btnsendmail_Click(object sender, EventArgs e)
        {
            try
            {
                 
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient(smtphost,smtpPort);
                mail.From =  new MailAddress(fromAddress);

                mail.To.Add(txtTosender.Text);
                mail.Subject = txtsubject.Text;
                mail.Body = txtmessage.Text;

                System.Net.Mail.Attachment attachment;
                //if (chkallfile.Checked == true)
                //{
                //    attachment = new System.Net.Mail.Attachment(lblLocation.Text);
                //    mail.Attachments.Add(attachment);
                //}
                if (chktwoforms.Checked == true)
                {
                    if (lblform12.Text != string.Empty || lblform12.Text != "Not found")
                    {
                        attachment = new System.Net.Mail.Attachment(lblform12.Text);
                        mail.Attachments.Add(attachment);
                    }
                    if (lblSelectedFile.Text != string.Empty || lblSelectedFile.Text != "Not found")
                    {
                        attachment = new System.Net.Mail.Attachment(lblSelectedFile.Text);
                        mail.Attachments.Add(attachment);
                    }
                }
                //Attachment Attachment = null;
                if (chkuplaod.Checked == true)
                {
                    if (lblattachedfile.Text != string.Empty)
                    {
                        attachment = new System.Net.Mail.Attachment(lblattachedfile.Text);
                        mail.Attachments.Add(attachment);
                    }
                }              
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new System.Net.NetworkCredential(username,password);

                smtp.Send(mail);
                //Attachment.Dispose();
                mail.Dispose();
                lblErrorMsg.Text = "Mail has been sent successfully!";

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
                    }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        string str;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    lblattachedfile.Text = openFileDialog1.FileName;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        void getCompany()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetCompanyMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    comboBox2.ValueMember = "Id";
                    comboBox2.DisplayMember = "CompanyName";
                    comboBox2.DataSource = dataTable;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        public void GetPatRegno()
        {

            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();

                    using (cmd = new SqlCommand("usp_GetPatientbyCompanyId", con))
                        cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(comboBox2.SelectedValue));
                    {
                        using (adapt = new SqlDataAdapter(cmd))
                        {
                            adapt.Fill(datatable);

                            comboBox1.ValueMember = "Id";
                            comboBox1.DisplayMember = "PatientName";
                            comboBox1.DataSource = datatable;
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                GetPatRegno();
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetCompanyMstByserchId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyId", Convert.ToInt32(comboBox2.SelectedValue));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            txtTosender.Text = Convert.ToString(reader["EmailId"]);

                        }
                        con.Close();
                    }

                }
            }
        }
       // string sFileToZip;
       // string sZipFile;
        

        string strform1,strform2;
        private void chktwoforms_CheckedChanged(object sender, EventArgs e)
        {
            if (chktwoforms.Checked == true)
            {
                lblattachedfile.Text = string.Empty;
                strform1= @"../../Imgs/" + str + "/" + str + "_form1.pdf";
                strform2= @"../../Imgs/" + str + "/" + str + "_form2.pdf";
                chkuplaod.Checked = false;
                if (File.Exists(strform1))
                { 
                    lblform12.Text = strform1;
                }
                else
                {
                    lblform12.Text = "Not found";
                }
                if (File.Exists(strform2))
                {
                    lblSelectedFile.Text = strform2;
                }
                else
                {
                    lblSelectedFile.Text = "Not found";
                }
               


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetPatientMstbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(comboBox1.SelectedValue));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            str = Convert.ToString(reader["FirstName"]) + "_" + Convert.ToString(reader["LastName"]); ;

                        }
                        con.Close();
                    }

                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    sFileToZip = @"../../Imgs/" + str;
        //    sZipFile = @"../../Imgs/" + str + ".zip";

        //    using (FileStream __fStream = File.Open(sZipFile, FileMode.Create))
        //    {
        //        GZipStream obj = new GZipStream(__fStream, CompressionMode.Compress);

        //        byte[] bt = File.ReadAllBytes(sFileToZip);
        //        obj.Write(bt, 0, bt.Length);
        //        lblattachedfile.Text= @sZipFile;
        //        obj.Close();
        //        obj.Dispose();
        //    }
        //}

        private void chkuplaod_CheckedChanged(object sender, EventArgs e)
        {
            if (chkuplaod.Checked==true)
            {
               // chkallfile.Checked = false;
                chktwoforms.Checked = false;
                lblform12.Text = string.Empty;
                lblSelectedFile.Text = string.Empty;
            }

        }

        //private void chkallfile_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    if (chkallfile.Checked == true)
        //    {
        //        chktwoforms.Checked = false;
        //        chkuplaod.Checked = false;
        //        if (comboBox1.SelectedValue != null)
        //        {
        //            filetoZipfolder();
        //            //lblAllfile.Text = sZipFile;
        //            lblLocation.Text = @"../../Imgs/" + str + ".rar";
        //        }
        //    }
        //}
    }
}
