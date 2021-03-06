using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryENT
/// </summary>
public class ContactCategoryENT
{
	#region Constructor

	public ContactCategoryENT()
	{
		_ContactCategoryID = SqlInt32.Null;
		_ContactCategoryName = SqlString.Null;
		_CreationDate = SqlDateTime.Null;
		_UserID = SqlInt32.Null;
	}

	#endregion

	#region ContactCategoryID

	protected SqlInt32 _ContactCategoryID;

	public SqlInt32 ContactCategoryID
	{
		get
		{
			return _ContactCategoryID;
		}
		set
		{
			_ContactCategoryID = value;
		}
	}

	#endregion

	#region ContactCategoryName

	protected SqlString _ContactCategoryName;

	public SqlString ContactCategoryName
	{
		get
		{
			return _ContactCategoryName;
		}
		set
		{
			_ContactCategoryName = value;
		}
	}

	#endregion

	#region CreationDate

	protected SqlDateTime _CreationDate;

	public SqlDateTime CreationDate
	{
		get
		{
			return _CreationDate;
		}
		set
		{
			_CreationDate = value;
		}
	}

	#endregion

	#region UserID

	protected SqlInt32 _UserID;

	public SqlInt32 UserID
	{
		get
		{
			return _UserID;
		}
		set
		{
			_UserID = value;
		}
	}

	#endregion


}