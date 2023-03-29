namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        public string Name { get; set; }

        public string Nationality { get; set; }

        public string Type { get; set; }

        public int[] Trucks { get; set; }
    }
}
