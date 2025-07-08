using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using static HSMAPP.LogIn;

namespace HSMAPP
{
    public partial class treamentInvoices : Form
    {
        public static string[] unitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        public static string[] tensMap = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public treamentInvoices()
        {

            InitializeComponent();
            if (Loginfo.UserID > 0)
            {
                
                getmonthyear();
                GetCompany();
                GetPatRegno();
                panel4.Visible = false;
              
            }
        }
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;// int rowId;
        int Id;
      
        int yrs = Convert.ToInt32(DateTime.Today.Year);
        DataTable dataTable;
        string outputFileName;

        void getmonthyear()
        {
            for (int i = 1; i <= 12; i++) { combomonth.Items.Add(i); }
            for (int j = 2020; j <= yrs; j++) { comboyear.Items.Add(j); }
        }
        public void GetCompany()
        {

            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();

                    using (cmd = new SqlCommand("Select Id,CompanyName from CompanyMst", con))
                    {
                        using (adapt = new SqlDataAdapter(cmd))
                        {
                            adapt.Fill(datatable);
                            comboxcompany.DataSource = datatable;
                            comboxcompany.ValueMember = "Id";
                            comboxcompany.DisplayMember = "CompanyName";
                            comboxcompany.Refresh();
                        }
                    }
                    con.Close();

                }
                // return datatable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string comName;
        string EmailId;
        public void getcomapnydetails()
        {
            using (con = new SqlConnection(dbconnectionstring))
            {
                con.Open();
                Id = Convert.ToInt32(comboxcompany.SelectedValue);
                cmd = new SqlCommand("usp_GetCompanyMstByserchId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyId", Id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read() != false)
                    {
                        // richTextBox1.Text =Convert.ToString(reader["Address"]);
                        comName = Convert.ToString(reader["CompanyName"]);
                        lblcustomername.Text = comName;
                        lblbilltoaddress.Text = Convert.ToString(reader["Address"]);
                        EmailId = Convert.ToString(reader["EmailId"]);
                        lblpanid.Text = Convert.ToString(reader["Panno"]);
                        txtto.Text = EmailId;
                    }
                }
                con.Close();

            }


        }
       
       
        void GetBillNo()
        {
            
                var datatable = new DataTable();
                try
                {
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        con.Open();

                        using (cmd = new SqlCommand("usp_GetTreatmentMstBycompanyId", con))
                            cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(comboxcompany.SelectedValue));
                    cmd.Parameters.AddWithValue("@Month", Convert.ToInt32(combomonth.SelectedItem));
                    cmd.Parameters.AddWithValue("@year", Convert.ToInt32(comboyear.SelectedItem));
                    {
                            using (adapt = new SqlDataAdapter(cmd))
                            {
                                adapt.Fill(datatable);

                                cboxbillno.ValueMember = "Id";
                                cboxbillno.DisplayMember = "BillNo";
                                cboxbillno.DataSource = datatable;
                            }
                        }
                        con.Close();
                    }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }


            void getinvoicedate()
            {
                try
                {
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        cmd = new SqlCommand("usp_GetTreatmentMstBycompanyId", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(comboxcompany.SelectedValue));
                        cmd.Parameters.AddWithValue("@Month", Convert.ToInt32(combomonth.SelectedItem));
                        cmd.Parameters.AddWithValue("@year", Convert.ToInt32(comboyear.SelectedItem));
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() != false)
                            {
                                lblinvicedate.Text = Convert.ToDateTime(reader["BillDate"]).ToShortDateString();
                               
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.Message;
                }
            }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboxcompany.SelectedValue != null)
            {
                GetBillNo();
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

                    using (cmd = new SqlCommand("usp_GetUserMstFordoc", con))
                        cmd.CommandType = CommandType.StoredProcedure;
                    {
                        using (adapt = new SqlDataAdapter(cmd))
                        {
                            adapt.Fill(datatable);
                            
                            comboxdoc.ValueMember = "Id";
                            comboxdoc.DisplayMember = "Name";
                            comboxdoc.DataSource = datatable;
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
        void datafindinvoice()
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetTreatmentdetailbyBillNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BillNo", cboxbillno.SelectedValue);
                    con.Open();


                    dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);

                    adapt.Fill( dataTable);

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Refresh();
                    con.Close();
                }
               

                double result = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    result += Convert.ToDouble(row.Cells["TotalAmount"].Value);


                }
                lbltotalAmount.Text = result.ToString();
                lblamtword.Text = InvoiceTestperform.NumberToWords(Convert.ToInt32(lbltotalAmount.Text)) + " " + "Only";

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }

        }


        public static string NumberToWords(int number)
        {
            if (number == 0) return "Zero"; if (number < 0) return "Minus " + NumberToWords(Math.Abs(number)); string words = ""; if ((number / 1000000) > 0) { words += NumberToWords(number / 1000000) + " Million "; number %= 1000000; }
            if ((number / 1000) > 0) { words += NumberToWords(number / 1000) + " Thousand "; number %= 1000; }
            if ((number / 100) > 0) { words += NumberToWords(number / 100) + " Hundred "; number %= 100; }
            if (number > 0) { if (words != "") words += "and "; if (number < 20) words += unitsMap[number]; else { words += tensMap[number / 10]; if ((number % 10) > 0) words += "-" + unitsMap[number % 10]; } }
            return words.Trim();
        }
        //Submit
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                getinvoicedate();
                getdoctordetails();
                getcomapnydetails();
                lblbillno.Text = cboxbillno.Text;
                datafindinvoice();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }

        }
       
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // populatedatafgridview();

        }
        public void paneltobmp()
        {
            getcomapnydetails();
            //  panel1.AutoSize = true;

            int width = panel1.Size.Width;
            int height = panel1.Size.Height;
            Bitmap bm = new Bitmap(width, height);
            // int page_area = 1000;
            //  e.Graphics.DrawImage(bitmap, (page_area.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
            panel1.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, 900, 900));
            PrintArea(panel1);
            outputFileName = @"../../Imgs/" + comName + "_Invoices" + cboxbillno.SelectedText + ".bmp";
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    bm.Save(memory, ImageFormat.Bmp);
                    Clipboard.SetImage(bm);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);

                }

            }
            //panel1.AutoSize = false;

        }
        string str, str1;

        public void convertimagetopdf()
        {
            str = outputFileName;
            str1 = str.Remove(str.Length - 4);
            str1 = str1 + ".pdf";

            Document doc = new Document();
            using (var stream = new FileStream(str1, FileMode.Create, FileAccess.Write, FileShare.None))
            {

                PdfWriter.GetInstance(doc, stream);
                doc.Open();
                using (var imagestream = new FileStream(str, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = iTextSharp.text.Image.GetInstance(imagestream);
                    doc.Add(image);
                }
                doc.Close();

            }
            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }

        }

        Bitmap bitmap;
        //print
        private void button3_Click(object sender, EventArgs e)
        {

            Print(this.panel1);
        }
        public void Print(Panel panel)
        {
            PrinterSettings set = new PrinterSettings();
            panel1 = panel;
            PrintArea(panel);
            // print.Document = print_doc;
            print_doc.PrintPage += new PrintPageEventHandler(PrintImage);
            print_doc.Print();

        }
        //SendMail
        private void btnsendmail_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient(smtphost, smtpPort);
                mail.From = new MailAddress(fromAddress);
                mail.To.Add(txtto.Text);
                mail.Subject = txtsubjects.Text;
                mail.Body = richTextBox2.Text;

                System.Net.Mail.Attachment attachment;
                if (lblAttachedfile.Text != string.Empty || lblAttachedfile.Text != "Not found")
                {
                    attachment = new System.Net.Mail.Attachment(lblAttachedfile.Text);
                    mail.Attachments.Add(attachment);
                }

                smtp.Credentials = new System.Net.NetworkCredential(username, password); smtp.EnableSsl = true;
                smtp.Send(mail);
                lblErrorMessage.Text = "Mail has been sent successfully!";

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
        


        public void PrintImage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Rectangle page_area = e.PageBounds;
            e.Graphics.DrawImage(bitmap, (page_area.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        public void PrintArea(Panel panel)
        {
            bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height));
        }
        string smtphost = ConfigurationManager.AppSettings["host"];
        string fromAddress = ConfigurationManager.AppSettings["from"];
        int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
        string username = ConfigurationManager.AppSettings["userName"];
        string password = ConfigurationManager.AppSettings["password"];
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string file = outputFileName;
            if (Directory.Exists(Path.GetDirectoryName(file)))
            {
                File.Delete(file);
            }
            else
            {
                paneltobmp();
                convertimagetopdf();

                lblAttachedfile.Text = str1;
                txtto.Text = EmailId;


            }
        }


             
        public void getdoctordetails()
        {
            using (con = new SqlConnection(dbconnectionstring))
            {
                con.Open();
                Id = Convert.ToInt32(comboxdoc.SelectedValue);
                cmd = new SqlCommand("usp_UermstbyId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId",Id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read() != false)
                    {
                       
                        lbldocName.Text = Convert.ToString(reader["Name"]);
                      
                        lblLine1.Text = Convert.ToString(reader["Line1"]);
                        lblLine2.Text = Convert.ToString(reader["Line2"]);
                        lblLine3.Text = Convert.ToString(reader["Line3"]);
                        
                    }
                }
                con.Close();

            }


        }


        private void comboxdoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {if(comboxdoc.SelectedValue != null) { getdoctordetails(); }

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboxcompany.SelectedValue != null && combomonth.SelectedItem!=null && comboyear.SelectedItem!=null)
            {
                panel4.Visible = true;
                GetBillNo();
            }
        }




    }
}
