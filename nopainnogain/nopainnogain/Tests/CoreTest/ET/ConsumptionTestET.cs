using Core.Productadministration;
using Core.Useradministration.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.CoreTest.ET
{
    [TestClass]
    public class ConsumptionTestET
    {

        [TestMethod]
        public void ConstructorTest()
        {
            Product product = new Product("Doener",600,50,100,45,1);
            Core.Useradministration.entities.User user = new Core.Useradministration.entities.User("schmidl.marco@protonmail.com", "12343", "Marco", "Schmidl", 22, Sex.Male, 182, 90, 3,"maintain");
            Consumption consumption = new Consumption(DateTimeOffset.Now,100,product,user);           
            Assert.AreEqual(100, consumption.Quantity);
            Assert.AreEqual(user, consumption.User);
        }

        [TestMethod]
        public void EqualsTest()
        {
            Product product = new Product("Doener", 600, 50, 100, 45, 1);
            Core.Useradministration.entities.User user = new Core.Useradministration.entities.User("schmidl.marco@protonmail.com", "12343", "Marco", "Schmidl", 22, Sex.Male, 182, 90, 3, "maintain");
            Consumption consumption1 = new Consumption(DateTimeOffset.Now, 100, product, user);
            Consumption consumption2 = new Consumption(DateTimeOffset.Now, 100, product, user);           
            Assert.IsTrue(consumption1.Equals(consumption2));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Product product = new Product("Doener", 600, 50, 100, 45, 1);
            Core.Useradministration.entities.User user = new Core.Useradministration.entities.User("schmidl.marco@protonmail.com", "12343", "Marco", "Schmidl", 22, Sex.Male, 182, 90, 3, "maintain");
            Consumption consumption = new Consumption(111, DateTimeOffset.Now, 100, product, user);
            Assert.AreNotEqual(-289728932, consumption.GetHashCode());
        }
        
    }
}
