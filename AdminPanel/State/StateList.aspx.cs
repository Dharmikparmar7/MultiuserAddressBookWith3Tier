using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
                FillStateGridView();
        }
    }
    #endregion

    #region Delete State
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        StateBAL balState = new StateBAL();

        balState.Delete(Convert.ToInt32(e.CommandArgument.ToString()));

        FillStateGridView();
    }
    #endregion

    #region Fill State GridView
    private void FillStateGridView()
    {
        StateBAL balState = new StateBAL();

        gvState.DataSource = balState.SelectAll(Convert.ToInt32(Session["UserID"].ToString()));

        gvState.DataBind();
    }
    #endregion
}