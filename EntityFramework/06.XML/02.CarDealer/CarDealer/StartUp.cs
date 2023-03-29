namespace CarDealer
{
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using CarDealer.Data;
    using CarDealer.DTOs.Export;
    using CarDealer.Models;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            string suppliersInput = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersInput));

            string partsInput = File.ReadAllText(@"../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, partsInput));

            string carsInput = File.ReadAllText(@"../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context,carsInput));

            string customersInput = File.ReadAllText(@"../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context,customersInput));

            string salesInput = File.ReadAllText(@"../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context,salesInput));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var suppliers = xmlDocument.Root.Elements();

            foreach (XElement supplier in suppliers)
            {
                Supplier supp = new Supplier()
                {
                    Name = supplier.Element("name").Value,
                    IsImporter = Boolean.Parse(supplier.Element("isImporter").Value)
                };

                context.Add(supp);
            }

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var importParts = xmlDocument.Root.Elements();

            ICollection<Part> validParts = new List<Part>();

            foreach (XElement importPart in importParts)
            {
                int supplierId = int.Parse(importPart.Element("supplierId").Value);

                if (!context.Suppliers.Contains(new Supplier() { Id = supplierId }))
                {
                    continue;
                }

                Part part = new Part()
                {
                    Name = importPart.Element("name").Value,
                    Price = decimal.Parse(importPart.Element("price").Value),
                    Quantity = int.Parse(importPart.Element("quantity").Value),
                    SupplierId = supplierId
                };
                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var carsXml = xmlDocument.Root.Elements();

            var cars = new List<Car>();

            int[] partInts = context.Parts.Select(p => p.Id).ToArray();
            var partIds = xmlDocument.Descendants("partId").Select(p => p.Attribute("id").Value);

            var parts = new List<PartCar>();

            int carId = 1;

            foreach (XElement carElement in carsXml)
            {
                Car car = new Car()
                {
                    Make = carElement.Element("make").Value,
                    Model = carElement.Element("model").Value,
                    TraveledDistance = long.Parse(carElement.Element("traveledDistance").Value)
                };

                cars.Add(car);

                foreach (var partId in carElement.Descendants("partId")
                             .Where(p => partIds.Contains(p.Attribute("id").Value))
                             .Select(p => p.Attribute("id").Value).Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        CarId = carId,
                        PartId = int.Parse(partId)
                    };

                    parts.Add(partCar);
                }

                carId++;
            }

            context.AddRange(cars);
            context.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var customersXML = xmlDocument.Root.Elements();

            var customers = new List<Customer>();

            foreach (var customer in customersXML)
            {
                Customer cust = new Customer()
                {
                    Name = customer.Element("name").Value,
                    BirthDate = DateTime.Parse(customer.Element("birthDate").Value),
                    IsYoungDriver = Boolean.Parse(customer.Element("isYoungDriver").Value)
                };

                customers.Add(cust);
            }

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var xmlSales = xmlDocument.Root.Elements();

            var sales = new List<Sale>();

            foreach (XElement xmlSale in xmlSales)
            {
                int carId = int.Parse(xmlSale.Element("carId").Value);
                int customerId = int.Parse(xmlSale.Element("customerId").Value);

                if (!context.Cars.Contains(new Car() { Id = carId }))
                {
                    continue;

                }

                Sale sale = new Sale()
                {
                    CarId = carId,
                    CustomerId = customerId,
                    Discount = decimal.Parse(xmlSale.Element("discount").Value)
                };


                sales.Add(sale);
            }

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}";

        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]), xmlRoot);

            var carsWithDistance = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, carsWithDistance, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportBmwDto[]), xmlRoot);

            var bmws = context.Cars
                .Where(b => b.Make == "BMW")
                .OrderBy(b => b.Model)
                .ThenByDescending(b => b.TraveledDistance)
                .Select(b => new ExportBmwDto()
                {
                    Id = b.Id,
                    Model = b.Model,
                    TraveledDistance = b.TraveledDistance
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, bmws, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");

            XmlSerializer serializer = new XmlSerializer(typeof(LocalSuppliersDto[]), xmlRoot);

            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalSuppliersDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Parts = s.Parts.Count
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsWithPartsDto[]), xmlRoot);

            var cars = context.Cars
                .Select(c => new ExportCarsWithPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .Select(pc => new PartForCarDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(pc => pc.Price)
                        .ToArray()

                })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("customers");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportTotalSalesCustomerDto[]), xmlRoot);

            var tempCustomers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.IsYoungDriver
                                ? c.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price * 0.95m, 2)))
                                : c.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price, 2)))



                })
                .ToArray();

            var customers = tempCustomers
                .Select(e => new ExportTotalSalesCustomerDto()
                {
                    FullName = e.FullName,
                    BoughtCars = e.BoughtCars,
                    SpentMoney = e.SpentMoney.Sum()
                })
                .OrderByDescending(e => e.SpentMoney)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, customers, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("sales");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSalesWithDiscountsDto[]), xmlRoot);

            var sales = context.Sales
                .Select(s => new ExportSalesWithDiscountsDto()
                {
                    CarDtoSales = new CarDtoSales()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },

                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)

                }).ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer,sales,namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}