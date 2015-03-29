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
    public partial class Default : System.Web.UI.Page
    {
        private void Refresh()
        {
            Connection.OpenConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.cn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM Players WHERE FirstName = 'Anthony'";
            cmd.CommandText = "SELECT * FROM Players";

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dbGridView.DataSource = dt;
            dbGridView.DataBind();
            Connection.CloseConnection();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Refresh();
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Refresh();
        //    //Connection.OpenConnection();

        //    //SqlCommand cmd = new SqlCommand();
        //    //cmd.Connection = Connection.cn;
        //    //cmd.CommandType = CommandType.Text;
        //    ////cmd.CommandText = "SELECT * FROM Players WHERE FirstName = 'Anthony'";
        //    //cmd.CommandText = "SELECT * FROM Players WHERE " + DropDownList1.SelectedItem.Text + " = @FirstName";
        //    //cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtSearch.Text;

        //    //SqlDataAdapter adp = new SqlDataAdapter();
        //    //adp.SelectCommand = cmd;

        //    //DataTable dt = new DataTable();
        //    //adp.Fill(dt);
        //    //dbGridView.DataSource = dt;
        //    //dbGridView.DataBind();
        //    //Connection.CloseConnection();
        //}

        //protected void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    Refresh();
        //}

        protected void btnAllPlayers_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        protected void btnSteveNash_Click1(object sender, EventArgs e)
        {
            Connection.OpenConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.cn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM Players WHERE FirstName = 'Anthony'";
            cmd.CommandText = "SELECT * FROM Players WHERE PlayerName = 'Steve Nash'";

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dbGridView.DataSource = dt;
            dbGridView.DataBind();
            Connection.CloseConnection();
        }

        protected void btnMiamiHeat_Click(object sender, EventArgs e)
        {
            Connection.OpenConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.cn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM Players WHERE FirstName = 'Anthony'";
            cmd.CommandText = "SELECT * FROM Players WHERE Team = 'Miami Heat'";

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dbGridView.DataSource = dt;
            dbGridView.DataBind();
            Connection.CloseConnection();
        }

        protected void btnBostonCeltics_Click(object sender, EventArgs e)
        {
            Connection.OpenConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.cn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM Players WHERE FirstName = 'Anthony'";
            cmd.CommandText = "SELECT * FROM Players WHERE Team = 'Boston Celtics'";

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dbGridView.DataSource = dt;
            dbGridView.DataBind();
            Connection.CloseConnection();
        }

        protected void btnNameSorK_Click(object sender, EventArgs e)
        {
            Connection.OpenConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.cn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM Players WHERE FirstName = 'Anthony'";
            cmd.CommandText = "SELECT * FROM Players WHERE PlayerName like 's%' or PlayerName like 'k%'";

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dbGridView.DataSource = dt;
            dbGridView.DataBind();
            Connection.CloseConnection();
        }

        protected void btnSalary_Click(object sender, EventArgs e)
        {
            Connection.OpenConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.cn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM Players WHERE FirstName = 'Anthony'";
            cmd.CommandText = "SELECT * FROM Players WHERE Salary > 40000 and Salary < 50000";

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dbGridView.DataSource = dt;
            dbGridView.DataBind();
            Connection.CloseConnection();
        }

        protected void btnHighestSalary_Click(object sender, EventArgs e)
        {
            Connection.OpenConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.cn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM Players WHERE FirstName = 'Anthony'";
            cmd.CommandText = "SELECT * FROM Players WHERE Salary > 50000 ORDER BY SALARY DESC";
            //cmd.CommandText = "SELECT TOP 3 Salary FROM Players ORDER BY Salary DESC";

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dbGridView.DataSource = dt;
            dbGridView.DataBind();
            Connection.CloseConnection();
        }


    }
}