using MulstiUserAddressBookWith3Tire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactDAL
/// </summary>

public class ContactDAL : DatabaseConfig
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
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_Insert";

                    objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    objCmd.Parameters.AddWithValue("@ContactCategoryID", entContact.ContactCategoryID);
                    objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                    objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                    objCmd.Parameters.AddWithValue("@Pincode", entContact.Pincode);
                    objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                    objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                    objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                    objCmd.Parameters.AddWithValue("@EmailAddress", entContact.EmailAddress);
                    objCmd.Parameters.AddWithValue("@MobileNo", entContact.MobileNo);
                    objCmd.Parameters.AddWithValue("@UserID", entContact.UserID);

                    #endregion

                    objCmd.ExecuteNonQuery();

                    if (objCmd.Parameters["@ContactID"].Value != null)
                        entContact.ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                    return true;
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion

    #region Update Operation
    public Boolean Update(ContactENT entContact)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_UpdateByPK";

                    objCmd.Parameters.AddWithValue("@ContactID", entContact.ContactID);
                    objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                    objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                    objCmd.Parameters.AddWithValue("@Pincode", entContact.Pincode);
                    objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                    objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                    objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                    objCmd.Parameters.AddWithValue("@EmailAddress", entContact.EmailAddress);
                    objCmd.Parameters.AddWithValue("@MobileNo", entContact.MobileNo);

                    #endregion

                    objCmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion

    #region Delete Operation
    public Boolean Delete(SqlInt32 ContactID)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_DeleteByPK";

                    objCmd.Parameters.AddWithValue("@ContactID", ContactID);

                    #endregion

                    objCmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion

    #region Select Operation

    #region SelectAll
    public DataTable SelectAll(SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_SelectAllByUserID";

                    objCmd.Parameters.AddWithValue("@UserID", UserID);
                    #endregion

                    #region Read Data and return DataTable
                    DataTable dt = new DataTable();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        dt.Load(objSDR);
                    }

                    return dt;
                    #endregion
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion

    #region SelectForCheckBoxList
    public DataTable SelectForCheckBoxList(SqlInt32 ContactID)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_SelectItemsCheckboxListByUserID";

                    objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                    #endregion

                    #region Read Data and return DataTable
                    DataTable dt = new DataTable();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        dt.Load(objSDR);
                    }

                    return dt;
                    #endregion
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion

    #region SelectByPK
    public ContactENT SelectByPK(SqlInt32 ContactID)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_SelectByPK";
                    objCmd.Parameters.AddWithValue("@ContactID", ContactID);

                    #endregion

                    #region Read Data and return ENT

                    ContactENT entContact = new ContactENT();

                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["ContactName"].Equals(DBNull.Value))
                                entContact.ContactName = Convert.ToString(objSDR["ContactName"]);

                            if (!objSDR["Address"].Equals(DBNull.Value))
                                entContact.Address = Convert.ToString(objSDR["Address"]);

                            if (!objSDR["Pincode"].Equals(DBNull.Value))
                                entContact.Pincode = Convert.ToString(objSDR["Pincode"]);

                            if (!objSDR["CityID"].Equals(DBNull.Value))
                                entContact.CityID = Convert.ToInt32(objSDR["CityID"]);

                            if (!objSDR["StateID"].Equals(DBNull.Value))
                                entContact.StateID = Convert.ToInt32(objSDR["StateID"]);

                            if (!objSDR["CountryID"].Equals(DBNull.Value))
                                entContact.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                            if (!objSDR["EmailAddress"].Equals(DBNull.Value))
                                entContact.EmailAddress = Convert.ToString(objSDR["EmailAddress"]);

                            if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                entContact.MobileNo = Convert.ToString(objSDR["MobileNo"]);

                            break;
                        }
                    }

                    return entContact;

                    #endregion;
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion

    #endregion
}
