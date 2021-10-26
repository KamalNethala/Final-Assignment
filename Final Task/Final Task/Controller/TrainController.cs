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
    [Route("api/Train")]
    //[ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainRepository _trainRepository;

        public TrainController(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }
        [HttpGet]
        public Task<IEnumerable<Train>> FetchTrain()
        {
            return _trainRepository.FetchTrain();
        }
        [HttpGet("date")]
        public Task<IEnumerable<Train>> FetchWithDate(string date)
        {
            return _trainRepository.FetchWithDate(date);
        }
        [HttpPost]
        public async Task<ActionResult<Train>> InsertTrains([FromBody] Train train)
        {
            var newTrain = await _trainRepository.Insertion(train);
            //return CreatedAtAction(nameof(FetchTrain), new { newtrain.Train_No } , newtrain);
            return null;
        }
    }
}
