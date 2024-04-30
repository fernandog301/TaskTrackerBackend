using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models
{
    public class AppModels
    {
        public int ID { get; set; }

        public string? ProfilePic { get; set; }

        public string? ProfilePicUrl { get; set;}

        public AppModels(){}
    }
}