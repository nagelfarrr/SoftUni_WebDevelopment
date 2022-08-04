using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FancyBarcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfBarcodes = int.Parse(Console.ReadLine());

            string pattern = @"\@\#{1,}(?<product>[A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1})\@\#{1,}";

            Regex regex = new Regex(pattern);

            List<string> validItems = new List<string>();

            for (int i = 0; i < numberOfBarcodes; i++)
            {
                string input = Console.ReadLine();

                string productGroup = string.Empty;

                Match currMatch = regex.Match(input);

                if (currMatch.Success)
                {
                    string currProduct = currMatch.Groups["product"].Value;

                    if (currProduct.Any(char.IsDigit))
                    {
                        for (int j = 0; j < currProduct.Length; j++)
                        {
                            if (currProduct[j] >= 48 && currProduct[j] <= 57)
                            {
                                productGroup += currProduct[j];
                            }
                        }

                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }


                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }

           
        }
    }
}
