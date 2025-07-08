using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;


namespace HSMAPP
{
    public partial class Form1print : Form
    {
        int Id;
        string outputFileName;
        public Form1print()
        {
            
            InitializeComponent();
            //int Id = ViewPatient.imagval.rowId;
            if (ViewPatient.imagval.rowId > 0)
            {
                Id = ViewPatient.imagval.rowId;
                data();
                //paneltobmp();
               

            }
            if (Home.Patientinfo.PatientId > 0)
            {
                Id = Home.Patientinfo.PatientId;
                data();
              //  paneltobmp();
                
                this.Hide();

            }


        }string str;
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int compname;

        public void data()
        {


            // var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetPatientMstbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Id));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {

                            lblpresentjobdesc.Text = Convert.ToString(reader["PresentJobDesc"]);
                            lblothercomplaints.Text = Convert.ToString(reader["OtherComplaints"]);

                            lblFmenstrualcycle.Text = Convert.ToString(reader["MenstrualCycle"]);
                            lblGender.Text = Convert.ToString(reader["Gender"]);
                            lblmariatalstatus.Text = Convert.ToString(reader["Mariatal_Status"]);

                            lblpasthistory.Text = Convert.ToString(reader["PastHistory"]);
                            lblpersonalhistory.Text = Convert.ToString(reader["PersonalHistory"]);
                            lblfamilyhistory.Text = Convert.ToString(reader["FamilyHistory"]);
                            lblImmunisation.Text = Convert.ToString(reader["Immunisation"]);
                            lbldomandhand.Text = Convert.ToString(reader["DominantHand"]);
                            lblpersonalhabbits.Text = Convert.ToString(reader["PersonalHabbits"]);
                            lblAddress.Text = Convert.ToString(reader["Address"]);
                            lblAge.Text = Convert.ToString(reader["Age"]);
                            lblDiet.Text = Convert.ToString(reader["Diet"]);
                            lblIDMark.Text = Convert.ToString(reader["IDMark"]);
                            pictureBox1.ImageLocation = Convert.ToString(reader["Photo"]);

                            lblDOB.Text = Convert.ToString(Convert.ToDateTime(reader["DOB"]).ToShortDateString());
                            lblcandidatename.Text = Convert.ToString(reader["FirstName"]) + " " + Convert.ToString(reader["LastName"]); ;
                            str= Convert.ToString(reader["FirstName"]) + "_" + Convert.ToString(reader["LastName"]); ;
                            lblDate.Text = Convert.ToString(Convert.ToDateTime(reader["DateOn"]).ToShortDateString());
                            lblRegNo.Text = Convert.ToString(reader["RegNo"]);
                           lbldatedown1.Text = Convert.ToString(DateTime.Now.ToShortDateString());

                            // lblCompanyName.Text
                            //lblcandidatename.Text= Convert.ToString(reader["FirstName"])+" "+ Convert.ToString(reader["LastName"]); ;
                            lblsigncanditae.Text = lblcandidatename.Text;
                            compname = Convert.ToInt32(reader["CompanyId"]);
                            companyname();
                        }
                        con.Close();

                    }
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        cmd = new SqlCommand("usp_GetPatientPreviousCompanyMstbyPatientId1", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Id));
                        con.Open();
                        DataTable dataTable = new DataTable();
                        adapt = new SqlDataAdapter(cmd);
                        adapt.Fill(dataTable);
                       // totalRecords = Convert.ToInt32(dataTable.Rows.Count);

                        dataGridView1.DataSource = dataTable;

                        dataGridView1.AutoGenerateColumns = false;
                        this.dataGridView1.Columns["PatientId"].Visible = false;
                       this.dataGridView1.Columns["Id"].Visible = false;
                        this.dataGridView1.Columns["RegNo"].Visible = false;
                        // this.dataGridView1.Columns["NameOfCompany"].Visible = true;
                        this.dataGridView1.Columns["Name Of Company"].Width = 200;
                        this.dataGridView1.Columns["No. Of Years"].Width = 150;
                        this.dataGridView1.Columns["Nature Of Job"].Width = 150;
                        this.dataGridView1.Columns["Any Occupational  Health Aliments"].Width = 300;

                       // dataGridView1.RowCount = 30;

                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridView1.Refresh();
                        con.Close();
                    }
                    


                  

                }
            }

            catch (Exception ex)
            { lblErrorMsg.Text = ex.Message; }

        }

        public void companyname()
        {
            using (con = new SqlConnection(dbconnectionstring))
            {
                cmd = new SqlCommand("usp_GetCompanyMstByserchId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyId", compname);
                con.Open();
                using (var reader1 = cmd.ExecuteReader())
                {
                    if (reader1.Read() != false)
                    {

                        lblCompanyName.Text = Convert.ToString(reader1["CompanyName"]);

                    }
                }
                con.Close();
            }

        }
        public void addimagetodatabase()
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_PatientfrmImage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Id));
                    cmd.Parameters.AddWithValue("@form1Image", outputFileName);
                    cmd.Parameters.AddWithValue("@form2Image","");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }


                        Bitmap bitmap;
       // private readonly object ImageDataFactory;
       // Bitmap bmp;
        public void Print(Panel panel)
        {
            PrinterSettings set = new PrinterSettings();
            panel_1 = panel;
            PrintArea(panel);
            print_doc.PrintPage += new PrintPageEventHandler(PrintImage);
            // print_doc.DefaultPageSettings.PaperSize("210 x 297 mm", 800, 800);
           
            print_doc.Print();
        }

        public void PrintImage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Rectangle page_area = e.PageBounds;
            e.Graphics.DrawImage(bitmap, (page_area.Width / 2) - (this.panel_1.Width / 2), this.panel_1.Location.Y);



        }
        public void PrintArea(Panel panel)
        {
            bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, panel_1.Width, panel_1.Height));
        }

        //protected override void OnPaint(PaintEventArgs args)
        //{
        //    args.Graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, this.Width, this.Height);
        //    TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
        //    TextRenderer.DrawText(args.Graphics, Text, Font, new Point(Width + 3, this.Height / 2), ForeColor, flags);
        //    this.Image = Image.FromFile(@outputFileName);
        //    base.OnPaint(args);
        //}
        // string outputFileName1;
        void convertimagetopdf()
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, panel_1.Width, panel_1.Height));
            byte[] imageBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Png);
                imageBytes = stream.ToArray();
            }
            outputFileName = @"../../Imgs/" + str + "//" + str + "_form1.pdf";
            // outputFileName1 = @"../../Imgs/" + str + "//" + str + "_form1.png";
            PdfWriter writer = new PdfWriter(outputFileName);
            // writer.Add(outputFileName);
            iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer);
            Document document = new Document(pdf);
            ImageData imageData = iText.IO.Image.ImageDataFactory.Create(imageBytes);
            iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);
            // document.Flush();
            document.Add(image);
            document.Close();
        }
        void paneltobmp()
        {
           
                outputFileName = @"../../Imgs/" + str + "//" + str + "_form1.pdf";
            //outputFileName1 = @"../../Imgs/" + str + "//" + str + "_form1.png";
            if (File.Exists(outputFileName)) { File.Delete(outputFileName); convertimagetopdf(); }
            else
            {
                convertimagetopdf();
            }
            lblErrorMsg.Text = "Pdf Created and Saved";
          
            if (outputFileName != null)
               {
                   addimagetodatabase();
               }
           
            
        }
        

      private void button1_Click(object sender, EventArgs e)
        {
            Print(this.panel_1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            paneltobmp();
            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1print_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
