using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactBAL
/// </summary>
public class ContactBAL
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
    public Boolean Insert(ContactENT entContact)
    {
        ContactDAL dalContact = new ContactDAL();

        if (dalContact.Insert(entContact))
        {
            return true;
        }
        else
        {
            Message = dalContact.Message;
            return false;
        }
    }
    #endregion

    #region Update Operation
    public Boolean Update(ContactENT entContact)
    {
        ContactDAL dalContact = new ContactDAL();

        if (dalContact.Update(entContact))
        {
            return true;
        }
        else
        {
            Message = dalContact.Message;
            return false;
        }
    }
    #endregion

    #region Delete Operation
    public Boolean Delete(SqlInt32 ContactID)
    {
        ContactDAL dalContact = new ContactDAL();

        if (dalContact.Delete(ContactID))
        {
            return true;
        }
        else
        {
            Message = dalContact.Message;
            return false;
        }
    }
    #endregion

    #region Select Operation

    #region SelectAll
    public DataTable SelectAll(SqlInt32 UserID)
    {
        ContactDAL dalContact = new ContactDAL();
        return dalContact.SelectAll(UserID);
    }
    #endregion

    #region SelectByPK
    public ContactENT SelectByPK(SqlInt32 ContactID)
    {
        ContactDAL dalContact = new ContactDAL();
        return dalContact.SelectByPK(ContactID);
    }
    #endregion

    #endregion
}