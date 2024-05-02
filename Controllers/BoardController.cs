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

<<<<<<< HEAD
<<<<<<< HEAD
        [HttpPut]
        [Route("AddBoardToUser/{id}/{username}")]
        public bool AddBoardToUser(string id, string username){
            return _board.AddBoardToUser(id, username);
        }
=======
        // [HttpPost]
        // [Route("AddBoardToUser/{id}/{username}")]
        // public bool AddBoardToUser(int id, string username){
        //     return _board.AddBoardToUser(id, username);
        // }
=======
        [HttpPost]
        [Route("AddBoardToUser/{id}/{username}")]
        public bool AddBoardToUser(int id, string username){
            return _board.AddBoardToUser(id, username);
        }
>>>>>>> 65218eb263f7fa8069a091c388222f8090547920


>>>>>>> f1a5b172a510a8592b9a248d1cd3f327c0f5955c
    }
}