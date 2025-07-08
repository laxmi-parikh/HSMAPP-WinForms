using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using static HSMAPP.LogIn;
namespace HSMAPP
{
    public partial class ViewPatient : Form
    {
        public ViewPatient()
        {
            InitializeComponent();
            if (Loginfo.UserID > 0)
            {
               
                getCompany();
                panel2.Visible = false;
                panel3.Visible = false;


            }
        }
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        
        int id;
        //int rowId;
        public static class imagval
        {
            public static int rowId;
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
                    cboxcompany.ValueMember = "Id";
                    cboxcompany.DisplayMember = "CompanyName";
                    cboxcompany.DataSource = dataTable;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        public void data()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetAllPatientbyCompanyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxcompany.SelectedValue));

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoGenerateColumns = false;
                    this.dataGridView1.Columns["Id"].Visible = false;
                    this.dataGridView1.Columns["DoctorId"].Visible = false;
                    this.dataGridView1.Columns["CompanyId"].Visible = false;
                    this.dataGridView1.Columns["UserId"].Visible = false;
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
        public void dataPreviousJobs()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetAllPatientPreviouscompanymstbycomapyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxcompany.SelectedValue));

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView3.DataSource = dataTable;
                    dataGridView3.AutoGenerateColumns = false;
                    this.dataGridView3.Columns["PatientId"].Visible = false;
                    this.dataGridView3.Columns["Id"].Visible = false;
                    dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView3.Refresh();
                    con.Close();
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }
        public void dataGeneralinformation()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetAllGeneralExaminationPatientMstbycomapyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxcompany.SelectedValue));

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                    dataGridView2.AutoGenerateColumns = false;

                    this.dataGridView2.Columns["PatientId"].Visible = false;
                    this.dataGridView2.Columns["Id"].Visible = false;
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView2.Refresh();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }

        public void dataSystematicinformation()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetAllSystemExaminationPatientMstbycompanyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxcompany.SelectedValue));

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView4.DataSource = dataTable;
                    dataGridView4.AutoGenerateColumns = false;

                    this.dataGridView4.Columns["PatientId"].Visible = false;
                    this.dataGridView4.Columns["Id"].Visible = false;
                    dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView4.Refresh();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }

        public void dataInvestigationinformation()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetAllInvestigationRemarkPatientMstbycompanyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxcompany.SelectedValue));

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView5.DataSource = dataTable;
                    dataGridView5.AutoGenerateColumns = false;

                    this.dataGridView5.Columns["PatientId"].Visible = false;
                    this.dataGridView5.Columns["Id"].Visible = false;
                    dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView5.Refresh();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }


        public void data1()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetPatientMstbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(id));

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoGenerateColumns = false;
                    this.dataGridView1.Columns["Id"].Visible = false;
                    this.dataGridView1.Columns["DoctorId"].Visible = false;
                    this.dataGridView1.Columns["CompanyId"].Visible = false;
                    this.dataGridView1.Columns["UserId"].Visible = false;
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
        public void dataPreviousJobs1()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetPatientPreviousCompanyMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(id));

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    this.dataGridView3.Columns["Id"].Visible = false;
                    dataGridView3.DataSource = dataTable;
                    dataGridView3.AutoGenerateColumns = false;
                    this.dataGridView3.Columns["PatientId"].Visible = false;
                    //this.dataGridView2.Columns["UserId"].Visible = false;
                    dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView3.Refresh();
                    con.Close();
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }
        public void dataGeneralinformation1()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetGeneralExaminationPatientMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(id));

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                    dataGridView2.AutoGenerateColumns = false;
                    // this.dataGridView2.Columns["DoctorId"].Visible = false;
                    this.dataGridView2.Columns["PatientId"].Visible = false;
                    this.dataGridView2.Columns["Id"].Visible = false;
                    //this.dataGridView2.Columns["UserId"].Visible = false;
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView2.Refresh();
                    con.Close();
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }

        public void dataSystematicinformation1()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetSystemExaminationPatientMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(id));
                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView4.DataSource = dataTable;
                    dataGridView4.AutoGenerateColumns = false;
                    // this.dataGridView2.Columns["DoctorId"].Visible = false;
                    this.dataGridView4.Columns["PatientId"].Visible = false;
                    this.dataGridView4.Columns["Id"].Visible = false;
                    //this.dataGridView2.Columns["UserId"].Visible = false;
                    dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView4.Refresh();
                    con.Close();
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }

        public void dataInvestigationinformation1()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetInvestigationRemarkPatientMstbyPatientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(id));

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView5.DataSource = dataTable;
                    dataGridView5.AutoGenerateColumns = false;
                    // this.dataGridView2.Columns["DoctorId"].Visible = false;
                    this.dataGridView5.Columns["PatientId"].Visible = false;
                    this.dataGridView5.Columns["Id"].Visible = false;
                    //this.dataGridView2.Columns["UserId"].Visible = false;
                    dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView5.Refresh();
                    con.Close();
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }

        private void ViewPatient_Load(object sender, EventArgs e)
        {
            // lbluserName.Text = "Hello" + Loginfo.UserName;
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
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxcompany.SelectedValue));
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


        private void btnpatviewsearch_Click(object sender, EventArgs e)
        {
            id = 0;
            id = Convert.ToInt32(comboBox1.SelectedValue);
            if (id > 0)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                imagval.rowId = Convert.ToInt32(id);
                data1();
                dataGeneralinformation1();
                dataInvestigationinformation1();
                dataSystematicinformation1();
                dataPreviousJobs1();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btndelete_Click(object sender, EventArgs e)
        { // 
            id = Convert.ToInt32(comboBox1.SelectedValue);

            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    if (id > 0)
                    {
                        cmd = new SqlCommand("usp_deletePatientbyId", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PatientId", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        lblErrorMsg.Text = "Deleted Successfully";

                    }

                }
               // GetPatRegno();
            }

            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        private void btnformprint1_Click(object sender, EventArgs e)
        {
            // Printform1 Form1print
            Form1print frm2 = new Form1print();
           // Printform1 frm2= new Printform1();
            frm2.Show();

        }

        private void btnform2print_Click(object sender, EventArgs e)
        {
            // imagval.rowId = Convert.ToInt32(comboBox1.SelectedValue);

            FormprintReport frmprint = new FormprintReport();

            frmprint.Show(); 
        }
       
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form2 f = new Form2();
            f.ShowDialog();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cboxcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxcompany.SelectedValue != null)
            {
                GetPatRegno();
                data();
                dataPreviousJobs();
                dataGeneralinformation();
                dataSystematicinformation();
                dataInvestigationinformation();

            }
            else { lblErrorMsg.Text = "Select Company Name"; }
        }

        private void ViewPatient_Load_1(object sender, EventArgs e)
        {

        }
    }
}