namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ExportCategoriesByProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("count")]
        public int NumberOfProducts { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePriceOfProducts { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
