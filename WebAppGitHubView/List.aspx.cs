using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebAppGitHubView
{
    public partial class List : System.Web.UI.Page
    {
        string pattern = @"(([a-z0-9\-\.]+)?[a-z0-9\-]+(!?\.[a-z]{2,4}))";
        Regex reg;
        GitHubUrlContext dhuc;

        protected void Page_Load(object sender, EventArgs e)
        {
            dhuc = new GitHubUrlContext();
            SelectedGridView(dhuc);
            message.Text = String.Empty;
            if (!IsPostBack)
            {
                //tb_url.Disabled = true;
                //btRemove.Enabled = false;
                //btEdit.Enabled = false;
                
            }

            if (IsPostBack)
            {
                
            }
        }

        void GridViewUrl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                { 
                    e.Row.Attributes.Add("onclick", "cell_list_Click(this)");
                    e.Row.Attributes.Add("class", "rowRepository");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void SelectedGridView(GitHubUrlContext gitHubUrlContext)
        {
            SqlDataSourceUrl.ConnectionString = gitHubUrlContext.Database.Connection.ConnectionString;
            SqlDataSourceUrl.SelectCommand = "SELECT * FROM [URLS]";
            GridViewUrl.DataSourceID = SqlDataSourceUrl.ID;
            GridViewUrl.RowDataBound += GridViewUrl_RowDataBound;
            gitHubUrlContext.Dispose();
        }
        protected void btAdd_Click(object sender, EventArgs e)
        {
            tb_url.Disabled = false;
            reg = new Regex(pattern);
            if (tb_url.Value.Length > 0 && reg.Match(tb_url.Value, 0).Value == "github.com")
            {
                dhuc = new GitHubUrlContext();
                using (SqlConnection conn = new SqlConnection(dhuc.Database.Connection.ConnectionString))
                {
                    string query = String.Format("INSERT INTO [URLS] VALUES ('{0}')", tb_url.Value);
                    SqlCommand com = new SqlCommand(query, conn);
                    conn.Open();
                    if (com.ExecuteNonQuery() == 1)
                    {
                        SelectedGridView(dhuc);
                        tb_url.Value = string.Empty;
                        tb_url.Disabled = true;
                        message.Text = "Yes github.com";
                    }
                }
            }
            if (String.IsNullOrEmpty(message.Text))
            {
                message.Text = "no github.com";
            }
        }

        protected void btRemove_Click(object sender, EventArgs e)
        {
            //if (reg.Match(tb_url.Value, 0).Value == "github.com")
            //{
                dhuc = new GitHubUrlContext();
                using (SqlConnection conn = new SqlConnection(dhuc.Database.Connection.ConnectionString))
                {
                    string query = String.Format("DELETE FROM [URLS] WHERE [URLS].[Id] = {0}", this.hdField.Value);
                    SqlCommand com = new SqlCommand(query, conn);
                    conn.Open();
                    if (com.ExecuteNonQuery() == 1)
                    {
                        SelectedGridView(dhuc);
                        tb_url.Value = String.Empty;
                    }
                }
            //}
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {

        }
    }
}