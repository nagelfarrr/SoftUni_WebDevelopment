namespace CarDealer.DTOs.Export
{
    using CarDealer.Models;
    using System.Xml.Serialization;

    [XmlType("supplier")]
    public class LocalSuppliersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("parts-count")]
        public int Parts { get; set; } 
    }
}
