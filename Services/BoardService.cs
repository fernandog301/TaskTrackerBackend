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
    public class BoardService : ControllerBase
    {
        private readonly DataContext _context;
        public BoardService(DataContext context)
        {
            _context = context;
        }

        public UserModels GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public BoardModel GetBoardModelByID(int id){
            return _context.BoardInfo.SingleOrDefault(board => board.ID == id);
        }

        public bool AddBoardToUser(int id, string username){
            UserModels foundUser = GetUserByUsername(username);
            BoardModel board = new BoardModel();
            foundUser.BoardInfo.Add(board);
            _context.Update<UserModels>(foundUser);
            return _context.SaveChanges() != 0;
        }

        public string CreateBoardID()
        {
            string[] abcArr = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Random random = new Random();

            int firstLetter = random.Next(0, 26);
            int secondLetter = random.Next(0, 26);
            int thirdLetter = random.Next(0, 26);
            int firstNum = random.Next(0, 10);
            int secondNum = random.Next(0, 10);
            int thirdNum = random.Next(0, 10);

            return abcArr[firstLetter] + abcArr[secondLetter] + abcArr[thirdLetter] + firstNum.ToString() + secondNum.ToString() + thirdNum.ToString();
        }

        public List<BoardModel> GetAllBoards()
        {
            return _context.BoardInfo.ToList();
        }

        public List<BoardModel> GetBoardModelsByUser(string username){
            UserModels foundUser = GetUserByUsername(username);
            return foundUser.BoardInfo;
        }

        public bool CreateBoard(CreateBoardDTO newBoard)
        {
            bool falseId = true;
            UserModels foundUser = GetUserByUsername(newBoard.Username);
            BoardModel createdBoard = new BoardModel();
            createdBoard.BoardName = newBoard.BoardName;
            createdBoard.Posts = new List<PostModels>();

            
            while (falseId)
            {
                bool newId = true;
                string id = CreateBoardID();
                List<BoardModel> boards = GetAllBoards();
                foreach (BoardModel board in boards)
                {
                    if (board.BoardID == id)
                    {
                        newId = false;
                    }
                }
                if (newId)
                {
                    createdBoard.BoardID = id;
                    falseId = false;
                }
            }

            _context.Add(createdBoard);
            
            // foundUser.BoardInfo.Add(createdBoard);

            // _context.Update<UserModels>(foundUser);

            return _context.SaveChanges() != 0;
        }

        public BoardModel GetBoardModelByID(string BoardID)
        {
            return _context.BoardInfo.SingleOrDefault(board => board.BoardID == BoardID);
        }

        public List<PostModels> GetPostsByBoardID(string BoardID)
        {
            BoardModel foundBoard = GetBoardModelByID(BoardID);

            return foundBoard.Posts;
        }
    }
}