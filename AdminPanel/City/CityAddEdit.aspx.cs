using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class AdminPanel_CityAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCityName.Focus();

            if (Session["UserID"] != null)
                CommonFillDropdown.FillCountryDropdown(Convert.ToInt32(Session["UserID"]), ddlCountryID, lblMessage);

            if (Page.RouteData.Values["CityID"] != null)
            {
                LoadControls();
                btnAddCity.Text = "Save";
            }
        }
    }

    #region LoadControls
    private void LoadControls()
    {
        CityBAL balCity = new CityBAL();
        StateBAL balState = new StateBAL();

        CityENT entCity = new CityENT();
        StateENT entState = new StateENT();

        entCity = balCity.SelectByPK(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["CityID"].ToString())));

        txtCityName.Text = entCity.CityName.ToString();
        txtPincode.Text = entCity.Pincode.ToString();
        txtSTDCode.Text = entCity.StateID.ToString();
        ddlStateID.SelectedValue = entCity.StateID.ToString();

        entState = balState.SelectByPK(entCity.StateID);

        ddlCountryID.SelectedValue = entState.CountryID.ToString();

        CommonFillDropdown.FillStateDropdown(Convert.ToInt32(Session["UserID"]), ddlStateID, lblMessage, Convert.ToInt32((ddlCountryID.SelectedValue)));
    }
    #endregion LoadControls


    #region Add and Edit
    protected void btnAddCity_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += "Select Country <br/>";

        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += "Select State<br/>";

        if (txtCityName.Text.Trim() == "")
            strErrorMessage += "Enter City Name<br/>";

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        CityENT entCity = new CityENT();

        #region Gather Information
        if (ddlStateID.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlStateID.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (txtPincode.Text.Trim() != "")
            entCity.Pincode = txtPincode.Text.Trim();

        if (txtSTDCode.Text.Trim() != "")
            entCity.STDCode = txtSTDCode.Text.Trim();
        #endregion Gather Information

        CityBAL balCity = new CityBAL();

        if (Page.RouteData.Values["CityID"] != null)
        {
            entCity.CityID = Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["CityID"].ToString()));

            balCity.Update(entCity);

            Response.Redirect("~/AddressBook/AdminPanel/City/Display");
        }
        else
        {
            entCity.UserID = Convert.ToInt32(Session["UserID"].ToString());

            balCity.Insert(entCity);

            lblMessage.Text = "Data Inserted Successfully";
            txtCityName.Text = "";
            txtPincode.Text = "";
            txtSTDCode.Text = "";

            ddlCountryID.SelectedIndex = 0;
            ddlStateID.Items.Clear();
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
        }
    }
    #endregion

    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFillDropdown.FillStateDropdown(Convert.ToInt32(Session["UserID"]), ddlStateID, lblMessage, Convert.ToInt32((ddlCountryID.SelectedValue)));

        lblMessage.Text = "";
    }

    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
    }
}