using Core.Persistence;
using Core.Persistence.impl;
using Core.Useradministration.entities;
using System.Collections.Generic;

namespace Core.Useradministration
{
    public class ConsumptionAdministration : IConsumptionAdministration
    {
        private static IConsumptionPersistence persistence = new ConsumptionPersistenceImpl();

        public Consumption AddConsumption(Consumption consumption)
        {
            return persistence.CreateConsumption(consumption);
        }

        public void DeleteConsumption(int id)
        {
            persistence.DeleteConsumption(id);
        }

        public ICollection<Consumption> GetAllConsumptions()
        {
            return persistence.GetAllConsumptions();
        }

        public Consumption GetConsumption(int id)
        {
            return persistence.GetConsumption(id);
        }

        public bool UpdateConsumption(string id, Consumption consumption)
        {
            return persistence.UpdateConsumption(id, consumption);
        }
    }
}
