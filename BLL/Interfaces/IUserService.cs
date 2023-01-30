using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDTO);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(UserDTO userDTO);
        UserDTO GetUserByUsername(string username);
        UserDTO Authenticate(string username, string password);
        void Dispose();
    }
}
