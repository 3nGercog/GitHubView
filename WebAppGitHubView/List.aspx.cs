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
            tb_url.Disabled = true;
            btRemove.Enabled = false;
            btEdit.Enabled = false;
            if (!IsPostBack)
            {
                dhuc = new GitHubUrlContext();
                SelectedGridView(dhuc);     
            }
            if (IsPostBack)
            {
                reg = new Regex(pattern);
            }
        }

        private void SelectedGridView(GitHubUrlContext gitHubUrlContext)
        {
            SqlDataSourceUrl.ConnectionString = gitHubUrlContext.Database.Connection.ConnectionString;
            SqlDataSourceUrl.SelectCommand = "SELECT * FROM [URLS]";
            GridViewUrl.DataSourceID = SqlDataSourceUrl.ID;
            dhuc.Dispose();
        }
        protected void btAdd_Click(object sender, EventArgs e)
        {
            tb_url.Disabled = false;

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
                    }
                }
            }
        }

        protected void btRemove_Click(object sender, EventArgs e)
        {

        }

        protected void btEdit_Click(object sender, EventArgs e)
        {

        }
    }
}