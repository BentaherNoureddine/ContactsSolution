
using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsSolution.Data
{


    public class clsCountryDataAcess
    {



        public static bool isExistsById(int CountyID)
        {

            bool isFound = false;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT found=1 FROM Countries WHERE CountyID = @CountyID";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountyID", CountyID);


            try
            {
                sqlConnection.Open();
                isFound = (Convert.ToInt32(sqlCommand.ExecuteScalar()) == 1);


            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            return isFound;
        }


    


        public static int create(string CountryName,string Code,string PhoneCode)
        {
            int countryId = -1;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "INSERT INTO Countries (CountryName,Code,PhoneCode) VALUES (@CountyName,@Code,PhoneCode); SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Name", CountryName);
            sqlCommand.Parameters.AddWithValue("@Code", Code);
            sqlCommand.Parameters.AddWithValue("@PhoneCode", PhoneCode);

            try
            {
                sqlConnection.Open();

                countryId = Convert.ToInt32(sqlCommand.ExecuteScalar());


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }

            return countryId;

        }




        public static bool update(int CountyID, string CountryName,string Code,string PhoneCode)
        {
            bool isUpdated = false;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "UPDATE Countries SET CountryName = @CountryName, Code=@COde, PhoneCode=@PhoneCode WHERE CountyID = @CountryID";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountryID", CountyID);
            sqlCommand.Parameters.AddWithValue("@CountryName", CountryName);
            sqlCommand.Parameters.AddWithValue("@Code", Code);
            sqlCommand.Parameters.AddWithValue("@PhoneCode", PhoneCode);


            try
            {
                sqlConnection.Open();
                isUpdated = (sqlCommand.ExecuteNonQuery() > 0);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            return isUpdated;
        }




        public static bool findCountryByName(string CountryName, ref int CountryID,ref string Code, ref string PhoneCode )
        {

            string sqlQuery = "SELECT CountryID, Code, PhoneCode  FROM Countries WHERE CountryName = @CountryName";

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.connectionString);

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    CountryID = Convert.ToInt32(sqlDataReader["CountryID"]);
                    Code = Convert.ToString(sqlDataReader["Code"]);
                    PhoneCode = Convert.ToString(sqlDataReader["PhoneCode"]);
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
        }


        public static bool findCountryById(int CountyID, ref string CountryName,ref string Code, ref string PhoneCode)
        {

            string sqlQuery = "SELECT CountryName, Code, PhoneCode  FROM Countries WHERE CountryID = @CountryID";

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.connectionString);

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountryID", CountyID);

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    CountryName = Convert.ToString(sqlDataReader["CountryName"]);
                    Code = Convert.ToString(sqlDataReader["Code"]);
                    PhoneCode = Convert.ToString(sqlDataReader["PhoneCode"]);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
        }




        public static bool isCountryExistsByName(string CountyName)
        {
            bool isFound = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "SELECT found=1 FROM Countries WHERE CountyName = @CountyName";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CountyName", CountyName);


            try
            {
                sqlConnection.Open();
                isFound = (Convert.ToInt32(sqlCommand.ExecuteScalar()) == 1);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }

            return isFound;

        }

        public static DataTable getAllCountries()
        {
            string sqlQuery = "SELECT * FROM Countries";

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.connectionString);

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            try
            {

                sqlConnection.Open();


                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
                else
                {
                    return null;
                }


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
        }



        public static bool DeleteCountryById(int CountryID)
        {
            bool isDeleted = false;

            string sqlQuery = "DELETE FROM Countries WHERE CountryID = @CountryID";

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.connectionString);

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountryID", CountryID);


            try
            {
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    isDeleted = true;

                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();

            }
            return isDeleted;
        }
  
    
    
    
    
    
    
    
    
    
    
    }



}
