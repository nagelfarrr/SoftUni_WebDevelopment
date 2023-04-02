namespace Boardgames.DataProcessor
{
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Creators");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCreatorsDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var creators = context.Creators
                .ToArray()
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportCreatorsDto()
                {
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    BoardgamesCount = c.Boardgames.Count,
                    Boardgames = c.Boardgames
                        .Select(b => new ExportBoardgameDto()
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished
                        })
                        .OrderBy(b => b.BoardgameName)
                        .ToArray()
                })
                .OrderByDescending(c => c.Boardgames.Length)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, creators, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(b =>
                    b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
                        .Select(b => new
                        {
                            Name = b.Boardgame.Name,
                            Rating = b.Boardgame.Rating,
                            Mechanics = b.Boardgame.Mechanics,
                            Category = b.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(b => b.Rating)
                        .ThenBy(b => b.Name)
                        .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}