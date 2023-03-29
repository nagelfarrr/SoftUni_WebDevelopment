namespace Trucks.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Despatcher")]
    public class ExportDespatchersDto
    {
        [XmlAttribute("TrucksCount")]
        public int TruckCount { get; set; }

        [XmlElement("DespatcherName")]
        public string DespatcherName { get; set; }

        [XmlArray("Trucks")]
        public ExportTrucksDto[] Trucks { get; set; }
    }

    [XmlType("Truck")]
    public class ExportTrucksDto
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [XmlElement("Make")]
        public string Make { get; set; }

    }
}
