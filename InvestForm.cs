using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using static HSMAPP.Home;
using static HSMAPP.LogIn;

namespace HSMAPP
{
    public partial class InvestForm : Form
    {
        public InvestForm()
        {
            InitializeComponent();
            if (Loginfo.UserID > 0)
            {
               // getCompany();
                // grpbxpage2.Visible = false;
                pboxaudiomtry.Visible = false;
                pboxbloodreport.Visible = false;
                pboxecg.Visible = false;
                pboxpft.Visible = false;
                pboxxray.Visible = false;
                pboxurinereport.Visible = false;
                pboxgovtform.Visible = false;
                pictureBox1.Visible = false;
                lblaudiomtry.Visible = false;
                lblbloodreport.Visible = false;
                lblecg.Visible = false;
                //panelreport.Visible = false;
                lblUrineReport.Visible = false;
                lblxray.Visible = false;
                lblpft.Visible = false;
                lblspirometry.Visible = false;
                lblgovtform.Visible = false;
                // btnupdateGeneralExam.Visible = false;
                btnupdateInvestexam.Visible = false;
                // btnUpdateSystemExam.Visible = false;
                comboxdoc_remark();
                getReg();
                getdetails();
                GetForUpdateInvastegationExambypatientId(Patientinfo.PatientId);
            }

        }
        string label31;
        void getdetails()
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();
                    int Id = Convert.ToInt32(Patientinfo.PatientId);
                    string query = "select Id,RegNo,FirstName,LastName from PatientMst where Id=" + Id;

                    cmd = new SqlCommand(query, con);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {

                            Regno = reader["RegNo"].ToString();
                            label31 =Convert.ToString( reader["FirstName"]+ " " + reader["LastName"]);
                            label3.Text = Convert.ToString(reader["FirstName"] + " " + reader["LastName"]);
                            str = Convert.ToString(reader["FirstName"] + "_" + reader["LastName"]);

                            txtremarks.Text = "I hereby certify that I have examined "
                                + label31.ToString() +
                                " and he/she is free from any contagious/obnoxious/infectious/communicable disease," + Environment.NewLine + "constitutional weakness or boildy deformity.";

                            cmp = Convert.ToInt32(reader["CompanyId"]);
                            //GetForUpdateGeneralExambypatientId(Id);
                            GetForUpdateInvastegationExambypatientId(Id);

                            //  GetForUpdateSystematicExambypatientId(Id);
                        }
                        else
                        {
                            lblErrorMsg.Text = "Data Not Found";

                        }


                    }
                    con.Close();
                    // grpbxpage2.Visible = true;

                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        string Regno; //SqlDataAdapter adapt;
        string str;
        int IID;
     
