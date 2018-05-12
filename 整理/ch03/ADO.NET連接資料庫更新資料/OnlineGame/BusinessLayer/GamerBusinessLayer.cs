using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLayer
{
    public class GamerBusinessLayer
    {
        public IEnumerable<Gamer> Gamers
        {
            get
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["OnlineGameContext"].ConnectionString;
                List<Gamer> gamers = new List<Gamer>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetGamers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Gamer gamer = new Gamer();
                        gamer.Id = Convert.ToInt32(rdr["Id"]);
                        gamer.Name = rdr["Name"].ToString();
                        gamer.Gender = rdr["Gender"].ToString();
                        gamer.City = rdr["City"].ToString();
                        gamer.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        gamer.TeamId = Convert.ToInt32(rdr["TeamId"]);
                        gamers.Add(gamer);
                    }
                }
                return gamers;
            }
        }


        public void AddGamer(Gamer gamer)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["OnlineGameContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddGamer", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sqlParamName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = gamer.Name
                };
                cmd.Parameters.Add(sqlParamName);

                SqlParameter sqlParamGender = new SqlParameter
                {
                    ParameterName = "@Gender",
                    Value = gamer.Gender
                };
                cmd.Parameters.Add(sqlParamGender);

                SqlParameter sqlParamCity = new SqlParameter
                {
                    ParameterName = "@City",
                    Value = gamer.City
                };
                cmd.Parameters.Add(sqlParamCity);

                SqlParameter sqlParamDateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = gamer.DateOfBirth
                };
                cmd.Parameters.Add(sqlParamDateOfBirth);

                SqlParameter sqlParamTeamId = new SqlParameter
                {
                    ParameterName = "@TeamId",
                    Value = gamer.TeamId
                };
                cmd.Parameters.Add(sqlParamTeamId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void SaveGamer(Gamer gamer)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["OnlineGameContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveGamer", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sqlParamId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = gamer.Id
                };
                cmd.Parameters.Add(sqlParamId);

                SqlParameter sqlParamName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = gamer.Name
                };
                cmd.Parameters.Add(sqlParamName);

                SqlParameter sqlParamGender = new SqlParameter
                {
                    ParameterName = "@Gender",
                    Value = gamer.Gender
                };
                cmd.Parameters.Add(sqlParamGender);

                SqlParameter sqlParamCity = new SqlParameter
                {
                    ParameterName = "@City",
                    Value = gamer.City
                };
                cmd.Parameters.Add(sqlParamCity);

                SqlParameter sqlParamDateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = gamer.DateOfBirth
                };
                cmd.Parameters.Add(sqlParamDateOfBirth);

                SqlParameter sqlParamTeamId = new SqlParameter
                {
                    ParameterName = "@TeamId",
                    Value = gamer.TeamId
                };
                cmd.Parameters.Add(sqlParamTeamId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
