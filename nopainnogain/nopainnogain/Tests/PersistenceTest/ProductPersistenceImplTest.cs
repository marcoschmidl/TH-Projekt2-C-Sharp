using Core.Persistence;
using Core.Persistence.impl;
using Core.Productadministration;
using Core.Useradministration.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.staticstuff;

namespace Tests.PersistenceTest
{

    [TestClass]
    public class ProductPersistenceImplTest
    {
        IProductPersistence persistence = new ProductPersistenceImpl();
        List<Product> testProducts = new List<Product>();

        [TestInitialize()]
        public void Setup()
        {
            DBCleanup.ClearProducts();


            testProducts.Add(new Product("Steak", 600, 80, 0, 40, 1));
            testProducts.Add(new Product("Banane", 100, 5, 50, 0, 1));
            testProducts.Add(new Product("Toast", 195, 12, 50, 6, 1));

        }

        [TestMethod]
        public void TestProductPersistence()
        {
            TestCreateProduct();
            TestGetAllProducts();
            TestGetProduct();
            TestDeleteProduct();
            TestDeleteAllProducts();

        }

        private void TestDeleteAllProducts()
        {
            persistence.DeleteAllProducts();
            using (CALContext db = new CALContext())
            {
                foreach (Product u in testProducts)
                {
                    Assert.IsNull(db.ProductsDB.Find(u.ProductID));
                }
            }
        }

        private void TestDeleteProduct()
        {
            persistence.DeleteProduct(-1);
            Product p = testProducts[0];
            testProducts.Remove(p);

            persistence.DeleteProduct(p.ProductID);

            using (CALContext db = new CALContext())
            {
                Assert.IsNull(db.ProductsDB.Find(p.ProductID));
            }
        }

        private void TestGetProduct()
        {
            Product product = persistence.GetProduct(testProducts[1].ProductID);
            Assert.AreEqual(testProducts[1], product);
        }

        private void TestGetAllProducts()
        {
            List<Product> dbProducts = persistence.GetAllProducts();
            Assert.AreEqual(3, dbProducts.Count);
            foreach (Product p in dbProducts)
            {
                testProducts.Contains(p);
            }
        }

        private void TestCreateProduct()
        {
            foreach (Product p in testProducts)
            {
                Assert.IsNotNull(persistence.CreateProduct(p));
            }
            using (CALContext db = new CALContext())
            {
                foreach (Product p in testProducts)
                {
                    Assert.IsNotNull(db.ProductsDB.Find(p.ProductID));
                }
            }
        }


        [TestCleanup()]

        public void CleanUp()
        {
            using (CALContext db = new CALContext())
            {
                List<Product> allDbProducts = db.ProductsDB.ToList();
                foreach (Product u in allDbProducts)
                {
                    db.ProductsDB.Remove(u);
                }
                db.SaveChanges();
            }
        }

    }

}