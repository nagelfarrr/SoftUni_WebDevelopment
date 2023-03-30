namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCoachesDto[]), xmlRoot);

            ExportCoachesDto[] coaches = context.Coaches
                .Where(c => c.Footballers.Any())
                .Select(c => new ExportCoachesDto()
                {
                    CoachName = c.Name,
                    FootballersCount = c.Footballers.Count(),
                    Footballers = c.Footballers.Select(f=> new ExportFootballerDto()
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString(),
                    })
                    .OrderBy(f=> f.Name)
                    .ToArray()

                })
                .OrderByDescending(c=> c.FootballersCount)
                .ThenBy(c=> c.CoachName)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, coaches, namespaces);
            }

            return sb.ToString().TrimEnd(); ;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                    .Where(f=> f.Footballer.ContractStartDate >= date)
                    .OrderByDescending(f => f.Footballer.ContractEndDate)
                    .ThenBy(f => f.Footballer.Name)
                    .Select(f => new
                    {
                        FootballerName = f.Footballer.Name,
                        ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = f.Footballer.BestSkillType.ToString(),
                        PositionType = f.Footballer.PositionType.ToString()

                    }).ToArray()

                })
                .OrderByDescending(t => t.Footballers.Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
