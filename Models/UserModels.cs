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

        public string AccountCreated { get; set; }

        public string Password { get; set; }
        
        public string? Salt { get; set; }

        public string? Hash { get; set; }

        public UserModels(){}
    }
}