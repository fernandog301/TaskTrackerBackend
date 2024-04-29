using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models.DTO
{
    public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public string DateCreated { get; set; }
        public string Status { get; set; }
        public string PriorityLevel { get; set; }
    }
}