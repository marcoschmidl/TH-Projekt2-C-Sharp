using System.Collections.Generic;
using Core.Useradministration.entities;

namespace Core.Persistence
{
    public interface IConsumptionPersistence
    {
        Consumption CreateConsumption(Consumption consumption);
        Consumption GetConsumption(int id);
        List<Consumption> GetAllConsumptions();
        bool UpdateConsumption(string id, Consumption consumption);
        void DeleteConsumption(int id);
        void DeleteAllCOnsumptions();
    }
}
