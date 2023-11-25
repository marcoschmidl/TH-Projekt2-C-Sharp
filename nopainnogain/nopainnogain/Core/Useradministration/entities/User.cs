using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Useradministration.entities
{
	#region Enum
	public enum Sex
	{
		Male,
		Female
	}
	#endregion

	[Serializable, Table("The_Users")]
	public class User
	{
		#region Properties
		[Key]
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public int Age { get; set; }

		[Required]
		public Sex Sex { get; set; }

		[Required]
		public int BodySize { get; set; }

		[Required]
		public int WeightGoal { get; set; }

		[Required]
		public double Activity { get; set; }

		[Required]
		public string Goal { get; set; }

		public int WeightToTrack
		{
			get; set;
		}

		public double testaktiv { get; set; }

		public virtual List<Consumption> Consumptions { get; set; }

		public virtual List<Weight> Weights { get; set; }
		#endregion

		#region Konstruktor
		public User() { }

		public User(
		  string email,
		  string password,
		  string name,
		  string lastName,
		  int age,
		  Sex sex,
		  int bodySize,
		  int weightGoal,
		  double akt,
		  string goal,
		  int weighttottrack
		  )
		{
			Email = email;
			Password = password;
			Name = name;
			LastName = lastName;
			Age = age;
			Sex = sex;
			BodySize = bodySize;
			WeightGoal = weightGoal;
			testaktiv = akt;
			Goal = goal;
			WeightToTrack = weighttottrack;
		}


		public User(
			string email,
			string password,
			string name,
			string lastName,
			int age,
			Sex sex,
			int bodySize,
			int weightGoal,
			double activity,
			string goal)
		{
			Email = email;
			Password = password;
			Name = name;
			LastName = lastName;
			Age = age;
			Sex = sex;
			BodySize = bodySize;
			WeightGoal = weightGoal;
			Activity = activity;
			Goal = goal;
		}

		public User(string email,
			string password,
			string name,
			string lastName,
			int age,
			Sex sex,
			int bodySize,
			int weightGoal,
			double activity,
			string goal,
			List<Consumption> consumptions,
			List<Weight> weights) : this(
				email,
				password,
				name,
				lastName,
				age,
				sex,
				bodySize,
				weightGoal,
				activity,
				goal)
		{
			Consumptions = consumptions;
			Weights = weights;
		}
		#endregion
		
		#region Standardmethoden
		public override string ToString()
		{
			return Email + " " + Name + " " + LastName;
		}

		public override bool Equals(object obj)
		{
			return obj is User user &&
				   Email == user.Email &&
				   Password == user.Password &&
				   Name == user.Name &&
				   LastName == user.LastName &&
				   Age == user.Age &&
				   Sex == user.Sex &&
				   BodySize == user.BodySize &&
				   WeightGoal == user.WeightGoal &&
				   Activity == user.Activity &&
				   Goal == user.Goal &&
				   WeightToTrack == user.WeightToTrack &&
				   testaktiv == user.testaktiv;
		}

		public override int GetHashCode()
		{
			int hashCode = -418252863;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
			hashCode = hashCode * -1521134295 + Age.GetHashCode();
			hashCode = hashCode * -1521134295 + Sex.GetHashCode();
			hashCode = hashCode * -1521134295 + BodySize.GetHashCode();
			hashCode = hashCode * -1521134295 + WeightGoal.GetHashCode();
			hashCode = hashCode * -1521134295 + Activity.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Goal);
			hashCode = hashCode * -1521134295 + WeightToTrack.GetHashCode();
			hashCode = hashCode * -1521134295 + testaktiv.GetHashCode();
			return hashCode;
		}
		#endregion
	}
}
