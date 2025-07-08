using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HSMAPP
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            label1.Visible = false;
            label4.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            GetRoleMst();

            if (Loginfo.UserID > 0)
            {
                this.Hide();
               
            }
            

        }
       
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public void GetRoleMst()
        {
            var datatable = new DataTable();
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {

                    con.Open();
                    using (cmd = new SqlCommand("Select Id,RoleName from RoleMst", con))
                    {
                        using (adapt = new SqlDataAdapter(cmd))
                        {
                            adapt.Fill(datatable);
                            if (datatable.Rows.Count > 0)
                            {
                                comboBox1.ValueMember = "id";

                                comboBox1.DisplayMember = "RoleName";
                                comboBox1.DataSource = datatable;


                            }
                        }
                    }

                }
                con.Close();
                // return datatable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static class Loginfo
        {
            public static int UserID;
            public static string UserName;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (txtUsername.Text != string.Empty || txtpswd.Text != string.Empty)
                {
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        cmd = new SqlCommand("usp_SelectUserMstbyUserName", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtpswd.Text);
                        con.Open();

                        using (var reader = cmd.ExecuteReader())
                        {

                            if (reader.Read() != false)
                            {
                                Loginfo.UserID = Convert.ToInt32(reader["Id"]);
                                Loginfo.UserName = Convert.ToString(reader["UserName"]);

                                MainForm par = new MainForm();
                                this.Hide();
                               this.Dispose();
                               par.Show();
                                

                            }

                            else
                            {
                                lblErrorMsg.Text = "Invalid UserName and Paswword";
                                label1.Visible = true;
                                label4.Visible = true;
                            }
                        }
                        con.Close();
                    }
                    this.Close();
                }
                else
                { lblErrorMsg.Text = "UserName and Password Required";
                    label1.Visible = true;
                    label4.Visible = true;
                }


            }
            catch (Exception ex)
            { lblErrorMsg.Text=ex.Message;
                label1.Visible = true;
                label4.Visible = true;
            }

        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label4.Visible = false;
            this.Close();
            this.Dispose(true);
           
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            panel2.Visible = true;
           // btnregsubmit.Visible = false;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnregsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //after register submit
                using (con = new SqlConnection(dbconnectionstring))
                {
                    if (txtName.Text != string.Empty && txtpsd.Text != string.Empty && txtUname.Text != string.Empty)
                    {
                        cmd = new SqlCommand("usp_InsertUserMst", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleId", Convert.ToInt32(comboBox1.SelectedValue));
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@UserName", txtUname.Text);
                        cmd.Parameters.AddWithValue("@Password", txtpsd.Text);

                        cmd.Parameters.AddWithValue("@Mobile", "");
                        cmd.Parameters.AddWithValue("@EmailId", "");
                        cmd.Parameters.AddWithValue("@Address", "");
                        if (Convert.ToInt32(comboBox1.SelectedValue) == 2)
                        {
                            cmd.Parameters.AddWithValue("@Line1", txtLine1.Text);
                            cmd.Parameters.AddWithValue("@Line2", txtLine2.Text);
                            cmd.Parameters.AddWithValue("@Line3", txtLine3.Text);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Line1", "");
                            cmd.Parameters.AddWithValue("@Line2", "");
                            cmd.Parameters.AddWithValue("@Line3", "");
                        }
                        cmd.Parameters.AddWithValue("@Pincode", "");


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblErrorMsg.Text = "Details Inserted Successfully ";
                        txtName.Clear();
                        txtUname.Clear();
                        txtpsd.Clear();
                        //txtcpsd.Clear();
                        //txtmobile.Clear();
                        //txtaddress.Clear();
                        this.Hide();
                    }

                    else
                    {
                        lblErrorMsg.Text = "Please enter mandatory details!";
                    }
                    //login page for log in
                }




            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             groupBox1.Visible = true;
            panel2.Visible=false;
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) == 2)
            {

                panel3.Visible = true;
            }
        }
    }
    }

