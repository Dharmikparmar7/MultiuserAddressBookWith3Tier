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
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

            if(balContactCategory.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
                FillContactCategoryGridview();
            else
                lblMessage.Text = balContactCategory.Message;
        }
    }
    #endregion

    #region Fill Contact Category Gridview
    private void FillContactCategoryGridview()
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        DataTable dt = new DataTable();
        
        dt = balContactCategory.SelectAll(Convert.ToInt32(Session["UserID"]));

        if (dt != null && dt.Rows.Count > 0)
        {
            gvContactCategory.DataSource = dt;

            gvContactCategory.DataBind();
        }

    }
    #endregion
}