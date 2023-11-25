using Core.Persistence;
using Core.Persistence.impl;
using Core.Useradministration.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.staticstuff;

namespace Tests.PersistenceTest
{
   
    [TestClass]
    public class UserPersistenceImplTest
    {
             
        IUserPersistence persistence = new UserPersistenceImpl();
        List<User> testUsers = new List<User>();

        [TestInitialize()]
        public void SetUp()
        {
            // Lösche alle DB einträge
            DBCleanup.ClearUsers();


            testUsers.Add(new User("schmidl.marco@gmx.de", "11111", "Marco", "Schmidl", 22, Sex.Male, 182, 87, 3, "maintain"));
            testUsers.Add(new User("katja.wm@yaho.de", "22222", "Katja", "Wiesmüller", 21, Sex.Female, 174, 54, 3, "maintain"));
            testUsers.Add(new User("luu.schunko@wb.de", "33333", "Lucas", "Schunko", 24, Sex.Male, 175, 72, 3, "maintain"));
        }

        [TestMethod]
        public void TestUserPersistence()
        {
            TestCreateUser();
            TestGetAllUsers();
            TestGetUsers();
            TestUpdateUser();
            TestDeleteUser();
            TestDeleteAllUsers();
        }

        public void TestCreateUser()
        {
            foreach (User u in testUsers)
            {
                Assert.IsNotNull(persistence.CreateUser(u));
            }

            using (CALContext db = new CALContext())
            {
                foreach (User u in testUsers)
                {
                    Assert.IsNotNull(db.UsersDB.Find(u.Email));
                }
            }
        }

        public void TestGetAllUsers()
        {
            List<User> dbUsers = persistence.GetAllUsers();
            Assert.AreEqual(3, dbUsers.Count);
            foreach (User u in dbUsers)
            {
                testUsers.Contains(u);
            }
        }

        public void TestGetUsers()
        {
            User user = persistence.GetUser(testUsers[1].Email);
            Assert.AreEqual(testUsers[1], user);
            Assert.IsNotNull(user.Weights);
            Assert.IsNotNull(user.Consumptions);
        }

        public void TestUpdateUser()
        {
            User u = testUsers[0]; 
            u.Age = 22;
            u.Name = "Hanse";
            u.LastName = "Meier";
            u.WeightGoal = 69;
            u.Goal = "lose";
            Assert.IsTrue(persistence.UpdateUser(u.Email, u));

            using (CALContext db = new CALContext())
            {
                User dbUser = db.UsersDB.Find(u.Email);
                Assert.AreEqual(u, dbUser);
            }
        }

        public void TestDeleteUser()
        {
            persistence.DeleteUser(null);
            User u = testUsers[0];
            testUsers.Remove(u);

            persistence.DeleteUser(u.Email);

            using (CALContext db = new CALContext())
            {
                Assert.IsNull(db.UsersDB.Find(u.Email));
            }
        }

        public void TestDeleteAllUsers()
        {
            persistence.DeleteAllUsers();
            using (CALContext db = new CALContext())
            {
                foreach (User u in testUsers)
                {
                    Assert.IsNull(db.UsersDB.Find(u.Email));
                }
            }
        }

        [TestCleanup()]
        public void CleanUp()
        {
            using (CALContext db = new CALContext())
            {
                List<User> allDbUsers = db.UsersDB.ToList();
                foreach (User u in allDbUsers)
                {
                    db.UsersDB.Remove(u);
                }
                db.SaveChanges();
            }
        }
    }
}
