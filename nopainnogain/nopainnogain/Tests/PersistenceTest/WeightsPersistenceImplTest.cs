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
    public class WeightsPersistenceImplTest
    {
        IWeightsPersistence weightsPersistenceforTest = new WeightsPersistenceImpl();
        List<Weight> testWeights = new List<Weight>();
        User testUser;


        [TestInitialize()]
        public void Setup()
        {
            DBCleanup.ClearUsers();
            DBCleanup.ClearWeights();

            //testUsers.Add(new User("schmidl.marco@gmx.de", "11111", "Marco", "Schmidl", 22, Sex.Male, 182, 87, 3, "maintain"));
            testUser = new User("katja.wm@yaho.de", "22222", "Katja", "Wiesmüller", 21, Sex.Female, 174, 54, 3, "maintain");
            CreateUserInDb(testUser);
            //testUsers.Add(new User("luu.schunko@wb.de", "33333", "Lucas", "Schunko", 24, Sex.Male, 175, 72, 3, "maintain"));
            
            testWeights.Add(new Weight(80, DateTimeOffset.Now, testUser));
            testWeights.Add(new Weight(69, DateTimeOffset.Now, testUser));
            testWeights.Add(new Weight(420, DateTimeOffset.Now, testUser));
        }

        [TestMethod]
        public void TestWeightsPersistence()
        {
            TestCreateWeight();
            TestGetAllWeights();
            TestGetWeights();
            TestDeleteWeight();
            TestDeleteAllWeights();
        }

        private void TestCreateWeight()
        {
            List<Weight> newWeights = new List<Weight>();
            foreach (Weight u in testWeights)
            {
                Weight added = weightsPersistenceforTest.CreateWeight(u);
                Assert.IsNotNull(added);
                newWeights.Add(added);
            }

            testWeights = newWeights;

            using (CALContext db = new CALContext())
            {
                foreach (Weight w in testWeights)
                {
                    Assert.IsNotNull(db.WeightsDB.Find(w.WeightID));
                }
            }
        }

        private void TestGetAllWeights()
        {
            List<Weight> dbweights = weightsPersistenceforTest.GetAllWeights();
            Assert.AreEqual(3, dbweights.Count);
            foreach (Weight u in dbweights)
            {
                testWeights.Contains(u);
            }
        }

        private void TestGetWeights()
        {
            Weight weight = weightsPersistenceforTest.GetWeight(testWeights[0].WeightID);
            Assert.AreEqual(testWeights[0], weight);
            Assert.IsNotNull(weight.User);
           
        }

        private void TestDeleteAllWeights()
        {
            weightsPersistenceforTest.DeteteAllWeights();
            using (CALContext db = new CALContext())
            {
                foreach (Weight u in testWeights)
                {
                    Assert.IsNull(db.WeightsDB.Find(u.WeightID));
                }
            }
        }

        private void TestDeleteWeight()
        {
            Weight u = testWeights[0];
            testWeights.Remove(u);
            weightsPersistenceforTest.DeleteWeight(u.WeightID);

            using (CALContext db = new CALContext())
            {
                Assert.IsNull(db.WeightsDB.Find(u.WeightID));
            }
        }

        [TestCleanup()] 
        public void CleanUp()
        {
            DBCleanup.ClearUsers();
            DBCleanup.ClearWeights();
        }

        private void CreateUserInDb(User user)
        {
            using (CALContext db = new CALContext())
            {
                db.UsersDB.Add(user);
                db.SaveChanges();
            }
        }
    }
}
