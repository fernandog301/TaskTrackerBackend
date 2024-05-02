using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models
{
    public class UserModels
    {
        public int ID { get; set; }

        public string Username { get; set; }




<<<<<<< HEAD
        public string? BoardIDs { get; set; }
=======
        public List<BoardModel>? BoardInfo { get; set; }
>>>>>>> 8f2c2b167812214b2955e951801de21ad0fb8b3b



        public string? ProfileImg {get; set; }



        public bool? AccountCreated { get; set; }

        public string Password { get; set; }
        public string? Salt { get; set; }


        public string? Hash { get; set; }

        public UserModels() { }
    }
}