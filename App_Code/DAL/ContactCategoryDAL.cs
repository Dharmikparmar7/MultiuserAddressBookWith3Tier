using MulstiUserAddressBookWith3Tire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for ContactCategoryDAL
/// </summary>

public class ContactCategoryDAL : DatabaseConfig
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
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_ContactCategory_Insert";

                    objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    objCmd.Parameters.AddWithValue("@ContactCategoryName", entContactCategory.ContactCategoryName);
                    objCmd.Parameters.AddWithValue("@UserID", entContactCategory.UserID);

                    #endregion

                    objCmd.ExecuteNonQuery();

                    if (objCmd.Parameters["@ContactCategoryID"].Value != null)
                        entContactCategory.ContactCategoryID = Convert.ToInt32(objCmd.Parameters["@ContactCategoryID"].Value);

                    return true;
                }
                catch (SqlException sqlex)
                {
                    //Message = sqlex.InnerException.Message;
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
    public Boolean Update(ContactCategoryENT entContactCategory)
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
                    objCmd.CommandText = "PR_ContactCategory_UpdateByPK";

                    objCmd.Parameters.AddWithValue("@ContactCategoryID", entContactCategory.ContactCategoryID);
                    objCmd.Parameters.AddWithValue("@ContactCategoryName", entContactCategory.ContactCategoryName);

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
    public Boolean Delete(SqlInt32 ContactCategoryID)
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
                    objCmd.CommandText = "PR_ContactCategory_DeleteByPK";

                    objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);

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
                    objCmd.CommandText = "PR_ContactCategory_SelectAllByUserID";

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

    #region SelectForDropdownList
    public DataTable SelectForDropdownList(SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command

                    objCmd.CommandText = "PR_ContactCategory_SelectAllByUserID";

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

    #region SelectByPK
    public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID)
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
                    objCmd.CommandText = "PR_ContactCategory_SelectByPK";

                    objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);
                    #endregion

                    #region Read Data and return ENT

                    ContactCategoryENT entContactCategory = new ContactCategoryENT();

                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                                entContactCategory.ContactCategoryName = Convert.ToString(objSDR["ContactCategoryName"]);

                            break;
                        }
                    }

                    return entContactCategory;

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