using Final_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.Repositories
{
    public interface ITrainRepository
    {
        Task<IEnumerable<Train>> FetchTrain();
        Task<IEnumerable<Train>> FetchWithDate(string date);
        Task<Train> Insertion(Train train);        
    }
}
