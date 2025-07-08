using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using static HSMAPP.LogIn;

namespace HSMAPP
{
    public partial class VisitForm : Form
    {
        public VisitForm()
        {
            InitializeComponent();
            if (Loginfo.UserID > 0)
            {
                //data();
               // data1();
                getCompany();
                GetPatRegno();
                getmonthyear();
                panel2.Visible = false;
                panel7.Visible = false;
                // this.Load += new System.EventHandler(this.VisitForm_Load);
            }
            // else { this.Hide(); }
        }
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int rowId;

        public void data()
        {

            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetvisitdetailbyvisitId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BillNo", comboBox1.SelectedValue);

                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                    this.dataGridView2.Columns["Id"].Visible = false;
                    //this.dataGridView2.Columns["visitId"].Visible = false;
                    this.dataGridView2.Columns["visitId"].Visible = false;
                    this.dataGridView2.Columns["BillNo"].Visible = false;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }
        }
        public void GetPatRegno()
        {

            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();

                    using (cmd = new SqlCommand("usp_GetUserMstFordoc", con))
                        cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(comboxcompany.SelectedValue));
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
        //public void data1()
        //{

        //    try
        //    {

        //        using (con = new SqlConnection(dbconnectionstring))
        //        {
        //            cmd = new SqlCommand("usp_GetVisitingMstbyvisitId", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@BillNo", comboBox1.SelectedValue);

        //            con.Open();
        //            DataTable dataTable = new DataTable();
        //            adapt = new SqlDataAdapter(cmd);
        //            adapt.Fill(dataTable);
        //            dataGridView2.DataSource = dataTable;

        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblerrormsg.Text = ex.Message;
        //    }
        //}

        //void data1()
        //{
        //    DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
        //    Editlink.UseColumnTextForLinkValue = true;
        //    Editlink.HeaderText = "Edit";
        //    Editlink.DataPropertyName = "lnkColumn";
        //    Editlink.Name = "edit";
        //    Editlink.LinkBehavior = LinkBehavior.SystemDefault;
        //    Editlink.Text = "Edit";
        //    dataGridView2.Columns.Add(Editlink);

        //    //Delete link

        //    DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
        //    Deletelink.UseColumnTextForLinkValue = true;
        //    Deletelink.HeaderText = "Delete";

        //    Deletelink.Name = "Delete";
        //    Deletelink.DataPropertyName = "DeleteColumn";
        //    Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
        //    Deletelink.Text = "Delete";
        //    dataGridView2.Columns.Add(Deletelink);


        //}
       // int treatId;
       
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                rowId = Convert.ToInt32(row.Cells["Id"].Value);
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["Delete"].Index)
                {
                    if (rowId > 0)
                    {
                        DeleteTreament();
                        dataGridView2.Rows.RemoveAt(e.RowIndex);
                        dataGridView2.Refresh();
                    }

                }
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["Edit"].Index)
                {
                    if (rowId > 0)
                    {
                      // GetVisitingDetails();
                        dataGridView2.Refresh();
                       // btnAdd.Visible = false;
                       // btnEdit.Visible = true;
                    }

                }
            }
        }
        //DateTime dpdate;
            //        public void GetVisitingDetails()
            //{
            //    var datatable = new DataTable();
            //    try
            //    {
            //        using (con = new SqlConnection(dbconnectionstring))
            //        {
            //            cmd = new SqlCommand("usp_GetVisitingMstById", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@Id", rowId);
            //            con.Open();
            //            using (var reader = cmd.ExecuteReader())
            //            {
            //                if (reader.Read() != false)
            //                {
                               
            //                    cboxcustomer.SelectedValue = reader["CompanyId"];
                               
            //                    dateTimePicker2.Value = Convert.ToDateTime(reader["Date"]);
            //                    txtamt1.Text = Convert.ToString(reader["Amount"]);
            //                    txtdescription1.Text = Convert.ToString(reader["Description"]);
            //                    cboxdoctor.SelectedValue = Convert.ToString(reader["DoctorId"]);
                               

            //            }
            //                con.Close();
            //            }

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        lblerrormsg.Text = ex.Message;
            //    }
            //}

            public void DeleteTreament()
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("delete from VisitingMst where Id=" + rowId, con);
                    // DataSet ds = new DataSet();
                    adapt.Fill(dt);
                    con.Close();

                }

            }

       
        public void getcomapnydetails()
        {
            using (con = new SqlConnection(dbconnectionstring))
            {
                con.Open();
               // Id = Convert.ToInt32();
                cmd = new SqlCommand("usp_GetCompanyMstByserchId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyId", rowId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read() != false)
                    {
                      
                       EmailId = Convert.ToString(reader["EmailId"]);
                      
                       
                    }
                }
                con.Close();

            }

            
        }
       
       
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                rowId = Convert.ToInt32(row.Cells["Id"].Value);


            }

        }
        string EmailId;
        private void VisitForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  Print(this.panel3);
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        void GetBillNo()
        {//llll

            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();

                    using (cmd = new SqlCommand("usp_GetVisitingmstBycompanyId", con))
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


        private void button2_Click(object sender, EventArgs e)
        {
            if (cboxcustomer.SelectedValue != null)
            {
                panel7.Visible = true;
                GetBillNo();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                data();
                panel2.Visible = true;
            }
        }
        int treatId=0;
        private void button5_Click(object sender, EventArgs e)
        {
            // save detail visit detail
            using (con = new SqlConnection(dbconnectionstring))
            {

                cmd = new SqlCommand("usp_InsertVisitingDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@visitId", treatId);
                cmd.Parameters.AddWithValue("@SrNo", txtsrno1.Text);
                cmd.Parameters.AddWithValue("@BillNo", comboBox1.SelectedValue);

                cmd.Parameters.AddWithValue("@CandidateName", txtname1.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@Description", txtdescription1.Text);
                cmd.Parameters.AddWithValue("@Amount", txtamt1.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", txttotalamt.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblerrormsg.Text = "Details Inserted Successfully";

                data();

            }
            txtsrno1.Clear();
            txtname1.Clear();
            txtdescription1.Clear();
            txtamt1.Text = "0";
            txttotalamt.Text = "0";

        }

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
                        adapt = new SqlDataAdapter("delete from VisitingDetail where Id=" + rowId, con);
                        // DataSet ds = new DataSet();
                        adapt.Fill(dt);
                        con.Close();

                    }
                }

                dataGridView2.Rows.Remove(row);

            }
        }
}
}
