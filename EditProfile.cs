using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static HSMAPP.LogIn;
using System.Configuration;

namespace HSMAPP
{
    public partial class EditProfile : Form
    {
        public EditProfile()
        {
            InitializeComponent();
            if (Loginfo.UserID > 0)
            {
                //panel1.Visible = true;
              //  panelEditRegister.Visible = false;
                data();
                GetRoleId(1);
            }
        }
        string dbconnectionstring = ConfigurationManager.AppSettings["dbconnectionstring"];
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
       
        
        void data()
        {
            try
            {

                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();
                    
                    cmd = new SqlCommand("usp_UermstbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", Loginfo.UserID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() != false)
                        {
                            comboBox2.SelectedValue = Convert.ToString(reader["RoleId"]);
                            txtAddress.Text = Convert.ToString(reader["Address"]);
                            txteditName.Text = Convert.ToString(reader["Name"]);
                            txtUname.Text = Convert.ToString(reader["UserName"]);
                            txtpsd.Text = Convert.ToString(reader["Password"]);
                            txtmobile.Text = Convert.ToString(reader["Mobile"]);
                           txtEmailId.Text= Convert.ToString(reader["EmailId"]);
                           txtLine1.Text = Convert.ToString(reader["Line1"]);
                            txtLine2.Text = Convert.ToString(reader["Line2"]);
                            txtLine3.Text = Convert.ToString(reader["Line3"]);

                           // GetRoleId(Convert.ToInt32(reader["RoleId"]));

                        }
                        else
                        {
                            lblErrorMsg.Text="Data Not Found";

                        }
                        con.Close();

                    }
                   

                }
            }
            catch (Exception ex)
            { lblErrorMsg.Text=ex.Message; }
        }
        public void GetRoleId(int Id)
        {
            var datatable = new DataTable();
            try
            {
                using (con = new SqlConnection(dbconnectionstring))
                {
                    con.Open();
                    {
                        using (cmd = new SqlCommand("Select * from RoleMst where Id="+Id, con))
                        {
                            using (adapt = new SqlDataAdapter(cmd))
                            {
                                adapt.Fill(datatable);
                                comboBox2.ValueMember = "Id";
                                comboBox2.DisplayMember = "RoleName";
                                comboBox2.DataSource=datatable;
                            }
                        }
                    }
                    con.Close();
                }

                // return datatable;
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text=ex.Message;
            }

        }
        private void btneditregister_Click(object sender, EventArgs e)
        {
           
        }

        private void btneditregister_Click_1(object sender, EventArgs e)
        {
            try
            {
                // edit reigter form after submit
                if (Loginfo.UserID > 0)
                {
                    
                   
                    using (con = new SqlConnection(dbconnectionstring))
                    {
                        
                        if (txteditName.Text != string.Empty)
                        {
                            cmd = new SqlCommand("usp_UpdateUserMstbyId", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UserId", Loginfo.UserID);
                            cmd.Parameters.AddWithValue("@RoleId", comboBox2.SelectedValue);
                          
                            cmd.Parameters.AddWithValue("@Name", txteditName.Text);
                            cmd.Parameters.AddWithValue("@UserName", txtUname.Text);
                            cmd.Parameters.AddWithValue("@Password", txtpsd.Text);

                            cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                            cmd.Parameters.AddWithValue("@EmailId",txtEmailId.Text);
                            cmd.Parameters.AddWithValue("@Address",txtAddress.Text);
                            cmd.Parameters.AddWithValue("@Pincode", "");
                            cmd.Parameters.AddWithValue("@Line1", txtLine1.Text);

                            cmd.Parameters.AddWithValue("@Line2", txtLine2.Text);

                            cmd.Parameters.AddWithValue("@Line3", txtLine3.Text);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            lblErrorMsg.Text="Details Updated Successfully";
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            { lblErrorMsg.Text=ex.Message; }

        }

      
      
      

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            panelEditRegister.Visible = false;
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // this.Hide();
           // panelEditRegister.Visible = false;

        }

        private void txtpincode_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txteditMboile_Validating(object sender, CancelEventArgs e)
        {
          

        }

        private void txtEmailId_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           // panelEditRegister.Visible = true;
           // panel1.Visible = false;
        }
    }
}
