using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HSMAPP.Home;
using static HSMAPP.LogIn;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HSMAPP
{
    public partial class generalform : Form
    {
        int PatId;
        string regno;

        public generalform()
        {
            InitializeComponent();
            if (Loginfo.UserID > 0)
            {
               // getCompany();
               // grpbxpage2.Visible = false;
                //panelreport.Visible = false;
                btnupdateGeneralExam.Visible = false;
                btnUpdateSystemExam.Visible = false;
                button2.Visible = false;
                // btnupdateInvestexam.Visible = false;
                // btnUpdateSystemExam.Visible = false;
                itemcolourvision();
                itemeyes();
                if (Patientinfo.PatientId > 0)
                {
                    todisplay();
                    PatId = Patientinfo.PatientId;
                    regno = Patientinfo.Regno;
                }
                else
                {
                    this.Hide();    
                }
            }
        }
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
       string Regno; //SqlDataAdapter adapt;
        string str;
        int GId, SID;
        public void itemcolourvision()

        {
            cboxcolourvision.Items.Add("NORMAL");
            cboxcolourvision.Items.Add("COLOUR BLIND");
            cboxcolourvision.Items.Add("PARTIAL COLOUR BLIND");


        }
        public void itemeyes()

        {
            cboxeyes.Items.Add("NORMAL");
            cboxeyes.Items.Add("WITHOUT SPECS");
            cboxeyes.Items.Add("WITH SPECS");


        }
        public void GetForUpdateGeneralExambypatientId(int PatientId)
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetGeneralExaminationPatientMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Patientinfo.PatientId));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            GId = Convert.ToInt32(reader["Id"]);
                            txtheight.Text = Convert.ToString(reader["Height"]);
                            txtweight.Text = Convert.ToString(reader["weight"]);

                            txtpluse.Text = Convert.ToString(reader["Pluse"]);
                            txtbp.Text = Convert.ToString(reader["BP"]);

                            txttemp.Text = Convert.ToString(reader["TempInF"]);
                            txtrespiration.Text = Convert.ToString(reader["Respiration"]);
                            txtbuilt.Text = Convert.ToString(reader["Built"]);
                            txtnutrition.Text = Convert.ToString(reader["Nutrition"]);
                            txtnails.Text = Convert.ToString(reader["Nails"]);
                            txtteeth.Text = Convert.ToString(reader["Teeth"]);
                            txtgums.Text = Convert.ToString(reader["Gums"]);
                            txtoralhygene.Text = Convert.ToString(reader["OralHygene"]);
                            txtlymphnodes.Text = Convert.ToString(reader["LymphNodes"]);
                            cboxeyes.SelectedItem = Convert.ToString(reader["Eyes"]);
                            txtspine.Text = Convert.ToString(reader["Spine"]);
                            txttongue.Text = Convert.ToString(reader["Tongue"]);
                            txtEnt.Text = Convert.ToString(reader["Ent"]);
                            txtbonesjoints.Text = Convert.ToString(reader["BonesJoints"]);
                            txtSkin.Text = Convert.ToString(reader["Skin"]);
                            txthearingR.Text = Convert.ToString(reader["HearingR"]);
                            txtHearingL.Text = Convert.ToString(reader["HearingL"]);
                            txteyevisionR.Text = Convert.ToString(reader["EyesVisionR"]);
                            txteyevisionL.Text = Convert.ToString(reader["EyesVisionL"]);
                           cboxcolourvision.SelectedItem = Convert.ToString(reader["ColourVision"]);
                            btnupdateGeneralExam.Visible = true;
                            btnsave1.Visible = false;
                        }
                        else
                        {
                            btnupdateGeneralExam.Visible = false;
                            btnsave1.Visible = true;

                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            { lblErrorMsg.Text = ex.Message; }
        }

        public void GetForUpdateSystematicExambypatientId(int PatientId)
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetSystemExaminationPatientMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(Patientinfo.PatientId));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            SID = Convert.ToInt32(reader["Id"]);
                            txtheartSound.Text = Convert.ToString(reader["Cardio_HeartSound"]);
                            txtmurmur.Text = Convert.ToString(reader["Cardio_Murmur"]);
                            txtrespiration.Text = Convert.ToString(reader["Respir_ChestMovements"]);
                            txttrachea.Text = Convert.ToString(reader["Respir_Trachea"]);
                            txtbreathSounds.Text = Convert.ToString(reader["Respir_BreathSounds"]);
                            txtAdventitoussounds.Text = Convert.ToString(reader["Respir_AdventitiousSounds"]);
                            txtLiver.Text = Convert.ToString(reader["Gastrointestional_Liver"]);
                            txtSpleen.Text = Convert.ToString(reader["Gastrointestional_Spleen"]);
                            txthigherfunction.Text = Convert.ToString(reader["CentralNervous_HigherFunction"]);
                            txtsensorysystem.Text = Convert.ToString(reader["CentralNervous_SensorySystem"]);
                            txtmotorsystem.Text = Convert.ToString(reader["CentralNervous_MotorSystem"]);
                            txtgenitourinarysystem.Text = Convert.ToString(reader["GenitoUrinarySystem"]);
                            btnSave2.Visible = false;
                            btnUpdateSystemExam.Visible = true;
                            //  btnupdateInvestexam.Visible = true;

                        }
                        else
                        {
                            btnSave2.Visible = true;
                            btnUpdateSystemExam.Visible = false;
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            { lblErrorMsg.Text = ex.Message; }
        }
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
        void todisplay()
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
                            label3.Text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                            str = Convert.ToString(reader["FirstName"] + "_" + reader["LastName"]);



                            GetForUpdateGeneralExambypatientId(Id);
                            // GetForUpdateInvastegationExambypatientId(Id);

                            GetForUpdateSystematicExambypatientId(Id);
                            panel1.Visible = true;
                            panel2.Visible = true;
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
        private void btnsave1_Click(object sender, EventArgs e)
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_InsertGeneralExaminationPatientMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Patientinfo.PatientId);
                    cmd.Parameters.AddWithValue("@RegNo", Regno);
                    cmd.Parameters.AddWithValue("@Height", txtheight.Text);
                    cmd.Parameters.AddWithValue("@weight", txtweight.Text);
                    cmd.Parameters.AddWithValue("@Pluse", txtpluse.Text);
                    cmd.Parameters.AddWithValue("@BP", txtbp.Text);
                    cmd.Parameters.AddWithValue("@TempInF", txttemp.Text);
                    cmd.Parameters.AddWithValue("@Respiration", txtrespiration.Text);
                    cmd.Parameters.AddWithValue("@Built", txtbuilt.Text);
                    cmd.Parameters.AddWithValue("@Nutrition", txtnutrition.Text);
                    cmd.Parameters.AddWithValue("@Nails", txtnails.Text);
                    cmd.Parameters.AddWithValue("@Teeth", txtteeth.Text);
                    cmd.Parameters.AddWithValue("@Gums", txtgums.Text);
                    cmd.Parameters.AddWithValue("@OralHygene", txtoralhygene.Text);
                    cmd.Parameters.AddWithValue("@LymphNodes", txtlymphnodes.Text);
                    cmd.Parameters.AddWithValue("@Eyes", cboxeyes.SelectedItem);
                    cmd.Parameters.AddWithValue("@Spine", txtspine.Text);
                    cmd.Parameters.AddWithValue("@Tongue", txttongue.Text);
                    cmd.Parameters.AddWithValue("@Ent", txtEnt.Text);
                    cmd.Parameters.AddWithValue("@BonesJoints", txtbonesjoints.Text);
                    cmd.Parameters.AddWithValue("@Skin", txtSkin.Text);
                    cmd.Parameters.AddWithValue("@HearingR", txthearingR.Text);
                    cmd.Parameters.AddWithValue("@HearingL", txtHearingL.Text);
                    cmd.Parameters.AddWithValue("@EyesVisionR", txteyevisionR.Text);
                    cmd.Parameters.AddWithValue("@EyesVisionL", txteyevisionL.Text);
                    cmd.Parameters.AddWithValue("@ColourVision", cboxcolourvision.SelectedItem);
                    con.Open();
                    GId = Convert.ToInt32(cmd.ExecuteNonQuery());
                    con.Close();
                    if (GId == 0)
                    {

                        lblErrorMsg.Text = "Already Exists General Examination Patient";
                    }
                    else
                    {
                        lblErrorMsg.Text = "Saved General Examination Patient Successfully";

                    }



                    //lblErrorMsg.Text=" Save General information Successfully";
                    btnsave1.Visible = false;
                    btnupdateGeneralExam.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        //Save2
        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {

                    cmd = new SqlCommand("usp_InsertSystemExaminationPatientMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Patientinfo.PatientId);

                    cmd.Parameters.AddWithValue("@RegNo", Regno);
                    cmd.Parameters.AddWithValue("@Cardio_HeartSound", txtheartSound.Text);
                    cmd.Parameters.AddWithValue("@Cardio_Murmur", txtmurmur.Text);
                    cmd.Parameters.AddWithValue("@Respir_ChestMovements", txtrespiration.Text);
                    cmd.Parameters.AddWithValue("@Respir_Trachea", txttrachea.Text);
                    cmd.Parameters.AddWithValue("@Respir_BreathSounds", txtbreathSounds.Text);
                    cmd.Parameters.AddWithValue("@Respir_AdventitiousSounds", txtAdventitoussounds.Text);
                    cmd.Parameters.AddWithValue("@Gastrointestional_Liver", txtLiver.Text);
                    cmd.Parameters.AddWithValue("@Gastrointestional_Spleen", txtSpleen.Text);
                    cmd.Parameters.AddWithValue("@CentralNervous_HigherFunction", txthigherfunction.Text);
                    cmd.Parameters.AddWithValue("@CentralNervous_SensorySystem", txtsensorysystem.Text);
                    cmd.Parameters.AddWithValue("@CentralNervous_MotorSystem", txtmotorsystem.Text);
                    cmd.Parameters.AddWithValue("@GenitoUrinarySystem", txtgenitourinarysystem.Text);
                    con.Open();
                    SID = Convert.ToInt32(cmd.ExecuteNonQuery());
                    con.Close();

                    if (SID == 0)
                    {

                        lblErrorMsg.Text = "Already Exists Systemetic Examination Patient";
                    }
                    else
                    {
                        lblErrorMsg.Text = "Saved Systemetic Examination Patient Successfully";

                    }

                    btnSave2.Visible = false;
                    btnUpdateSystemExam.Visible = true;
                    button2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }

        private void btnUpdateSystemExam_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {

                    cmd = new SqlCommand("usp_UpdateSystemExaminationPatientMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SID);
                    cmd.Parameters.AddWithValue("@PatientId",Patientinfo.PatientId);
                    cmd.Parameters.AddWithValue("@RegNo", Regno);
                    cmd.Parameters.AddWithValue("@Cardio_HeartSound", txtheartSound.Text);
                    cmd.Parameters.AddWithValue("@Cardio_Murmur", txtmurmur.Text);
                    cmd.Parameters.AddWithValue("@Respir_ChestMovements", txtrespiration.Text);
                    cmd.Parameters.AddWithValue("@Respir_Trachea", txttrachea.Text);
                    cmd.Parameters.AddWithValue("@Respir_BreathSounds", txtbreathSounds.Text);
                    cmd.Parameters.AddWithValue("@Respir_AdventitiousSounds", txtAdventitoussounds.Text);
                    cmd.Parameters.AddWithValue("@Gastrointestional_Liver", txtLiver.Text);
                    cmd.Parameters.AddWithValue("@Gastrointestional_Spleen", txtSpleen.Text);
                    cmd.Parameters.AddWithValue("@CentralNervous_HigherFunction", txthigherfunction.Text);
                    cmd.Parameters.AddWithValue("@CentralNervous_SensorySystem", txtsensorysystem.Text);
                    cmd.Parameters.AddWithValue("@CentralNervous_MotorSystem", txtmotorsystem.Text);
                    cmd.Parameters.AddWithValue("@GenitoUrinarySystem", txtgenitourinarysystem.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    lblErrorMsg.Text = " Updated Systemic information Successfully";
                    btnSave2.Visible = false;
                    // btnUpdateSystemExam.Visible = true;

                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            this.Dispose();
            InvestForm frm = new InvestForm();
            frm.ShowDialog();
        }

        private void btnupdateGeneralExam_Click(object sender, EventArgs e)
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_UpdateGeneralExaminationPatientMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", GId);
                    cmd.Parameters.AddWithValue("@PatientId", Patientinfo.PatientId);
                    cmd.Parameters.AddWithValue("@RegNo", Regno);
                    cmd.Parameters.AddWithValue("@Height", txtheight.Text);
                    cmd.Parameters.AddWithValue("@weight", txtweight.Text);
                    cmd.Parameters.AddWithValue("@Pluse", txtpluse.Text);
                    cmd.Parameters.AddWithValue("@BP", txtbp.Text);
                    cmd.Parameters.AddWithValue("@TempInF", txttemp.Text);
                    cmd.Parameters.AddWithValue("@Respiration", txtrespiration.Text);
                    cmd.Parameters.AddWithValue("@Built", txtbuilt.Text);
                    cmd.Parameters.AddWithValue("@Nutrition", txtnutrition.Text);
                    cmd.Parameters.AddWithValue("@Nails", txtnails.Text);
                    cmd.Parameters.AddWithValue("@Teeth", txtteeth.Text);
                    cmd.Parameters.AddWithValue("@Gums", txtgums.Text);
                    cmd.Parameters.AddWithValue("@OralHygene", txtoralhygene.Text);
                    cmd.Parameters.AddWithValue("@LymphNodes", txtlymphnodes.Text);
                    cmd.Parameters.AddWithValue("@Eyes", cboxeyes.SelectedItem);
                    cmd.Parameters.AddWithValue("@Spine", txtspine.Text);
                    cmd.Parameters.AddWithValue("@Tongue", txttongue.Text);
                    cmd.Parameters.AddWithValue("@Ent", txtEnt.Text);
                    cmd.Parameters.AddWithValue("@BonesJoints", txtbonesjoints.Text);
                    cmd.Parameters.AddWithValue("@Skin", txtSkin.Text);
                    cmd.Parameters.AddWithValue("@HearingR", txthearingR.Text);
                    cmd.Parameters.AddWithValue("@HearingL", txtHearingL.Text);
                    cmd.Parameters.AddWithValue("@EyesVisionR", txteyevisionR.Text);
                    cmd.Parameters.AddWithValue("@EyesVisionL", txteyevisionL.Text);
                    cmd.Parameters.AddWithValue("@ColourVision", cboxcolourvision.SelectedItem);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    lblErrorMsg.Text = " Updated General information Successfully";
                    btnsave1.Visible = false;
                    button2.Visible = true;

                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
    }
}
