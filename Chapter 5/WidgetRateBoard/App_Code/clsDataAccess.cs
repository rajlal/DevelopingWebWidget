//*****************************************************************************************************************
//Class name : clsDataAccess 
//Defination : This class does all the updating,Inserting,deleting,Retrieving
//part in the database.The methods in this class is called by all the other methods in other classes.Connection
//with the database is set up here only.
//Date Added : 11/23/03
//Author     : Rajesh Lal Connectrajesh@hotmail.com 
//*****************************************************************************************************************

using System;
using System.Configuration;
using System.Data; 
using System.Data.SqlClient; 

namespace AddRating
{
	/// Summary description for clsDataAccess.
	
	public class clsDataAccess // Class defination
	{
		public clsDataAccess()
		{
		}
		SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);  
		public bool openConnection() // Opens database connection with Granth in SQL SERVER
		{
			mycon.Open();
 		return true;
		}
		public void closeConnection() // Closes database connection with Granth in SQL SERVER
		{
		mycon.Close(); 
		mycon = null;
		}
		public SqlDataReader getData(string query) // Getdata from the table required(given in query)in datareader
		{
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.CommandText= query;
			sqlCommand.Connection=mycon;
			SqlDataReader myr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return myr;
			 
		}
        public void saveData(string query) // Save data usually,inserts and updates the data in table given in query
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Connection = mycon;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();

        }
        public int CreateNewItemRate(string Title, string URL)
        {
            // Execute SQL Command
            
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.ReturnValue, null);
            AddParamToSQLCmd(sqlCmd, "@Title", SqlDbType.NText, 255, ParameterDirection.Input, Title);
            AddParamToSQLCmd(sqlCmd, "@URL", SqlDbType.NText, 255, ParameterDirection.Input, URL);
            
            SetCommandType(sqlCmd, CommandType.StoredProcedure, "AddRatings_Item_CreateRate");
            sqlCmd.Connection = mycon;
                Object result = null;
                result = sqlCmd.ExecuteScalar();
                return ((int)sqlCmd.Parameters["@ReturnValue"].Value);
        }
        public int CreateNewSession(string IPAddress, int RatingID)
        {
            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.ReturnValue, null);
            AddParamToSQLCmd(sqlCmd, "@IPAddress", SqlDbType.NVarChar, 16, ParameterDirection.Input, IPAddress);
            AddParamToSQLCmd(sqlCmd, "@RatingID", SqlDbType.Int, 0, ParameterDirection.Input, RatingID);
            SetCommandType(sqlCmd, CommandType.StoredProcedure, "AddRatings_Session_Item_Create");
            sqlCmd.Connection = mycon;
            Object result = null;
            result = sqlCmd.ExecuteScalar();
            return ((int)sqlCmd.Parameters["@ReturnValue"].Value);
        }
		private void SetCommandType(SqlCommand sqlCmd, CommandType cmdType, string cmdText) 
		{
			sqlCmd.CommandType = cmdType;
			sqlCmd.CommandText = cmdText;
		}
		private void AddParamToSQLCmd(SqlCommand sqlCmd, string paramId, SqlDbType sqlType, int paramSize, ParameterDirection paramDirection, object paramvalue) 
		{
			// Validate Parameter Properties
			if (sqlCmd== null)
				throw (new ArgumentNullException("sqlCmd"));
			if (paramId == string.Empty)
				throw (new ArgumentOutOfRangeException("paramId"));

			// Add Parameter
			SqlParameter newSqlParam = new SqlParameter();
			newSqlParam.ParameterName= paramId;
			newSqlParam.SqlDbType = sqlType;
			newSqlParam.Direction = paramDirection;

			if (paramSize > 0)
				newSqlParam.Size=paramSize;

			if (paramvalue != null)
				newSqlParam.Value = paramvalue;

			sqlCmd.Parameters.Add (newSqlParam);
		}
	}
}
