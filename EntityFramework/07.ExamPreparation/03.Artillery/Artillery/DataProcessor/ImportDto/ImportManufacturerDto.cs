using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    [Index(nameof(ManufacturerName), IsUnique = true)]
    public class ImportManufacturerDto
    {
        [XmlElement("ManufacturerName")]
        [MinLength(4), MaxLength(40)]
        public string ManufacturerName { get; set; }

        [XmlElement("Founded")]
        [MinLength(10), MaxLength(100)]
        public string Founded { get; set; }
    }
}
