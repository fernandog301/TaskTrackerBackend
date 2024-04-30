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
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _posts;
        public PostController(PostService posts)
        {
            _posts = posts;
        }

        [HttpGet] 
        [Route("GetPostByID/{ID}")]
        public PostModels GetPostByID(int ID)
        {
            return _posts.GetPostByID(ID);
        }

        [HttpGet]
        [Route("GetPostsByBoardID/{BoardID}")]
        public IEnumerable<PostModels> GetPostsByBoardID(string BoardID)
        {
            return _posts.GetPostsByBoard(BoardID);
        }

        [HttpPost]
        [Route("CreatePost/{username}")]
        public bool CreatePost(string username, CreatePostDTO createdPost){
            return _posts.CreatePost(username, createdPost);
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