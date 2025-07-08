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
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;


namespace HSMAPP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (ViewPatient.imagval.rowId > 0)
            {
                Id = ViewPatient.imagval.rowId;
                data();
                GetForUpdateGeneralExambypatientId();
                GetForUpdateInvastegationExambypatientId();
                GetForUpdateSystematicExambypatientId();
               // paneltobmp();
                
            }
            if (AddPatient2.patientId > 0)
            {
                Id = AddPatient2.patientId;
                data();
                GetForUpdateGeneralExambypatientId();
                GetForUpdateInvastegationExambypatientId();
                GetForUpdateSystematicExambypatientId();
                
               // paneltobmp();
               // addimagetodatabase();
                this.Hide();
            }
        }
        int Id;
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        string str;
        int compname;
        public void data()
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

                        lblregno.Text = Convert.ToString(reader["RegNo"]);
                        compname = Convert.ToInt32(reader["CompanyId"]);
                        lblcandidatename.Text = Convert.ToString(reader["FirstName"]) + " " + Convert.ToString(reader["LastName"]);
                        str= Convert.ToString(reader["FirstName"]) + "_" + Convert.ToString(reader["LastName"]);
                        lbldate.Text = Convert.ToString(DateTime.Now.ToShortDateString());
                        lbldatetop.Text = Convert.ToString(DateTime.Now.ToShortDateString());
                        lblgender.Text = Convert.ToString(reader["Gender"]);
                        lblage.Text = Convert.ToString(reader["Age"]);

                    }
                }
                con.Close();

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
                            lblcompanyname.Text = Convert.ToString(reader1["CompanyName"]);

                        }
                    }
                    con.Close();
                }
            }
        
    }

        public void addimagetodatabase()
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_insertpatientformimage2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Id));
                   // cmd.Parameters.AddWithValue("@form1Image", "");
                    cmd.Parameters.AddWithValue("@form2Image", outputFileName);
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
        public void GetForUpdateGeneralExambypatientId()
        {
           
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetGeneralExaminationPatientMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Id));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            // GId = Convert.ToInt32(reader["Id"]);
                            lblHeight.Text = Convert.ToString(reader["Height"]);
                            lblWeight.Text = Convert.ToString(reader["weight"]);

                            lblpulse.Text = Convert.ToString(reader["Pluse"]);
                            lblbp.Text = Convert.ToString(reader["BP"]);

                            lbltemp.Text = Convert.ToString(reader["TempInF"]);
                            lblrespiration.Text = Convert.ToString(reader["Respiration"]);
                            lblbuilt.Text = Convert.ToString(reader["Built"]);
                            lblnutrition.Text = Convert.ToString(reader["Nutrition"]);
                            lblnails.Text = Convert.ToString(reader["Nails"]);
                            lblteeth.Text = Convert.ToString(reader["Teeth"]);
                            lblgums.Text = Convert.ToString(reader["Gums"]);
                            lbloralhygene.Text = Convert.ToString(reader["OralHygene"]);
                            lbllymphnode.Text = Convert.ToString(reader["LymphNodes"]);
                            lbleye.Text = Convert.ToString(reader["Eyes"]);
                            lblspine.Text = Convert.ToString(reader["Spine"]);
                            lbltongue.Text = Convert.ToString(reader["Tongue"]);
                            lblEnt.Text = Convert.ToString(reader["Ent"]);
                            lblbonesjoints.Text = Convert.ToString(reader["BonesJoints"]);
                            lblSkin.Text = Convert.ToString(reader["Skin"]);
                            lblhearing.Text = Convert.ToString(reader["HearingR"]);
                            lblhearingL.Text = Convert.ToString(reader["HearingL"]);
                            lbleyesvision.Text = Convert.ToString(reader["EyesVisionR"]);
                            lbleyesvisionL.Text = Convert.ToString(reader["EyesVisionL"]);
                            lblcolorvision.Text = Convert.ToString(reader["ColourVision"]);

                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            { lblErrorMsg.Text = ex.Message;
              }
        }

        public void GetForUpdateSystematicExambypatientId()
        {
            var datatable = new DataTable();
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetSystemExaminationPatientMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Id));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            // SID = Convert.ToInt32(reader["Id"]);

                            lblHeartSound.Text = Convert.ToString(reader["Cardio_HeartSound"]);
                            lblmurmur.Text = Convert.ToString(reader["Cardio_Murmur"]);
                            lblChestmovements.Text = Convert.ToString(reader["Respir_ChestMovements"]);
                            lbltreachea.Text = Convert.ToString(reader["Respir_Trachea"]);
                            lblbreathsound.Text = Convert.ToString(reader["Respir_BreathSounds"]);
                            lbladventitoussound.Text = Convert.ToString(reader["Respir_AdventitiousSounds"]);
                            lblliver.Text = Convert.ToString(reader["Gastrointestional_Liver"]);
                            lblspleen.Text = Convert.ToString(reader["Gastrointestional_Spleen"]);
                            lblhigherfunction.Text = Convert.ToString(reader["CentralNervous_HigherFunction"]);
                            lblsensorysystem.Text = Convert.ToString(reader["CentralNervous_SensorySystem"]);
                            lblmotorsystem.Text = Convert.ToString(reader["CentralNervous_MotorSystem"]);
                            lblgentourniarysystem.Text = Convert.ToString(reader["GenitoUrinarySystem"]);


                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            { lblErrorMsg.Text = ex.Message; }
        }
       // string strr;
        public void GetForUpdateInvastegationExambypatientId()
        {
            var datatable = new DataTable();
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetInvestigationRemarkPatientMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Id));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            // IID = Convert.ToInt32(reader["Id"]);
                            lblDoctorremarks.Text = Convert.ToString(reader["DoctorsRemark"]);
                            lblBloodreport.Text = Convert.ToString(reader["BloodReport"]);
                            lblUrinereport.Text = Convert.ToString(reader["UrineReport"]);
                            lblaudiometryreport.Text = Convert.ToString(reader["Audiometry"]);
                            lblpft.Text = Convert.ToString(reader["PFT"]);
                            lblecgreport.Text = Convert.ToString(reader["ECG"]);
                            lblXraychest.Text = Convert.ToString(reader["XRayChestReport"]);

                            lblAdvise.Text = Convert.ToString(reader["Advise"]);
                            remark = Convert.ToString(reader["Remarks"]);
                            if (remark != null)
                            {
                                seperateremarks();


                            }

                           

                        }
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            { lblErrorMsg.Text = ex.Message; }
        }
        string remark;
        void seperateremarks()
        {
            string text = remark;
            char[] delimiters = new char[] {' '};
            string[]words=text.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
            int midpoint = words.Length / 2;
            string firsthalf = string.Join(" ", words.Take(midpoint));
            string secondhalf = string.Join(" ", words.Skip(midpoint));
            lblRemarks.Text=firsthalf+"\r\n"+secondhalf;
        }
       // string outputFileName;
        private void btnprint_Click(object sender, EventArgs e)
        {
           
            Print(this.panel1);
        }
        Bitmap bitmap;
        public void Print(Panel panel)
        {
            PrinterSettings set = new PrinterSettings();
            panel1 = panel;
            PrintArea(panel);
            print_doc.PrintPage += new PrintPageEventHandler(PrintImage);
            print_doc.Print();
        }

        public void PrintImage(object sender, PrintPageEventArgs e)
        {
            Rectangle page_area = e.PageBounds;
            e.Graphics.DrawImage(bitmap, (page_area.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);



        }
        public void PrintArea(Panel panel)
        {
            bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new Rectangle(950, 800, panel.Width, panel.Height));
        }
        string outputFileName;
       

        private void button1_Click(object sender, EventArgs e)
        {
            paneltobmp();
        }//string outputFileName1;
        void convertimagetopdf()
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, panel1.Width, panel1.Height));
            byte[] imageBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Png);
                imageBytes = stream.ToArray();
            }
            // outputFileName1 = @"../../Imgs/" + str + "//" + str + "_form2.png";
            outputFileName = @"../../Imgs/" + str + "//" + str + "_form2.pdf";
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
           // outputFileName1 = @"../../Imgs/" + str + "//" + str + "_form2.png";
            outputFileName = @"../../Imgs/" + str + "//" + str + "_form2.pdf";
            if (File.Exists(outputFileName)) { File.Delete(outputFileName);
                convertimagetopdf();


            }
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void lblgender_Click(object sender, EventArgs e)
        {

        }

        private void lblaudiometryreport_Click(object sender, EventArgs e)
        {

        }

        private void lblHeartSound_Click(object sender, EventArgs e)
        {

        }
    }
}
