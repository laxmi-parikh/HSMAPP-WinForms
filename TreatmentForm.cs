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
using static HSMAPP.MainForm;

namespace HSMAPP
{
    public partial class TreatmentForm: Form
    {
       // private Panel mainContentPanel;
        public TreatmentForm()
        {
            InitializeComponent();
            Getdoctor();
            getCompany();
            getmonthyear();
            panel2.Visible = false;
            panel7.Visible = false;
        }
        int treatId=0;
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];

        private void TreatmentForm_Load(object sender, EventArgs e)
        {

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
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxcustomer.SelectedValue));
                    cmd.Parameters.AddWithValue("@Month", Convert.ToInt32(cboxbillmonth.SelectedItem));
                    cmd.Parameters.AddWithValue("@year", Convert.ToInt32(cboxbillyear.SelectedItem));
                    {
                        using (adapt = new SqlDataAdapter(cmd))
                        {
                            adapt.Fill(datatable);

                            comboBox1.ValueMember = "BillNo";
                            comboBox1.DisplayMember = "BillNo";
                            comboBox1.DataSource = datatable;
                        }
                    }
                    con.Close();
                }
                // txtbillno.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }
        }
        public void getmonthyear()
        {
            for (int i = 1; i <= 12; i++)
            {
                cboxbillmonth.Items.Add(i);
            }
            for (int j = 2020; j <= DateTime.Now.Year; j++)
            {
                cboxbillyear.Items.Add(j);
            }

        }
        public void data1()
        {

            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetTreatmentbyTraementId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BillNo", comboBox1.SelectedValue);

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                    this.dataGridView2.Columns["Id"].Visible = false;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
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
                    cboxcustomer.ValueMember = "Id";
                    cboxcustomer.DisplayMember = "CompanyName";
                    cboxcustomer.DataSource = dataTable;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        // int rowId;
        public void Getdoctor()
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

                            cboxdoctor.ValueMember = "Id";
                            cboxdoctor.DisplayMember = "Name";
                            cboxdoctor.DataSource = datatable;
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //fillup billno
            if (cboxcustomer.SelectedValue != null)
            {
                panel7.Visible = true;
                GetBillNo();   
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //saveif(

            if (comboBox1.SelectedValue != null)
            {
                data1();
                panel2.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // //treatment detail
            using (con = new SqlConnection(dbconnectionstring))
            {

                cmd = new SqlCommand("usp_InsertTreatmentDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TreatmentId", treatId);
                cmd.Parameters.AddWithValue("@SrNo", txtsrno1.Text);
                cmd.Parameters.AddWithValue("@BillNo", comboBox1.SelectedValue);

                cmd.Parameters.AddWithValue("@CandidateName", txtname1.Text);
                cmd.Parameters.AddWithValue("@Date", dpicker1.Value);
                cmd.Parameters.AddWithValue("@Description", txtdescription1.Text);
                cmd.Parameters.AddWithValue("@Amount", txtamt1.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", txttotalamt.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblerrormsg.Text = "Details Inserted Successfully";

                data1();

            }
            txtsrno1.Clear();
            txtname1.Clear();
            txtdescription1.Clear();
            txtamt1.Text = "0";
            txttotalamt.Text = "0";

        }
        int rowId;
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                rowId = Convert.ToInt32(row.Cells["Id"].Value);
                if (rowId > 0)
                {
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        con.Open();
                        DataTable dt = new DataTable();
                        adapt = new SqlDataAdapter("delete from TreatmentDetail where Id=" + rowId, con);
                        // DataSet ds = new DataSet();
                        adapt.Fill(dt);
                        con.Close();

                    }
                }

                dataGridView2.Rows.Remove(row);
                dataGridView2.Refresh();


            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        // int treatId = 0;
    }
}
    

