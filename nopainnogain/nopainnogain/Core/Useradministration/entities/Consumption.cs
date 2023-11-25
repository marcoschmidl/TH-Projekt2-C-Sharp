using Core.Persistence;
using Core.Productadministration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Core.Useradministration.entities
{
    [Serializable, Table("The_Consumptions")]
    public class Consumption
    {
        #region Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsumptionID { get; set; }

        [Required]
        public DateTimeOffset ConsumptionTime { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [Required]
        public virtual User User { get; set; }
        #endregion

        #region Konstruktor
        public Consumption() { }

        public Consumption(
            DateTimeOffset consumptionTime,
            int quantity,
            Product product,
            User user)
        {
            ConsumptionTime = consumptionTime;
            Quantity = quantity;
            Product = product;
            User = user;
        }

        public Consumption(
            int consumptionID,
            DateTimeOffset consumptionTime,
            int quantity,
            Product product,
            User user)
        {
            ConsumptionID = consumptionID;
            ConsumptionTime = consumptionTime;
            Quantity = quantity;
            Product = product;
            User = user;
        }
        #endregion

        #region Methoden
        /// <summary>
        /// Wir nehmen die Liste und errechen für jedes Product darin anhand von Stück anzahl oder Gramm einen kalorien Wert
        /// </summary>
        /// <param name="clist"></param>
        /// <returns></returns>
        public int GetConsumptionCals(List<Consumption> clist)
        {
            int cal = 0;
            foreach (Consumption c in clist)
            {
                cal += (int)c.Quantity * (int)(c.Product.Kcal / (float)c.Product.Amount);
            }
            return cal;
        }

        /// <summary>
        /// Wir erstellen eine Liste anhand der Email die es mir anzeigt wird
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<Consumption> ConsumptionList(string email)
        {
            DateTimeOffset today = DateTimeOffset.Now;
            today = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            using (CALContext db = new CALContext())
            {
                return db.ConsumptionsDB
                    .Where(c => c.User.Email == email)
                    .Where(c => c.ConsumptionTime > today)
                    .Include(w => w.Product)
                    .ToList();
            }
        }

        /// <summary>
        /// Tracker Item hilft als ergänzug um die Consumptions in der GUI anzuzeigen 
        /// </summary>
        public class TrackerItem
        {
            public string Name { get; set; }
            public int Calorie { get; set; }
            public int Quant { get; set; }
            public int Total { get; set; }

            public TrackerItem(string name, int cal, int quant, int total)
            {
                this.Name = name;
                this.Calorie = cal;
                this.Quant = quant;
                this.Total = total;

            }

            public override string ToString()
            {
                return "Name: " + Name + "\n" + "Calories:  " + Calorie + " per 100g" + "\t" + " Total: " + Total + " Calories";

            }
        }

        /// <summary>
        /// Unterschied zur oberen : Soll Liste für ein DataGrid erstellen und ausgeben 
        /// </summary>
        /// <returns></returns>
        public List<TrackerItem> otherConsumptionList(string email)
        {
            List<TrackerItem> consump = new List<TrackerItem>();
            List<Consumption> x = ConsumptionList(email);
            
            foreach (Consumption item in x)
            {
                int quantitiy = item.Quantity;
                int calorie = item.Product.Kcal;
                string name = item.Product.Name;
                int total = (quantitiy * calorie) / 100;

                consump.Add(new TrackerItem(name, calorie, quantitiy, total));
            }
            return consump;
        }

        /// <summary>
        /// Wir geben einen User an, anhand dessern fragen wir die Properties ab und errechnen was der Kalorien Bedarf ist
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int CalorieTest(User u)
        {
            double demand = 0;
            if (u.Goal == "maintain")
            {
                if (u.Sex == Sex.Male)
                {
                    demand = 66.5 + (13.75 * (double)u.WeightToTrack) + (5.003 * (double)u.BodySize) - (6.775 * (double)u.Age);
                    demand = demand + (demand * (u.testaktiv - 1.0));
                    return (int)demand;
                }
                else
                {
                    demand = 655.1 + (9.563 + (double)u.WeightToTrack) + (1.850 * (double)u.BodySize) - (4.676 * (double)u.Age);
                    demand = demand + (demand * (u.testaktiv - 1.0));
                    return (int)demand;
                }
            }
            else if (u.Goal == "lose")
            {
                if (u.Sex == Sex.Male)
                {
                    demand = 66.5 + (13.75 * (double)u.WeightToTrack) + (5.003 * (double)u.BodySize) - (6.775 * (double)u.Age);
                    demand = (demand + (demand * (u.testaktiv - 1.0))) - 300.0;
                    return (int)demand;
                }
                else
                {
                    demand = 655.1 + (9.563 + (double)u.WeightToTrack) + (1.850 * (double)u.BodySize) - (4.676 * (double)u.Age);
                    demand = (demand + (demand * (u.testaktiv - 1.00))) - 300.0;
                    return (int)demand;
                }
            }
            else if (u.Goal == "gain")
            {
                if (u.Sex == Sex.Male)
                {
                    demand = 66.5 + (13.75 * (double)u.WeightToTrack) + (5.003 * (double)u.BodySize) - (6.775 * (double)u.Age);
                    demand = (demand + (demand * (u.testaktiv - 1))) + 250.0;
                    return (int)demand;
                }
                else
                {
                    demand = 655.1 + (9.563 + (double)u.WeightToTrack) + (1.850 * (double)u.BodySize) - (4.676 * (double)u.Age);
                    demand = (demand + (demand * (u.testaktiv - 1))) + 250.0;
                    return (int)demand;
                }
            }
            return (int)demand;
        }

        /// <summary>
        /// Wir übergeben das Ergebnis von CalorieTest und ziehen davon die Kalorien ab, die wir in einer Liste an Projukten Iteriert haben
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <returns></returns>               
        public int AuswertungConsumptonList(User user, string email)
        {
            List<Consumption> awList = ConsumptionList(email);
            int ConsumedCals = 0;

            foreach (Consumption item in awList)
            {
                ConsumedCals += item.GetConsumptionCals(awList);
            }
            return CalorieTest(user) - ConsumedCals;

        }
        #endregion

        #region Zusatzmethode
        public override bool Equals(object obj)
        {
            return obj is Consumption consumption &&
                   ConsumptionID == consumption.ConsumptionID &&
                   ConsumptionTime.Equals(consumption.ConsumptionTime) &&
                   Quantity == consumption.Quantity;
        }

        public override string ToString()
        {
            return Quantity + " " + Product.Name + " " + Product.Kcal + " " + User.Email;
        }

        public override int GetHashCode()
        {
            int hashCode = -289728932;
            hashCode = hashCode * -1521134295 + ConsumptionID.GetHashCode();
            hashCode = hashCode * -1521134295 + ConsumptionTime.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
        #endregion
    }
}
