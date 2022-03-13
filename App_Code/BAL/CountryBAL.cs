using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for CountryBAL
/// </summary>
public class CountryBAL 
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
    public Boolean Insert(CountryENT entCountry)
    {
        CountryDAL dalCountry = new CountryDAL();

        if (dalCountry.Insert(entCountry))
        {
            return true;
        }
        else
        {
            Message = dalCountry.Message;
            return false;
        }
    }
    #endregion

    #region Update Operation
    public Boolean Update(CountryENT entCountry)
    {
        CountryDAL dalCountry = new CountryDAL();

        if (dalCountry.Update(entCountry))
        {
            return true;
        }
        else
        {
            Message = dalCountry.Message;
            return false;
        }
    }
    #endregion

    #region Delete Operation
    public Boolean Delete(SqlInt32 CountryID)
    {
        CountryDAL dalCountry = new CountryDAL();

        if (dalCountry.Delete(CountryID))
        {
            return true;
        }
        else
        {
            Message = dalCountry.Message;
            return false;
        }
    }
    #endregion

    #region Select Operation

    #region SelectAll
    public DataTable SelectAll(SqlInt32 UserID)
    {
        CountryDAL dalCountry = new CountryDAL();
        return dalCountry.SelectAll(UserID);
    }
    #endregion

    #region Select For Dropdown List
    public DataTable SelectForDropdownList(SqlInt32 UserID)
    {
        CountryDAL dalCountry = new CountryDAL();
        return dalCountry.SelectForDropdownList(UserID);
    }
    #endregion

    #region SelectByPK
    public CountryENT SelectByPK(SqlInt32 CountryID)
    {
        CountryDAL dalCountry = new CountryDAL();
        return dalCountry.SelectByPK(CountryID);
    }
    #endregion

    #endregion
}