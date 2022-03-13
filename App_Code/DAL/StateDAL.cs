using MulstiUserAddressBookWith3Tire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for StateDAL
/// </summary>

public class StateDAL : DatabaseConfig
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
    public Boolean Insert(StateENT entState)
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
                    objCmd.CommandText = "PR_State_Insert";

                    objCmd.Parameters.Add("@StateID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                    objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                    objCmd.Parameters.AddWithValue("@UserID", entState.UserID);

                    #endregion

                    objCmd.ExecuteNonQuery();

                    if (objCmd.Parameters["@StateID"].Value != null)
                        entState.StateID = Convert.ToInt32(objCmd.Parameters["@StateID"].Value);

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
    public Boolean Update(StateENT entState)
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
                    objCmd.CommandText = "PR_State_UpdateByPK";

                    objCmd.Parameters.AddWithValue("@StateID", entState.StateID);
                    objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                    objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                    objCmd.Parameters.AddWithValue("@UserID", entState.UserID);

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
    public Boolean Delete(SqlInt32 StateID)
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
                    objCmd.CommandText = "PR_State_DeleteByPK";

                    objCmd.Parameters.AddWithValue("@StateID", StateID);

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
                    objCmd.CommandText = "PR_State_SelectAllByUserID";

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
    public DataTable SelectForDropdownList(SqlInt32 CountryID, SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command
                    objCmd.CommandText = "PR_State_SelectDropdownListByUserID";

                    objCmd.CommandType = CommandType.StoredProcedure;

                    objCmd.Parameters.AddWithValue("@CountryID", CountryID);

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
    public StateENT SelectByPK(SqlInt32 StateID)
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
                    objCmd.CommandText = "PR_State_SelectByPK";
                    objCmd.Parameters.AddWithValue("@StateID", StateID);
                    #endregion

                    #region Read Data and return ENT

                    StateENT entState = new StateENT();

                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["StateName"].Equals(DBNull.Value))
                                entState.StateName = Convert.ToString(objSDR["StateName"]);

                            if (!objSDR["CountryID"].Equals(DBNull.Value))
                                entState.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                            break;
                        }
                    }

                    return entState;

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