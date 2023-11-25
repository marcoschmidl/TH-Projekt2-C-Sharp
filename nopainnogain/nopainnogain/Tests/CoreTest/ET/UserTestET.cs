using Core.Productadministration;
using Core.Useradministration.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests.CoreTest.ET
{
    [TestClass]
    public class UserTestET
    {
        [TestMethod]
        public void ConstructorTest()
        {
            User user = new User("schmidl.marco@protonmail.com", "12343", "Marco", "Schmidl", 22, Sex.Male, 182, 90, 3, "maintain");
            Assert.AreEqual("schmidl.marco@protonmail.com", user.Email);
            Assert.AreEqual("12343", user.Password);
            Assert.AreEqual("Marco", user.Name);
            Assert.AreEqual("Schmidl", user.LastName);
            Assert.AreEqual(22, user.Age);
            Assert.AreEqual(Sex.Male, user.Sex);
            Assert.AreEqual(182, user.BodySize);
            Assert.AreEqual(90, user.WeightGoal);
            Assert.AreEqual(3, user.Activity);
            Assert.AreEqual("maintain", user.Goal);
        }

        [TestMethod]
        public void EqualsTest()
        {
            User user1 = new User("schmidl.marco@protonmail.com", "12343", "Marco", "Schmidl", 22, Sex.Male, 182, 90, 3, "maintain");
            User user2 = new User("schmidl.marco@protonmail.com", "12343", "Marco", "Schmidl", 22, Sex.Male, 182, 90, 3, "maintain");
            User user3 = new User("luu.schunko@web.de", "33333", "Lucas", "Schunko", 24, Sex.Male, 170, 70, 3, "maintain");

            Assert.IsTrue(user1.Equals(user2));
            Assert.IsFalse(user1.Equals(user3));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            User user = new User("schmidl.marco@protonmail.com", "12343", "Marco", "Schmidl", 22, Sex.Male, 182, 90, 4, "maintain");
            Assert.AreNotEqual(-418252863, user.GetHashCode());
        }               
    }
}
