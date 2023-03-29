namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XDocument xmlDocument = XDocument.Parse(xmlString);

            var despatchers = xmlDocument.Root.Elements();

            var validDespatchers = new HashSet<Despatcher>();

            foreach (XElement despatcher in despatchers)
            {
                if (despatcher.Element("Name").Value.Length < 2 || despatcher.Element("Name").Value.Length > 40)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(despatcher.Element("Position").Value))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validTrucks = new HashSet<Truck>();

                foreach (XElement truck in despatcher.Element("Trucks").Elements("Truck"))
                {
                    string pattern = @"[A-Z]{2}\d{4}[A-Z]{2}";
                    string regNumber = truck.Element("RegistrationNumber").Value;

                    Match match = Regex.Match(regNumber, pattern);

                    if (regNumber.Length > 8)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!match.Success)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (truck.Element("VinNumber").Value.Length != 17)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (int.Parse(truck.Element("TankCapacity").Value) < 950 ||
                        int.Parse(truck.Element("TankCapacity").Value) > 1420)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (int.Parse(truck.Element("CargoCapacity").Value) < 5000 ||
                        int.Parse(truck.Element("CargoCapacity").Value) > 29000)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck validTruck = new Truck()
                    {
                        RegistrationNumber = truck.Element("RegistrationNumber").Value,
                        VinNumber = truck.Element("VinNumber").Value,
                        TankCapacity = int.Parse(truck.Element("TankCapacity").Value),
                        CargoCapacity = int.Parse(truck.Element("CargoCapacity").Value),
                        CategoryType = Enum.Parse<CategoryType>(truck.Element("CategoryType").Value),
                        MakeType = Enum.Parse<MakeType>(truck.Element("MakeType").Value)
                    };

                    validTrucks.Add(validTruck);
                }

                Despatcher validDespatcher = new Despatcher()
                {
                    Name = despatcher.Element("Name").Value,
                    Position = despatcher.Element("Position").Value,
                    Trucks = validTrucks
                };

                validDespatchers.Add(validDespatcher);

                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, validDespatcher.Name, validDespatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var clients = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

            ICollection<Client> validClients = new HashSet<Client>();

            ICollection<int> existingTrucksIds = context.Trucks
                .Select(t => t.Id).ToArray();

            foreach (var client in clients)
            {
                if (client.Name.Length < 3 || client.Name.Length > 40)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (client.Nationality.Length < 2 || client.Nationality.Length > 40)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrWhiteSpace(client.Type) || client.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client validClient = new Client()
                {
                    Name = client.Name,
                    Nationality = client.Nationality,
                    Type = client.Type
                };

                foreach (var truckId in client.Trucks.Distinct())
                {
                    if (!existingTrucksIds.Contains(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck ct = new ClientTruck()
                    {
                        Client = validClient,
                        TruckId = truckId
                    };

                    validClient.ClientsTrucks.Add(ct);
                }
                validClients.Add(validClient);

                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, validClient.ClientsTrucks.Count));
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}