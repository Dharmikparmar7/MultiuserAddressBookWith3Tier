using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Session["UserID"] != null)
                FillCountryGridView();
        }
    }

    #region Delete Country
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        CountryBAL balCountry = new CountryBAL();

        balCountry.Delete(Convert.ToInt32(e.CommandArgument.ToString()));

        FillCountryGridView();
    }
    #endregion


    #region Fill Country Gridview
    private void FillCountryGridView()
    {
        CountryBAL balCountry = new CountryBAL();

        gvCountry.DataSource = balCountry.SelectAll(Convert.ToInt32(Session["UserID"].ToString()));

        gvCountry.DataBind();
    }
    #endregion
}