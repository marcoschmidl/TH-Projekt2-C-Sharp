using Core.Useradministration.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.impl
{
    public class WeightsPersistenceImpl : IWeightsPersistence
    {
        public Weight CreateWeight(Weight weight)
        {
            using (CALContext db = new CALContext())
            {
                    weight.User = db.UsersDB.Find(weight.User.Email);
                    Weight created = db.WeightsDB.Add(weight);
                    db.SaveChanges();
                    created = db.WeightsDB
                        .Where(w => w.WeightID == created.WeightID)
                        .Include(w => w.User)
                        .FirstOrDefault();

                    return created;
                }
            }
        

        public void DeleteWeight(int WeightID)
        {
            using (CALContext db = new CALContext())
            {
                Weight weightdelete = db.WeightsDB.Find(WeightID);
                if (weightdelete == null)
                    return;

                db.WeightsDB.Remove(weightdelete);
                db.SaveChanges();
            }
        }

        public void DeteteAllWeights()
        {
            using (CALContext db = new CALContext())
            {
                foreach (Weight u in db.WeightsDB.ToList())
                {
                    if (u == null)
                        continue;

                    db.WeightsDB.Remove(u);
                }
                db.SaveChanges();
            }
        }

        public List<Weight> GetAllWeights()
        {
            using (CALContext db = new CALContext())
            {
                return db.WeightsDB.Include(w => w.User).ToList();
            }
        }

        public Weight GetWeight(int id)
        {
            using (CALContext db = new CALContext())
            {
                Weight weight = db.WeightsDB
                .Where(w => w.WeightID == id)
                .Include(w => w.User)
                .FirstOrDefault();
                if (weight == null)
                    throw new KeyNotFoundException(); 
                else
                    return weight;
            }

        }



        public bool UpdateWeight(int id, Weight weight)
        {  
            using (CALContext db = new CALContext())
            {
                Weight x = db.WeightsDB.Find(weight);
                if (x == null)
                    return false;
                x.Amount = weight.Amount;
                x.Datetime = weight.Datetime;
                x.User.Email = weight.User.Email;
                db.SaveChanges();
                
                x = db.WeightsDB.Find(id);
                return x.Equals(weight);
            }

        }
    }
}
