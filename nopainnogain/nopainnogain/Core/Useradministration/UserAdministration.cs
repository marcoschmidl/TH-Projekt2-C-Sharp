using Core.Persistence;
using Core.Persistence.impl;
using System.Collections.Generic;

namespace Core.Useradministration.entities
{
    public class UserAdministrationImpl : IUserAdministration
    {
        private static IUserPersistence userPersistence = new UserPersistenceImpl();
        private static IWeightsPersistence weightsPersistence = new WeightsPersistenceImpl();

        public void AddWeight(string email, Weight weight)
        {
            User u = userPersistence.GetUser(email);
            weight.User = u;
            weightsPersistence.CreateWeight(weight);
        }

        public void CreateUser(User user)
        {

            userPersistence.CreateUser(user);
        }

        public void DeleteUser(string email)
        {
            userPersistence.DeleteUser(email);
        }

        public ICollection<User> GetAllUsers()
        {
            return userPersistence.GetAllUsers();
        }

        public User GetUser(string email)
        {
            return userPersistence.GetUser(email);
        }

        public bool LoginUser(string email, string password)
        {

            User user = GetUser(email);
            if (user != null)
            {
                if (password == user.Password)
                {
                    return true;
                }
            }
            return false;
        }


        public void UpdateUser(string email, User user)
        {
            userPersistence.UpdateUser(email, user);
        }

    }
}

