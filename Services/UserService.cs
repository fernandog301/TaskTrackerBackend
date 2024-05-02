
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        public bool DoesUserExist(string Username)
        {
            return _context.UserInfo.SingleOrDefault(User => User.Username == Username) != null;
        }

        public string GenerateImgID()
        {
            string[] abcArr = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Random random = new Random();

            string remainingDigits = "";
                for (int i = 0; i < 6; i++)
                {
                    if (random.Next(0, 2)== 0)
                    {
                        int digit = random.Next(0, 10); // Generate a random digit from 0 to 9
                        remainingDigits += digit.ToString();

                    }
                    else {
                        int digit = random.Next(0, 26);
                        remainingDigits += abcArr[digit];
                    }
                }
            return remainingDigits;

        }
            
       

        public bool CreateUser(CreateAccountDTO UserToAdd)
        {
            bool result = false;

            if(!DoesUserExist(UserToAdd.Username))
            {
                UserModels newUser = new UserModels();

                var hashPassword = HashPassword(UserToAdd.Password);
                
                    newUser.ID = UserToAdd.ID;

                    newUser.ProfileImg = UserToAdd.ProfileImg;

                    newUser.Username = UserToAdd.Username;   

                    
                    newUser.Password = "Cant see it";
                    
                    newUser.Username = UserToAdd.Username;




                    newUser.Salt = hashPassword.Salt;
                    newUser.Hash = hashPassword.Hash;  
                    newUser.AccountCreated = true;
                    // newUser.BoardInfo = new List<BoardModel>();

                    _context.Add(newUser);

                    result = _context.SaveChanges() != 0;  
                    result = true;    
            }

            return result;
        }


        public PasswordDTO HashPassword(string Password)
        {

            PasswordDTO NewHashPassword = new PasswordDTO();

            byte[] SaltBytes = new byte[64];
            
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

            provider.GetNonZeroBytes(SaltBytes);

            string salt = Convert.ToBase64String(SaltBytes);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 1000);

            string hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            NewHashPassword.Salt = salt;
            NewHashPassword.Hash = hash;

            return NewHashPassword;

        }

        public bool VerifyPassword(string Password, string StoredHash, string StoredSalt)
        {
            byte[] SaltBytes = Convert.FromBase64String(StoredSalt);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 1000);

            string NewHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return NewHash == StoredHash;

        }

        public IActionResult Login(LoginDTO User)
        {
            IActionResult Result = Unauthorized();

            if(DoesUserExist(User.Username))
            {

                UserModels foundUser = GetUserByUsername(User.Username);

                if(VerifyPassword(User.Password, foundUser.Hash, foundUser.Salt)){

                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


                    Result = Ok(new { Token = tokenString});
                }
            }
            return Result;
        }

        public UserModels GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        // public List<BoardModel> GetBaordById(string BoardID)
        // {
        //     return _context.BoardInfo.Where(board => board.BoardID == BoardID).ToList();
        // }


        public bool UpdateUser(UserModels userToUpdate)
        {
            _context.Update<UserModels>(userToUpdate);
            return _context.SaveChanges() !=0 ;
        }

        public bool UpdateProfileImg(int id, string profileImg)
        {   
            UserModels foundUser = GetUserById(id);

             bool result = false;
             if(foundUser != null)
             {
                foundUser.ProfileImg = profileImg;
                _context.Update<UserModels>(foundUser);
                result = _context.SaveChanges() !=0 ;
             }
             return result;
        }


        public bool UpdateUsername(int id, string username)
        {
            UserModels foundUser = GetUserById(id);

            bool result = false;
             if(foundUser != null)
             {
                foundUser.Username = username;
                _context.Update<UserModels>(foundUser);
                result = _context.SaveChanges() !=0 ;
             }
             return result;

        }

        public UserModels GetUserById(int id)
        {
            return _context.UserInfo.SingleOrDefault(user => user.ID == id);
        }

        // public bool GetImage()
        // {
        //     return _context.ImageInfo.Any()
        // }
        
        public bool DeleteUser(string userToDelete)
        {
            // We are only sending over the username
            // If username found, delete user

            UserModels foundUser = GetUserByUsername(userToDelete);

            bool result = false;

            if (foundUser != null)
            {
                // If we have found a user

                _context.Remove<UserModels>(foundUser);
                result = _context.SaveChanges() != 0;
            }

            return result;
        }

        public UserIdDTO GetUserIdDTOByUsername(string username)
        {
            UserIdDTO UserInfo = new UserIdDTO();

            // Now we need to query through our database to find the user based on the name inside the database
            UserModels foundUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);

            UserInfo.UserId = foundUser.ID;

            // Assign the 
            UserInfo.PublisherName = foundUser.Username;

            return UserInfo;
        }





    }
}