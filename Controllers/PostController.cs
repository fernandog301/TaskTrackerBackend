using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services;

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

        [HttpPost]
        [Route("CreatePost/{username}")]
        public bool CreatePost(string username, CreatePostDTO createdPost){
            return _posts.CreatePost(username, createdPost);
        }
    }
}