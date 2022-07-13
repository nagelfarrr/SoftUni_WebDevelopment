using System;
using System.Collections.Generic;

namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyInfo = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                string[] companyInput = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string companyName = companyInput[0];
                string employeeID = companyInput[1];

                if (!companyInfo.ContainsKey(companyName))
                {
                    companyInfo[companyName] = new List<string>();
                }
                if (!companyInfo[companyName].Contains(employeeID))
                {
                    companyInfo[companyName].Add(employeeID);
                }
            }

            foreach (var company in companyInfo)
            {
                Console.WriteLine($"{company.Key}");
                for (int i = 0; i < company.Value.Count; i++)
                {
                    Console.WriteLine($"--{company.Value[i]}");
                }
            }
        }
    }
}
