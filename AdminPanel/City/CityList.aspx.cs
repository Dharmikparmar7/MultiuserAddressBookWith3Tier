using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
                FillCityGridView();
        }
    }
    
    #region Delete City
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        CityBAL balCity = new CityBAL();

        balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString()));

        FillCityGridView();
    }
    #endregion

    #region Fill City GridView
    private void FillCityGridView()
    {
        CityBAL balCity = new CityBAL();

        gvCity.DataSource = balCity.SelectAll(Convert.ToInt32(Session["UserID"]));

        gvCity.DataBind();
    }
    #endregion
}