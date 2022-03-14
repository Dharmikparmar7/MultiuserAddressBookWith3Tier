using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
                FillContactGridView();
        }
    }

    #region Delete Contact
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            ContactBAL balContact = new ContactBAL();

            balContact.Delete(Convert.ToInt32(e.CommandArgument.ToString()));

            FillContactGridView();
        }
    }
    #endregion

    #region Fill Contact GridView
    private void FillContactGridView()
    {
        DataTable dt = new DataTable();

        ContactBAL balContact = new ContactBAL();

        dt = balContact.SelectAll(Convert.ToInt32(Session["UserID"]));

        if (dt != null && dt.Rows.Count > 0)
        {
            gvContact.DataSource = dt;

            gvContact.DataBind();
        }

    }
    #endregion
}

//Adiths
//JarvisLite
//Certificate