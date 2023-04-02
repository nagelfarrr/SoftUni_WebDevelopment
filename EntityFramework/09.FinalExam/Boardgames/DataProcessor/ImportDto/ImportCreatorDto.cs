namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [XmlElement("FirstName")]
        [MinLength(2)]
        [MaxLength(7)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [MinLength(2)]
        [MaxLength(7)]
        public string LastName { get; set; }

        [XmlArray("Boardgames")]
        public ImportBoardGameDto[] Boardgames { get; set; }

    }
}
