using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models
{
    public class CommentsModels
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string? Reply { get; set; }
        public int? PostId { get; set; }
        

        public int? CommentId { get; set; }

        public string? Description { get; set; }
 
        public CommentsModels(){}
    }
}