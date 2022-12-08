using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character 
    {
		private string name;
		private double health;
		private double armor;

		public Character(string name, double health, double armor, double abilityPoints, Bag bag)
		{
			Name= name;
			Health= health;
			Armor= armor;
			AbilityPoints= abilityPoints;
			Bag= bag;
		}


		public string Name
		{
			get => name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
				}
				name = value;
			}
		}
		public double BaseHealth { get; private set; }
		public double Health 
		{
			get => health; 
			set
			{
				if (value>BaseHealth)
				{
					value = BaseHealth;
				}
				else if (value<0)
				{
					value = 0;
				}
				health = value;
			}
}
		public double BaseArmor  { get; private set; }
		public double Armor
		{
			get => armor;
			set
			{
				if (value>BaseArmor)
				{
					value = BaseArmor;
				}
				else if (value<0)
				{
					value = 0;
				}
				armor = value;
			}
		}
		public double AbilityPoints { get; set; }
		public IBag Bag { get; private set; }

		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
		{
			if (IsAlive)
			{
				Armor -= hitPoints;
				if (Armor<0)
				{
					double hitPointsLeft = Math.Abs(Armor);
					Armor = 0;
					Health-= hitPointsLeft;

					if (Health<=0)
					{
						Health=0;
						IsAlive= false;
					}
				}

			}
		}

		public void UseItem(Item item)
		{
			if (IsAlive) 
			{
				item.AffectCharacter(this);
			}
		}

    }
}