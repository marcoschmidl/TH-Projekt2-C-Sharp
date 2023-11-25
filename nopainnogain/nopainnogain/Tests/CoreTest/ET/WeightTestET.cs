using Core.Useradministration.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.CoreTest.ET
{
    [TestClass]
    public class WeightTestET
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var user3 = new User(
                "luu.schunko@wb.de",
                "33333",
                "Lucas",
                "Schunko",
                24,
                Sex.Male,
                175,
                72,
                3,
                "maintain");

            var weight = new Weight(90,DateTimeOffset.Now,user3);         
            Assert.AreEqual(90,weight.Amount);          
            Assert.AreEqual(user3, weight.User);            
        }

        [TestMethod]
        public void EqualsTest()
        {
            var user1 = new User(
                "luu.schunko@wb.de",
                "33333",
                "Lucas",
                "Schunko",
                24,
                Sex.Male,
                175,
                72,
                3,
                "maintain");
            var user2 = new User(
               "luu.schunko@wb.de",
               "33333",
               "Lucas",
               "Schunko",
               24,
               Sex.Male,
               175,
               72,
               3,
               "maintain");

            var weight1 = new Weight( 90,DateTimeOffset.Now, user1);
            var weight2 = new Weight( 90,DateTimeOffset.Now,  user1);
            Assert.IsTrue(weight1.Equals(weight2));          
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            var user1 = new User(
              "luu.schunko@wb.de",
              "33333",
              "Lucas",
              "Schunko",
              24,
              Sex.Male,
              175,
              72,
              3,
              "maintain");

            Weight weight1 = new Weight(90,DateTimeOffset.Now, user1);
            Assert.AreNotEqual(1235814647, weight1.GetHashCode());
        }
    }
}
