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
    public class StationRepository : IStationRepository
    {
        private readonly string _connectionString;

        public StationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Station>> FetchStations()
        {
            var sqlQuery = "SELECT * FROM Stations";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Station>(sqlQuery);
            }
        }
        public async Task<Station> Fetch( string stationname, string arrivaltime)
        {
            var sqlQuery = "SELECT * FROM Stations WHERE Station_Name=@Stationname and Arrival_Time=@Arrivaltime";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Station>(sqlQuery, new { Stationname = stationname, Arrivaltime=arrivaltime });
            }
        }
        public async Task<IEnumerable<Station>> FetchWith(string trainname)
        {
            var sqlQuery = "SELECT * FROM Stations WHERE Train_Name=@Trainname";
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Station>(sqlQuery, new { Trainname = trainname });
            }
        }

        public async Task<Station> Insertion(Station station)
        {
            var sqlQuery = "INSERT INTO Stations (Station_No, Station_Name, Train_Name,Arrival_Time, Departure_Time) VALUES (@Station_No, @Station_Name, @Train_Name,@Arrival_Time,@Departure_Time)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    station.Station_No,
                    station.Station_Name,
                    station.Train_Name,
                    station.Arrival_Time,
                    station.Departure_Time
                    
                });

                return station;
            }
        }
    }
}
