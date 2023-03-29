namespace Trucks.DataProcessor
{
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Despatchers");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportDespatchersDto[]), xmlRoot);

            ExportDespatchersDto[] despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatchersDto()
                {
                    TruckCount = d.Trucks.Count,
                    DespatcherName = d.Name,
                    Trucks = d.Trucks.Select(t => new ExportTrucksDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    }).OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(d => d.Trucks.Length)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty,string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer,despatchers,namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .ToArray()
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .Select(ct => new
                        {
                            TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                            VinNumber = ct.Truck.VinNumber,
                            TankCapacity = ct.Truck.TankCapacity,
                            CargoCapacity = ct.Truck.CargoCapacity,
                            CategoryType = ct.Truck.CategoryType.ToString(),
                            MakeType = ct.Truck.MakeType.ToString()
                        })
                        .OrderBy(ct => ct.MakeType)
                        .ThenByDescending(ct => ct.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
