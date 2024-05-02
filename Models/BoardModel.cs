using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models
{
    public class BoardModel
    {
        public int ID { get; set; } = 0;
        public int UserID {get; set; }
        public string? BoardName { get; set; }
        public string? BoardID { get; set; }

        public BoardModel () {}
    }
}