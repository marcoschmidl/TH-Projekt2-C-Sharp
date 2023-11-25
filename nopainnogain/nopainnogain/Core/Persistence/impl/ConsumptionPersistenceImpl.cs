using Core.Useradministration.entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.Persistence.impl
{
    public class ConsumptionPersistenceImpl : IConsumptionPersistence
    {
        public Consumption CreateConsumption(Consumption consumption)
        {
            using (CALContext db = new CALContext())
            {
                consumption.User = db.UsersDB.Find(consumption.User.Email);
                consumption.Product = db.ProductsDB.Find(consumption.Product.ProductID);
                Consumption created = db.ConsumptionsDB.Add(consumption);
                db.SaveChanges();

                created = db.ConsumptionsDB
                    .Where(c => c.ConsumptionID == created.ConsumptionID)
                    .Include(c => c.User)
                    .Include(c => c.Product)
                    .FirstOrDefault();

                return created;
            }
        }

        public void DeleteConsumption(int id)
        {
            using (CALContext db = new CALContext())
            {
                Consumption consumptionDelete = db.ConsumptionsDB.Find(id);
                if (consumptionDelete == null)
                    return;

                db.ConsumptionsDB.Remove(consumptionDelete);
                db.SaveChanges();
            }
        }

        public List<Consumption> GetAllConsumptions()
        {
            using (CALContext db = new CALContext())
            {
                return db.ConsumptionsDB
                    .Include(c => c.User)
                    .Include(c => c.Product)
                    .ToList();
            }
        }

        public Consumption GetConsumption(int id)
        {
            using (CALContext db = new CALContext())
            {
                Consumption consumption = db.ConsumptionsDB
                    .Where(c => c.ConsumptionID == id)
                    .Include(w => w.User)
                    .Include(w => w.Product)
                    .FirstOrDefault();
                if (consumption == null)
                    throw new KeyNotFoundException();
                else
                    return consumption;
            }
        }

        public bool UpdateConsumption(string id, Consumption consumption)
        {
            using (CALContext db = new CALContext())
            {
                Consumption c = db.ConsumptionsDB.Find(id);
                if (c == null)
                    return false;

                c.ConsumptionTime = consumption.ConsumptionTime;
                c.Quantity = consumption.Quantity;
                c.Product = consumption.Product; 
                db.SaveChanges();

                c = db.ConsumptionsDB.Find(id);
                return c.Equals(consumption);
            }

        }

        public void DeleteAllCOnsumptions()
        {
            using (CALContext db = new CALContext())
            {

                foreach (Consumption u in db.ConsumptionsDB.ToList())
                {
                    db.ConsumptionsDB.Remove(u);
                }
                db.SaveChanges();
            }
        }
    }
}
