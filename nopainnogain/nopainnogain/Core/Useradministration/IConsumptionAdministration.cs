using Core.Useradministration.entities;
using System.Collections.Generic;

namespace Core.Useradministration
{
    public interface IConsumptionAdministration
    {
        Consumption AddConsumption(Consumption consumption);
        Consumption GetConsumption(int id);
        ICollection<Consumption> GetAllConsumptions();
        bool UpdateConsumption(string id, Consumption consumption);
        void DeleteConsumption(int id);
    }
}
