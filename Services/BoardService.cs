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

        public BoardModel GetBoardModelByBoardID(string id){
            return _context.BoardInfo.SingleOrDefault(board => board.BoardID == id);
        }
        public bool AddBoardToUser(string id, string username){
            UserModels foundUser = GetUserByUsername(username);
            BoardModel board = GetBoardModelByID(id);
            if(!foundUser.BoardIDs.Contains(board.BoardID)){
                foundUser.BoardIDs += board.BoardID  + "-";
            }
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

        public IEnumerable<BoardModel> GetBoardModelsByUser(string username){
            UserModels foundUser = GetUserByUsername(username);
            return _context.BoardInfo.Where(blog => blog.UserID == foundUser.ID);
        }

        public bool CreateBoard(CreateBoardDTO newBoard)
        {
            bool falseId = true;
            UserModels foundUser = GetUserByUsername(newBoard.Username);
            BoardModel createdBoard = new BoardModel();
            createdBoard.BoardName = newBoard.BoardName;
            createdBoard.UserID = foundUser.ID;
            
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

            return _context.SaveChanges() != 0;
        }

        public BoardModel GetBoardModelByID(string BoardID)
        {
            return _context.BoardInfo.SingleOrDefault(board => board.BoardID == BoardID);
        }

    }
}