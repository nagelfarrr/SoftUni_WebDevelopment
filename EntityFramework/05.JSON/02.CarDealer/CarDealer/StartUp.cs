namespace CarDealer
{
    using CarDealer.Data;
    using AutoMapper;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string jsonSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.json");
            string jsonParts = File.ReadAllText(@"../../../Datasets/parts.json");


            Console.WriteLine(ImportParts(context,jsonParts));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            var jsonSettings = CamelCaseSettings();

            ImportSupplierDto[] supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson, jsonSettings);

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (ImportSupplierDto supplierDto in supplierDtos)
            {
                Supplier supplier = mapper.Map<Supplier>(supplierDto);

                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}.";

        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            var jsonSettings = CamelCaseSettings();

            ImportPartDto[] partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson, jsonSettings);


            var supplierMaxId = context.Suppliers
                .OrderByDescending(s => s.Id)
                .Select(s => s.Id)
                .ToList()
                .First();

            ICollection<Part> validParts = new HashSet<Part>();

            foreach (ImportPartDto partDto in partDtos)
            {
                if (partDto.SupplierId <= supplierMaxId)
                {
                    Part part = mapper.Map<Part>(partDto);

                    validParts.Add(part);
                }
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }

        private static JsonSerializerSettings CamelCaseSettings()
        {
            return new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}