        public void GetForUpdateInvastegationExambypatientId(int PatientId)
        {

            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetInvestigationRemarkPatientMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Patientinfo.PatientId));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            IID = Convert.ToInt32(reader["Id"]);
                            cmboxdoc_remark.SelectedItem= Convert.ToString(reader["DoctorsRemark"]);
                            if (Convert.ToString(reader["BloodReport"]) == "REPORT ATTACHED")
                            {
                                chkbloodreport.Checked = true;
                                lblbloodreport.Text = Convert.ToString(reader["BloodReportAttached"]);

                            }
                            else
                            {
                                chkbloodreport.Checked = false;
                            }


                            if (Convert.ToString(reader["UrineReport"]) == "REPORT ATTACHED")
                            {
                                chkUrinereport.Checked = true;
                                lblUrineReport.Text = Convert.ToString(reader["UrineReportAttached"]);
                            }
                            else
                            {
                                chkUrinereport.Checked = false;
                            }

                            if (Convert.ToString(reader["XRayChestReport"]) == "NORMAL")
                            {
                                chkxraychestreport.Checked = true;
                                lblxray.Text = Convert.ToString(reader["XRayChestReportAttached"]);
                            }
                            else
                            {
                                chkxraychestreport.Checked = false;
                            }


                            if (Convert.ToString(reader["PFT"]) == "NORMAL")
                            {
                                chkpftreport.Checked = true;
                                lblpft.Text = Convert.ToString(reader["PFTAttached"]);
                            }
                            else
                            {
                                chkpftreport.Checked = false;
                            }


                            if (Convert.ToString(reader["ECG"]) == "NORMAL")
                            {
                                chkECG.Checked = true;
                                lblecg.Text = Convert.ToString(reader["ECGAttached"]);
                            }
                            else
                            {
                                chkECG.Checked = false;
                            }


                            if (Convert.ToString(reader["Audiometry"]) == "NORMAL")
                            {
                                chkAduiometry.Checked = true;
                                lblaudiomtry.Text = Convert.ToString(reader["AudiometryAttached"]);
                            }
                            else
                            {
                                chkAduiometry.Checked = false;

                            }

                            if (Convert.ToString(reader["Spirometry"]) == "NORMAL")
                            {
                                chkspiromtry.Checked = true;
                                lblaudiomtry.Text = Convert.ToString(reader["SpirometryAttached"]);
                            }
                            else
                            {
                                chkspiromtry.Checked = false;
                            }

                            if (Convert.ToString(reader["FitnessCertificate"]) == "FORM ATTACHED")
                            {
                               
                                chkgovtform.Checked = true;
                                lblgovtform.Text = Convert.ToString(reader["FitnessCertificateAttached"]);

                            }
                            else
                            {
                                chkgovtform.Checked = false;
                            }

                            txtadvise.Text = Convert.ToString(reader["Advise"]);
                            txtremarks.Text = Convert.ToString(reader["Remarks"]);
                            button5.Visible = false;
                            btnupdateInvestexam.Visible = true;

                        }
                        else
                        {
                            button5.Visible = true;
                            btnupdateInvestexam.Visible = false;
                            chkbloodreport.Checked = false;
                            chkgovtform.Checked = false;
                            chkAduiometry.Checked = false;
                            chkspiromtry.Checked = false;
                            chkECG.Checked = false;
                            chkxraychestreport.Checked = false;
                            chkUrinereport.Checked = false;
                            chkpftreport.Checked = false;
                        }
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            { lblErrorMsg.Text = ex.Message; }
        }
        int cmp;
        void getReg()
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();
                    int Id = Convert.ToInt32(Patientinfo.PatientId);
                    string query = "select RegNo,FirstName,LastName from PatientMst where Id=" + Id;

                    cmd = new SqlCommand(query, con);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            Regno = reader["RegNo"].ToString();
                           // cmp = Convert.ToInt32(reader["CompanyId"]);
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

        public void comboxdoc_remark()
        {
            cmboxdoc_remark.Items.Add("Select");
            cmboxdoc_remark.Items.Clear();
            cmboxdoc_remark.Items.Add("FIT");
            cmboxdoc_remark.Items.Add("UNFIT");
            cmboxdoc_remark.Items.Add("PROVISONAL FITNESS");

        }

        int patientId;
        private void button5_Click(object sender, EventArgs e)
        {
            {   //to add system genral
                try
                {

                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        cmd = new SqlCommand("ups_InsertInvestigationRemarkPatientMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PatientId", Patientinfo.PatientId);
                        cmd.Parameters.AddWithValue("@RegNo", Regno);
                        cmd.Parameters.AddWithValue("@BloodReport", txtblood.Text);
                        cmd.Parameters.AddWithValue("@UrineReport", txturine.Text);
                        cmd.Parameters.AddWithValue("@XRayChestReport", txtxray.Text);

                        if (chkbloodreport.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@BloodReportAttached", lblbloodreport.Text);
                        }
                        else
                        {
                            // cmd.Parameters.AddWithValue("@BloodReport", "REPORT NOT ATTACHED");
                            cmd.Parameters.AddWithValue("@BloodReportAttached", "NA");
                        }
                        if (chkUrinereport.Checked == true)
                        {

                            cmd.Parameters.AddWithValue("@UrineReportAttached", lblUrineReport.Text);
                        }
                        else
                        {
                            // cmd.Parameters.AddWithValue("@UrineReport", "REPORT NOT ATTACHED");
                            cmd.Parameters.AddWithValue("@UrineReportAttached", "NA");
                        }
                        if (chkxraychestreport.Checked == true)
                        {

                            cmd.Parameters.AddWithValue("@XRayChestReportAttached", lblxray.Text);
                        }
                        else
                        {
                            //cmd.Parameters.AddWithValue("@XRayChestReport", "REPORT NOT ATTACHED");
                            cmd.Parameters.AddWithValue("@XRayChestReportAttached", "NA");
                        }
                        cmd.Parameters.AddWithValue("@PFT", txtpft.Text);
                        if (chkpftreport.Checked == true)
                        {

                            cmd.Parameters.AddWithValue("@PFTAttached", lblpft.Text);
                        }
                        else
                        {
                            // cmd.Parameters.AddWithValue("@PFT", "REPORT NOT ATTACHED");
                            cmd.Parameters.AddWithValue("@PFTAttached", "NA");
                        }
                        cmd.Parameters.AddWithValue("@ECG", txtECG.Text);
                        if (chkECG.Checked == true)
                        {

                            cmd.Parameters.AddWithValue("@ECGAttached", lblecg.Text);
                        }
                        else
                        {
                            // cmd.Parameters.AddWithValue("@ECG", "REPORT NOT ATTACHED");
                            cmd.Parameters.AddWithValue("@ECGAttached", "NA");
                        }
                        cmd.Parameters.AddWithValue("@Audiometry", txtAudiometry.Text);
                        if (chkAduiometry.Checked == true)
                        {

                            cmd.Parameters.AddWithValue("@AudiometryAttached", lblaudiomtry.Text);
                        }
                        else
                        {
                            // cmd.Parameters.AddWithValue("@Audiometry", "ABNORMAL");
                            cmd.Parameters.AddWithValue("@AudiometryAttached", "NA");
                        }
                        cmd.Parameters.AddWithValue("@FitnessCertificate", txtgovtform.Text);
                        if (chkgovtform.Checked == true)
                        {

                            cmd.Parameters.AddWithValue("@FitnessCertificateAttached", lblgovtform.Text);
                        }
                        else
                        {
                            //  cmd.Parameters.AddWithValue("@FitnessCertificate", "REPORT NOT ATTACHED");
                            cmd.Parameters.AddWithValue("@FitnessCertificateAttached", "NA");
                        }
                        cmd.Parameters.AddWithValue("@Spirometry", txtspirometry.Text);
                        if (chkspiromtry.Checked == true)
                        {

                            cmd.Parameters.AddWithValue("@SpirometryAttached", lblspirometry.Text);
                        }
                        else
                        {
                            //cmd.Parameters.AddWithValue("@Spirometry", "REPORT NOT ATTACHED");
                            cmd.Parameters.AddWithValue("@SpirometryAttached", "NA");
                        }

                        cmd.Parameters.AddWithValue("@Advise", txtadvise.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txtremarks.Text);
                        cmd.Parameters.AddWithValue("@DoctorsRemark", cmboxdoc_remark.SelectedItem.ToString());
                        con.Open();
                        IID = Convert.ToInt32(cmd.ExecuteNonQuery());
                        con.Close();
                        if (IID == 0)
                        {
                            lblErrorMsg.Text = "Already Exists Investigation Remark Patient";
                        }
                        else
                        {

                            lblErrorMsg.Text = "Saved Investigation Remark Patient Successfully";
                            patientId = Convert.ToInt32(Patientinfo.PatientId);
                            //  Form2 frm=new Form2();
                            //frm.Hide();
                            lblaudiomtry.Text = "";
                            lblbloodreport.Text = "";
                            lblecg.Text = "";
                            lblpft.Text = "";
                            lblUrineReport.Text = "";
                            lblgovtform.Text = "";
                            lblxray.Text = "";
                            chkAduiometry.Checked = false;



                        }



                        button5.Visible = false;
                        btnupdateInvestexam.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text = ex.Message;
                }

            }

        }

        private void btnupdateInvestexam_Click(object sender, EventArgs e)
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_UpdateInvestigationRemarkPatientMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", IID);
                    cmd.Parameters.AddWithValue("@PatientId", Patientinfo.PatientId);
                    cmd.Parameters.AddWithValue("@RegNo", Regno);
                    cmd.Parameters.AddWithValue("@BloodReport", txtblood.Text);
                    if (chkbloodreport.Checked == true)
                    {


                        cmd.Parameters.AddWithValue("@BloodReportAttached", lblbloodreport.Text);
                    }
                    else
                    {
                        //cmd.Parameters.AddWithValue("@BloodReport", "NA");
                        cmd.Parameters.AddWithValue("@BloodReportAttached", "NA");
                    }
                    cmd.Parameters.AddWithValue("@UrineReport", txturine.Text);
                    if (chkUrinereport.Checked == true)
                    {

                        cmd.Parameters.AddWithValue("@UrineReportAttached", lblUrineReport.Text);
                    }
                    else
                    {
                        //cmd.Parameters.AddWithValue("@UrineReport", "NA");
                        cmd.Parameters.AddWithValue("@UrineReportAttached", "NA");
                    }
                    cmd.Parameters.AddWithValue("@XRayChestReport", txtxray.Text);
                    if (chkxraychestreport.Checked == true)
                    {

                        cmd.Parameters.AddWithValue("@XRayChestReportAttached", lblxray.Text);
                    }
                    else
                    {
                        //cmd.Parameters.AddWithValue("@XRayChestReport", "NA");
                        cmd.Parameters.AddWithValue("@XRayChestReportAttached", "NA");
                    }
                    cmd.Parameters.AddWithValue("@PFT", txtpft.Text);
                    if (chkpftreport.Checked == true)
                    {

                        cmd.Parameters.AddWithValue("@PFTAttached", lblpft.Text);
                    }
                    else
                    {
                        // cmd.Parameters.AddWithValue("@PFT", "NA");
                        cmd.Parameters.AddWithValue("@PFTAttached", "NA");
                    }
                    cmd.Parameters.AddWithValue("@ECG", txtECG.Text);
                    if (chkECG.Checked == true)
                    {

                        cmd.Parameters.AddWithValue("@ECGAttached", lblecg.Text);
                    }
                    else
                    {
                        // cmd.Parameters.AddWithValue("@ECG", "NA");
                        cmd.Parameters.AddWithValue("@ECGAttached", "NA");
                    }
                    cmd.Parameters.AddWithValue("@Audiometry", txtAudiometry.Text);
                    if (chkAduiometry.Checked == true)
                    {

                        cmd.Parameters.AddWithValue("@AudiometryAttached", lblaudiomtry.Text);
                    }
                    else
                    {
                        // cmd.Parameters.AddWithValue("@Audiometry", "NA");
                        cmd.Parameters.AddWithValue("@AudiometryAttached", "NA");
                    }
                    cmd.Parameters.AddWithValue("@FitnessCertificate", txtgovtform.Text);
                    if (chkgovtform.Checked == true)
                    {

                        cmd.Parameters.AddWithValue("@FitnessCertificateAttached", lblgovtform.Text);
                    }
                    else
                    {
                        //cmd.Parameters.AddWithValue("@FitnessCertificate", "NA");
                        cmd.Parameters.AddWithValue("@FitnessCertificateAttached", "NA");
                    }
                    cmd.Parameters.AddWithValue("@Spirometry", txtspirometry.Text);
                    if (chkspiromtry.Checked == true)
                    {

                        cmd.Parameters.AddWithValue("@SpirometryAttached", lblspirometry.Text);
                    }
                    else
                    {
                        //  cmd.Parameters.AddWithValue("@Spirometry", "NA");
                        cmd.Parameters.AddWithValue("@SpirometryAttached", "NA");
                    }


                    cmd.Parameters.AddWithValue("@Advise", txtadvise.Text);
                    cmd.Parameters.AddWithValue("@Remarks", txtremarks.Text);
                    cmd.Parameters.AddWithValue("@DoctorsRemark", cmboxdoc_remark.SelectedItem.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    lblErrorMsg.Text = "Details Updated Successfully";
                    button5.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }
        //string label3;


        private void chkbloodreport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbloodreport.Checked == true)
            {
                // panel3.Visible = true;
                pboxbloodreport.Visible = true;
            }
            else
            {
                pboxbloodreport.Visible = false;
            }

        }

        private void pboxbloodreport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;

                    pboxbloodreport.Image = new System.Drawing.Bitmap(selectedFilePath);
                    //string targetFolder = Application.StartupPath;
                    var PatId = Convert.ToString(str + "_BloodReport");

                    var path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");

                    lblbloodreport.Text = path.ToString();
                    try
                    {
                        pboxbloodreport.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                }

            }
        }
        private void pboxurinereport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;

                    pboxurinereport.Image = new System.Drawing.Bitmap(selectedFilePath);
                    //string targetFolder = Application.StartupPath;
                    var PatId = Convert.ToString(str + "_UrineReport");

                    var path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");

                    lblUrineReport.Text = path.ToString();
                    try
                    {
                        pboxurinereport.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                }

            }

        }

        private void pboxxray_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;

                    pboxxray.Image = new System.Drawing.Bitmap(selectedFilePath);
                    //string targetFolder = Application.StartupPath;
                    var PatId = Convert.ToString(str + "xRayReport");

                    var path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");

                    lblxray.Text = path.ToString();
                    try
                    {
                        pboxxray.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                }

            }
        }

        private void pboxpft_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;

                    pboxpft.Image = new System.Drawing.Bitmap(selectedFilePath);
                    //string targetFolder = Application.StartupPath;
                    var PatId = Convert.ToString(str + "_PFTReport");

                    var path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");

                    lblpft.Text = path.ToString();
                    try
                    {
                        pboxpft.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                }

            }
        }

        private void pboxecg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;

                    pboxecg.Image = new System.Drawing.Bitmap(selectedFilePath);
                    //string targetFolder = Application.StartupPath;
                    var PatId = Convert.ToString(str + "ECGReport");

                    var path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");

                    lblecg.Text = path.ToString();
                    try
                    {
                        pboxecg.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                }

            }
        }

        private void pboxaudiomtry_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;

                    pboxaudiomtry.Image = new System.Drawing.Bitmap(selectedFilePath);
                    //string targetFolder = Application.StartupPath;
                    var PatId = Convert.ToString(str + "_AudiometryReport");

                    var path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");

                    lblaudiomtry.Text = path.ToString();
                    try
                    {
                        pboxaudiomtry.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                }

            }

        }

        private void chkUrinereport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUrinereport.Checked == true)
            {
                // panel3.Visible = true;
                pboxurinereport.Visible = true;
            }
            else
            {
                pboxurinereport.Visible = false;

            }
        }

        private void chkxraychestreport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkxraychestreport.Checked == true)
            {
                // panel3.Visible = true;
                pboxxray.Visible = true;
            }
            else
            {
                pboxxray.Visible = false;

            }
        }

        private void chkpftreport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpftreport.Checked == true)
            {
                // panel3.Visible = true;
                pboxpft.Visible = true;
            }
            else
            {
                pboxpft.Visible = false;

            }
        }

     
        private void pboxgovtform_Click(object sender, EventArgs e)
        {
            var PatId = Convert.ToString(str + "_FitnessCertificate");
            var path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;

                    pboxgovtform.Image = new System.Drawing.Bitmap(selectedFilePath);
                    //string targetFolder = Application.StartupPath;
                    PatId = Convert.ToString(str + "_FitnessCertificate");

                    path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");

                    lblgovtform.Text = path.ToString();
                    try
                    {
                        pboxgovtform.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                }

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {//sipormrty puicturebox
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;

                    pictureBox1.Image = new System.Drawing.Bitmap(selectedFilePath);
                    //string targetFolder = Application.StartupPath;
                    var PatId = Convert.ToString(str + "_SpirometryReport");

                    var path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");

                    lblspirometry.Text = path.ToString();
                    try
                    {
                        pictureBox1.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                }

            }
        }

        private void chkgovtform_CheckedChanged(object sender, EventArgs e)
        {
            if (chkgovtform.Checked == true)
            {
                // panel3.Visible = true;
                pboxgovtform.Visible = true;
            }
            else
            {
                pboxgovtform.Visible = false;

            }
        }
        void getCompany()
        {
            
        }
       
        private void chkECG_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkECG.Checked == true)
            {
                // panel3.Visible = true;
                pboxecg.Visible = true;
            }
            else
            {
                pboxecg.Visible = false;

            }

        }

        private void chkAduiometry_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkAduiometry.Checked == true)
            {
                // panel3.Visible = true;
                pboxaudiomtry.Visible = true;
            }
            else
            {
                pboxaudiomtry.Visible = false;

            }
        }


      
        private void btnPaymentadd_Click(object sender, EventArgs e)
        {

        }

        private void chkspiromtry_CheckedChanged(object sender, EventArgs e)
        {
            if (chkspiromtry.Checked == true)
            {
                // panel3.Visible = true;
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
            }

        }

        private void pboxbloodreport_Click_1(object sender, EventArgs e)
        {
            //sipormrty puicturebox
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;

                    pboxbloodreport.Image = new System.Drawing.Bitmap(selectedFilePath);
                    //string targetFolder = Application.StartupPath;
                    var PatId = Convert.ToString(str + "_BloodReport");

                    var path = Convert.ToString(@"..\..\Imgs\" + str + "\\" + PatId + ".jpg");

                    lblbloodreport.Text = path.ToString();
                    try
                    {
                        pboxbloodreport.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                }

            }
        }
        //string paymentdate;
        private void btnPaymentadd_Click_1(object sender, EventArgs e)
        {
            //payment by patient
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {


                    if(txtpaymentamt.Text != string.Empty)
                    {
                        cmd = new SqlCommand("usp_InsertTestMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(LogIn.Loginfo.UserID));
                        cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Patientinfo.PatientId));
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(Patientinfo.compId));
                       // paymentdate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                        cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@TestName", "Tests");
                        cmd.Parameters.AddWithValue("@Cost", txtpaymentamt.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblErrorMsg.Text = "Details Inserted Successfully";

                        // data();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Please enter mandatory details!";
                    }

                    // data();
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
            //txttestname.Clear();
            txtpaymentamt.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            this.Dispose();
        }
    }
}
