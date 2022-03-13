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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUserName.Focus();
    }

    #region Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlString Username = SqlString.Null;
        SqlString Password = SqlString.Null;

        if (txtUserName.Text.Trim() != "")
            Username = txtUserName.Text;

        if (txtPassword.Text.Trim() != "")
            Password = txtPassword.Text;

        UserMasterBAL balUserMaster = new UserMasterBAL();

        DataTable dtUser = new DataTable();

        dtUser = balUserMaster.SelectByUserNamePassword(Username, Password);

        if (dtUser != null && dtUser.Rows.Count > 0)
        {
            foreach (DataRow drUser in dtUser.Rows)
            {
                if (!drUser["UserID"].Equals(DBNull.Value))
                {
                    Session["UserID"] = drUser["UserID"].ToString();
                }
                if (!drUser["FullName"].Equals(DBNull.Value))
                {
                    Session["FullName"] = drUser["FullName"].ToString();
                }
                if (!drUser["PhotoPath"].Equals(DBNull.Value))
                {
                    Session["ImgProfile"] = drUser["PhotoPath"].ToString();
                }

                break;
            }
            Response.Redirect("~/AddressBook/AdminPanel/Contact/Display");
        }
        else
        {
            lblMessage.Text = "Username or Password is not valid";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtUserName.Focus();
        }
    }
    #endregion
}