using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;
using static HSMAPP.LogIn;

namespace HSMAPP
{
    public partial class CompanyF : Form
    {
        public CompanyF()
        {
            InitializeComponent();
            if (Loginfo.UserID > 0)
            {
                data();
                data1();
                getCompany();
                btnclear.Visible=false;
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
                    cmd = new SqlCommand("usp_GetCompanyMst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoGenerateColumns = false;
                    // this.dataGridView1.Columns["Id"].Visible = false;
                     this.dataGridView1.Columns["UserId"].Visible = false;
                    //this.dataGridView1.Columns["Country"].Visible = false;
                    //this.dataGridView1.Columns["State"].Visible = false;
                    //this.dataGridView1.Columns["City"].Visible = false;
                    //this.dataGridView1.Columns["zone"].Visible = false;
                    //this.dataGridView1.Columns["Website"].Visible = false;

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Refresh();
                    con.Close();
                }
               
            } 
            catch (Exception ex)
            {
                lblErrorMsg.Text =ex.Message;
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
                    comboBox1.ValueMember = "Id";
                    comboBox1.DisplayMember = "CompanyName";
                    comboBox1.DataSource = dataTable;
                   
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text=ex.Message;
            }
        }

        Regex expr;
        public bool phone(string no)
        {
            expr = new Regex(@"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$");
            if (expr.IsMatch(no))
            {
                return true;
            }
            else return false;
        }

        public bool EmailId(string EmailId)
        {
            expr = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
            if (expr.IsMatch(EmailId))
            {
                return true;
            }
            else return false;
        }

     
        private void btnAddComDetail_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {


                                if (txtCompanyName.Text != string.Empty )
                                {
                                    cmd = new SqlCommand("usp_InsertCompanyMst", con);
                                    cmd.CommandType=CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@UserId", Loginfo.UserID);
                                    cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                                    cmd.Parameters.AddWithValue("@Country","India");
                                    cmd.Parameters.AddWithValue("@State", "Maharashtra");
                                    cmd.Parameters.AddWithValue("@city","Boisor");
                                    cmd.Parameters.AddWithValue("@zone", "Palghar");
                                    cmd.Parameters.AddWithValue("@Pincode", "401501");
                                    cmd.Parameters.AddWithValue("@WebSite","");
                                    cmd.Parameters.AddWithValue("@EmailId", txtEmailId.Text);
                                    cmd.Parameters.AddWithValue("@Fax","");
                                    cmd.Parameters.AddWithValue("@ContactName", txtconatctName.Text);
                                    cmd.Parameters.AddWithValue("@ContactNumber", txtmobile.Text);
                                    cmd.Parameters.AddWithValue("@Designation", txtDesig1.Text);
                                    cmd.Parameters.AddWithValue("@ContactName1", "None");
                                    cmd.Parameters.AddWithValue("@ContactNumber1","");
                                    cmd.Parameters.AddWithValue("@Designation1", "");
                                    cmd.Parameters.AddWithValue("@PayingAmt", "");
                                    cmd.Parameters.AddWithValue("@Vat","");
                                   cmd.Parameters.AddWithValue("@GSTIN", txtGstNo.Text);
                        cmd.Parameters.AddWithValue("@Panno", txtpanno.Text);
                        if (rbtnGovernment.Checked == true)

                        {
                            cmd.Parameters.AddWithValue("@ServiceType", "Public");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ServiceType", "Private");
                        }

                        con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    lblErrorMsg.Text="Details Inserted Successfully";
                                   
                                    data();
                                }
                                else
                                {
                                   lblErrorMsg.Text="Please enter mandatory details!";
                                }

                    getCompany();

                }
            }
            catch (Exception ex)
            {
               lblErrorMsg.Text=ex.Message;
            }
            txtCompanyName.Clear();
            txtDesig1.Clear();
            
            txtconatctName.Clear();
            txtAddress.Clear();
            txtmobile.Clear();
           
