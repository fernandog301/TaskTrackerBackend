using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models.DTO
{
    public class CreateBoardDTO
    {
        public string BoardName { get; set; }
        public string Username { get; set; }
    }
}