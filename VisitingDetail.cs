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

namespace HSMAPP
{
    public partial class VisitingDetail: Form
    {
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];

        public VisitingDetail()
        {
            InitializeComponent();
            Getdoctor();
            getCompany();
            getmonthyear();
            panel8.Visible = false;

        }
        static int treatId;
        public void GetTreatmentDetails()
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetVisitinDetailById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", rowId);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            txttotalamount.Text = Convert.ToString(reader["Amount"]);
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

        private void button3_Click(object sender, EventArgs e)
        {
            // to go modifiya page
            VisitForm t = new VisitForm();
            t.Show();

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // to add details visit mst

        //    try
        //    {
        //        if (txtbillno.Text != string.Empty && cboxbillmonth.SelectedItem != null && cboxbillyear.SelectedItem != null)
        //        {
        //            using (con = new SqlConnection(dbconnectionstring))
        //            {

        //                cmd = new SqlCommand("usp_InsertVisitingMst", con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);
        //                cmd.Parameters.AddWithValue("@BillDate", dpbilldate.Value);
        //                cmd.Parameters.AddWithValue("@BillMonth", cboxbillmonth.SelectedItem);
        //                cmd.Parameters.AddWithValue("@BillYear", cboxbillyear.SelectedItem);
        //                cmd.Parameters.AddWithValue("@CompanyId", cboxcustomer.SelectedValue);

        //                cmd.Parameters.AddWithValue("@DoctorId", cboxdoctor.SelectedValue);
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //                panel8.Visible = true;
        //            }

        //        }
        //        else { lblerrormsg.Text = "All Fields are neccessary !"; }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblerrormsg.Text = ex.Message;
        //    }

        //    // else { data(); }
        //    data();


        //}
        int rowId;
        public void data()
        {

            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetvisitdetailbyvisitId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView3.DataSource = dataTable;
                    this.dataGridView3.Columns["Id"].Visible = false;
                    this.dataGridView3.Columns["visitId"].Visible = false;
                    this.dataGridView3.Columns["BillNo"].Visible = false;
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

        //private void btnSaveChanges_Click(object sender, EventArgs e)
        //{
        //    // save detail visit detail
        //    using (con = new SqlConnection(dbconnectionstring))
        //    {

        //        cmd = new SqlCommand("usp_InsertVisitingDetail", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@visitId", treatId);
        //        cmd.Parameters.AddWithValue("@SrNo", txtsrno.Text);
        //        cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);

        //        cmd.Parameters.AddWithValue("@CandidateName", txtcandidatename.Text);
        //        cmd.Parameters.AddWithValue("@Date", dpvistdate.Value);
        //        cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
        //        cmd.Parameters.AddWithValue("@Amount", txttotalamount.Text);
        //        cmd.Parameters.AddWithValue("@TotalAmount", txttotalamount.Text);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        lblerrormsg.Text = "Details Inserted Successfully";

        //        data();

        //    }
        //    txtsrno.Clear();
        //    txtcandidatename.Clear();
        //    txtdesc.Clear();
        //    txttotalamount.Text = "0";
        //    txttotalamount.Text = "0";

        //}

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            // delete 
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                rowId = Convert.ToInt32(row.Cells["Id"].Value);
                if (rowId > 0)
                {
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        con.Open();
                        DataTable dt = new DataTable();
                        adapt = new SqlDataAdapter("delete from VisitingDetail where Id=" + rowId, con);
                        // DataSet ds = new DataSet();
                        adapt.Fill(dt);
                        con.Close();

                    }
                }

                dataGridView3.Rows.Remove(row);


            }
        }
        void getBillData()
        {

            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetVisitingsMstBYBillNo", con);
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
                    cmd = new SqlCommand("usp_GetVisitingsMstBYBillNo", con);
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

        private void button2_Click(object sender, EventArgs e)
        {
            //for edit bill
            using (con = new SqlConnection(dbconnectionstring))
            {

                cmd = new SqlCommand("usp_UpdateVisitingMst", con);
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

                          }
            getBillData();
            GetBillDetails();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // for delete bill
            GetBillDetails();
            using (con = new SqlConnection(dbconnectionstring))
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("delete from VisitingMst where Id=" + treatId, con);
                // DataSet ds = new DataSet();
                adapt.Fill(dt);
                con.Close();
                con.Open();
                DataTable dt1 = new DataTable();
                adapt = new SqlDataAdapter("delete from VisitingDetail where visitId=" + treatId, con);
                // DataSet ds = new DataSet();
                adapt.Fill(dt1);
                con.Close();

            }

            getBillData();

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // edit detail
            if (rowId > 0)
            {
                using (con = new SqlConnection(dbconnectionstring))
                {

                    cmd = new SqlCommand("usp_UpdateVisitingDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", rowId);
                    cmd.Parameters.AddWithValue("@VisitId", treatId);

                    cmd.Parameters.AddWithValue("@SrNo", txtsrno.Text);
                    cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);

                    cmd.Parameters.AddWithValue("@CandidateName", txtcandidatename.Text);
                    cmd.Parameters.AddWithValue("@Date", dpvistdate.Value);
                    cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
                    cmd.Parameters.AddWithValue("@Amount", txttotalamount.Text);
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
                txttotalamount.Text = "0";
                txttotalamount.Text = "0";


            }
        }



        private void button8_Click(object sender, EventArgs e)
        {
            // delete detail
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                rowId = Convert.ToInt32(row.Cells["Id"].Value);
                if (rowId > 0)
                {
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        con.Open();
                        DataTable dt = new DataTable();
                        adapt = new SqlDataAdapter("delete from VisitingDetail where Id=" + rowId, con);
                        // DataSet ds = new DataSet();
                        adapt.Fill(dt);
                        con.Close();

                    }
                }

                dataGridView3.Rows.Remove(row);
                dataGridView3.Refresh();

            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbillno.Text != string.Empty && cboxbillmonth.SelectedItem != null && cboxbillyear.SelectedItem != null)
                {
                    using (con = new SqlConnection(dbconnectionstring))
                    {

                        cmd = new SqlCommand("usp_InsertVisitingMst", con);
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
                        panel8.Visible = true;
                    }

                }
                else { lblerrormsg.Text = "All Fields are neccessary !"; }
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

        private void button7_Click(object sender, EventArgs e)
        {
            //usp_InsertVisitingDetail
            using (con = new SqlConnection(dbconnectionstring))
            {

                cmd = new SqlCommand("usp_InsertVisitingDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VisitId", treatId);
                cmd.Parameters.AddWithValue("@SrNo", txtsrno.Text);
                cmd.Parameters.AddWithValue("@BillNo", txtbillno.Text);

                cmd.Parameters.AddWithValue("@CandidateName", txtcandidatename.Text);
                cmd.Parameters.AddWithValue("@Date", dpvistdate.Value);
                cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
                cmd.Parameters.AddWithValue("@Amount", txttotalamount.Text);
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
            txttotalamount.Text = "0";
            txttotalamount.Text = "0";


        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
                    }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_SelectionChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                rowId = Convert.ToInt32(row.Cells["Id"].Value);
                if (rowId > 0)
                {
                    GetTreatmentDetails();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            VisitForm vf = new VisitForm();
            vf.Show();
        }
    }
}
