using Core.Productadministration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CoreTest.ET
{
    [TestClass]
    public class ProductTestET
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Product product = new Product("Doener", 600, 50, 100, 45, 1);
            Assert.AreEqual("Doener",product.Name);
            Assert.AreEqual(600, product.Kcal);
            Assert.AreEqual(50, product.Protein);
            Assert.AreEqual(100, product.Carbs);
            Assert.AreEqual(45, product.Fat);
            Assert.AreEqual(1, product.Amount);
        }

        [TestMethod]
        public void EqualsTest()
        {
            Product product1 = new Product("Doener", 600, 50, 100, 45, 1);
            Product product2 = new Product("Doener", 600, 50, 100, 45, 1);
            Assert.IsTrue(product1.Equals(product2));           
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Product product = new Product("Doener", 600, 50, 100, 45, 1);
            Assert.AreNotEqual(-323619555, product.GetHashCode());
        }   
    }
}
