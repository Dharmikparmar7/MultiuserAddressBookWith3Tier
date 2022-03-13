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

public partial class AdminPanel_StateAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStateName.Focus();

            CommonFillDropdown.FillCountryDropdown(Convert.ToInt32(Session["UserID"]), ddlCountryID, lblMessage);

            if (Page.RouteData.Values["StateID"] != null)
            {
                btnAdd.Text = "Save";

                LoadControls();
            }
        }
    }

    #region LoadControls
    private void LoadControls()
    {
        StateBAL balState = new StateBAL();

        StateENT entState = new StateENT();

        entState = balState.SelectByPK(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["StateID"].ToString())));

        txtStateName.Text = entState.StateName.ToString();

        ddlCountryID.SelectedValue = entState.CountryID.ToString();
    }
    #endregion


    #region Add and Edit
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (txtStateName.Text.Trim() == "")
        {
            strErrorMessage += "Enter State Name";
        }
        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "Select Country";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        StateENT entState = new StateENT();

        #region Gather Information
        if (ddlCountryID.SelectedIndex > 0)
        {
            entState.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (txtStateName.Text.Trim() != "")
        {
            entState.StateName = txtStateName.Text.Trim();
        }
        #endregion Gather Information
        
        StateBAL balState = new StateBAL();

        if (Page.RouteData.Values["StateID"] != null)
        {
            entState.StateID = Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["StateID"].ToString()));

            balState.Update(entState);

            Response.Redirect("~/AddressBook/AdminPanel/State/Display");
        }
        else
        {
            entState.UserID = Convert.ToInt32(Session["UserID"].ToString());

            balState.Insert(entState);

            lblMessage.Text = "Data Inserted Successfully";

            txtStateName.Text = "";

            ddlCountryID.SelectedIndex = 0;
        }

    }
    #endregion


    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
    }
}