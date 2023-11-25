using System.Collections.Generic;
using Core.Useradministration.entities;

namespace Core.Persistence
{
    public interface IWeightsPersistence
    {
        Weight CreateWeight(Weight weight);      
        Weight GetWeight(int id);      
        List<Weight> GetAllWeights();      
        void DeleteWeight(int weightID);
        void DeteteAllWeights();
        bool UpdateWeight(int id, Weight weight);
    }
}
