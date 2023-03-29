namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore.Storage;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XDocument xmlDocument = XDocument.Parse(xmlString);

            var coaches = xmlDocument.Root.Elements();

            ICollection<Coach> validCoaches = new HashSet<Coach>();

            foreach (XElement xmlCoach in coaches)
            {
                if (xmlCoach.Element("Name").Value.Length < 3 || xmlCoach.Element("Name").Value.Length > 40)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(xmlCoach.Element("Nationality").Value))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name = xmlCoach.Element("Name").Value,
                    Nationality = xmlCoach.Element("Nationality").Value
                };

                ICollection<Footballer> validFootballers = new HashSet<Footballer>();

                foreach (XElement xmlFootballer in xmlCoach.Element("Footballers").Elements())
                {
                    if (xmlFootballer.Element("Name").Value.Length < 2 ||
                        xmlFootballer.Element("Name").Value.Length > 40)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime validStartDate;
                    bool isStartDateValid = DateTime.TryParseExact(xmlFootballer.Element("ContractStartDate").Value,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validStartDate);

                    DateTime validEndDate;
                    bool isEndDateValid = DateTime.TryParseExact(xmlFootballer.Element("ContractEndDate").Value,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validEndDate);

                    if (!isStartDateValid || !isEndDateValid || validEndDate < validStartDate)
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = xmlFootballer.Element("Name").Value,
                        ContractStartDate = validStartDate,
                        ContractEndDate = validEndDate,
                        BestSkillType = Enum.Parse<BestSkillType>(xmlFootballer.Element("BestSkillType").Value),
                        PositionType = Enum.Parse<PositionType>(xmlFootballer.Element("PositionType").Value)
                    };

                    validFootballers.Add(footballer);
                }

                coach.Footballers = validFootballers;

                validCoaches.Add(coach);

                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, validFootballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
