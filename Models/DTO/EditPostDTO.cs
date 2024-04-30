using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerBackend.Models;

namespace WebApiTest.Models.DTO
{
    public class EditPostDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public string Status { get; set; }
        public string PriorityLevel { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}