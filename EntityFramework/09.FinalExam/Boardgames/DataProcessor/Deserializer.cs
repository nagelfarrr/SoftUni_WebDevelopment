namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper.Internal.Mappers;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Creators");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCreatorDto[]), xmlRoot);

            ImportCreatorDto[] xmlCreators;

            using (StringReader reader = new StringReader(xmlString))
            {
                xmlCreators = (ImportCreatorDto[])xmlSerializer.Deserialize(reader);
            }

            ICollection<Creator> validCreators = new HashSet<Creator>();

            foreach (ImportCreatorDto creatorDto in xmlCreators)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator validCreator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    


                    Boardgame validBoardgame = new Boardgame()
                    {
                        Name = boardgameDto.BoardgameName,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = Enum.Parse<CategoryType>(boardgameDto.CategoryType.ToString()),
                        Mechanics = boardgameDto.Mechanics
                    };

                    validCreator.Boardgames.Add(validBoardgame);
                }

                validCreators.Add(validCreator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, validCreator.FirstName, validCreator.LastName,
                    validCreator.Boardgames.Count));
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportSellerDto[] jsonSellers = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            ICollection<Seller> validSellers = new HashSet<Seller>();

            foreach (var importSellerDto in jsonSellers)
            {
                if (!IsValid(importSellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(importSellerDto.Country) 
                    || string.IsNullOrEmpty(importSellerDto.Website) 
                    || string.IsNullOrEmpty(importSellerDto.Name)
                    || string.IsNullOrEmpty(importSellerDto.Address))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller validSeller = new Seller()
                {
                    Name = importSellerDto.Name,
                    Address = importSellerDto.Address,
                    Country = importSellerDto.Country,
                    Website = importSellerDto.Website,
                };

                foreach (var boardgameId in importSellerDto.BoardgamesIds.Distinct())
                {
                    Boardgame boardgame = context.Boardgames.Find(boardgameId);

                    if (boardgame == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller bs = new BoardgameSeller()
                    {
                        Boardgame = boardgame,
                        Seller = validSeller
                    };

                    validSeller.BoardgamesSellers.Add(bs);
                }

                validSellers.Add(validSeller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, validSeller.Name,
                    validSeller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
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
