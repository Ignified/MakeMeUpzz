using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Viewss
{
    public partial class ManageMakeupPage : System.Web.UI.Page
    {
        List<Makeup> makeups = new List<Makeup>();
        List<MakeupType> makeupTypes = new List<MakeupType>();
        List<MakeupBrand> makeupBrands = new List<MakeupBrand>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ManageMakeupView.Visible = false;

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                User user = new User();
                Application["user_count"] = 1;
                if (Session["user"] == null)
                {
                    int userID = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    user = UserHandler.FindUserbyID(userID);
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }
                if (user.UserRole.Equals("Admin"))
                {
                    makeups = MakeupHandler.GetAllMakeups();
                    MakeupGV.DataSource = makeups;
                    MakeupGV.DataBind();

                    makeupTypes = MakeupHandler.GetAllMakeupTypes();
                    MakeupTypeGV.DataSource = makeupTypes;
                    MakeupTypeGV.DataBind();

                    makeupBrands = MakeupHandler.GetAllMakeupBrands();
                    BindMakeupBrandGrid("MakeupBrandRating", SortDirection.Descending);

                    ManageMakeupView.Visible = true;
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        private void BindMakeupBrandGrid(string sortExpression = null, SortDirection sortDirection = SortDirection.Ascending)
        {
            var data = makeupBrands;

            if (!string.IsNullOrEmpty(sortExpression))
            {
                var prop = typeof(MakeupBrand).GetProperty(sortExpression);
                if (sortDirection == SortDirection.Ascending)
                {
                    data = data.OrderBy(x => prop.GetValue(x, null)).ToList();
                }
                else
                {
                    data = data.OrderByDescending(x => prop.GetValue(x, null)).ToList();
                }
            }

            MakeupBrandGV.DataSource = data;
            MakeupBrandGV.DataBind();
        }

        protected void MakeupBrandGV_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = GetSortDirection(e.SortExpression);
            BindMakeupBrandGrid(e.SortExpression, sortDirection);
        }

        private SortDirection GetSortDirection(string column)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null && sortExpression == column)
            {
                SortDirection lastDirection = (SortDirection)ViewState["SortDirection"];
                if (lastDirection == SortDirection.Ascending)
                {
                    sortDirection = SortDirection.Descending;
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void InsertMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupPage.aspx");
        }

        protected void InsertMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupTypePage.aspx");
        }

        protected void InsertMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupBrandPage.aspx");
        }

        protected void MakeupGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            MakeupHandler.RemoveMakeupByID(id);
            makeups = MakeupHandler.GetAllMakeups();
            MakeupGV.DataSource = makeups;
            MakeupGV.DataBind();
        }

        protected void MakeupGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupGV.Rows[e.NewEditIndex];
            int MakeupID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupPage.aspx?id=" + MakeupID);
        }

        protected void MakeupTypeGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupTypeGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            MakeupHandler.RemoveMakeupTypeByID(id);
            makeupTypes = MakeupHandler.GetAllMakeupTypes();
            MakeupTypeGV.DataSource = makeupTypes;
            MakeupTypeGV.DataBind();
        }

        protected void MakeupTypeGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupTypeGV.Rows[e.NewEditIndex];
            int MakeupTypeID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupTypePage.aspx?id=" + MakeupTypeID);
        }

        protected void MakeupBrandGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupBrandGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            MakeupHandler.RemoveMakeupBrandByID(id);
            makeupBrands = MakeupHandler.GetAllMakeupBrands();
            MakeupBrandGV.DataSource = makeupBrands;
            MakeupBrandGV.DataBind();
        }

        protected void MakeupBrandGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupBrandGV.Rows[e.NewEditIndex];
            int MakeupBrandID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupBrandPage.aspx?id=" + MakeupBrandID);
        }
    }
}