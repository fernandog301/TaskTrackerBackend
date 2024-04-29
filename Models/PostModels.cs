using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models
{
    public class PostModels
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string DateCreated { get; set; }

        public string AlignedTo { get; set; }

        public string? DateUpdated { get; set; }

        public bool IsDeleted { get; set; } = false;

        public PostModels(){
            
        }
    }
}