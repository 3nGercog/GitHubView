using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Octokit;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace WebAppGitHubView
{
    public partial class Default : System.Web.UI.Page
    {
        //HtmlTextWriter writer;
        GitHubClient github;
        string nameUser;
        string passwordUser;
        GridView grid;
        IPStatus status;
        RepositorysInfo info;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.8.2.min.js"
            });
            if (IsPostBack)
            {
                nameUser = Request.Form["ctl00$default$text"];
                passwordUser = Request.Form["ctl00$default$password"];
            
                Ping p = new Ping();
                PingReply pr = p.Send(@"github.com");
                status = pr.Status;
            }
        }

        private void DisplayControl(ControlCollection controls, int depth)
        {
            foreach (Control control in controls)
            {
                // Количество отступов в представлении дерева элементов управления
                Response.Write(new String('-', depth * 4) + "> ");

                // Отобразить элемент управления
                Response.Write(control.GetType().ToString() + " - <b>" +
                  control.ID + "</b><br />");

                if (control.Controls != null)
                {
                    DisplayControl(control.Controls, depth + 1);
                }
            }
        }


        protected async void text_Click(object sender, EventArgs e)
        {
            if (status == IPStatus.Success && !String.IsNullOrEmpty(nameUser) && !String.IsNullOrEmpty(passwordUser))
            {
                try
                {
                    github = new GitHubClient(new ProductHeaderValue("test")) { Credentials = new Credentials(nameUser, passwordUser) };
                    Session["GitHub"] = github;
                    var user = await github.User.Get(nameUser);

                    var repositorys = await github.Repository.GetAllForCurrent();

                    htmlImg.Visible = true;
                    htmlImg.ImageUrl = user.AvatarUrl;
                    var repositorysCount = repositorys.Count;
                    tableRepos.Visible = true;
                    tableRepos.ViewStateMode = System.Web.UI.ViewStateMode.Enabled;
                    Page.Title = "Repository Page";

                    int countRow = (repositorysCount % 2 == 0) ? repositorysCount / 2 : repositorysCount / 2 + 1;
                    int endCell = (repositorysCount % 2 == 0) ? 2 : 1;
                    TableRow row; TableCell cell; DataTable dt;
                    int cellCount = 0;
                    for (int i = 0; i < countRow; i++)
                    {
                        row = new TableRow();
                        row.ID = "rowRepos" + i;
                        for (int k = 0; k < 2; k++)
                        {
                            cell = new TableCell();
                            cell.ID = "cellRepos" + cellCount;

                            grid = new GridView();
                            grid.ID = "GridView" + cellCount;
                            grid.Attributes.Add("class", "tableCellRepository");
                            grid.Attributes.Add("onclick", "cell_Click(this)");

                            GetInfoRepositorys(repositorys, cellCount++);

                            cell.Attributes.Add("class", "cellRepository");
                            //cell.Attributes.Add("onclick", "cell_Click(this)");
                            dt = new DataTable();
                            DataColumn col1 = new DataColumn("First", typeof(string));
                            DataColumn col2 = new DataColumn("Second", typeof(string));
                            dt.Columns.Add(col1);
                            dt.Columns.Add(col2);
                            DataRow dRow = null;

                            for (int first = 0; first < info.FirstColum.Length; first++)
                            {
                                if (first == 0)
                                {//repository = info.SecondColum[first];
                                }
                                dRow = dt.NewRow();
                                dRow["First"] = info.FirstColum[first];
                                dRow["Second"] = info.SecondColum[first];
                                dt.Rows.Add(dRow);
                            }


                            grid.RowDataBound += grid_RowDataBound;
                            grid.DataSource = dt;
                            grid.DataBind();
                            grid.AutoGenerateColumns = true;

                            cell.Controls.Add(grid);

                            if (endCell == 1 && i == countRow - 1 && k == 1)
                                break;
                            row.Cells.Add(cell);
                        }
                        tableRepos.Rows.Add(row);
                    }
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }
              
            }
            else if (String.IsNullOrEmpty(nameUser))
                Response.Write("НЕТ такого юзера!");
            else if (String.IsNullOrEmpty(passwordUser))
                Response.Write("Пароль не верен!");
            else
                Response.Write("НЕТ подключения к интернету!");
        }

        void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.BackColor = System.Drawing.Color.Bisque;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                TableCell tableCell = new TableCell();

                tableCell.Attributes["ColSpan"] =
                    grid.Columns.Count.ToString();

                tableCell.BackColor = System.Drawing.Color.Chocolate;
                

                GridViewRow gridViewRow = new GridViewRow(-1, -1,
                    DataControlRowType.DataRow,
                        DataControlRowState.Alternate);

                gridViewRow.Cells.Add(tableCell);

                Table table = e.Row.Parent as Table;

                table.Controls.AddAt(grid.Controls[0].Controls.Count, gridViewRow);
            }
        }

        private void GetInfoRepositorys(IReadOnlyList<Repository> repositorys, int cell)
        {
            string description = "";
            for (int i = 0; i < repositorys.Count; i++)
            {
                if (i == cell)
                {
                    description = repositorys[i].Description;
                    if (description == "")
                        description = "No description!";
                    info = new RepositorysInfo(repositorys[i].Name, repositorys[i].FullName, description, 
                        repositorys[i].HtmlUrl, repositorys[i].Id, repositorys[i].CreatedAt.DateTime);
                }
            }
        }
    }
}