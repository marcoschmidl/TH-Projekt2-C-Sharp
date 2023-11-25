using Core.Calculations;
using Core.Persistence;
using Core.Persistence.impl;
using Core.Productadministration;
using Core.Productadministration.impl;
using Core.Useradministration;
using Core.Useradministration.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Demo
{
    [TestClass]
    public class UserDemo
    {
        private static IUserPersistence userPersist = new UserPersistenceImpl();
        private static IProductPersistence productPersist = new ProductPersistenceImpl();
        private static IConsumptionPersistence consumptionPersist = new ConsumptionPersistenceImpl();
        private static IWeightsPersistence weightsPersist = new WeightsPersistenceImpl();

        [AssemblyInitialize()]
        public static void AssemblySetup(TestContext test)
        {
            userPersist.DeleteAllUsers();
            productPersist.DeleteAllProducts();
            consumptionPersist.DeleteAllCOnsumptions();
            weightsPersist.DeteteAllWeights();
        }


        [AssemblyCleanup()]
        public static void Cleanup()
        {
            userPersist.DeleteAllUsers();
            productPersist.DeleteAllProducts();
            consumptionPersist.DeleteAllCOnsumptions();
            weightsPersist.DeteteAllWeights();

            IUserAdministration userAdmin = new UserAdministrationImpl();
            IProductAdministration productAdmin = new ProductAdministrationImpl();
            IConsumptionAdministration consumptionAdmin = new ConsumptionAdministration();

            #region user daten
            List<User> users = new List<User>();
            users.Add(new User("katja.wiesmueller@gmx.de", "1234", "Katja", "Wiesmüller", 21, Sex.Female, 168, 56, 1.7, "lose", 57));
            users.Add(new User("lucas.schunko@gmx.de", "1234", "Lucas", "Schunko", 24, Sex.Male, 175, 75, 1.7, "maintain", 75));
            users.Add(new User("marco.schmidl@gmx.de", "5678", "Marco", "Schmidl", 22, Sex.Male, 182, 90, 1.9, "gain", 87));
            userAdmin.CreateUser(users[0]);
            userAdmin.CreateUser(users[1]);
            userAdmin.CreateUser(users[2]);

            #endregion

            Random random = new Random();
            List<Weight> weights = new List<Weight>();
            for (int i = 0; i < 50; i++)
            {

                int amount = random.Next(50, 90);
                DateTimeOffset time = getRandomTime(random);
                int u = random.Next(users.Count - 1);

                Weight w = new Weight(amount, time, users[u]);
                weights.Add(w);
                userAdmin.AddWeight(w.User.Email, w);
            }

            #region products
            List<Product> products = new List<Product>();
            foreach (List<string> x in ReadFile("./demo/resources/products.txt", ','))
            {
                Product p = new Product(x[0], Convert.ToInt32(x[1]), Convert.ToInt32(x[2]), Convert.ToInt32(x[3]), Convert.ToInt32(x[4]), Convert.ToInt32(x[5]));
                productAdmin.CreateProduct(p);
                products.Add(p);
            }
            #endregion 

            for (int i = 0; i < 50; i++)
            {
                DateTimeOffset time = getRandomTime(random);
                int quantity = random.Next(20, 200);
                int p = random.Next(products.Count - 1);
                int u = random.Next(users.Count - 1);
                Consumption c = new Consumption(time, quantity, products[p], users[u]);
                consumptionAdmin.AddConsumption(c);
            }
        }

        private static DateTimeOffset getRandomTime(Random random)
        {
            int year = random.Next(2019, 2020);
            int month = random.Next(1, 12);
            int day = random.Next(1, 28);
            int hour = random.Next(0, 23);
            int minute = random.Next(0, 59);
            int second = random.Next(0, 59);
            return new DateTimeOffset(new DateTime(year, month, day, hour, minute, second));
        }

        private static List<List<string>> ReadFile(string path, char splitChar)
        {
            List<List<string>> output = new List<List<string>>();

            int counter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                output.Add(line.Split(splitChar).ToList());
                counter++;
            }
            file.Close();

            return output;
        }
    }
}
