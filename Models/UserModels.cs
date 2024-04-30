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
<<<<<<< HEAD
        public string AccountCreated { get; set; }

        
        public string Password { get; set; }
=======
        
>>>>>>> 68671510b6e5dca6dced2185bfea9b2c9df64832
        
=======
        

>>>>>>> bc137981cea85b634c05ba70698df1bc0b516ae5
        public string? Salt { get; set; }


        public string? Hash { get; set; }

        public UserModels(){}
    }
}