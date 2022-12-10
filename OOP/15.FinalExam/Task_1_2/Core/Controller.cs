namespace ChristmasPastryShop.Core
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
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

    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;

            IBooth booth = new Booth(boothId, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            IDelicacy delicacy;

            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case "Stolen":
                    delicacy = new Stolen(delicacyName);
                    break;
                default:
                    return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail = null;

            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            if (booth.CocktailMenu.Models.Any(c => c.Size == size) &&
                booth.CocktailMenu.Models.Any(c => c.Name == cocktailName))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var orderedBooths = booths.Models.Where(b => !b.IsReserved)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .ToList();



            if (!orderedBooths.Any() || orderedBooths.Any(b=>b.Capacity<countOfPeople))
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            var boothToReserve = orderedBooths.First();
            boothToReserve.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, boothToReserve.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            string[] orderParts = order.Split('/');
            string itemTypeName = orderParts[0];
            string itemName = orderParts[1];
            int countOrdered = int.Parse(orderParts[2]);
            string cocktailSize = string.Empty;
            
            
            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                cocktailSize = orderParts[3];
            }

            if (itemTypeName != "Hibernation" && itemTypeName != "MulledWine"
                  && itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName) && !booth.DelicacyMenu.Models.Any(d=>d.Name ==itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            ICocktail cocktail;
            IDelicacy delicacy;

            if (itemTypeName == "Hibernation")
            {
                cocktail = new Hibernation(itemName, cocktailSize);

                if (!booth.CocktailMenu.Models.Any(c => c.Name == cocktail.Name) || !booth.CocktailMenu.Models.Any(c => c.Size == cocktail.Size))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, cocktailSize, itemName);
                }
                else
                {
                    double price = cocktail.Price * countOrdered;
                    booth.UpdateCurrentBill(price);
                }
            }
            else if (itemTypeName == "MulledWine")
            {
                cocktail = new MulledWine(itemName, cocktailSize);

                if (!booth.CocktailMenu.Models.Any(c=>c.Name == cocktail.Name) || !booth.CocktailMenu.Models.Any(c=>c.Size == cocktail.Size))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, cocktailSize, itemName);
                }
                else
                {
                    double price = cocktail.Price * countOrdered;
                    booth.UpdateCurrentBill(price);
                }
            }
            else if (itemTypeName == "Stolen")
            {
                delicacy = new Stolen(itemName);
                if (!booth.DelicacyMenu.Models.Any(d=>d.Name == delicacy.Name))
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
                else
                {
                    double price = delicacy.Price * countOrdered;
                    booth.UpdateCurrentBill(price);
                }
            }
            else if (itemTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(itemName);

                if (!booth.DelicacyMenu.Models.Any(d => d.Name == delicacy.Name))
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
                else
                {
                    double price = delicacy.Price * countOrdered;
                    booth.UpdateCurrentBill(price);
                }
            }

            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOrdered, itemName);
        }

        public string LeaveBooth(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            string bill = $"Bill {currentBill:F2} lv" + Environment.NewLine + $"Booth {boothId} is now available!";

            return bill;
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }
    }
}
