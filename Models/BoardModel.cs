using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models
{
    public class BoardModel
    {
        public int ID { get; set; }
        public string BoardID { get; set; }
        public List<PostModels> Posts { get; set; }
    }
}