using System;

namespace Core.Calculations
{
	public class ReportItem
    {
		#region Properties
		public DateTimeOffset Date { get; set; }
        public int CalsConsumed { get; set; }
        public int CurrentWeight { get; set; }
		#endregion

		#region Konstruktor
		public ReportItem(
            DateTimeOffset date,
            int calsConsumed,
            int currentWeight)
        {
            Date = date;
            CalsConsumed = calsConsumed;
            CurrentWeight = currentWeight;
        }
        #endregion

       
    }
}
