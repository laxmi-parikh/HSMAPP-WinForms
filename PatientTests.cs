using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HSMAPP
{
    public partial class PatientTests : Form
    {
        public PatientTests()
        {
            InitializeComponent();
            if (LogIn.Loginfo.UserID > 0)
            {
                //data();
                //data1();
                getCompany();
                txtyear.Text=DateTime.Today.Year.ToString();
                txtmonth.Text=DateTime.Today.Month.ToString();
                // getTestmst();
                Getdoctor();
                data1();
               // data1();


            }
        }
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dataTable;
        int rowId;
        static int totalRecords;
        int pageSize;
        int startval=0;

        void data1()
        {
            DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            Editlink.UseColumnTextForLinkValue = true;
            Editlink.HeaderText = "Edit";
            Editlink.DataPropertyName = "lnkColumn";
            Editlink.Name = "edit";
            Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            Editlink.Text = "Edit";
            dataGridView1.Columns.Add(Editlink);

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


        public void data()
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetAlltestinvices1", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxCompany.SelectedValue));
                    cmd.Parameters.AddWithValue("@months", Convert.ToInt32(txtmonth.Text));
                    cmd.Parameters.AddWithValue("@years", Convert.ToInt32(txtyear.Text));
                    cmd.Parameters.AddWithValue("@doctorId", Convert.ToInt32(comboxdoc.SelectedValue));

                    con.Open();


                    dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);

                    adapt.Fill(startval, pageSize, dataTable);

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoGenerateColumns = false;
                    this.dataGridView1.Columns["PatientId"].Visible = false;
                    // this.dataGridView1.Columns["Nos"].Visible = false;
                
                      dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Refresh();
                    con.Close();
                }
                dataGridView1.Refresh();


            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
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
                    cboxCompany.ValueMember = "Id";
                    cboxCompany.DisplayMember = "CompanyName";
                    cboxCompany.DataSource = dataTable;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
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

                    using (cmd = new SqlCommand("usp_GetPatientbyCompanyId", con))
                        cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxCompany.SelectedValue));
                    {
                        using (adapt = new SqlDataAdapter(cmd))
                        {
                            adapt.Fill(datatable);

                            cboxpatient.ValueMember = "Id";
                            cboxpatient.DisplayMember = "PatientName";
                            cboxpatient.DataSource = datatable;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
   
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {


                    if ( txtcost.Text != string.Empty)
                    {
                        cmd = new SqlCommand("usp_InsertTestMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(LogIn.Loginfo.UserID));
                        cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(cboxpatient.SelectedValue));
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxCompany.SelectedValue));
                        cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@TestName",txtdesc.Text);
                        cmd.Parameters.AddWithValue("@Cost", txtcost.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblErrorMessage.Text = "Details Inserted Successfully";

                        // data();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Please enter mandatory details!";
                    }

                    data();
                    totalrecordcount();
                    datafindinvoice();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            //txttestname.Clear();
            txtcost.Clear();
        }

        private void cboxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxCompany.SelectedValue != null)
            {
                GetPatRegno();
            }
        }

       


        public void Getvalueforupdate()
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetTestmstbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", rowId);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            //Id = Convert.ToInt32(reader["Id"]);
                            txtcost.Text = Convert.ToString(reader["Cost"]);
                            txtdesc.Text= Convert.ToString(reader["TestName"]);
                            cboxpatient.SelectedValue = Convert.ToInt32(reader["PatientId"]);
                            // comboBox1.SelectedValue  = Convert.ToString(reader["TestName"]);
                            dateTimePicker1.Value = Convert.ToDateTime(reader["Date"]).Date;
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
  }

        private void btnudate_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_UpdateTestMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", rowId);
                    //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(LogIn.Loginfo.UserID));
                    cmd.Parameters.AddWithValue("@PatientId", Convert.ToInt32(cboxpatient.SelectedValue));
                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxCompany.SelectedValue));
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@TestName",txtdesc.Text);

                    cmd.Parameters.AddWithValue("@Cost", txtcost.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblErrorMessage.Text = "Details Updated Successfully";
                }
                txtcost.Clear();
               // comboBox1.SelectedValue.Clear();

                data();
                totalrecordcount();
                datafindinvoice();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
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
                    //cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(comboxcompany.SelectedValue));
                    {
                        using (adapt = new SqlDataAdapter(cmd))
                        {
                            adapt.Fill(datatable);
                            
                            comboxdoc.ValueMember = "Id";
                            comboxdoc.DisplayMember = "Name";
                            comboxdoc.DataSource = datatable;
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        void totalrecordcount()
        {

            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetAlltestinvices", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxCompany.SelectedValue));
                    cmd.Parameters.AddWithValue("@months", Convert.ToInt32(txtmonth.Text));
                    cmd.Parameters.AddWithValue("@years", Convert.ToInt32(txtyear.Text));
                    cmd.Parameters.AddWithValue("@doctorId", Convert.ToInt32(comboxdoc.SelectedValue));

                    con.Open();


                    dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);

                    adapt.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        totalRecords = Convert.ToInt32(dataTable.Rows.Count);
                        label4.Text = totalRecords.ToString();
                    }
                    pageSize = Convert.ToInt32(txtpagesize.Text);
                     //startval=0;
                }
            }
            catch (Exception ex)
            {
               lblErrorMessage.Text= ex.Message;
            }


                }
                void datafindinvoice()
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetAlltestinvices", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CompanyId", Convert.ToInt32(cboxCompany.SelectedValue));
                    cmd.Parameters.AddWithValue("@months", Convert.ToInt32(txtmonth.Text));
                    cmd.Parameters.AddWithValue("@years", Convert.ToInt32(txtyear.Text));
                    cmd.Parameters.AddWithValue("@doctorId", Convert.ToInt32(comboxdoc.SelectedValue));

                    con.Open();


                    dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);

                    adapt.Fill(startval, pageSize, dataTable);

                    dataGridView2.DataSource = dataTable;
                    dataGridView2.AutoGenerateColumns = false;
                    this.dataGridView2.Columns["PatientId"].Visible = false;
                    this.dataGridView2.Columns["Id"].Visible = false;
                  //  dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView2.Refresh();
                    con.Close();
                }
                double result = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    result += Convert.ToDouble(row.Cells["Amount"].Value);


                }
                lbltotalcost.Text = result.ToString();
                //double result1 = 0;
                //foreach (DataGridViewRow row in dataGridView2.Rows)
                //{
                //    result1 += Convert.ToDouble(row.Cells["TotalTest"].Value);

                //}
                //lbltotaltest.Text = result1.ToString();

                //foreach (DataGridViewRow row in dataGridView2.Rows)
                //{
                //    testdesc(Convert.ToInt32(row.Cells["PatientId"].Value));

                //    row.Cells["Details"].Value = testdescrib.ToString();
                //    // row.Cells["Test_Details"].Value = testdescrib.ToString();

                //}

                //exec usp_getdestest @PatientId,@CompanyId
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }

        }
        private void btnfind_Click(object sender, EventArgs e)
        {
            totalrecordcount();
            datafindinvoice();
            data();

        }
      

       
                //pevoius
        private void button1_Click(object sender, EventArgs e)
        {
            if (startval <= 0)
            {
                startval = 0;
            }
            else
            {
                startval -= pageSize;
            }
           
            datafindinvoice();
        }
        //next
        private void button2_Click(object sender, EventArgs e)
        {
            totalRecords = totalRecords - pageSize;
                if (startval <= totalRecords)
                {
                    startval = pageSize; 
                }
                else
                {
                startval += pageSize;
                }
                        
            datafindinvoice();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InvoiceTestperform inv = new InvoiceTestperform();
            inv.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    testdesc(Convert.ToInt32(row.Cells["PatientId"].Value));
            //    row.Cells["Details"].Value = testdescrib.ToString();
            //    // row.Cells["Test_Details"].Value = testdescrib.ToString();

            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rowId > 0)
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("delete from TestMst where Id=" + rowId, con);
                    // DataSet ds = new DataSet();
                    adapt.Fill(dt);
                    con.Close();

                }
               // dataGridView1.Rows.RemoveAt(e.RowIndex);
               // dataGridView1.Refresh();
                data();
                totalrecordcount();
                datafindinvoice();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                rowId = Convert.ToInt32(row.Cells["Id"].Value);
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                {
                    if (rowId > 0)
                    {
                        using (con = new SqlConnection(dbconnectionstring))
                        {
                            con.Open();
                            DataTable dt = new DataTable();
                            adapt = new SqlDataAdapter("delete from TestMst where Id=" + rowId, con);
                            // DataSet ds = new DataSet();
                            adapt.Fill(dt);
                            con.Close();

                        }
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                         dataGridView1.Refresh();

                    }

                }
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
                {
                    if (rowId > 0)
                    {
                        Getvalueforupdate();

                    }

                }


            }
            //  data();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //rowId = 0;
            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
            //    rowId = Convert.ToInt32(row.Cells[0].Value);
            //    if (rowId > 0)
            //    {
            //        Getvalueforupdate();
            //    }
                  


           // }
            //  data();
        }
    }
    }
      
    