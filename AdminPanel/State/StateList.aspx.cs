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

        if(balState.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
            FillStateGridView();
        else
            lblMessage.Text = balState.Message;

    }
    #endregion

    #region Fill State GridView
    private void FillStateGridView()
    {
        StateBAL balState = new StateBAL();

        DataTable dt = new DataTable();

        dt = balState.SelectAll(Convert.ToInt32(Session["UserID"].ToString()));

        if (dt != null && dt.Rows.Count > 0)
        {
            gvState.DataSource = dt;
            gvState.DataBind();

        }
    }
    #endregion
}