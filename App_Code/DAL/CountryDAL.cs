using MulstiUserAddressBookWith3Tire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for CountryDAL
/// </summary>

public class CountryDAL : DatabaseConfig
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
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Country_Insert";

                    objCmd.Parameters.Add("@CountryID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                    objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);
                    objCmd.Parameters.AddWithValue("@UserID", entCountry.UserID);

                    #endregion

                    objCmd.ExecuteNonQuery();

                    if (objCmd.Parameters["@CountryID"].Value != DBNull.Value)
                        entCountry.CountryID = Convert.ToInt32(objCmd.Parameters["@CountryID"].Value.ToString());
                    
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
    public Boolean Update(CountryENT entCountry)
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
                    objCmd.CommandText = "PR_Country_UpdateByPK";

                    objCmd.Parameters.AddWithValue("@CountryID", entCountry.CountryID);
                    objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                    objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);

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
    public Boolean Delete(SqlInt32 CountryID)
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
                    objCmd.CommandText = "PR_Country_DeleteByPK";

                    objCmd.Parameters.AddWithValue("@CountryID", CountryID);

                    #endregion

                    objCmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.Message;
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
                    objCmd.CommandText = "PR_Country_SelectAllByUserID";

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
                    objCmd.CommandText = "PR_Country_SelectDropdownListByUserID";

                    objCmd.CommandType = CommandType.StoredProcedure;

                    objCmd.Parameters.AddWithValue("@UserID", UserID);
                    #endregion

                    #region Read Data and return DataTable
                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(objSDR);

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
    public CountryENT SelectByPK(SqlInt32 CountryID)
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
                    objCmd.CommandText = "PR_Country_SelectByPK";

                    objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                    #endregion

                    #region Read Data and return ENT

                    CountryENT entCountry = new CountryENT();

                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["CountryName"].Equals(DBNull.Value))
                                entCountry.CountryName = Convert.ToString(objSDR["CountryName"]);

                            if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                entCountry.CountryCode = Convert.ToString(objSDR["CountryCode"]);

                            break;
                        }
                    }

                    return entCountry;

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