using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Useradministration.entities
{
    [Serializable, Table("The_Weights")]
    public class Weight : IComparable<Weight>
    {
        #region Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeightID { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTimeOffset Datetime { get; set; }

        [Required]
        public virtual User User { get; set; } //vitual keyword bedeutet lazy loading
        #endregion

        #region Konstruktor
        public Weight() { }

        //Konstrukter für Front-End
        public Weight(
            int amount,
            DateTimeOffset datetime)
        {
            Amount = amount;
            Datetime = datetime;
        }

        public Weight(
            int amount,
            DateTimeOffset datetime,
            User user)
        {
            Amount = amount;
            Datetime = datetime;
            User = user;
        }

        //Konstruktor für Persistenz
        public Weight(
            int weightID,
            int amount,
            DateTimeOffset datetime,
            User user)
        {
            WeightID = weightID;
            Amount = amount;
            Datetime = datetime;
            User = user;
        }
        #endregion

        #region ZusatzMethoden
        public int CompareTo(Weight other)
        {
            return Amount.CompareTo(other.Amount);
        }

        public override string ToString()
        {
            return WeightID + " " + Amount;
        }

        public override bool Equals(object obj)
        {
            return obj is Weight weight &&
                   WeightID == weight.WeightID &&
                   Amount == weight.Amount &&
                   Datetime.Equals(weight.Datetime);
        }

		public override int GetHashCode()
		{
			int hashCode = 1235814647;
			hashCode = hashCode * -1521134295 + WeightID.GetHashCode();
			hashCode = hashCode * -1521134295 + Amount.GetHashCode();
			hashCode = hashCode * -1521134295 + Datetime.GetHashCode();
			return hashCode;
		}
		#endregion

	}
}
