using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;
using Image = iTextSharp.text.Image;
using System.Configuration;
using System.Data;

namespace HSMAPP
{
    public partial class FormprintReport : Form
    {
       // int str;
        Bitmap bitmap;
        public FormprintReport()
        {
            InitializeComponent();
            getCompany();
           
        }
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt; //int rowId;

        public void dataInvestigationinformation1()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();
                    int Id = Convert.ToInt32(comboBox1.SelectedValue);
                    string query = "SELECT Id,PatientId,RegNo,BloodReportAttached,UrineReportAttached,XRayChestReportAttached,PFTAttached,ECGAttached,AudiometryAttached,FitnessCertificateAttached,SpirometryAttached FROM InvestigationRemarkPatientMst where PatientId=" + Id;

                    cmd = new SqlCommand(query, con);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            lblPatientName.Text = Convert.ToString(reader["RegNo"]);
                            lblBloodReport.Text = Convert.ToString(reader["BloodReportAttached"]);
                            lblUrinereport.Text = Convert.ToString(reader["UrineReportAttached"]);
                            lblXrayreport.Text = Convert.ToString(reader["XRayChestReportAttached"]);
                            lblpftreport.Text = Convert.ToString(reader["PFTAttached"]);
                            lblEcgreport.Text = Convert.ToString(reader["ECGAttached"]);
                            lblaudiometry.Text = Convert.ToString(reader["AudiometryAttached"]);
                           lblfitnesscertifcate.Text = Convert.ToString(reader["FitnessCertificateAttached"]);
                           lblspiormetry.Text = Convert.ToString(reader["SpirometryAttached"]);
                        }
                        else
                        {
                            lblErrorMsg.Text = "Data Not Found";

                        }


                        //con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
           
            Print(this.panel_print);
        }

        
        public void Print(Panel panel)
        {
            PrinterSettings set = new PrinterSettings();
            panel_print = panel;
            PrintArea(panel);
           // print.Document = print_doc;
            print_doc.PrintPage += new PrintPageEventHandler(PrintImage);
            print_doc.Print();

        }

        public void PrintImage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Rectangle page_area = e.PageBounds;
            e.Graphics.DrawImage(bitmap, (page_area.Width / 2) - (this.panel_print.Width / 2), this.panel_print.Location.Y);
        }

        public void PrintArea(Panel panel)
        {
            bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = lblBloodReport.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            str = lblBloodReport.Text;
            // pictureBox1.Image.Save(lblBloodReport.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUrinereport_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = lblUrinereport.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            str= lblUrinereport.Text;

        }

        private void btnxrayreport_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = lblXrayreport.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            str= lblXrayreport.Text;

        }

        private void btnpftreport_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = lblpftreport.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            str= lblpftreport.Text;

        }

        private void btnecgreport_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = lblEcgreport.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            str = lblEcgreport.Text;
        }

        private void btnaudiomtryreport_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = lblaudiometry.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            str = lblaudiometry.Text;

        }

       
        private void button5_Click(object sender, EventArgs e)
        {//fitness certificate
            pictureBox1.ImageLocation = lblfitnesscertifcate.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            str = lblfitnesscertifcate.Text;
        }
       string str;
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
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                GetPatRegno();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        { if (comboBox1.SelectedValue != null)
            {
                dataInvestigationinformation1();
            }

        }

        private void btnspirometry_Click(object sender, EventArgs e)
        {
            //fitness certificate
            pictureBox1.ImageLocation = lblspiormetry.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            str = lblspiormetry.Text;
        }

        private void btnbloodreport_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = lblBloodReport.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            str = lblBloodReport.Text;

        }

       


        // private void btnpftreport_Click_1(object sender, EventArgs e)
        // {

        //}



        // string str1;
        //private void checkBox3_CheckedChanged(object sender, EventArgs e)
        //{
        //    //selected one //pdf
        //    checkBox1.Checked = false;
        //    checkBox2.Checked = false;
        //    lblAttachedfile.Text = string.Empty;
        //    str1 = str.Remove(str.Length - 4);
        //    str1 = str1 + ".pdf";

        //    Document doc = new Document();
        //    using (var stream =new FileStream(str1,FileMode.Create,FileAccess.Write,FileShare.None))
        //    {

        //        PdfWriter.GetInstance(doc, stream);
        //        doc.Open();
        //        using (var imagestream = new FileStream(str, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) 
        //        {
        //            var image = iTextSharp.text.Image.GetInstance(imagestream);
        //            doc.Add(image);
        //        }
        //        doc.Close();     

        //    }
        //    if (checkBox3.Checked == true)
        //    {
        //        lblAttachedfile.Text = str1;
        //    }
        //}






    }
}
