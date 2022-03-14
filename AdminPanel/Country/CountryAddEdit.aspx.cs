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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCountryName.Focus();

            if (Page.RouteData.Values["CountryID"] != null)
            {
                btnAdd.Text = "Save";
                LoadControls();
            }
        }
    }

    #region Load Controls
    protected void LoadControls()
    {
        CountryBAL balCountry = new CountryBAL();

        CountryENT entCountry = new CountryENT();

        entCountry = balCountry.SelectByPK(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["CountryID"].ToString())));

        if (!entCountry.CountryName.IsNull)
            txtCountryName.Text = entCountry.CountryName.ToString();

        if (!entCountry.CountryCode.IsNull)
            txtCountryCode.Text = entCountry.CountryCode.ToString();
    }
    #endregion

    #region Add and Edit
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "Enter Country Name <br/>";
        }

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        CountryENT entCountry = new CountryENT();

        #region Gather Information
        if (txtCountryName.Text.Trim() != "")
        {
            entCountry.CountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text.Trim() != "")
        {
            entCountry.CountryCode = txtCountryCode.Text.Trim();
        }
        #endregion Gather Information

        CountryBAL balCountry = new CountryBAL();

        if (Page.RouteData.Values["CountryID"] != null)
        {
            entCountry.CountryID = Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["CountryID"].ToString()));

            if (balCountry.Update(entCountry))
                Response.Redirect("~/AddressBook/AdminPanel/Country/Display");
            else
                lblMessage.Text = balCountry.Message;

        }
        else
        {
            entCountry.UserID = Convert.ToInt32(Session["UserID"].ToString());

            if (balCountry.Insert(entCountry))
            {
                lblMessage.Text = "Data Inserted Successfully";

                txtCountryCode.Text = "";
                txtCountryName.Text = "";
            }
            else
                lblMessage.Text = balCountry.Message;

        }
    }
    #endregion
}
