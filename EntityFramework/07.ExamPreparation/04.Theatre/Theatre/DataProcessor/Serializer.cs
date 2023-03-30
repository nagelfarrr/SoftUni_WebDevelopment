namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theathres = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(tt => tt.RowNumber >= 1 && tt.RowNumber <= 5).Sum(tt => tt.Price),
                    Tickets = t.Tickets
                    .Select(ti => new
                    {
                        Price = ti.Price,
                        RowNumber = ti.RowNumber,
                    })
                    .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                    .OrderByDescending(ti => ti.Price)
                    .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theathres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRoot);

            var plays = context.Plays
                .ToArray()
                .Where(p => p.Rating <= raiting)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Raiting = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    exportActors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ExportActorDto()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, plays, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
