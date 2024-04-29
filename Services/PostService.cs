using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services.Context;

namespace TaskTrackerBackend.Services
{
    public class PostService : ControllerBase
    {
        private readonly DataContext _context;
        public PostService(DataContext context)
        {
            _context = context;
        }

        public UserModels GetUserByUsername(string username) {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public bool CreatePost(string username, CreatePostDTO createdPost) {
            UserModels foundUser = GetUserByUsername(username);
            UserModels assignee = GetUserByUsername(createdPost.Assignee);
            var newPost = new PostModels();
            newPost.UserId = foundUser.ID;
            newPost.Description = createdPost.Description;
            newPost.Title = createdPost.Title;
            newPost.DateCreated = createdPost.DateCreated;
            newPost.AssigneeID = assignee.ID;
            newPost.Status = createdPost.Status;
            newPost.PriorityLevel = createdPost.PriorityLevel;
            newPost.Comments = new List<CommentsModels>();
            newPost.IsDeleted = false;

            return _context.SaveChanges() != 0;
        }

        
    }
}