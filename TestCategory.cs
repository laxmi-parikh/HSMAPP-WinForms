using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HSMAPP.LogIn;

namespace HSMAPP
{
    public partial class TestCategory : Form
    {
        public TestCategory()
        {
            InitializeComponent();
            if (Loginfo.UserID > 0)
            {
                data();
                data1();
                
            }
            else { this.Hide(); }
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
                    cmd = new SqlCommand("usp_GetTestCategoryMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoGenerateColumns = false;
                    // this.dataGridView1.Columns["Id"].Visible = false;
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {


                    if (txttestname.Text != string.Empty )
                    {
                        cmd = new SqlCommand("usp_InsertTestCategoryMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", Loginfo.UserID);
                        cmd.Parameters.AddWithValue("@TestCategory", txttestname.Text);
                        cmd.Parameters.AddWithValue("@Cost", txtcost.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblErrorMsg.Text = "Details Inserted Successfully";

                       
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
            txttestname.Clear();
            data();


        }

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
                            adapt = new SqlDataAdapter("delete from TestCategoryMst where Id=" + rowId, con);
                            // DataSet ds = new DataSet();
                            adapt.Fill(dt);
                            con.Close();

                        }
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                       // dataGridView1.Refresh();

                    }

                }
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
                {
                    if (rowId > 0)
                    {
                        GetTestDetails();
                       
                    }

                }

            }
            dataGridView1.Refresh();
            data();
        }

        public void GetTestDetails()
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetTestCategoryMstbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@testId", rowId);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            txttestname.Text = Convert.ToString(reader["TestCategory"]);
                            txtcost.Text= Convert.ToString(reader["Cost"]);
                        }
                        con.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {


                    if (txttestname.Text != string.Empty)
                    {
                        cmd = new SqlCommand("usp_UpdateTestCategoryMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", rowId);
                        cmd.Parameters.AddWithValue("@UserId", Loginfo.UserID);
                        cmd.Parameters.AddWithValue("@TestCategory", txttestname.Text);
                        cmd.Parameters.AddWithValue("@Cost", txtcost.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblErrorMsg.Text = "Details Updated Successfully";

                       
                    }
                    else
                    {
                        lblErrorMsg.Text = "Please enter mandatory details!";
                    }


                }
                data();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
            txttestname.Clear();
            txtcost.Clear();


        }
    }
}
