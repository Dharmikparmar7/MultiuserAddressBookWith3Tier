using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactWiseContactCategoryBAL
/// </summary>
public class ContactWiseContactCategoryBAL 
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
    public Boolean Insert(ContactWiseContactCategoryENT entContactWiseContactCategory)
    {
        ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();

        if (dalContactWiseContactCategory.Insert(entContactWiseContactCategory))
        {
            return true;
        }
        else
        {
            Message = dalContactWiseContactCategory.Message;
            return false;
        }
    }
    #endregion

    #region Update Operation
    public Boolean Update(ContactWiseContactCategoryENT entContactWiseContactCategory)
    {
        ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();

        if (dalContactWiseContactCategory.Update(entContactWiseContactCategory))
        {
            return true;
        }
        else
        {
            Message = dalContactWiseContactCategory.Message;
            return false;
        }
    }
    #endregion

    #region Delete Operation
    public Boolean Delete(SqlInt32 ContactID, SqlInt32 ContactWiseContactCategoryID)
    {
        ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();

        if (dalContactWiseContactCategory.Delete(ContactID ,ContactWiseContactCategoryID))
        {
            return true;
        }
        else
        {
            Message = dalContactWiseContactCategory.Message;
            return false;
        }
    }
    #endregion

    #region Select Operation

    #region SelectAll
    public DataTable SelectAll()
    {
        ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
        return dalContactWiseContactCategory.SelectAll();
    }
    #endregion

    #region Select For Dropdown List
    public DataTable SelectForDropdownList()
    {
        ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
        return dalContactWiseContactCategory.SelectForDropdownList();
    }
    #endregion

    #region SelectByPK
    public ContactWiseContactCategoryENT SelectByPK(SqlInt32 ContactWiseContactCategoryID)
    {
        ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
        return dalContactWiseContactCategory.SelectByPK(ContactWiseContactCategoryID);
    }
    #endregion

    #endregion
}