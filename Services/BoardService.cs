using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Services.Context;

namespace TaskTrackerBackend.Services
{
    public class BoardService : ControllerBase
    {
        private readonly DataContext _context;
        public BoardService(DataContext context)
        {
            _context = context;
        }

        public BoardModel GetBoardModelByID(string BoardID) {
            return _context.BoardInfo.SingleOrDefault(board => board.BoardID == BoardID);
        }

        public List<PostModels> GetPostsByBoardID(string BoardID)
        {
            BoardModel foundBoard = GetBoardModelByID(BoardID);

            return foundBoard.Posts;
        }
    }
}