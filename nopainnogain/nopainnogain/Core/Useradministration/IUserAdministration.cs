using Core.Useradministration.entities;
using System.Collections.Generic;

namespace Core.Useradministration
{
    public interface IUserAdministration
    {
        void CreateUser(User user);
        User GetUser(string email);
        ICollection<User> GetAllUsers();
        void UpdateUser(string email, User user);
        void AddWeight(string email, Weight weight);
        void DeleteUser(string email);
        bool LoginUser(string email, string password);
    }
}
