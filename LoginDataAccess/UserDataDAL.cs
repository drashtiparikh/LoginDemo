using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using LoginDataProp;

namespace LoginDataAccess
{
    public class UserDataDAL
    {
        #region Variable Declaration
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        DataSet ds;

        #endregion

        public UserDataDAL()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["mydbconn"].ToString();
        }


        #region Methods

        public bool insertUserData(UserData userData)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspInsertUserData";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(UserData.FIRST_NAME, userData.FirstName);
                cmd.Parameters.AddWithValue(UserData.LAST_NAME, userData.LastName);
                cmd.Parameters.AddWithValue(UserData.EMAIL_ID, userData.Emailid);
                cmd.Parameters.AddWithValue(UserData.PASSWORD, userData.Password);
                cmd.Parameters.AddWithValue(UserData.PHONE_NO, userData.PhoneNo);

                SqlParameter outParam = new SqlParameter();
                outParam.Direction = ParameterDirection.Output;
                outParam.DbType = DbType.Int32;

                outParam.ParameterName = UserData.ID;
                cmd.Parameters.Add(outParam);

                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                userData.Id = Convert.ToInt32(cmd.Parameters[UserData.ID].Value);


                return true;

            }
            catch
            {
                return false;
            }

        }

        public bool updateUserData(UserData userData)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspUpdateUserData";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(UserData.ID, userData.Id);

                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;

            }
            catch
            {
                return false;
            }

        }

        public DataSet selectAllUserData()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspSelectAllUserData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();

            da.Fill(ds);

            return ds;
        }

        public bool selectUserData(UserData userData)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspSelectUserData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue(UserData.EMAIL_ID, userData.Emailid);
                cmd.Parameters.AddWithValue(UserData.PASSWORD, userData.Password);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();

                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        userData.Id = Convert.ToInt32(ds.Tables[0].Rows[0][UserData.ID]);
                        userData.FirstName = Convert.ToString(ds.Tables[0].Rows[0][UserData.FIRST_NAME]);
                        userData.LastName = Convert.ToString(ds.Tables[0].Rows[0][UserData.LAST_NAME]);
                        userData.Emailid = Convert.ToString(ds.Tables[0].Rows[0][UserData.EMAIL_ID]);
                        userData.PhoneNo = Convert.ToString(ds.Tables[0].Rows[0][UserData.PHONE_NO]);
                        userData.Isvalid = Convert.ToBoolean(ds.Tables[0].Rows[0][UserData.IS_VALID]);

                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool selectExistsUserData(UserData userData)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspSelectExistsUserData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue(UserData.EMAIL_ID, userData.Emailid);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();

                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        userData.Id = Convert.ToInt32(ds.Tables[0].Rows[0][UserData.ID]);
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Functions
        #endregion


    }
}
