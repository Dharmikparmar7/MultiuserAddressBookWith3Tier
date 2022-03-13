using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for UserMasterBAL
/// </summary>
public class UserMasterBAL 
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
    public Boolean Insert(UserMasterENT entUserMaster)
    {
        UserMasterDAL dalUserMaster = new UserMasterDAL();

        if (dalUserMaster.Insert(entUserMaster))
        {
            return true;
        }
        else
        {
            Message = dalUserMaster.Message;
            return false;
        }
    }
    #endregion

    #region Update Operation
    public Boolean Update(UserMasterENT entUserMaster)
    {
        UserMasterDAL dalUserMaster = new UserMasterDAL();

        if (dalUserMaster.Update(entUserMaster))
        {
            return true;
        }
        else
        {
            Message = dalUserMaster.Message;
            return false;
        }
    }
    #endregion

    #region Delete Operation
    public Boolean Delete(SqlInt32 UserMasterID)
    {
        UserMasterDAL dalUserMaster = new UserMasterDAL();

        if (dalUserMaster.Delete(UserMasterID))
        {
            return true;
        }
        else
        {
            Message = dalUserMaster.Message;
            return false;
        }
    }
    #endregion

    #region Select Operation

    #region SelectAll
    public DataTable SelectAll()
    {
        UserMasterDAL dalUserMaster = new UserMasterDAL();
        return dalUserMaster.SelectAll();
    }
    #endregion

    #region Select For Dropdown List
    public DataTable SelectForDropdownList()
    {
        UserMasterDAL dalUserMaster = new UserMasterDAL();
        return dalUserMaster.SelectForDropdownList();
    }
    #endregion

    #region SelectBy Username and Password
    public DataTable SelectByUserNamePassword(SqlString Username, SqlString Password)
    {
        UserMasterDAL dalUserMaster = new UserMasterDAL();
        return dalUserMaster.SelectByUserNamePassword(Username, Password);
    }
    #endregion

    #endregion
}