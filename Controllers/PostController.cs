using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services;
using WebApiTest.Models.DTO;

namespace TaskTrackerBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _posts;
        public PostController(PostService posts)
        {
            _posts = posts;
        }

        [HttpGet] 
        [Route("GetPostsByBoardID/{ID}")]
        public IEnumerable<PostModels> GetPostByID(string ID)
        {
            return _posts.GetPostsByBoardId(ID);
        }

        [HttpPost]
        [Route("CreatePost")]
        public bool CreatePost(CreatePostDTO createdPost){
            return _posts.CreatePost( createdPost);
        }

        [HttpPut]
        [Route("EditPost")]
        public bool EditPost(EditPostDTO editedPost){
            return _posts.EditPost(editedPost);
        }

        [HttpPut]
        [Route("DeletePostByID/{ID}")]
        public bool DeletePostByID(int ID){
            return _posts.DeletePostById(ID);
        }
        
    }
}