using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services.Context;

namespace TaskTrackerBackend.Services
{
    public class UserService : ControllerBase
    {
        

        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        // public bool DoesUserExist(string Username)
        // {
        //     return _context.UserInfo.SingleOrDefault(User => User.Username == Username) != null;
        // }

        // public bool CreateUser(CreateAccountDTO UserToAdd)
        // {
        //     bool result = false;

        //     if(!DoesUserExist(UserToAdd.Username))
        //     {
        //         UserModels newUser = new UserModels();

        //         var hashPassword = HashPassword(UserToAdd.Password);
        //             newUser.ID = UserToAdd.ID;
        //             newUser.Username = UserToAdd.Username;        
        //             newUser.Salt = hashPassword.Salt;
        //             newUser.Hash = hashPassword.Hash;  

        //             _context.Add(newUser);

        //             result = _context.SaveChanges() != 0;      
        //     }

        //     return result;
        // }


        // public PasswordDTO HashPassword(string Password)
        // {

        //     PasswordDTO NewHashPassword = new PasswordDTO();

        //     byte[] SaltBytes = new byte[64];
            
        //     RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
        //     provider.GetNonZeroBytes(SaltBytes);
        //     string salt = Convert.ToBase64String(SaltBytes);
        //     Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 1000);
        //     string Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

        //     NewHashPassword.Salt = salt;
        //     NewHashPassword.Hash = Hash;

        //     return NewHashPassword;

        // }

        // public bool VerifyPassword(string Password, string StoredHash, string StoredSalt)
        // {
        //     byte[] SaltBytes = Convert.FromBase64String(StoredSalt);
        //     Rfc2898DeriveBytes rfc2898DeriveBytes
        // }




    }
}