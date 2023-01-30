using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Entities;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork unitOfWork) 
        {
            Database = unitOfWork;
        }
        public UserDTO Authenticate(string username, string password)
        {
            var account = Database.Users.Find(user => user.Username.Equals(username)).FirstOrDefault();
            if (account == null)
            {
                throw new Exception("User not found");
            } else if (!password.Equals(account.Password))
            {
                throw new Exception("Wrong password");
            }
            
            return MapperService.UserMapper.Map<UserDTO>(account);
        }

        public void CreateUser(UserDTO userDTO)
        {
            var error = Validator(userDTO);
            if (error != null)
            {
                throw new Exception(error);
            }

            var user = MapperService.UserDTOtoEntityMapper.Map<User>(userDTO);
            Database.Users.Create(user);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void UpdateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByUsername(string username)
        {
            var user = Database.Users.Find(_user => _user.Username.Equals(username)).FirstOrDefault();
            if (user != null) 
            {
                return MapperService.UserMapper.Map<UserDTO>(user);
            } else
            {
                throw new Exception("User does not exist");
            }
        }

        public string Validator(UserDTO user)
        {
            var tempUser = Database
                .Users
                .Find(_user => _user.Username.Equals(user.UserName))
                .FirstOrDefault();

            if (tempUser != null)
            {
                return "Such user already exists";
            }

            if (!Regex.IsMatch(user.FirstName, "^([a-zA-Z]){1,30}$"))
            {
                return "First name is incorrect";
            }

            if (!Regex.IsMatch(user.LastName, "^([a-zA-Z]){1,30}$"))
            {
                return "Last name is incorrect";
            }

            if (!Regex.IsMatch(user.Email, @"^((\w){1,30}@(\w){1,15}\.(\w){1,10})$"))
            {
                return "Email is incorrect";
            }

            if (!Regex.IsMatch(user.UserName, @"^((\w+)[a-zA-Z0-9]*){5,30}$"))
            {
                return "Username is incorrect";
            }

            if (!Regex.IsMatch(user.Password, @"\S{8,40}"))
            {
                return "Password is incorrect";
            }

            return null;
        }
    }
}
