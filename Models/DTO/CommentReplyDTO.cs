using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models.DTO
{
    public class CommentReplyDTO
    {
        public int ID { get; set; }
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public List<CommentReplyDTO> Replies { get; set; }
        public int? PostID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string? Description { get; set; }
    }
}