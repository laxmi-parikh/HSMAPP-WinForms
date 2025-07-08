using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HSMAPP
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            txtmobileno.KeyPress += new KeyPressEventHandler(txtmobileno_KeyPress);
            lblimagepath.Visible = false;
            if (LogIn.Loginfo.UserID > 0)
            {
                             Getdoctor();
                Getcompany();
                Getcompany1();
                noexofyrs();
                //comboBox1.Items.Add("Select");
                //comboBox2.Items.Add("Select");
                data2();
                data1();
                btnupdatecompany.Visible = false;
                btnaddcompany.Visible = true;
                button1.Visible = false;
                button3.Visible = true;
                button5.Visible = false;
                grpbxAddPat.Visible=true;
            }

        }


        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        string reg;
        int Id1 = 0;//, Id2=0,Id3=0;
        public static class Patientinfo
        {
            public static int PatientId;
            public static string Regno;
            public static int compId;
        }
        public void Getdoctor()
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();


                    using (cmd = new SqlCommand("Select Id,Name from UserMst where RoleId = 2", con))
                    {
                        using (adapt = new SqlDataAdapter(cmd))
                        {
                            adapt.Fill(datatable);
                            cmboxdoctor.DataSource = datatable;
                            cmboxdoctor.ValueMember = "Id";
                            cmboxdoctor.DisplayMember = "Name";
                        }
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        public void Getcompany()
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
                            cmbxCompany.DataSource = datatable;
                            cmbxCompany.ValueMember = "Id";

                            cmbxCompany.DisplayMember = "CompanyName";
                        }
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        public void Getcompany1()
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
                            comboBox2.DataSource = datatable;
                            comboBox2.ValueMember = "Id";

                            comboBox2.DisplayMember = "CompanyName";
                        }
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        private void Home_Load(object sender, EventArgs e)
        {


        }
       // string datestring, dateofbirth;
        private void button3_Click(object sender, EventArgs e)
        {    // Add data to db page1
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    if (txtfirstName.Text != string.Empty)
                    {

                        cmd = new SqlCommand("usp_InsertPatientMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", LogIn.Loginfo.UserID);
                        cmd.Parameters.AddWithValue("@DoctorId", cmboxdoctor.SelectedValue);
                        cmd.Parameters.AddWithValue("@CompanyId", cmbxCompany.SelectedValue);
                        Patientinfo.compId = Convert.ToInt32(cmbxCompany.SelectedValue);
                      //  datestring= dtpkInsertedondate.Value.ToString("MM/dd/yyyy");
                        cmd.Parameters.AddWithValue("@DateOn", dtpkInsertedondate.Value) ;
                       
                        cmd.Parameters.AddWithValue("@FirstName", txtfirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtlastName.Text);
                     //  dateofbirth = dpkDOB.Value.ToString("MM/dd/yyyy");

                        cmd.Parameters.AddWithValue("@DOB", dpkDOB.Value);
                       
                        cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                        if (rdMale.Checked == true && rdfemale.Checked == false)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Male");
                            txtMenstrual.Text = "NA";
                            txtOtherCompliant.Text = "NA";
                            txtpresentjobdesc.Text = "NA";
                            cmd.Parameters.AddWithValue("@Title", "Mr.");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Female");
                            cmd.Parameters.AddWithValue("@Title", "Ms.");
                        }
                        if (rdMarried.Checked == true && rdunmarried.Checked == false)
                        {
                            cmd.Parameters.AddWithValue("@Mariatal_Status", "Married");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Mariatal_Status", "UnMarried");
                        }

                        cmd.Parameters.AddWithValue("@Photo", lblimagepath.Text);
                        cmd.Parameters.AddWithValue("@IDMark", txtIDMark.Text);
                        cmd.Parameters.AddWithValue("@Diet", txtDiet.Text);
                        cmd.Parameters.AddWithValue("@MobileNumber", txtmobileno.Text);
                        cmd.Parameters.AddWithValue("@Address", txtPermantAddress.Text);
                        cmd.Parameters.AddWithValue("@PersonalHabbits", txtPersonalHabits.Text);

                        cmd.Parameters.AddWithValue("@DominantHand", txtDomianthand.Text);
                        cmd.Parameters.AddWithValue("@Immunisation", txtImmunisation.Text);
                        cmd.Parameters.AddWithValue("@FamilyHistory", txtFamilyHistory.Text);
                        cmd.Parameters.AddWithValue("@PersonalHistory", txtPersonalHistory.Text);
                        cmd.Parameters.AddWithValue("@PastHistory", txtpastHistory.Text);
                        
                            cmd.Parameters.AddWithValue("@smokehabbit", "No");
                           cmd.Parameters.AddWithValue("@smokehabbityear","");
                        cmd.Parameters.AddWithValue("@smokehabbitday","");
                        cmd.Parameters.AddWithValue("@MenstrualCycle", txtMenstrual.Text);
                        cmd.Parameters.AddWithValue("@OtherComplaints", txtOtherCompliant.Text);
                        cmd.Parameters.AddWithValue("@PresentJobDesc", txtpresentjobdesc.Text);
                        con.Open();
                        Patientinfo.PatientId = Convert.ToInt32(cmd.ExecuteNonQuery());
                        con.Close();
                        if (Patientinfo.PatientId == 0)
                        {
                            lblErrorMsg.Text = "Patient Already Exists ";
                        }
                        patientfolder();
                        data();

                        GetPatRegno();


                        button1.Visible = true;

                        lblErrorMsg.Text = "Details Inserted Successfully";
                        this.Refresh();
                        txtfirstName.Clear();
                        txtlastName.Clear();
                        txtPermantAddress.Clear();
                        txtAge.Text = "0";
                    }
                    else
                    {
                        lblErrorMsg.Text = "Please enter mandatory details!";
                    }


                }
                
               

                this.Refresh();

            }

            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }

        void noexofyrs()
        {
            for (int i = 0; i < 20; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedIndex = 0;
         }
        void patientfolder()
        {
            //patient Name folder created
           // string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var PatId = Convert.ToString(txtfirstName.Text + "_" + txtlastName.Text);
            var path = Convert.ToString(@"..\..\Imgs\" + PatId);
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }
        void data()
        {
            // DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {

                    // int Id;
                    string query = "select Top 1 Id from PatientMst order by Id DESC";
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            Patientinfo.PatientId = Convert.ToInt32(reader["Id"]);
                        }
                        else
                        {
                            //string query1 = "select Top 1 Id,RegNo from PatientMst order by Id DESC";
                            cmd = new SqlCommand(query, con);
                            using (var reader1 = cmd.ExecuteReader())
                            {
                                if (reader1.Read())
                                {
                                    Patientinfo.PatientId = Convert.ToInt32(reader1["Id"]);
                                    Patientinfo.Regno = Convert.ToString(reader1["RegNo"]);
                                }
                                else
                                {

                                    Patientinfo.PatientId = 1;
                                }
                            }

                        }


                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMale.Checked == true)
            { panel1.Visible = false; }
            else
            { panel1.Visible = true; }
        }

        private void rdfemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdfemale.Checked == false)
            { panel1.Visible = false; }
            else
            { panel1.Visible = true; }
        }

        private void rbtnsmokeyes_CheckedChanged(object sender, EventArgs e)
        {
          

        }

        private void rbtnsmokeno_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnuploadphoto_Click(object sender, EventArgs e)
        {
                patientfolder();
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files(*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog1.FileName;
                    //lblimagepath.Text = selectedFilePath;
                    pictureBox1.Image = new System.Drawing.Bitmap(selectedFilePath);
                    string targetFolder = Application.StartupPath;
                    var PatId = Convert.ToString(txtfirstName.Text + "_" + txtlastName.Text);

                    var path = Convert.ToString(@"..\..\Imgs\"+ PatId +"\\" + PatId + "_Photo.jpg");

                    lblimagepath.Text = path.ToString();
                    try
                    {
                        pictureBox1.Image.Save(@path);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    //string targetFileName = Path.Combine(targetFolder, path);
                    //Image.Save(path);


                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        int pId;
            public void GetPatRegno()
            {

            if (comboBox2.SelectedValue != null)
            {
                pId = Convert.ToInt32(comboBox2.SelectedValue);
               
            }else

            {
                pId = 1;

            }
                var datatable = new DataTable();
                try
                {
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        con.Open();

                        using (cmd = new SqlCommand("usp_GetPatientbyCompanyId", con))
                            cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(pId));
                        {
                            using (adapt = new SqlDataAdapter(cmd))
                            {
                                adapt.Fill(datatable);

                                comboBox4.ValueMember = "Id";
                                comboBox4.DisplayMember = "PatientName";
                                comboBox4.DataSource = datatable;
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
        

            private void txtfirstName_Validating(object sender, CancelEventArgs e)
        {
            if (txtfirstName.Text == string.Empty)
            {
                lblErrorMsg.Text = "Invalid First Name";
            }
        }

        private void dpkDOB_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtlastName_Validating(object sender, CancelEventArgs e)
        {
            if (txtlastName.Text == string.Empty)
            {
                lblErrorMsg.Text = "Invalid Last Name";
            }
        }

        private void txtmobileno_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtmobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == ' ') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void lblErrorMsg_Click(object sender, EventArgs e)
        {

        }
      
        //Edit button to display or update value
        private void button2_Click(object sender, EventArgs e)
        {
            btnupdatecompany.Visible = true;
            btnaddcompany.Visible = false;
            button3.Visible = false;
            button5.Visible = true;
            //var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetPatientMstbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(comboBox4.SelectedValue));
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {

                            txtpresentjobdesc.Text = Convert.ToString(reader["PresentJobDesc"]);
                            txtOtherCompliant.Text = Convert.ToString(reader["OtherComplaints"]);

                            txtMenstrual.Text = Convert.ToString(reader["MenstrualCycle"]);
                           // txtcigday.Text = Convert.ToString(reader["smokehabbitday"]);

                            //txtsmokeyear.Text = Convert.ToString(reader["smokehabbityear"]);
                            //if (Convert.ToString(reader["smokehabbit"]) == "yes")
                            //{
                            //    rbtnsmokeyes.Checked = true;

                            //}
                            //else { rbtnsmokeno.Checked = true; }

                            if (Convert.ToString(reader["Gender"]) == "Female")
                            {
                                rdfemale.Checked = true;

                            }
                            else { rdMale.Checked = true; }

                            if (Convert.ToString(reader["Mariatal_Status"]) == "Married")
                            { rdMarried.Checked = true; }
                            else { rdunmarried.Checked = true; }
                            txtpastHistory.Text = Convert.ToString(reader["PastHistory"]);
                            txtPersonalHistory.Text = Convert.ToString(reader["PersonalHistory"]);
                            txtFamilyHistory.Text = Convert.ToString(reader["FamilyHistory"]);
                            txtImmunisation.Text = Convert.ToString(reader["Immunisation"]);
                            txtDomianthand.Text = Convert.ToString(reader["DominantHand"]);
                            txtPersonalHabits.Text = Convert.ToString(reader["PersonalHabbits"]);
                            txtPermantAddress.Text = Convert.ToString(reader["Address"]);
                            txtmobileno.Text = Convert.ToString(reader["MobileNumber"]);
                            txtDiet.Text = Convert.ToString(reader["Diet"]);
                            txtIDMark.Text = Convert.ToString(reader["IDMark"]);
                            lblimagepath.Text = Convert.ToString(reader["Photo"]);
                            if (lblimagepath.Text != null)
                            {
                                pictureBox1.ImageLocation = lblimagepath.Text.ToString();

                            }
                            dpkDOB.Value = Convert.ToDateTime(reader["DOB"]);
                            txtlastName.Text = Convert.ToString(reader["LastName"]);
                            txtfirstName.Text = Convert.ToString(reader["FirstName"]);
                            dtpkInsertedondate.Value = Convert.ToDateTime(reader["DateOn"]);
                            reg = Convert.ToString(reader["RegNo"]);
                            data2(); //();
                        }
                        con.Close();
                    }

                    
                }

                
            }
            catch (Exception ex)
            { lblErrorMsg.Text = ex.Message; }
        }
        //update button
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    if (txtfirstName.Text != string.Empty)
                    {

                        cmd = new SqlCommand("usp_UpdatePatientMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(comboBox4.SelectedValue));
                        cmd.Parameters.AddWithValue("@UserId", LogIn.Loginfo.UserID);
                        cmd.Parameters.AddWithValue("@DoctorId", cmboxdoctor.SelectedValue);
                        cmd.Parameters.AddWithValue("@CompanyId", cmbxCompany.SelectedValue);
                        cmd.Parameters.AddWithValue("@RegNo", Convert.ToString(reg));
                        cmd.Parameters.AddWithValue("@DateOn", dtpkInsertedondate.Value.Date);
                        cmd.Parameters.AddWithValue("@FirstName", txtfirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtlastName.Text);
                        cmd.Parameters.AddWithValue("@DOB", dpkDOB.Value.Date);
                        
                        cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                        if (rdMale.Checked == true && rdfemale.Checked == false)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Male");
                            txtMenstrual.Text = "NA";
                            txtOtherCompliant.Text = "NA";
                            txtpresentjobdesc.Text = "NA";
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Female");
                        }
                        if (rdMarried.Checked == true && rdunmarried.Checked == false)
                        {
                            cmd.Parameters.AddWithValue("@Mariatal_Status", "Married");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Mariatal_Status", "Single");
                        }

                        cmd.Parameters.AddWithValue("@Photo", lblimagepath.Text);
                        cmd.Parameters.AddWithValue("@IDMark", txtIDMark.Text);
                        cmd.Parameters.AddWithValue("@Diet", txtDiet.Text);
                        cmd.Parameters.AddWithValue("@MobileNumber", txtmobileno.Text);
                        cmd.Parameters.AddWithValue("@Address", txtPermantAddress.Text);
                        cmd.Parameters.AddWithValue("@PersonalHabbits", txtPersonalHabits.Text);

                        cmd.Parameters.AddWithValue("@DominantHand", txtDomianthand.Text);
                        cmd.Parameters.AddWithValue("@Immunisation", txtImmunisation.Text);
                        cmd.Parameters.AddWithValue("@FamilyHistory", txtFamilyHistory.Text);
                        cmd.Parameters.AddWithValue("@PersonalHistory", txtPersonalHistory.Text);
                        cmd.Parameters.AddWithValue("@PastHistory", txtpastHistory.Text);
                            cmd.Parameters.AddWithValue("@smokehabbit", "No");
                        
                        cmd.Parameters.AddWithValue("@smokehabbityear", "");
                        cmd.Parameters.AddWithValue("@smokehabbitday","");
                        cmd.Parameters.AddWithValue("@MenstrualCycle", txtMenstrual.Text);
                        cmd.Parameters.AddWithValue("@OtherComplaints", txtOtherCompliant.Text);
                        cmd.Parameters.AddWithValue("@PresentJobDesc", txtpresentjobdesc.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        data();
                        txtDiet.Clear();
                        txtmobileno.Clear();
                        txtPermantAddress.Clear();
                        txtPersonalHabits.Clear();


                        txtfirstName.Clear();
                        txtIDMark.Clear();
                        lblErrorMsg.Text = "Details Updated Successfully";
                    }
                          

                    
                    else
                    {
                        lblErrorMsg.Text = "Please enter mandatory details!";
                    }


                }

            }

            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }

        private void grpbxAddPat_Enter(object sender, EventArgs e)
        {

        }
        // update prevoius company details
        private void btnupdatecompany_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(dbconnectionstring))
            {
                cmd = new SqlCommand("usp_UpdatePatientPreviousCompanyMst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (txtcomp1.Text != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(Id1));
                    cmd.Parameters.AddWithValue("@RegNo", Convert.ToString(reg));
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(comboBox4.SelectedValue));
                    
                        cmd.Parameters.AddWithValue("@NameOfCompany", txtcomp1.Text);
                        cmd.Parameters.AddWithValue("@NoOfyrs", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@NatureOfJob", txtnaturejob1.Text);
                        cmd.Parameters.AddWithValue("@AnyOccupationalHealthAilments", txtcomoccp1.Text);
                    

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtcomp1.Text = "";
                    txtnaturejob1.Text = "Good";
                    comboBox1.SelectedItem = 0;
                    txtcomoccp1.Text="NA";
                    data2();
                }
                Patientinfo.PatientId = Convert.ToInt32(comboBox4.SelectedValue);
                
                lblErrorMsg.Text = "Details Updated Successfully";

            }
        }
        //public void GetCompanyDetails()
        //{
        //    using (con = new SqlConnection(dbconnectionstring))
        //    {
        //        cmd = new SqlCommand("usp_GetPatientPreviousCompanyMstbyPatientId", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(comboBox1.SelectedValue));
        //        con.Open();
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read() != false)
        //            {
        //                Id1 = Convert.ToInt32(reader["Id"]);
        //                txtcomp1.Text = Convert.ToString(reader["NameOfCompany"]);
        //                comboBox1.SelectedItem = Convert.ToString(reader["NoOfyrs"]);
        //                txtnaturejob1.Text = Convert.ToString(reader["NatureOfJob"]);
        //                txtcomoccp1.Text = Convert.ToString(reader["AnyOccupationalHealthAilments"]);


        //            }
        //            con.Close();
        //        }
        //    }
        //}
            public void data2()
        {
            int pPatID;
            if (Patientinfo.PatientId > 0)
            {
                pPatID = Patientinfo.PatientId;
            }
            else
            {
                pPatID = Convert.ToInt32(comboBox4.SelectedValue);
            }
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetPatientPreviousCompanyMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                   cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(pPatID));
                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoGenerateColumns = false;
                    this.dataGridView1.Columns["Id"].Visible = false;
                    this.dataGridView1.Columns["PatientId"].Visible = false;
                    this.dataGridView1.Columns["RegNo"].Visible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Refresh();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }




        }
        void data1()
        {
            //DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            //Editlink.UseColumnTextForLinkValue = true;
            //Editlink.HeaderText = "Edit";
            //Editlink.DataPropertyName = "lnkColumn";
            //Editlink.Name = "edit";
            //Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            //Editlink.Text = "Edit";
            //dataGridView1.Columns.Add(Editlink);

            //Delete link

            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "Delete";

            Deletelink.Name = "Delete";
            Deletelink.DataPropertyName = "DeleteColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            dataGridView1.Columns.Add(Deletelink);
        }
        int rowId;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                rowId = Convert.ToInt32(row.Cells[0].Value);
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                {
                    if (rowId > 0)
                    {
                        using (con = new SqlConnection(dbconnectionstring))
                        {
                            con.Open();
                            DataTable dt = new DataTable();
                            adapt = new SqlDataAdapter("delete from PatientPreviousCompanyMst where Id=" + rowId, con);
                            // DataSet ds = new DataSet();
                            adapt.Fill(dt);
                            con.Close();

                        }
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        dataGridView1.Refresh();

                    }

                }
                //if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
                //{
                //    if (rowId > 0)
                //    {
                //        data2();
                //        dataGridView1.Refresh();
                //    }

                //}
                data2();
            }

        }
        // add previous company details
        private void btnaddcompany_Click(object sender, EventArgs e)
        {
            if (Patientinfo.PatientId > 0)
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_InsertPatientPreviousCompanyMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Patientinfo.PatientId);
                    if (txtcomp1.Text != string.Empty)
                    {

                        cmd.Parameters.AddWithValue("@NameOfCompany", txtcomp1.Text);
                        cmd.Parameters.AddWithValue("@NoOfyrs", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@NatureOfJob", txtnaturejob1.Text);
                        cmd.Parameters.AddWithValue("@AnyOccupationalHealthAilments", txtcomoccp1.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        lblErrorMsg.Text = "Details Inserted Successfully";
                        data2();
                    }

                    else
                    {
                        lblErrorMsg.Text = "Please enter mandatory details!";
                    }
                }
            }
            txtcomp1.Text = "";
            txtnaturejob1.Text = "Good";
            comboBox1.SelectedItem = 0;
            txtcomoccp1.Text = "NA";
           
            }
       
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            { GetPatRegno(); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         generalform addpat=new generalform();
            addpat.Show();

        }

        private void dpkDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

