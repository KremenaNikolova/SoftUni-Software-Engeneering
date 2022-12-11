using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> boothRepository;
        public Controller()
        {
            boothRepository = new BoothRepository();
        }


        public string AddBooth(int capacity)
        {
            int boothID = boothRepository.Models.Count+1;
            Booth booth = new Booth(boothID, capacity);

            boothRepository.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, boothID, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy;
            switch (delicacyTypeName)
            {
                case "Gingerbread": delicacy = new Gingerbread(delicacyName); break;
                case "Stolen": delicacy = new Stolen(delicacyName); break;
                default: return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (boothRepository.Models.Any(x => x.DelicacyMenu.Models.Any(y => y.Name == delicacyName)))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            var booth = boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);
            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);

        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail coctail;
            switch (cocktailTypeName)
            {
                case "Hibernation": coctail = new Hibernation(cocktailName, size); break;
                case "MulledWine": coctail = new MulledWine(cocktailName, size); break;
                default: return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            var coctailNameExistAlready = boothRepository.Models.Any(x => x.CocktailMenu.Models.Any(y => y.Name == cocktailName));
            var coctailSizeExistAlready = boothRepository.Models.Any(x => x.CocktailMenu.Models.Any(y => y.Size == size));

            if (coctailNameExistAlready && coctailSizeExistAlready)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            var booth = boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);
            booth.CocktailMenu.AddModel(coctail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }

        public string ReserveBooth(int countOfPeople)
        {
            var availibleBooths = boothRepository.Models.Where(x => x.IsReserved == false).Where(x => x.Capacity >= countOfPeople).OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId).FirstOrDefault();

            if (availibleBooths==null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            availibleBooths.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, availibleBooths.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] tokens = order.Split("/");
            string itemTypeName = tokens[0];
            string itemName = tokens[1];
            int countOfOrderedPieces = int.Parse(tokens[2]);
            ICocktail coctail;
            IDelicacy delicacy;
            var booth = boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (itemTypeName== "Hibernation" || itemTypeName== "MulledWine")
            {
                string size = tokens[3];
                coctail = booth.CocktailMenu.Models.Where(x=>x.Name==itemName).Where(x=>x.GetType().Name==itemTypeName).FirstOrDefault();
                if (coctail==null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                if (coctail.Size!=size)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }
                booth.UpdateCurrentBill(coctail.Price*countOfOrderedPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }

            if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                delicacy = booth.DelicacyMenu.Models.Where(x => x.Name == itemName).Where(x => x.GetType().Name == itemTypeName).FirstOrDefault();
                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                booth.UpdateCurrentBill(delicacy.Price*countOfOrderedPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }

            return string.Format(OutputMessages.NotRecognizedType, itemTypeName);

        }

        public string LeaveBooth(int boothId)
        {
            var booth = boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);
            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            booth.Charge();
            booth.ChangeStatus();

            return sb.ToString().TrimEnd();
        }


        public string BoothReport(int boothId)
        {
            var booth = boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);

            return booth.ToString();
        }



    }
}
