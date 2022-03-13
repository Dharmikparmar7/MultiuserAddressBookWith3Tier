using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for StateBAL
/// </summary>
public class StateBAL 
{
	#region Local Variables
    private string _Message;

    public string Message
    {
        get
        {
            return _Message;
        }
        set
        {
            _Message = value;
        }
    }
    #endregion

    #region Insert Operation
    public Boolean Insert(StateENT entState)
    {
        StateDAL dalState = new StateDAL();

        if (dalState.Insert(entState))
        {
            return true;
        }
        else
        {
            Message = dalState.Message;
            return false;
        }
    }
    #endregion

    #region Update Operation
    public Boolean Update(StateENT entState)
    {
        StateDAL dalState = new StateDAL();

        if (dalState.Update(entState))
        {
            return true;
        }
        else
        {
            Message = dalState.Message;
            return false;
        }
    }
    #endregion

    #region Delete Operation
    public Boolean Delete(SqlInt32 StateID)
    {
        StateDAL dalState = new StateDAL();

        if (dalState.Delete(StateID))
        {
            return true;
        }
        else
        {
            Message = dalState.Message;
            return false;
        }
    }
    #endregion

    #region Select Operation

    #region SelectAll
    public DataTable SelectAll(SqlInt32 UserID)
    {
        StateDAL dalState = new StateDAL();
        return dalState.SelectAll(UserID);
    }
    #endregion

    #region Select For Dropdown List
    public DataTable SelectForDropdownList(SqlInt32 CountryID, SqlInt32 UserID)
    {
        StateDAL dalState = new StateDAL();
        return dalState.SelectForDropdownList(CountryID, UserID);
    }
    #endregion

    #region SelectByPK
    public StateENT SelectByPK(SqlInt32 StateID)
    {
        StateDAL dalState = new StateDAL();
        return dalState.SelectByPK(StateID);
    }
    #endregion

    #endregion
}