using Core.Useradministration.entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.Persistence.impl
{
	public class UserPersistenceImpl : IUserPersistence
    {

        public User CreateUser(User user)
        {
            using (CALContext db = new CALContext())
            {
                User created = db.UsersDB.Add(user);
                db.SaveChanges();

                return created;
            }
        }

        public void DeleteAllUsers()
        {
            using (CALContext db = new CALContext())
            {
                foreach (User u in db.UsersDB.ToList())
                {
                    if (u == null)
                        continue;

                    db.UsersDB.Remove(u);
                }
                db.SaveChanges();
            }
        }

        public void DeleteUser(string email)
        {
            using (CALContext db = new CALContext())
            {
                User userdelete = db.UsersDB.Find(email);
                if (userdelete == null)
                    return;

                db.UsersDB.Remove(userdelete);
                db.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            using (CALContext db = new CALContext())
            {
                return db.UsersDB
                     .Include(u => u.Weights)
                     .Include(u => u.Consumptions)
                     .ToList();
            }
        }

        public User GetUser(string email)
        {
            using (CALContext db = new CALContext())
            {
                User user = db.UsersDB
                    .Where(u => u.Email == email)
                    .Include(u => u.Weights)
                    .Include(u => u.Consumptions)
                    .FirstOrDefault();
                return user;
            }
        }

        public bool UpdateUser(string email, User user)
        {
            using (CALContext db = new CALContext()) 
            {
                User x = db.UsersDB.Find(email);
                if (x == null)
                    return false;

                x.Password = user.Password;
                x.Name = user.Name;
                x.LastName = user.LastName;
                x.Age = user.Age;
                x.Sex = user.Sex;
                x.BodySize = user.BodySize;
                x.WeightGoal = user.WeightGoal;
                x.Goal = user.Goal;
                x.Activity = user.Activity;
                x.testaktiv = user.testaktiv;
                x.WeightToTrack = user.WeightToTrack;
                db.SaveChanges();
            }
            return true;
        }
    }
}
