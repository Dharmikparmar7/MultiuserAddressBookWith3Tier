using MulstiUserAddressBookWith3Tire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for CityDAL
/// </summary>

public class CityDAL : DatabaseConfig
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
    public Boolean Insert(CityENT entCity)
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
                    objCmd.CommandText = "PR_City_Insert";

                    objCmd.Parameters.Add("@CityID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                    objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                    objCmd.Parameters.AddWithValue("@Pincode", entCity.Pincode);
                    objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                    objCmd.Parameters.AddWithValue("@UserID", entCity.UserID);

                    #endregion

                    objCmd.ExecuteNonQuery();

                    if (objCmd.Parameters["@CityID"].Value != null)
                        entCity.CityID = Convert.ToInt32(objCmd.Parameters["@CityID"].Value);

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
    public Boolean Update(CityENT entCity)
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
                    objCmd.CommandText = "PR_City_UpdateByPK";

                    objCmd.Parameters.AddWithValue("@CityID", entCity.CityID);
                    objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                    objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                    objCmd.Parameters.AddWithValue("@Pincode", entCity.Pincode);
                    objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);

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
    public Boolean Delete(SqlInt32 CityID)
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
                    objCmd.CommandText = "PR_City_DeleteByPK";

                    objCmd.Parameters.AddWithValue("@CityID", CityID);

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
                    objCmd.CommandText = "PR_City_SelectAllByUserID";

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
    public DataTable SelectForDropdownList(SqlInt32 StateID, SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command
                    objCmd.CommandText = "PR_City_SelectDropdownListByUserID";

                    objCmd.CommandType = CommandType.StoredProcedure;

                    objCmd.Parameters.AddWithValue("@StateID", StateID);

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
    public CityENT SelectByPK(SqlInt32 CityID)
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
                    objCmd.CommandText = "PR_City_SelectByPK";

                    objCmd.Parameters.AddWithValue("@CityID", CityID);
                    #endregion

                    #region Read Data and return ENT

                    CityENT entCity = new CityENT();

                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["StateID"].Equals(DBNull.Value))
                                entCity.StateID = Convert.ToInt32(objSDR["StateID"]);

                            if (!objSDR["CityName"].Equals(DBNull.Value))
                                entCity.CityName = Convert.ToString(objSDR["CityName"]);

                            if (!objSDR["Pincode"].Equals(DBNull.Value))
                                entCity.Pincode = Convert.ToString(objSDR["Pincode"]);

                            if (!objSDR["STDCode"].Equals(DBNull.Value))
                                entCity.STDCode = Convert.ToString(objSDR["STDCode"]);

                            break;
                        }
                    }

                    return entCity;

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