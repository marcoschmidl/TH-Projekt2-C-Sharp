using Core.Useradministration.entities;
using System.Collections.Generic;

namespace Core.Persistence
{
    public interface IUserPersistence
    {
        User CreateUser(User user);      
        bool UpdateUser(string email, User user);      
        User GetUser(string email);      
        List<User> GetAllUsers();
        void DeleteUser(string email);
        void DeleteAllUsers();
    }
}
