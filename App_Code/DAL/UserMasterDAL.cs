using MulstiUserAddressBookWith3Tire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for UserMasterDAL
/// </summary>

public class UserMasterDAL : DatabaseConfig
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
    public Boolean Insert(UserMasterENT entUserMaster)
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

                    objCmd.CommandText = "PR_UserMaster_RegisterUser";

                    
                    objCmd.Parameters.AddWithValue("@UserName", entUserMaster.UserName);
                    objCmd.Parameters.AddWithValue("@Password", entUserMaster.Password);
                    objCmd.Parameters.AddWithValue("@FullName", entUserMaster.FullName);
                    objCmd.Parameters.AddWithValue("@Address", entUserMaster.Address);
                    objCmd.Parameters.AddWithValue("@MobileNo", entUserMaster.MobileNo);
                    objCmd.Parameters.AddWithValue("@Email", entUserMaster.Email);
                    objCmd.Parameters.AddWithValue("@PhotoPath", entUserMaster.PhotoPath);

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

    #region Update Operation
    public Boolean Update(UserMasterENT entUserMaster)
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
                    objCmd.CommandText = "PR_UserMaster_UpdateByPK";
                    objCmd.Parameters.AddWithValue("@UserID", entUserMaster.UserID);
                    objCmd.Parameters.AddWithValue("@UserName", entUserMaster.UserName);
                    objCmd.Parameters.AddWithValue("@Password", entUserMaster.Password);
                    objCmd.Parameters.AddWithValue("@FullName", entUserMaster.FullName);
                    objCmd.Parameters.AddWithValue("@Address", entUserMaster.Address);
                    objCmd.Parameters.AddWithValue("@MobileNo", entUserMaster.MobileNo);
                    objCmd.Parameters.AddWithValue("@Email", entUserMaster.Email);
                    objCmd.Parameters.AddWithValue("@PhotoPath", entUserMaster.PhotoPath);

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
    public Boolean Delete(SqlInt32 UserMasterID)
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
                    objCmd.CommandText = "PR_UserMaster_DeleteByPK";

                    objCmd.Parameters.AddWithValue("@UserMasterID", UserMasterID);

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
    public DataTable SelectAll()
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
                    objCmd.CommandText = "PR_UserMaster_SelectAll";
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
    public DataTable SelectForDropdownList()
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            objConn.Open();

            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {

                    DataTable dt = new DataTable();

                    return dt;
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

    #region SelectBy UserName and Password
    public DataTable SelectByUserNamePassword(SqlString Username, SqlString Password)
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
                    objCmd.CommandText = "PR_UserMaster_SelectByUserNamePassword";

                    objCmd.Parameters.AddWithValue("@UserName", Username);
                    objCmd.Parameters.AddWithValue("@Password", Password);
                    #endregion

                    #region Read Data and return ENT

                    UserMasterENT entUserMaster = new UserMasterENT();

                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(objSDR);

                    return dt;

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