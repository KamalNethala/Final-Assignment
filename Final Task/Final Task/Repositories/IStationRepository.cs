using Final_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.Repositories
{
    public interface IStationRepository
    {
        Task<IEnumerable<Station>> FetchStations();
        Task<Station> Insertion(Station station);
        Task<Station> Fetch(string stationname, string arrivaltime);
        Task<IEnumerable<Station>> FetchWith(string trainname);
       
    }
}
