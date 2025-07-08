using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HSMAPP
{

    public partial class Printform1 : Form
    {
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        //SqlDataAdapter adapt;
        int compname;
        int Id;
        public Printform1()
        {
            InitializeComponent();
            if (ViewPatient.imagval.rowId > 0)
            {
                Id = ViewPatient.imagval.rowId;
                data();
                paneltobmp();


            }
        }
        Bitmap bitmap;
        private void Printform1_Load(object sender, EventArgs e)
        {


        }
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
                            lblDate.Text = Convert.ToString(Convert.ToDateTime(reader["DateOn"]).ToShortDateString());
                            lblRegNo.Text = Convert.ToString(reader["RegNo"]);
                            lbldatedown1.Text = Convert.ToString(DateTime.Now.ToShortDateString());

                            // lblCompanyName.Text
                            //lblcandidatename.Text= Convert.ToString(reader["FirstName"])+" "+ Convert.ToString(reader["LastName"]); ;
                            lblsigncanditae.Text = lblcandidatename.Text;
                            compname = Convert.ToInt32(reader["CompanyId"]);

                        }
                        con.Close();

                    }
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        cmd = new SqlCommand("usp_GetPatientPreviousCompanyMstbyPatientId", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Id));
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() != false)
                            {
                                // Id1 = Convert.ToInt32(reader["Id"]);
                                lblcompany1.Text = Convert.ToString(reader["NameOfCompany"]);
                                lblnoyrs1.Text = Convert.ToString(reader["NoOfyrs"]);
                                lblnatueofjob.Text = Convert.ToString(reader["NatureOfJob"]);
                                lblanyoccupational1.Text = Convert.ToString(reader["AnyOccupationalHealthAilments"]);
                                lblcompany2.Text = Convert.ToString(reader["NameOfCompany1"]);
                                lblnoyrs2.Text = Convert.ToString(reader["NoOfyrs1"]);
                                lblnature2.Text = Convert.ToString(reader["NatureOfJob1"]);
                                lblocuupation2.Text = Convert.ToString(reader["AnyOccupationalHealthAilments1"]);
                                lblcompany3.Text = Convert.ToString(reader["NameOfCompany2"]);
                                lblnoyear3.Text = Convert.ToString(reader["NoOfyrs2"]);
                                lblnaturjob3.Text = Convert.ToString(reader["NatureOfJob2"]);
                                lblanyoccupational3.Text = Convert.ToString(reader["AnyOccupationalHealthAilments2"]);

                            }
                            con.Close();
                        }
                    }


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
            }

            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

        }
        void paneltobmp()
        {
            using (bitmap = new Bitmap(this.panel1.ClientSize.Width, this.panel1.ClientSize.Height))
            {
               //this.panel1.BackgroundImage.Clone();
               this.panel1.DrawToBitmap(bitmap,this.panel1.ClientRectangle );
               //this.panel1.BackgroundImage.Clone();
                bitmap.Save(@"../../Imgs/" + lblcandidatename.Text + "_form1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);



                string outputFileName = @"../../Imgs/" + lblcandidatename.Text + "_form1.bmp";

                if (outputFileName != null)
                {
                    // addimagetodatabase();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Image imag = Image.FromFile(@"../../Imgs/" + lblcandidatename.Text + "_form1.bmp");
          
            e.Graphics.DrawImage(imag, new Point(0, 0));
        }
    }
}