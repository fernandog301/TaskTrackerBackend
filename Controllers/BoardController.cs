using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services;

namespace TaskTrackerBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly BoardService _board;
        public BoardController(BoardService boardService)
        {
            _board = boardService;
        }

        [HttpGet]
        [Route("GetBoardByBoardID/{id}")]
        public BoardModel GetBoardsByBoardID(string id){
            return _board.GetBoardModelByBoardID(id);
        }

        [HttpPost]
        [Route("CreateBoard")]
        public bool CreateBoard(CreateBoardDTO newBoard){
            return _board.CreateBoard(newBoard);
        }

        [HttpPut]
        [Route("AddBoardToUser/{id}/{username}")]
        public bool AddBoardToUser(string id, string username){
            return _board.AddBoardToUser(id, username);
        }
    }
}