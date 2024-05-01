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
        [Route("GetPostsByBoardID/{BoardID}")]
        public List<PostModels> GetPostsByBoardID(string BoardID){
            return _board.GetPostsByBoardID(BoardID);
        }

        [HttpPost]
        [Route("CreateBoard")]
        public bool CreateBoard(CreateBoardDTO newBoard){
            return _board.CreateBoard(newBoard);
        }

    }
}