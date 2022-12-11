using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;
        private IRepository<IDelicacy> delicacyRepository;
        private IRepository<ICocktail> coctailRepository;

        public Booth()
        {
          delicacyRepository = new DelicacyRepository();
          coctailRepository = new CocktailRepository();
        }
        public Booth(int boothId, int capacity):this()
        {
            BoothId = boothId;
            Capacity = capacity;
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacyRepository;

        public IRepository<ICocktail> CocktailMenu => coctailRepository;

        public double CurrentBill { get; private set; } //set initial value to zero

        public double Turnover { get; private set; } //set initial value to zero

        public bool IsReserved { get; private set; }



        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");

            sb.AppendLine($"-Cocktail menu:");
            foreach (var item in coctailRepository.Models)
            {
                sb.AppendLine($"--{item.ToString()}");
            }

            sb.AppendLine($"-Delicacy menu:");
            foreach (var item in delicacyRepository.Models)
            {
                sb.AppendLine($"--{item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
