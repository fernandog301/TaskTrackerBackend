using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services.Context;
using WebApiTest.Models.DTO;

namespace TaskTrackerBackend.Services
{
    public class PostService : ControllerBase
    {
        private readonly DataContext _context;
        public PostService(DataContext context)
        {
            _context = context;
        }

        public UserModels GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public PostModels GetPostByID(int ID)
        {
            return _context.PostInfo.SingleOrDefault(post => post.ID == ID);
        }

        public IEnumerable<PostModels> GetPostsByBoardId(string BoardID){
            return _context.PostInfo.Where(post => post.BoardID == BoardID);
        }

        public BoardModel GetBoardModelByID(string BoardID)
        {
            return _context.BoardInfo.SingleOrDefault(board => board.BoardID == BoardID);
        }

        public bool CreatePost(CreatePostDTO createdPost)
        {
            BoardModel foundBoard = GetBoardModelByID(createdPost.BoardID);
            UserModels assignee = GetUserByUsername(createdPost.Assignee);
            var newPost = new PostModels();
            newPost.BoardID = createdPost.BoardID;
            newPost.Description = createdPost.Description;
            newPost.Title = createdPost.Title;
            newPost.DateCreated = createdPost.DateCreated;
            newPost.AssigneeID = assignee.ID;
            newPost.Status = createdPost.Status;
            newPost.PriorityLevel = createdPost.PriorityLevel;
            newPost.IsDeleted = false;

            _context.Add(newPost);

            return _context.SaveChanges() != 0;
        }

        public bool EditPost(EditPostDTO editedPost)
        {

            UserModels foundUser = GetUserByUsername(editedPost.Assignee);
            PostModels foundPost = GetPostByID(editedPost.ID);

            foundPost.Title = editedPost.Title;
            foundPost.Description = editedPost.Description;
            foundPost.AssigneeID = foundUser.ID;
            foundPost.Status = editedPost.Status;
            foundPost.PriorityLevel = editedPost.PriorityLevel;

            _context.Update<PostModels>(foundPost);

            return _context.SaveChanges() != 0;
        }

        public bool DeletePostById(int id)
        {
            PostModels foundPost = GetPostByID(id);
            
            foundPost.IsDeleted = true;

            _context.Update<PostModels>(foundPost);
            return _context.SaveChanges() != 0;
        }
    }


}