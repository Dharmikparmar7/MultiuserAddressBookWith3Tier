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

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Register
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        UserMasterENT entUserMaster = new UserMasterENT();

        if (txtFullName.Text.Trim() != "")
            entUserMaster.FullName = txtFullName.Text;

        if (txtUserName.Text.Trim() != "")
            entUserMaster.UserName = txtUserName.Text;

        if (txtPassword.Text.Trim() != "")
            entUserMaster.Password = txtPassword.Text;

        if (txtAddress.Text.Trim() != "")
            entUserMaster.Address = txtAddress.Text;

        if (txtMobileNo.Text.Trim() != "")
            entUserMaster.MobileNo = txtMobileNo.Text;

        if (txtEmail.Text.Trim() != "")
            entUserMaster.Email = txtEmail.Text;

        if (fuImage.HasFile)
            entUserMaster.PhotoPath = "~/Content/Image/" + fuImage.FileName;

        UserMasterBAL balUserMaster = new UserMasterBAL();

        balUserMaster.Insert(entUserMaster);

        fuImage.SaveAs(Server.MapPath(entUserMaster.PhotoPath.ToString()));

        Response.Redirect("~/AddressBook/AdminPanel/Login");

    }
    #endregion
}