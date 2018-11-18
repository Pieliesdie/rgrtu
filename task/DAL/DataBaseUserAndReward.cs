using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DataBaseUserAndReward 
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool AddUser()
        {
            throw new NotImplementedException();
        }

        public static bool DeleteUser(int id)
        {
            int result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userid", id);
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            if (result > 0)
                return true;
            else
                return false;
        }
        public static List<Rewards> GetRewards()
        {
            List<Rewards> rewards = new List<Rewards>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetRewards", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Rewards tmp = new Rewards()
                        {
                            ID = result.GetInt32(0),
                            Title = result.GetString(1),
                            Decription = result.GetString(2)
                        };
                        rewards.Add(tmp);
                    }
                }
                return rewards;
            }
        }

        public static List<Rewards> GetRewardsByID(int id)
        {
            List<Rewards> rewards = new List<Rewards>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetUserRewards", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userid", id);
                connection.Open();
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Rewards tmp = new Rewards()
                        {
                            ID = result.GetInt32(0),
                            Title = result.GetString(1),
                            Decription = result.GetString(2)                           
                        };
                        rewards.Add(tmp);
                    }
                }
                return rewards;
            }
        }

        public static List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetUsers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Users tmp = new Users()
                        {
                            ID = result.GetInt32(0),
                            FirstName = result.GetString(1),
                            LastName = result.GetString(2),
                            Birthday = result.GetDateTime(3)                            
                        };
                        users.Add(tmp);
                    }
                }
                return users;
            }
        }
    }
}