            txtEmailId.Clear();

        }

        private void btnclear_Click(object sender, EventArgs e)
        {            // update company detail clear
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    if (txtCompanyName.Text !=string.Empty )
                    {
                        cmd = new SqlCommand("usp_UpdateCompanyMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@companyId", rowId);
                        cmd.Parameters.AddWithValue("@UserId", Loginfo.UserID);
                        cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Country","India");
                        cmd.Parameters.AddWithValue("@State", "Maharashtra");
                        cmd.Parameters.AddWithValue("@city", "Boisor");
                        cmd.Parameters.AddWithValue("@zone", "Palghar");
                        cmd.Parameters.AddWithValue("@Pincode", "401501");
                        cmd.Parameters.AddWithValue("@WebSite", "");
                        cmd.Parameters.AddWithValue("@EmailId", txtEmailId.Text);
                        cmd.Parameters.AddWithValue("@Fax", "");
                        cmd.Parameters.AddWithValue("@ContactName", txtconatctName.Text);
                        cmd.Parameters.AddWithValue("@ContactNumber", txtmobile.Text);
                        cmd.Parameters.AddWithValue("@Designation",txtDesig1.Text);
                        cmd.Parameters.AddWithValue("@ContactName1","None");
                        cmd.Parameters.AddWithValue("@ContactNumber1","");
                        cmd.Parameters.AddWithValue("@Designation1", "");
                        cmd.Parameters.AddWithValue("@PayingAmt", "");
                        cmd.Parameters.AddWithValue("@Vat","");
                        cmd.Parameters.AddWithValue("@GSTIN", txtGstNo.Text);
                        cmd.Parameters.AddWithValue("@Panno", txtpanno.Text);
                        if (rbtnGovernment.Checked == true)

                        {
                            cmd.Parameters.AddWithValue("@ServiceType", "Public");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ServiceType","Private");
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblErrorMsg.Text="Details Updated Successfully";
                        
                        data();
                    }
                    else
                    {
                        lblErrorMsg.Text="Please enter mandatory details!";
                    }
                }
                getCompany();

                btnclear.Visible= false;
                btnAddComDetail.Visible = true;

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text=ex.Message;
            }
            txtCompanyName.Clear();
            txtconatctName.Clear();
            txtAddress.Clear();
            txtmobile.Clear();
           
}
         
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetCompanyMstByserchId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyId", Convert.ToInt32(comboBox1.SelectedValue));
                    con.Open();
                    DataTable dataTable = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoGenerateColumns = false;
                    this.dataGridView1.Columns["UserId"].Visible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.Refresh();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text=ex.Message;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
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
                            adapt = new SqlDataAdapter("delete from CompanyMst where Id=" + rowId, con);
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
                    if(rowId>0)
                    { 
                    GetCompanyDetails();
                        dataGridView1.Refresh();
                    }
                    btnAddComDetail.Visible= false;
                    btnclear.Visible = true;
                }
             
            }
            
        }

        public void GetCompanyDetails()
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    cmd = new SqlCommand("usp_GetCompanyMstByserchId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyId",rowId);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                           txtCompanyName.Text= Convert.ToString(reader["CompanyName"]);
                            txtconatctName.Text = Convert.ToString(reader["ContactName"]);
                            txtAddress.Text= Convert.ToString(reader["Address"]);
                            txtmobile.Text = Convert.ToString(reader["ContactNumber"]);
                           // txtpayingamt.Text=Convert.ToString(reader["PayingAmt"]);
                           // txtcity.Text = Convert.ToString(reader["city"]);
                           // txtcontactname2.Text = Convert.ToString(reader["ContactName1"]);
                           // txtcountry.Text = Convert.ToString(reader["Country"]);
                            //txtstate.Text = Convert.ToString(reader["State"]);
                           // txtwebsite.Text = Convert.ToString(reader["Website"]);
                            //txtzone.Text = Convert.ToString(reader["zone"]);
                           // txtpincode.Text = Convert.ToString(reader["Pincode"]);
                           // txtfax.Text = Convert.ToString(reader["Fax"]);
                            txtEmailId.Text = Convert.ToString(reader["EmailId"]);
                            txtDesig1.Text = Convert.ToString(reader["Designation"]);
                            //txtDesig2.Text = Convert.ToString(reader["Designation1"]);
                            //txtmobile2.Text = Convert.ToString(reader["ContactNumber1"]);
                            txtpanno.Text = Convert.ToString(reader["Panno"]);
                            txtGstNo.Text= Convert.ToString(reader["GSTIN"]);

                            if (Convert.ToString(reader["ServiceType"]) == "Public")

                            {
                                rbtnGovernment.Checked = true;
                                rbtnPrivate.Checked = false;
                            }
                            else
                            {
                                rbtnGovernment.Checked = false;
                                rbtnPrivate.Checked = true;

                            }

                        }
                        con.Close();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text=ex.Message;
            }
        }

        //private void txtwebsite_Validating(object sender, CancelEventArgs e)
        //{
        //    if (websitecheck(txtwebsite.Text) == false) { lblErrorMsg.Text = "Invalid Website Link"; }
        //}

        //private void txtpincode_Validating(object sender, CancelEventArgs e)
        //{
            
        //    if (ZipCode(txtpincode.Text) == false)
        //    { lblErrorMsg.Text = "Invalid Pincode"; }

        //}

        //private void txtmobile_Validating(object sender, CancelEventArgs e)
        //{
        //    if (phone(txtmobile.Text) == false)
        //    {
        //        lblErrorMsg.Text = "Invalid Contact Number";
        //    }
            


       // }

        //private void txtEmailId_Validating(object sender, CancelEventArgs e)
        //{
        //    if (EmailId(txtEmailId.Text) == false)
        //    { lblErrorMsg.Text = "Invalid Email Address"; }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void grpbxAdddcom_Enter(object sender, EventArgs e)
        {

        }

        private void rbtnGovernment_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnGovernment.Checked == true)

            {
                rbtnPrivate.Checked = false;
            }
            else
            {
                rbtnPrivate.Checked = true;
            }
        }

        private void rbtnPrivate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPrivate.Checked == true)

            {
                rbtnGovernment.Checked = false;
            }
            else
            {
                rbtnGovernment.Checked = true;
            }

        }

        //private void btnAddpatient_Click(object sender, EventArgs e)
        //{
        //    AddPatient1 pat=new AddPatient1();
        //    pat.Show();
        //}
    }
    }