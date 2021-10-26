using Dapper;
using Final_Task.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.Repositories
{
    public class TrainRepository : ITrainRepository
    {
        private readonly string _connectionString;

        public TrainRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<Train>> FetchTrain()
        {
            var sqlQuery = "SELECT * FROM Trains";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Train>(sqlQuery);
            }
        }
        public async Task<IEnumerable<Train>> FetchWithDate(string date)
        {
            var sqlQuery = "Select * FROM Trains WHERE Date=@Date";
            using(var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Train> (sqlQuery, new { Date = date });
                
            }
        }       
        public async Task<Train> Insertion(Train train)
        {
            var sqlQuery = "INSERT INTO Trains(Train_No, Train_Name, Start_Station,Start_Time,End_Station,End_Time,Date) VALUES (@Train_No, @Train_Name, @Start_Station,@Start_Time,@End_Station,@End_Time,@Date)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    train.Train_No,
                    train.Train_Name,
                    train.Start_Station,
                    train.Start_Time,
                    train.End_Station,
                    train.End_Time,
                    train.Date
                });

                return train;
            }
        }

    }
}
