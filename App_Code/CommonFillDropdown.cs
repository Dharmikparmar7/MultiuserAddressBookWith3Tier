using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class CommonFillDropdown
{
    #region Fill Country Dropdown
    public static void FillCountryDropdown(Int32 UserID, DropDownList ddlCountryID, Label lblMessage)
    {
        CountryBAL balCountry = new CountryBAL();

        DataTable dt = balCountry.SelectForDropdownList(UserID);

        ddlCountryID.DataSource = dt.CreateDataReader();

        ddlCountryID.DataTextField = "CountryName";

        ddlCountryID.DataValueField = "CountryID";

        ddlCountryID.DataBind();

        ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
    }
    #endregion

    public static void FillStateDropdown(Int32 UserID, DropDownList ddlStateID, Label lblMessage, Int32 CountryID)
    {
        StateBAL balState = new StateBAL();

        ddlStateID.DataSource = balState.SelectForDropdownList(CountryID, UserID).CreateDataReader();

        ddlStateID.DataTextField = "StateName";

        ddlStateID.DataValueField = "StateID";

        ddlStateID.DataBind();

        ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
    }

    public static void FillCityDropdown(Int32 UserID, DropDownList ddlCityID, Label lblMessage, Int32 StateID)
    {
        CityBAL balCity = new CityBAL();

        ddlCityID.DataSource = balCity.SelectForDropdownList(StateID, UserID).CreateDataReader();

        ddlCityID.DataTextField = "CityName";

        ddlCityID.DataValueField = "CityID";

        ddlCityID.DataBind();

        ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
    }

    public static void FillContactCategoryList(Int32 UserID, CheckBoxList cblContactCategoryID, Label lblMessage)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        cblContactCategoryID.DataSource = balContactCategory.SelectAll(UserID).CreateDataReader();

        cblContactCategoryID.DataTextField = "ContactCategoryName";

        cblContactCategoryID.DataValueField = "ContactCategoryID";

        cblContactCategoryID.DataBind();
    }
}