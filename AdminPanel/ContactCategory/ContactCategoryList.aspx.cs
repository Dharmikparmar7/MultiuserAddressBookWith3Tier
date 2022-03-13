using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_Category_ContactCategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
                FillContactCategoryGridview();
        }
    }

    #region Delete Contact Category
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        balContactCategory.Delete(Convert.ToInt32(e.CommandArgument.ToString()));

        FillContactCategoryGridview();
    }
    #endregion

    #region Fill Contact Category Gridview
    private void FillContactCategoryGridview()
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        gvContactCategory.DataSource = balContactCategory.SelectAll(Convert.ToInt32(Session["UserID"]));

        gvContactCategory.DataBind();
    }
    #endregion
}