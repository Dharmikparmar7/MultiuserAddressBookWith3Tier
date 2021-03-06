using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategoryENT
/// </summary>
public class ContactWiseContactCategoryENT
{
	#region Constructor

	public ContactWiseContactCategoryENT()
	{
		_ContactWiseContactCategoryID = SqlInt32.Null;
		_ContactID = SqlInt32.Null;
		_ContactCategoryID = SqlInt32.Null;
	}

	#endregion

	#region ContactWiseContactCategoryID

	protected SqlInt32 _ContactWiseContactCategoryID;

	public SqlInt32 ContactWiseContactCategoryID
	{
		get
		{
			return _ContactWiseContactCategoryID;
		}
		set
		{
			_ContactWiseContactCategoryID = value;
		}
	}

	#endregion

	#region ContactID

	protected SqlInt32 _ContactID;

	public SqlInt32 ContactID
	{
		get
		{
			return _ContactID;
		}
		set
		{
			_ContactID = value;
		}
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


}