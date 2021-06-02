using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Demo
{
    public class DataAccess
    {
        private System.Data.IDbConnection connection;
        private readonly string storedProc_VerifyLogin = "GetDemoLoginInfo";
    

        public DataAccess()
        {
            
        }

        public DataAccess(System.Data.IDbConnection connection)
        { 
            this.connection = connection;
        }

        #region DbActions
        internal bool VerifyLoginFromDb(string userName, string password)
        {
            bool success = false;

            AssuredConnected();
            using (System.Data.IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = storedProc_VerifyLogin;
                command.CommandType = System.Data.CommandType.StoredProcedure;

  // Add input parameter.

                SqlParameter parameterNameOf = new SqlParameter();

        parameterNameOf.ParameterName = "@UserName";

                parameterNameOf.SqlDbType = SqlDbType.VarChar;

                parameterNameOf.Direction = ParameterDirection.Input;

                parameterNameOf.Value = userName;

                // Add input parameter.

                SqlParameter parameterTotalMade = new SqlParameter();

        parameterTotalMade.ParameterName = "@Password";

                parameterTotalMade.SqlDbType = SqlDbType.VarChar;

                parameterTotalMade.Direction = ParameterDirection.Input;

                parameterTotalMade.Value = password;                 command.Parameters.Add(parameterNameOf);

                command.Parameters.Add(parameterTotalMade);



                using (System.Data.IDataReader reader = command.ExecuteReader())
                {
                    if (reader.RecordsAffected > 0)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }

      

        #endregion

      
        private bool AssuredConnected()
        {
            switch (connection.State)
            {
                case (System.Data.ConnectionState.Closed):
                    connection.Open();
                    return false;

                case (System.Data.ConnectionState.Broken):
                    connection.Close();
                    connection.Open();
                    return false;

                default: return true;
            }
        }
    }
}
