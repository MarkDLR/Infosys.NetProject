using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Demo
{
    public class DataAccess
    {
        private System.Data.IDbConnection connection;
        private readonly string storedProc_VerifyLogin = "VerifyLogin";
    

        public DataAccess()
        {
            
        }

        public DataAccess(System.Data.IDbConnection connection)
        { 
            this.connection = connection;
        }

        #region DbActions
        internal bool VerifyLoginFromDb()
        {
            bool success = false;

            AssuredConnected();
            using (System.Data.IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = storedProc_VerifyLogin;
                command.CommandType = System.Data.CommandType.StoredProcedure;

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
