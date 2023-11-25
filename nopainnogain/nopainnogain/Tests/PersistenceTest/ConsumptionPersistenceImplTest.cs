using Core.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Persistence.impl;
using Core.Calculations;
using Core.Useradministration.entities;
using System.Linq;
using Core.Productadministration;
using Tests.staticstuff;

namespace Tests.PersistenceTest
{
    [TestClass]
    public class ConsumptionPersistenceTest
    {
        IConsumptionPersistence persistence = new ConsumptionPersistenceImpl();
        List<Consumption> testConsumptions = new List<Consumption>();
        User testUser;
        Product testProduct;
        
        [TestInitialize]
        public void Setup()
        {
            DBCleanup.ClearConsumptions();
            DBCleanup.ClearUsers();
            DBCleanup.ClearProducts();

            testUser = new User("schmidl.marco@gmx.de", "11111", "Marco", "Schmidl", 22, Sex.Male, 182, 87, 3, "maintain");
            CreateUserInDb(testUser);

            testProduct = new Product("Steak", 600, 80, 0, 40, 1);
            CreateProductInDb(testProduct);

            testConsumptions.Add(new Consumption(DateTimeOffset.Now, 50, testProduct, testUser));
            testConsumptions.Add(new Consumption(DateTimeOffset.Now, 100, testProduct, testUser));
            testConsumptions.Add(new Consumption(DateTimeOffset.Now, 150, testProduct, testUser));
        }

        [TestMethod]
        public void TestConsumptionPersistence()
        {
            TestCreateConsumption();
            TestGetAllConsumptions();
            TestGetConsumptions();
            TestDeleteConsumption();
            TestDeleteAllConsumptions();
        }
        private void TestCreateConsumption()
        {
            foreach (Consumption c in testConsumptions)
            {
                Assert.IsNotNull(persistence.CreateConsumption(c));
            }

            using (CALContext db = new CALContext())
            {
                foreach (Consumption c in testConsumptions)
                {
                    Assert.IsNotNull(db.ConsumptionsDB.Find(c.ConsumptionID));
                }
            }
        }
        private void TestGetAllConsumptions()
        {
            List<Consumption> dbConsumptions = persistence.GetAllConsumptions();
            Assert.AreEqual(3, dbConsumptions.Count);
            foreach (Consumption u in dbConsumptions)
            {
                testConsumptions.Contains(u);
                Assert.IsNotNull(u.Product);
                Assert.IsNotNull(u.User);
            }
        }

        private void TestGetConsumptions()
        {
            Consumption consumption = persistence.GetConsumption(testConsumptions[0].ConsumptionID);
            Assert.AreEqual(testConsumptions[0], consumption);
            Assert.IsNotNull(consumption.User);
            Assert.IsNotNull(consumption.Product);
        }

        private void TestDeleteConsumption()
        {
            persistence.DeleteConsumption(-1);
            Consumption c = testConsumptions[0];
            testConsumptions.Remove(c);

            persistence.DeleteConsumption(c.ConsumptionID);

            using (CALContext db = new CALContext())
            {
                Assert.IsNull(db.ConsumptionsDB.Find(c.ConsumptionID));
            }
        }

        private void TestDeleteAllConsumptions()
        {
            persistence.DeleteAllCOnsumptions();
            using (CALContext db = new CALContext())
            {
                foreach (Consumption c in testConsumptions)
                {
                    Assert.IsNull(db.ConsumptionsDB.Find(c.ConsumptionID));
                }
            }
        }
      
        [TestCleanup()]
        public void CleanUp()
        {
            DBCleanup.ClearConsumptions();
            DBCleanup.ClearUsers();
            DBCleanup.ClearProducts();

        }

        private void CreateUserInDb(User user)
        {
            using (CALContext db = new CALContext())
            {
                db.UsersDB.Add(user);
                db.SaveChanges();
            }
        }

        private void CreateProductInDb(Product product)
        {
            using (CALContext db = new CALContext())
            {
                db.ProductsDB.Add(product);
                db.SaveChanges();
            }
        }
    }
}


