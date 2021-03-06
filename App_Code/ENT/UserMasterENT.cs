using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserMasterENT
/// </summary>
public class UserMasterENT
{
	#region Constructor

	public UserMasterENT()
	{
		_UserID = SqlInt32.Null;
		_UserName = SqlString.Null;
		_Password = SqlString.Null;
		_FullName = SqlString.Null;
		_Address = SqlString.Null;
		_MobileNo = SqlString.Null;
		_Email = SqlString.Null;
		_PhotoPath = SqlString.Null;
		_CreationDate = SqlDateTime.Null;
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

	#region UserName

	protected SqlString _UserName;

	public SqlString UserName
	{
		get
		{
			return _UserName;
		}
		set
		{
			_UserName = value;
		}
	}

	#endregion

	#region Password

	protected SqlString _Password;

	public SqlString Password
	{
		get
		{
			return _Password;
		}
		set
		{
			_Password = value;
		}
	}

	#endregion

	#region FullName

	protected SqlString _FullName;

	public SqlString FullName
	{
		get
		{
			return _FullName;
		}
		set
		{
			_FullName = value;
		}
	}

	#endregion

	#region Address

	protected SqlString _Address;

	public SqlString Address
	{
		get
		{
			return _Address;
		}
		set
		{
			_Address = value;
		}
	}

	#endregion

	#region MobileNo

	protected SqlString _MobileNo;

	public SqlString MobileNo
	{
		get
		{
			return _MobileNo;
		}
		set
		{
			_MobileNo = value;
		}
	}

	#endregion

	#region Email

	protected SqlString _Email;

	public SqlString Email
	{
		get
		{
			return _Email;
		}
		set
		{
			_Email = value;
		}
	}

	#endregion

	#region PhotoPath

	protected SqlString _PhotoPath;

	public SqlString PhotoPath
	{
		get
		{
			return _PhotoPath;
		}
		set
		{
			_PhotoPath = value;
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


}