using iText.Commons.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HSMAPP.LogIn;
using static HSMAPP.MainForm;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace HSMAPP
{
    public partial class TreatmentDetail : Form
    {
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];


        public TreatmentDetail()
        {
            InitializeComponent();
            Getdoctor();
            getCompany();
            getmonthyear();
            panel2.Visible = false;

        }

        static int treatId;
        public void GetTreatmentDetails()
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetTreatmentDetailbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", rowId);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            txtamt.Text = Convert.ToString(reader["Amount"]);
                            txtcandidatename.Text = Convert.ToString(reader["CandidateName"]);
                            txtdesc.Text = Convert.ToString(reader["Description"]);
                            txttotalamount.Text = Convert.ToString(reader["TotalAmount"]);
                            txtsrno.Text = Convert.ToString(reader["SrNo"]);
                            dpvistdate.Text = Convert.ToDateTime(reader["Date"]).ToShortDateString();



                        }
                        con.Close();
                    }

                }
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
        private void button1_Click(object sender, EventArgs e)
        {
            // insert in treatmentmst

            try
            {
                if (txtbillno.Text != string.Empty && cboxbillmonth.SelectedItem != null && cboxbillyear.SelectedItem != null)
                {
                    using (con = new SqlConnection(dbconnectionstring))
                    {

                        cmd = new SqlCommand("usp_InsertTreatmentMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);
                        cmd.Parameters.AddWithValue("@BillDate", dpbilldate.Value);
                        cmd.Parameters.AddWithValue("@BillMonth", cboxbillmonth.SelectedItem);
                        cmd.Parameters.AddWithValue("@BillYear", cboxbillyear.SelectedItem);
                        cmd.Parameters.AddWithValue("@CompanyId", cboxcustomer.SelectedValue);

                        cmd.Parameters.AddWithValue("@DoctorId", cboxdoctor.SelectedValue);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        panel2.Visible = true;
                    }

                } else { lblerrormsg.Text = "All Fields are neccessary !"; }
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }

            // else { data(); }
            GetBillDetails();
            getBillData();
            data();


        }

        void getBillData()
        {

            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetTreatmentsMstBYBillNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                    this.dataGridView2.Columns["CompanyId"].Visible = false;
                    this.dataGridView2.Columns["DoctorId"].Visible = false;

                    this.dataGridView2.Columns["Id"].Visible = false;
                    // rowId1 =Convert.ToInt16( dataGridView1.Rows[0].Cells["Id"].Value);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }

        }
        void GetBillDetails()
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetTreatmentsMstBYBillNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            treatId = Convert.ToInt32(reader["Id"]);
                            txtbillno.Text = Convert.ToString(reader["BillNo"]);
                            cboxbillmonth.SelectedItem = Convert.ToString(reader["BillMonth"]);
                            cboxbillyear.SelectedItem = Convert.ToString(reader["BillYear"]);
                            cboxcustomer.SelectedValue = Convert.ToString(reader["CompanyId"]);
                            cboxdoctor.SelectedValue = Convert.ToString(reader["DoctorId"]);

                        }
                        con.Close();
                    }

                }
                getBillData();
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }

        }
        public void data()
        {

            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetTreatmentbyTraementId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    this.dataGridView1.Columns["Id"].Visible = false;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }
        }
        private void TreatmentDetail_Load(object sender, EventArgs e)
        {

        }
        int rowId;
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
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

                dataGridView1.Rows.Remove(row);
                dataGridView1.Refresh();


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
        // string bill;
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(dbconnectionstring))
            {

                cmd = new SqlCommand("usp_InsertTreatmentDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TreatmentId", treatId);
                cmd.Parameters.AddWithValue("@SrNo", txtsrno.Text);
                cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);

                cmd.Parameters.AddWithValue("@CandidateName", txtcandidatename.Text);
                cmd.Parameters.AddWithValue("@Date", dpvistdate.Value);
                cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
                cmd.Parameters.AddWithValue("@Amount", txtamt.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", txttotalamount.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblerrormsg.Text = "Details Inserted Successfully";

                data();

            }
            txtsrno.Clear();
            txtcandidatename.Clear();
            txtdesc.Clear();
            txtamt.Text = "0";
            txttotalamount.Text = "0";

        }
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Mark the row for deletion
            DataRowView rowView = (DataRowView)dataGridView1.Rows[e.Row.Index].DataBoundItem;
            rowView.Row.Delete();
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView rowView = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            rowView.Row[e.ColumnIndex] = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            TreatmentForm t = new TreatmentForm();
            t.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Edit button to add value

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Edit btn to save treatment detail

        }
   


        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                rowId = Convert.ToInt32(row.Cells["Id"].Value);
                if (rowId > 0)
                {

                    using (con = new SqlConnection(dbconnectionstring))
                    {

                        cmd = new SqlCommand("usp_UpdateTreatmentDetail", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", rowId);
                        // cmd.Parameters.AddWithValue("@TreatmentId", treatId);
                        cmd.Parameters.AddWithValue("@SrNo", txtsrno.Text);
                        // cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);

                        cmd.Parameters.AddWithValue("@CandidateName", txtcandidatename.Text);
                        cmd.Parameters.AddWithValue("@Date", dpvistdate.Value);
                        cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtamt.Text);
                        cmd.Parameters.AddWithValue("@TotalAmount", txttotalamount.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblerrormsg.Text = "Details Updated Successfully";

                        data();

                    }
                    txtsrno.Clear();
                    txtcandidatename.Clear();
                    txtdesc.Clear();
                    txtamt.Text = "0";
                    txttotalamount.Text = "0";

                }
            }



        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                rowId = Convert.ToInt32(row.Cells["Id"].Value);
                if (rowId > 0)
                {
                    GetTreatmentDetails();
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click_2(object sender, EventArgs e)
        {

            using (con = new SqlConnection(dbconnectionstring))
            {

                cmd = new SqlCommand("usp_UpdateTreatment1Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", treatId);

                cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);
                cmd.Parameters.AddWithValue("@BillDate", dpbilldate.Value);
                cmd.Parameters.AddWithValue("@BillMonth", cboxbillmonth.SelectedItem);
                cmd.Parameters.AddWithValue("@BillYear", cboxbillyear.SelectedItem);
                cmd.Parameters.AddWithValue("@CompanyId", cboxcustomer.SelectedValue);

                cmd.Parameters.AddWithValue("@DoctorId", cboxdoctor.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblerrormsg.Text = "Details Updated Successfully";

                getBillData();
                GetBillDetails();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            GetBillDetails();
            using (con = new SqlConnection(dbconnectionstring))
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("delete from TreatmentMst where Id=" + treatId, con);
                // DataSet ds = new DataSet();
                adapt.Fill(dt);
                con.Close();
                con.Open();
                DataTable dt1 = new DataTable();
                adapt = new SqlDataAdapter("delete from TreatmentDetail where TreatmentId=" + treatId, con);
                // DataSet ds = new DataSet();
                adapt.Fill(dt1);
                con.Close();

            }

            getBillData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (rowId > 0)
            {
                using (con = new SqlConnection(dbconnectionstring))
                {

                    cmd = new SqlCommand("usp_UpdateTreatmentDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", rowId);
                    cmd.Parameters.AddWithValue("@TreatmentId", treatId);

                    cmd.Parameters.AddWithValue("@SrNo", txtsrno.Text);
                    cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);

                    cmd.Parameters.AddWithValue("@CandidateName", txtcandidatename.Text);
                    cmd.Parameters.AddWithValue("@Date", dpvistdate.Value);
                    cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtamt.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", txttotalamount.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblerrormsg.Text = "Details Updated Successfully";

                    data();

                }
                txtsrno.Clear();
                txtcandidatename.Clear();
                txtdesc.Clear();
                txtamt.Text = "0";
                txttotalamount.Text = "0";


            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 }