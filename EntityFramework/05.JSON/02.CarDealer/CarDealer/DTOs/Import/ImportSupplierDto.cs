namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;

    public class ImportSupplierDto
    {
        public string Name { get; set; } = null!;

        public bool IsImporter { get; set; }

    }
}
