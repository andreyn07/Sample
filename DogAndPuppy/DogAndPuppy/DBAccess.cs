using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DogAndPuppy
{
    public class DBAccess
    {
        public DBAccess()
        {
        }
        public DataTable GetDog(int ? breedId = null, int? dogId = null)
        {
            DataTable dt = null;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "P_GetDog";
                cmd.Connection = cn;
                cmd.Parameters.Add("@BreedId", SqlDbType.Int).Value = breedId;
                cmd.Parameters.Add("@DogId", SqlDbType.Int).Value = dogId;
                dt = LoadDataTable(cmd);                
                cn.Close();

            }
            catch (Exception)
            {
                
            }
            return dt;

        }
        public void SetDog(string name, string address, string city, string stateId, string zipcode,
            int countryId, int breedId, int colorId, int sizeId, int genderId, ref int dogId)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "P_SetDog";
                cmd.Connection = cn;

                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
                cmd.Parameters.Add("@StateId", SqlDbType.VarChar).Value = stateId;
                cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = zipcode;
                cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = countryId;
                cmd.Parameters.Add("@BreedId", SqlDbType.Int).Value = breedId;
                cmd.Parameters.Add("@ColorId", SqlDbType.Int).Value = colorId;
                cmd.Parameters.Add("@SizeId", SqlDbType.Int).Value = sizeId;
                cmd.Parameters.Add("@GenderID", SqlDbType.Int).Value = genderId;
                cmd.Parameters.Add("@DogID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                dogId = (int)cmd.Parameters["@DogID"].Value;
                cn.Close();

            }
            catch (Exception)
            {

                dogId = 0;
            }
        }

        public int SetPuppy(string name,
                            string address,
                            string city,
                            string stateId,
                            string zipcode,
                            int countryId,
                            int colorId,
                            int sizeId,
                            int genderId,
                            int dogId,
                            decimal price,
                            string dob,
                            string firstname,
                            string lastname,
                            ref string msg)
        {
            int puppyId = 0;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "P_SetPuppy";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
                cmd.Parameters.Add("@StateID", SqlDbType.VarChar).Value = stateId;
                cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = zipcode;
                cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = countryId;
                cmd.Parameters.Add("@ColorID", SqlDbType.Int).Value = colorId;
                cmd.Parameters.Add("@SizeID", SqlDbType.Int).Value = sizeId;
                cmd.Parameters.Add("@GenderID", SqlDbType.Int).Value = genderId;
                cmd.Parameters.Add("@DogID", SqlDbType.Int).Value = dogId;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = dob;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastname;
                cmd.Parameters.Add("@PuppyID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                puppyId = (int)cmd.Parameters["@PuppyID"].Value;
                cn.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return puppyId;
        }


        public DataSet GetLookup()
        {
            DataSet ds = null;
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("P_GetLookUp"))
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    ds = LoadDatatSet(cmd);
                }
                cn.Close();
            }
            return ds;
        }

        private DataSet LoadDatatSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        private DataTable LoadDataTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        private string GetConnectionStr()
        {
            string strCon = ConfigurationManager.ConnectionStrings["Sql_Connection"].ConnectionString;
            return strCon;
        }

        
    }
}