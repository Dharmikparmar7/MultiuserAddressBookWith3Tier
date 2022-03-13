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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCCName.Focus();

            if (Page.RouteData.Values["ContactCategoryID"] != null)
            {
                btnAdd.Text = "Save";
                LoadControls();
            }
        }
    }

    #region Load Controls
    protected void LoadControls()
    {
        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        entContactCategory = balContactCategory.SelectByPK(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString())));

        txtCCName.Text = entContactCategory.ContactCategoryName.ToString();
    }
    #endregion

    #region Add and Edit
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (txtCCName.Text.Trim() == "")
        {
            strErrorMessage = "Enter Contact Category Name<br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion

        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        #region Gather Information
        if (txtCCName.Text.Trim() != "")
        {
            entContactCategory.ContactCategoryName = txtCCName.Text.Trim();
        }
        #endregion Gather Information

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        if (Page.RouteData.Values["ContactCategoryID"] != null)
        {
            entContactCategory.ContactCategoryID = Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString()));

            balContactCategory.Update(entContactCategory);

            Response.Redirect("~/AddressBook/AdminPanel/ContactCategory/Display");
        }
        else
        {
            if (Session["UserID"] != null)
                entContactCategory.UserID = Convert.ToInt32(Session["UserID"].ToString());

            balContactCategory.Insert(entContactCategory);

            lblMessage.Text = "Data Inserted Successfully";

            txtCCName.Text = "";
        }
    }
    #endregion
}