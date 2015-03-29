using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SimpleSnake
{
    public partial class Registration : System.Web.UI.Page
    {
        private void LoadUsers()
        {
            Connection.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Users";
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            Connection.CloseConnection();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtVerifySubmit.Text = "";
            LoadUsers();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            txtVerifySubmit.Text = "";
            if (txtIDNo.Text != "")
            {
                Connection.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Connection.cn;
                cmd.CommandText = "UPDATE Users SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, ContactNo = @ContactNo, Email = @Email, UserName = @UserName, Password = @Password, LastPasswordUpdate = @LastPassUp WHERE UsersID = @UsersID";
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtFirstName.Text;
                cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = txtMiddleName.Text;
                cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = txtContactNo.Text;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmailAddress.Text;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text;
                cmd.Parameters.Add("@LastPassUp", SqlDbType.NVarChar).Value = DateTime.Now;
                cmd.Parameters.Add("@UsersID", SqlDbType.NVarChar).Value = txtIDNo.Text;
                cmd.ExecuteNonQuery();

                Connection.CloseConnection();
                txtVerifySubmit.Text = "Database Updated!";
            }
            else
            {
                Connection.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Connection.cn;
                cmd.CommandText = "INSERT INTO Users values(@LastName, @FirstName, @MiddleName, @ContactNo, @Email, @UserName, @Password, @LastPassUp)";
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtFirstName.Text;
                cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = txtMiddleName.Text;
                cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = txtContactNo.Text;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmailAddress.Text;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text;
                cmd.Parameters.Add("@LastPassUp", SqlDbType.NVarChar).Value = DateTime.Now;
                cmd.ExecuteNonQuery();

                Connection.CloseConnection();
                txtVerifySubmit.Text = "Database Updated!";
            }

            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVerifySubmit.Text = "";
            txtIDNo.Text = GridView1.SelectedRow.Cells[1].Text;
            txtLastName.Text = GridView1.SelectedRow.Cells[2].Text;
            txtFirstName.Text = GridView1.SelectedRow.Cells[3].Text;
            txtMiddleName.Text = GridView1.SelectedRow.Cells[4].Text;
            txtContactNo.Text = GridView1.SelectedRow.Cells[5].Text;
            txtEmailAddress.Text = GridView1.SelectedRow.Cells[6].Text;
            txtUsername.Text = GridView1.SelectedRow.Cells[7].Text;
        }
    }
}