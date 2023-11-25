using Core.Useradministration.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Productadministration
{
    [Serializable, Table("The_Poducts")]
    public class Product
    {
        #region Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Kcal { get; set; }

        [Required]
        public int Protein { get; set; } //einbauen

        [Required]
        public int Carbs { get; set; }

        [Required]
        public int Fat { get; set; }

        [Required]
        public int Amount { get; set; }

        public ICollection<Consumption> Consumptions { get; set; }
        #endregion

        #region Konstruktor
        public Product() { }

        public Product(
            string name,
            int kcal,
            int protein,
            int carbs,
            int fat,
            int amount)
        {
            Name = name;
            Kcal = kcal;
            Protein = protein;
            Carbs = carbs;
            Fat = fat;
            Amount = amount;

        }
		#endregion

		#region Zusatzmethoden
		public override bool Equals(object obj)
        {
            return obj is Product product &&
                   ProductID == product.ProductID &&
                   Name == product.Name &&
                   Kcal == product.Kcal &&
                   Protein == product.Protein &&
                   Carbs == product.Carbs &&
                   Fat == product.Fat &&
                   Amount == product.Amount;

        }

        public override string ToString()
        {
            return ProductID + " " + Name + " " + Kcal + " " + Protein + " " + Carbs + " " + Fat + " " + Amount;
        }

        public override int GetHashCode()
        {
            int hashCode = -323619555;
            hashCode = hashCode * -1521134295 + ProductID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Kcal.GetHashCode();
            hashCode = hashCode * -1521134295 + Protein.GetHashCode();
            hashCode = hashCode * -1521134295 + Carbs.GetHashCode();
            hashCode = hashCode * -1521134295 + Fat.GetHashCode();
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();

            return hashCode;
        }
		#endregion
	}
}
