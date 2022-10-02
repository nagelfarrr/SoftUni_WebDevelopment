using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            HashSet<string> invitations = new HashSet<string>();
            while (input != "PARTY")
            {
                input = Console.ReadLine();
                invitations.Add(input);
            }

            while (input != "END")
            {
                input = Console.ReadLine();
                if (invitations.Contains(input))
                {
                    invitations.Remove(input);
                }
            }
            invitations = invitations.OrderByDescending(c => char.IsDigit(c,0)).ToHashSet();
            ;
            invitations.Remove("PARTY");
            Console.WriteLine(invitations.Count);
            foreach (var invitation in invitations)
            {
                Console.WriteLine(invitation);
            }
        }
    }
}
