using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demonsNames = Regex.Split(Console.ReadLine(), @"[\s,]+").ToArray();
            SortedDictionary<string,Dictionary<int, double>> demonsData = new SortedDictionary<string,Dictionary<int, double>>();

            string demonHealthPattern = @"[^\d\+\-\*\/\.]";
            string demonDamagePattern = @"((|-)\d+\.\d+|(|-)\d+)";
            string mathSymbolsPattern = @"[\*\/]";
            

            Regex healthRegex = new Regex(demonHealthPattern);
            Regex damageRegex = new Regex(demonDamagePattern);
            Regex mathSymbolsRegex = new Regex(mathSymbolsPattern);

            for (int i = 0; i < demonsNames.Length; i++)
            {
                int demonHealth = 0;
                double demonDamage = 0.0;
                demonHealth = DemonHealth(healthRegex, demonsNames, i, demonHealth);

                demonDamage = DemonDamage(damageRegex, demonsNames, i, demonDamage, mathSymbolsRegex);

                if (!demonsData.ContainsKey(demonsNames[i]))
                {
                    demonsData[demonsNames[i]] = new Dictionary<int, double>();
                }
                demonsData[demonsNames[i]][demonHealth] = demonDamage;
            }

            foreach (var demon in demonsData)
            {
                Console.Write($"{demon.Key} - ");
                foreach (var healthAndDamage in demon.Value)
                {
                    Console.WriteLine($"{healthAndDamage.Key} health, {healthAndDamage.Value:f2} damage");
                }

            }
        }

        private static int DemonHealth(Regex healthRegex, string[] demonsNames, int i, int demonHealth)
        {
            MatchCollection healthMatches = healthRegex.Matches(demonsNames[i]);
            StringBuilder sb = new StringBuilder();
            foreach (Match healthMatch in healthMatches)
            {
                sb.Append(healthMatch.Value);
            }

            for (int j = 0; j < sb.Length; j++)
            {
                demonHealth += sb[j];
            }

            return demonHealth;
        }

        private static double DemonDamage(Regex damageRegex, string[] demonsNames, int i, double demonDamage,
            Regex mathSymbolsRegex)
        {
            MatchCollection damageMatches = damageRegex.Matches(demonsNames[i]);
            foreach (Match damageMatch in damageMatches)
            {
                demonDamage += double.Parse(damageMatch.Value);
            }

            MatchCollection mathSymbols = mathSymbolsRegex.Matches(demonsNames[i]);

            foreach (Match mathSymbol in mathSymbols)
            {
                switch (mathSymbol.Value)
                {
                    case "*":
                        demonDamage *= 2;
                        break;
                    case "/":
                        demonDamage /= 2;
                        break;
                }
            }

            return demonDamage;
        }
    }
}
