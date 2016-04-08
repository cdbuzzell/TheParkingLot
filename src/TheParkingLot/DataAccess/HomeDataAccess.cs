using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TheParkingLot.Models;

namespace TheParkingLot.DataAccess
{
    public class HomeDataAccess
    {
        string _connectionString = string.Empty;

        public HomeDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<GolferSeasonTotal> GetLeaderboard(int season)
        {
            List<GolferSeasonTotal> leaderboard = new List<GolferSeasonTotal>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetLeaderboard", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Season", season);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            leaderboard.Add(new GolferSeasonTotal
                            {
                                Golfer = new Golfer
                                {
                                    GolferId = reader["GolferId"] == DBNull.Value ? Guid.Empty : (Guid)reader["GolferId"],
                                    Alias = reader["Alias"].ToString(),
                                    GolferName = reader["GolferName"].ToString()
                                },
                                Rank = (Int64) reader["Rank"],
                                Par3Wins = (int) reader["Par3Wins"],
                                GameWins = (int) reader["GameWins"],
                                TotalPoints = (double) reader["TotalPoints"],
                                PointsBehind = (double) reader["PointsBehind"],
                                Season = (int) reader["Season"]
                            });
                        }
                    }

                    connection.Close();
                }
            }

            return leaderboard;
        }
        
        public List<GolferRound> GetGolferRounds(string alias, int season)
        {
            List<GolferRound> seasonRounds = new List<GolferRound>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetGolferRounds", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Golfer", alias);
                    command.Parameters.AddWithValue("@Season", season);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            seasonRounds.Add(new GolferRound
                            {
                                GolferRoundId = reader["GolferRoundId"] == DBNull.Value ? Guid.Empty : (Guid)reader["GolferRoundId"],
                                Round = new Round
                                {
                                    RoundId = (Guid)reader["RoundId"],
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    RoundName = reader["RoundName"].ToString(),
                                    Details = reader["Details"].ToString(),
                                    Game = reader["Game"].ToString()
                                },
                                Course = new Course
                                {
                                    CourseId = (Guid)reader["CourseId"],
                                    Name = reader["CourseName"].ToString(),
                                    Url = reader["Url"].ToString(),
                                    Par = (int)reader["Par"],
                                    Rating = reader["Rating"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["Rating"]),
                                    Slope = reader["Slope"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Slope"])
                                },
                                Golfer = new Golfer
                                {
                                    GolferId = reader["GolferId"] == DBNull.Value ? Guid.Empty : (Guid)reader["GolferId"],
                                    Alias = reader["Alias"].ToString(),
                                    GolferName = reader["GolferName"].ToString()
                                },
                                Points = reader["Points"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["Points"]),
                                Score = reader["Score"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Score"]),
                                Par3sWon = reader["Par3sWon"] == DBNull.Value ? (int?)null : (int)reader["Par3sWon"],
                                WonGame = reader["WonGame"] == DBNull.Value ? false : Convert.ToBoolean(reader["WonGame"]),
                                Comments = reader["Comments"].ToString()
                            });
                        }
                    }

                    connection.Close();
                }
            }

            return seasonRounds;
        }

        public List<GolferSeasonTotal> GetGolferTotals(string alias)
        {
            List<GolferSeasonTotal> seasonTotals = new List<GolferSeasonTotal>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetGolferTotals", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Golfer", alias);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            seasonTotals.Add(new GolferSeasonTotal
                            {
                                Golfer = new Golfer
                                {
                                    GolferId = reader["GolferId"] == DBNull.Value ? Guid.Empty : (Guid)reader["GolferId"],
                                    GolferName = reader["GolferName"].ToString(),
                                    Alias = reader["Alias"].ToString()
                                },
                                Par3Wins = reader["Par3Wins"] == DBNull.Value ? 0 : (int)reader["Par3Wins"],
                                GameWins = reader["GameWins"] == DBNull.Value ? 0 : (int)reader["GameWins"],
                                TotalPoints = reader["TotalPoints"] == DBNull.Value ? 0 : Convert.ToDouble(reader["TotalPoints"]),
                                AverageToPar = reader["AverageToPar"] == DBNull.Value ? (int?)null : (int)reader["AverageToPar"],
                                Season = (int)reader["Season"]
                            });
                        }
                    }

                    connection.Close();
                }
            }

            return seasonTotals;
        }
    }
}
