using Core.Persistence;
using Core.Productadministration;
using Core.Useradministration.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.staticstuff
{
    public class DBCleanup
    {
        public static void ClearUsers()
        {
            using (CALContext db = new CALContext())
            {
                List<User> allUsers = db.UsersDB.ToList();
                foreach (User u in allUsers)
                {
                    db.UsersDB.Remove(u);
                }
                db.SaveChanges();
            }
        }

        public static void ClearWeights()
        {
            using (CALContext db = new CALContext())
            {
                List<Weight> allWeights = db.WeightsDB.ToList();
                foreach (Weight w in allWeights)
                {
                    db.WeightsDB.Remove(w);

                }
                db.SaveChanges();
            }
        }

        public static void ClearProducts()
        {

            using (CALContext db = new CALContext())
            {
                List<Product> allProducts = db.ProductsDB.ToList();
                foreach (Product p in allProducts)
                {
                    db.ProductsDB.Remove(p);
                }
                db.SaveChanges();
            }
        }
        public static void ClearConsumptions()
        {

            using (CALContext db = new CALContext())
            {
                List<Consumption> allConsumptions = db.ConsumptionsDB.ToList();
                foreach (Consumption c in allConsumptions)
                {
                    db.ConsumptionsDB.Remove(c);
                }
                db.SaveChanges();
            }
        }

    }
}
