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


public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtContactName.Focus();

            if (Session["UserID"] != null)
            {
                CommonFillDropdown.FillContactCategoryList(Convert.ToInt32(Session["UserID"]), cblContactCategoryID, lblMessage);

                CommonFillDropdown.FillCountryDropdown(Convert.ToInt32(Session["UserID"]), ddlCountryID, lblMessage);
            }

            if (Page.RouteData.Values["ContactID"] != null)
            {
                LoadControls();
                LoadContactCategoryCheckbox();
                btnAdd.Text = "Save";
            }
        }
    }

    #region Select Contact Category Checkbox
    protected void LoadContactCategoryCheckbox()
    {
        ContactBAL balContact = new ContactBAL();

        DataTable dt = new DataTable();

        dt = balContact.SelectForCheckBoxList(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString())));

        foreach (DataRow row in dt.Rows)
        {
            cblContactCategoryID.Items.FindByValue(row["ContactCategoryID"].ToString()).Selected = true;
        }
    }
    #endregion

    #region Add and Edit
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (ddlCityID.SelectedItem.Text == "Select City")
        {
            strErrorMessage += "Select City<br/>";
        }
        if (ddlStateID.SelectedItem.Text == "Select State")
        {
            strErrorMessage += "Select State<br/>";
        }
        if (ddlCountryID.SelectedItem.Text == "Select Country")
        {
            strErrorMessage += "Select Country<br/>";
        }
        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "Enter Contact Name<br/>";
        }
        if (txtMobile.Text.Trim() == "")
        {
            strErrorMessage += "Enter Mobile Number<br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        ContactENT entContact = new ContactENT();

        #region Gather Information

        if (ddlCityID.SelectedIndex > 0)
        {
            entContact.CityID = Convert.ToInt32(ddlCityID.SelectedValue);
        }
        if (ddlStateID.SelectedIndex > 0)
        {
            entContact.StateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (ddlCountryID.SelectedIndex > 0)
        {
            entContact.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (txtContactName.Text.Trim() != "")
        {
            entContact.ContactName = txtContactName.Text.Trim();
        }
        if (txtMobile.Text.Trim() != "")
        {
            entContact.MobileNo = txtMobile.Text.Trim();
        }
        if (txtAddress.Text.Trim() != "")
        {
            entContact.Address = txtAddress.Text.Trim();
        }
        if (txtEmail.Text.Trim() != "")
        {
            entContact.EmailAddress = txtEmail.Text.Trim();
        }
        if (txtPincode.Text.Trim() != "")
        {
            entContact.Pincode = txtPincode.Text.Trim();
        }
        #endregion

        ContactBAL balContact = new ContactBAL();


        if (Page.RouteData.Values["ContactID"] != null)
        {
            int ContactID = Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString()));

            entContact.ContactID = ContactID;

            if (balContact.Update(entContact))
            {

                foreach (ListItem li in cblContactCategoryID.Items)
                {
                    if (li.Selected)
                    {
                        InsertContactCategory(ContactID, Convert.ToInt32(li.Value));
                    }
                    else
                    {
                        DeleteContactCategory(ContactID, Convert.ToInt32(li.Value));
                    }
                }

                Response.Redirect("~/AddressBook/AdminPanel/Contact/Display");
            }
            else
                lblMessage.Text = balContact.Message;

        }
        else
        {
            if (Session["UserID"] != null)
                entContact.UserID = Convert.ToInt32(Session["UserID"].ToString());

            if (balContact.Insert(entContact))
            {

                foreach (ListItem li in cblContactCategoryID.Items)
                {
                    if (li.Selected)
                    {
                        InsertContactCategory(Convert.ToInt32(entContact.ContactID.ToString()), Convert.ToInt32(li.Value));
                    }
                }

                lblMessage.Text = "Data Inserted Successfully";

                txtContactName.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
                txtPincode.Text = "";

                ddlCountryID.SelectedIndex = 0;

                ddlStateID.Items.Clear();

                ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
                ddlStateID.SelectedValue = "-1";

                ddlCityID.Items.Clear();

                ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
                ddlCityID.SelectedValue = "-1";

                cblContactCategoryID.ClearSelection();
            }
            else
                lblMessage.Text = balContact.Message;

        }
    }
    #endregion

    #region Insert Contact Category
    protected void InsertContactCategory(Int32 ContactID, Int32 ContactCategoryID)
    {
        ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();

        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();

        entContactWiseContactCategory.ContactID = ContactID;

        entContactWiseContactCategory.ContactCategoryID = ContactCategoryID;

        if(!balContactWiseContactCategory.Insert(entContactWiseContactCategory))
        {
            lblMessage.Text = balContactWiseContactCategory.Message;
        }
    }
    #endregion

    #region Delete ContactCategory
    protected void DeleteContactCategory(Int32 ContactID, Int32 ContactCategoryID)
    {
        ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();

        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();

        entContactWiseContactCategory.ContactID = ContactID;

        entContactWiseContactCategory.ContactCategoryID = ContactCategoryID;

        if(!balContactWiseContactCategory.Delete(ContactID, ContactCategoryID))
            lblMessage.Text = balContactWiseContactCategory.Message;
    }
    #endregion

    #region LoadControl
    private void LoadControls()
    {
        ContactENT entContact = new ContactENT();
        ContactBAL balContact = new ContactBAL();

        entContact = balContact.SelectByPK(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString())));

        if (!entContact.ContactName.IsNull)
            txtContactName.Text = entContact.ContactName.ToString();

        if (!entContact.Address.IsNull)
            txtAddress.Text = entContact.Address.ToString();

        if (!entContact.EmailAddress.IsNull)
            txtEmail.Text = entContact.EmailAddress.ToString();

        if (!entContact.MobileNo.IsNull)
            txtMobile.Text = entContact.MobileNo.ToString();

        if (!entContact.Pincode.IsNull)
            txtPincode.Text = entContact.Pincode.ToString();

        if (!entContact.CountryID.IsNull)
            ddlCountryID.SelectedValue = entContact.CountryID.ToString();

        CommonFillDropdown.FillStateDropdown(Convert.ToInt32(Session["UserID"]), ddlStateID, lblMessage, Convert.ToInt32((entContact.CountryID.ToString())));

        if(!entContact.StateID.IsNull)
            ddlStateID.SelectedValue = entContact.StateID.ToString();

        CommonFillDropdown.FillCityDropdown(Convert.ToInt32(Session["UserID"]), ddlCityID, lblMessage, Convert.ToInt32((entContact.StateID.ToString())));

        if (!entContact.CityID.IsNull)
            ddlCityID.SelectedValue = entContact.CityID.ToString();
    }
    #endregion

    protected void ddlCountryID_TextChanged(object sender, EventArgs e)
    {
        if (ddlCountryID.SelectedIndex == 0)
        {
            ddlStateID.Items.Clear();
            ddlCityID.Items.Clear();

            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            ddlStateID.SelectedValue = "-1";

            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
            ddlCityID.SelectedValue = "-1";
            return;
        }

        CommonFillDropdown.FillStateDropdown(Convert.ToInt32(Session["UserID"]), ddlStateID, lblMessage, Convert.ToInt32((ddlCountryID.SelectedValue)));

        ddlCityID.Items.Clear();
        ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
        ddlCityID.SelectedValue = "-1";

        lblMessage.Text = "";
    }

    protected void ddlStateID_TextChanged(object sender, EventArgs e)
    {
        CommonFillDropdown.FillCityDropdown(Convert.ToInt32(Session["UserID"]), ddlCityID, lblMessage, Convert.ToInt32((ddlStateID.SelectedValue)));

        lblMessage.Text = "";
    }

    protected void ddlContactCategoryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
    }

    protected void ddlCityID_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
    }
}