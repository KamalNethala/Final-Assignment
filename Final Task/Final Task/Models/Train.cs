using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.Models
{
    public class Train
    {
        public int Train_No { get; set; }
        public string Train_Name { get; set; }
        public string Start_Station { get; set; }
        public string Start_Time { get; set; }
        public string End_Station { get; set; }
        public string End_Time{get; set;}
        public string Date { get; set; }
    }
}