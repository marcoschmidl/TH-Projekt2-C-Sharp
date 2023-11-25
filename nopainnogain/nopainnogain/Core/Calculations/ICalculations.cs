using Core.Useradministration.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Calculations
{
    public interface ICalculations
    {
        //report of the weight data and the consumed calories of the last 7 days
        List<ReportItem> GetReport(Useradministration.entities.User user, string email);
    }
}
