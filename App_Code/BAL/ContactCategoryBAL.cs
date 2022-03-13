using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactCategoryBAL
/// </summary>
public class ContactCategoryBAL 
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
    public Boolean Insert(ContactCategoryENT entContactCategory)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();

        if (dalContactCategory.Insert(entContactCategory))
        {
            return true;
        }
        else
        {
            Message = dalContactCategory.Message;
            return false;
        }
    }
    #endregion

    #region Update Operation
    public Boolean Update(ContactCategoryENT entContactCategory)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();

        if (dalContactCategory.Update(entContactCategory))
        {
            return true;
        }
        else
        {
            Message = dalContactCategory.Message;
            return false;
        }
    }
    #endregion

    #region Delete Operation
    public Boolean Delete(SqlInt32 ContactCategoryID)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();

        if (dalContactCategory.Delete(ContactCategoryID))
        {
            return true;
        }
        else
        {
            Message = dalContactCategory.Message;
            return false;
        }
    }
    #endregion

    #region Select Operation

    #region SelectAll
    public DataTable SelectAll(SqlInt32 UserID)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
        return dalContactCategory.SelectAll(UserID);
    }
    #endregion

    #region Select For Dropdown List
    public DataTable SelectForDropdownList(SqlInt32 UserID)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
        return dalContactCategory.SelectForDropdownList(UserID);
    }
    #endregion

    #region SelectByPK
    public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
        return dalContactCategory.SelectByPK(ContactCategoryID);
    }
    #endregion

    #endregion
}