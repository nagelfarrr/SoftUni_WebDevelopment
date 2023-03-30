namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Countries");
            XmlSerializer deserializer = new XmlSerializer(typeof(ImportCountryDto[]), xmlRoot);

            ImportCountryDto[] xmlCountries;

            using (StringReader reader = new StringReader(xmlString))
            {
                xmlCountries = (ImportCountryDto[])deserializer.Deserialize(reader);
            }

            ICollection<Country> validCountries = new HashSet<Country>();

            foreach (var xmlCountry in xmlCountries)
            {
                if (!IsValid(xmlCountry))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country()
                {
                    CountryName = xmlCountry.CountryName,
                    ArmySize = xmlCountry.ArmySize,
                };

                validCountries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }
            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Manufacturers");
            XmlSerializer deserializer = new XmlSerializer(typeof(ImportManufacturerDto[]), xmlRoot);

            ImportManufacturerDto[] xmlManufacturers;

            using (StringReader reader = new StringReader(xmlString))
            {
                xmlManufacturers = (ImportManufacturerDto[])deserializer.Deserialize(reader);
            }

            ICollection<Manufacturer> validManufacturers = new HashSet<Manufacturer>();

            foreach (var xmlManufacturer in xmlManufacturers)
            {
                if (!IsValid(xmlManufacturer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validManufacturers.Any(m => m.ManufacturerName == xmlManufacturer.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = xmlManufacturer.ManufacturerName,
                    Founded = xmlManufacturer.Founded,
                };

                string[] townAndCountry = xmlManufacturer.Founded.Split(", ").TakeLast(2).ToArray();

                validManufacturers.Add(manufacturer);
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, xmlManufacturer.ManufacturerName, string.Join(", ", townAndCountry)));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Shells");
            XmlSerializer deserializer = new XmlSerializer(typeof(ImportShellDto[]), xmlRoot);

            ImportShellDto[] xmlShells;

            using (StringReader reader = new StringReader(xmlString))
            {
                xmlShells = (ImportShellDto[])deserializer.Deserialize(reader);
            }

            ICollection<Shell> validShells = new HashSet<Shell>();

            foreach (var xmlShell in xmlShells)
            {
                if (!IsValid(xmlShell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell()
                {
                    ShellWeight = xmlShell.ShellWeight,
                    Caliber = xmlShell.Caliber,
                };

                validShells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }
            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGunDto[] jsonGuns = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            ICollection<Gun> validGuns = new HashSet<Gun>();

            foreach (var jsonGun in jsonGuns)
            {
                if (!IsValid(jsonGun))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                if (!Enum.TryParse<GunType>(jsonGun.GunType, out GunType result))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun()
                {
                    ManufacturerId = jsonGun.ManufacturerId,
                    GunWeight = jsonGun.GunWeight,
                    BarrelLength = jsonGun.BarrelLength,
                    NumberBuild = jsonGun.NumberBuild,
                    Range = jsonGun.Range,
                    GunType = Enum.Parse<GunType>(jsonGun.GunType),
                    ShellId = jsonGun.ShellId,

                };

                foreach(var cg  in jsonGun.CountryIds)
                {
                   
                    CountryGun countryGun = new CountryGun()
                    {
                        CountryId = cg.Id,
                        Gun = gun
                    };

                    gun.CountriesGuns.Add(countryGun);
                }

                validGuns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
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