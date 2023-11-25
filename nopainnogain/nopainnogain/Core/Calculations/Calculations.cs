using Core.Persistence;
using Core.Useradministration.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.Calculations
{
    public class Calculations : ICalculations
    {     
        public List<ReportItem> GetReport(User user, string email)
        {
            DateTimeOffset today = DateTimeOffset.Now;
            List<DateTimeOffset> offsets = new List<DateTimeOffset>();
            //last 7 Days
            offsets.Add(new DateTimeOffset(new DateTime(today.Year, today.Month, today.Day, 0, 0, 0)));
            for (int i = 1; i <= 7; i++)
            {
                offsets.Add(offsets[0].AddDays(-i));
            }        
            List<Consumption> listCalculation = AllConsumptions(email);
            //weight data and calories consumed in the last 7 days 
            List<ReportItem> report = new List<ReportItem>();
            for (int i = 0; i < offsets.Count - 1; i++)
            {
                int calsConsumed = 0;
                foreach (Consumption c in listCalculation)
                {
                    if (c.ConsumptionTime < offsets[i])
                    {
                        calsConsumed += c.GetConsumptionCals(listCalculation);
                    }
                    else if (c.ConsumptionTime > offsets[i + 1])
                    {
                        break;
                    }
                }
                     
                int currentWeight = 0;
                foreach (Weight w in user.Weights)
                {
                    if (IsSameDay(w.Datetime, offsets[i + 1]))
                    {
                        currentWeight = w.Amount;
                        break;
                    }
                }
                report.Add(new ReportItem(offsets[i + 1], calsConsumed, currentWeight));
            }
            return report;
        }
            
        /// <summary>
        /// Liste die alle Consumptions vom von user x rausfilter
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<Consumption> AllConsumptions(string email)
        {
            using (CALContext db = new CALContext())
            {
                return db.ConsumptionsDB
                   .Where(c => c.User.Email == email)                   
                   .Include(w => w.Product)
                   .ToList();
            }
        }

        //Hilfsklasse
        private bool IsSameDay(DateTimeOffset a, DateTimeOffset b)
        {
            return a.Year == b.Year &&
                a.Month == b.Month &&
                a.Day == b.Day;
        }


    }
}
