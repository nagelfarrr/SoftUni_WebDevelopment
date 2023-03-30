namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            ImportPlayDto[] xmlPlays;

            using (StringReader reader = new StringReader(xmlString))
            {
                xmlPlays = (ImportPlayDto[])xmlSerializer.Deserialize(reader);
            }

            ICollection<Play> validPlays = new HashSet<Play>();

            foreach (var xmlPlay in xmlPlays)
            {
               
                if(!TimeSpan.TryParse(xmlPlay.Duration, out var duration))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan ts = TimeSpan.Parse(xmlPlay.Duration);

                if(ts.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(xmlPlay))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(!Enum.TryParse<Genre>(xmlPlay.Genre, out var genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = xmlPlay.Title,
                    Duration = ts,
                    Rating = xmlPlay.Rating,
                    Genre = Enum.Parse<Genre>(xmlPlay.Genre),
                    Description = xmlPlay.Description,
                    Screenwriter = xmlPlay.Screenwriter
                };

                validPlays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay,play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            ImportCastDto[] xmlCasts;

            using ( StringReader reader = new StringReader(xmlString))
            {
                xmlCasts = (ImportCastDto[])xmlSerializer.Deserialize(reader);
            }

            ICollection<Cast> validCasts = new HashSet<Cast>();

            foreach (var xmlCast in xmlCasts)
            {
                if (!IsValid(xmlCast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = xmlCast.FullName,
                    IsMainCharacter = xmlCast.IsMainCharacter,
                    PhoneNumber = xmlCast.PhoneNumber,
                    PlayId = xmlCast.PlayId,
                };

                validCasts.Add(cast);

                string mainLesserCharacter = cast.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, mainLesserCharacter));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTheatreDto[] jsonTheatres = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            ICollection<Theatre> validTheatres = new HashSet<Theatre>();

            foreach (var jsonTheatre in jsonTheatres)
            {
                if (!IsValid(jsonTheatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = jsonTheatre.Name,
                    NumberOfHalls = jsonTheatre.NumberOfHalls,
                    Director = jsonTheatre.Director,
                };

                
                foreach (var jsonTicket in jsonTheatre.Tickets)
                {
                    if (!IsValid(jsonTicket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = jsonTicket.Price,
                        RowNumber = jsonTicket.RowNumber,
                        PlayId = jsonTicket.PlayId,
                    };

                    theatre.Tickets.Add(ticket);
                }

                validTheatres.Add(theatre);

                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
