namespace ProductShop
{
    using System.Text;
    using System.Xml;
    using ProductShop.Data;

    using System.Xml.Linq;
    using System.Xml.Serialization;
    using ProductShop.DTOs.Export;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();

            string usersImport = @"../../../Datasets/users.xml";
            //ImportUsers(context, usersImport);

            string productsImport = File.ReadAllText(@"../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, productsImport));

            string categoriesImport = File.ReadAllText(@"../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, categoriesImport));

            string categoriesProductsImport = File.ReadAllText(@"../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context,categoriesProductsImport));

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Load(inputXml);

            var users = xmlDocument.Root.Elements();

            foreach (var user in users)
            {
                User currUser = new User()
                {
                    FirstName = user.Element("firstName").Value,
                    LastName = user.Element("lastName").Value,
                    Age = int.Parse(user.Element("age").Value)
                };

                context.Users.Add(currUser);
            }

            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var products = xmlDocument.Root.Elements();


            foreach (var product in products)
            {
                Product currProduct = new Product()
                {
                    Name = product.Element("name").Value,
                    Price = decimal.Parse(product.Element("price").Value),
                    SellerId = int.Parse(product.Element("sellerId").Value),
                    BuyerId = product.Elements().Count() > 3 ? int.Parse(product.Element("buyerId").Value) : null
                };

                context.Products.Add(currProduct);
            }

            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var categories = xmlDocument.Root.Elements();

            var validCategories = new HashSet<Category>();

            foreach (XElement category in categories)
            {
                if (category.Element("name") == null)
                {
                    continue;
                }

                var currCategory = new Category()
                {
                    Name = category.Element("name").Value
                };

                validCategories.Add(currCategory);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var cps = xmlDocument.Root.Elements();

            var validCps = new HashSet<CategoryProduct>();

            foreach (XElement cp in cps)
            {
                if (int.Parse(cp.Element("CategoryId").Value) > context.Categories.Count() ||
                    int.Parse(cp.Element("ProductId").Value) > context.Products.Count())
                {
                    continue;
                }

                var currCp = new CategoryProduct()
                {
                    CategoryId = int.Parse(cp.Element("CategoryId").Value),
                    ProductId = int.Parse(cp.Element("ProductId").Value)
                };

                validCps.Add(currCp);
            }

            context.CategoryProducts.AddRange(validCps);
            context.SaveChanges();

            return $"Successfully imported {validCps.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductsInRangeDto[]), xmlRoot);

            ExportProductsInRangeDto[] productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, productsInRange, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUsernameSoldProductsDto[]), xmlRoot);

            ExportUsernameSoldProductsDto[] users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUsernameSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold.Select(p => new ProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoriesByProductsDto[]), xmlRoot);

            ExportCategoriesByProductsDto[] categories = context.Categories
                .Select(c => new ExportCategoriesByProductsDto()
                {
                    Name = c.Name,
                    NumberOfProducts = c.CategoryProducts.Count,
                    AveragePriceOfProducts = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.NumberOfProducts)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUsersAndProductsDto), xmlRoot);

            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new UserInfo()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProducts()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Where(p => p.BuyerId != null)
                            .Select(p => new ProductX()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            ExportUsersAndProductsDto usersAndProducts = new ExportUsersAndProductsDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(p => p.BuyerId != null)),
                Users = users
            };

            using StringWriter writer = new StringWriter(sb);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(writer,usersAndProducts,namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}