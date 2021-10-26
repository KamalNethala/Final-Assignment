using Final_Task.Models;
using Final_Task.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.Controller
{
    [Route("api/Station")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationRepository _stationRepository;

        public StationController(IStationRepository StationRepository)
        {
            _stationRepository = StationRepository;
        }
        [HttpGet]
        public Task<IEnumerable<Station>> FetchStations()
        {
            return _stationRepository.FetchStations();
        }
        [HttpGet("stationname, arrivaltime")]
        public async Task<ActionResult<Station>> FetchTrains(string stationname, string arrivaltime)
        {
            return await _stationRepository.Fetch(stationname,arrivaltime);
            
        }
        [HttpGet("trainname")]
        public async Task<IEnumerable<Station>> FetchWithTrainname(string trainname)
        {
            return await _stationRepository.FetchWith(trainname);
        }
 
        [HttpPost]
        public async Task<ActionResult<Station>> InsertStations([FromBody] Station station)
        {
            var newStation = await _stationRepository.Insertion(station);
            //return CreatedAtAction(nameof(FetchTrain), new { newtrain.Train_No } , newtrain);
            return null;
        }
    }
}
