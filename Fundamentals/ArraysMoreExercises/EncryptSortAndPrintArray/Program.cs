using System;
using System.Linq;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            string vowel = "aoeiuAOEIU";

            bool isVowel = false;



            int[] sequence = new int[numberOfStrings];


            for (int i = 0; i < numberOfStrings; i++)
            {
                string name = Console.ReadLine();
                int sum = 0;
                
                for (int j = 0; j < name.Length; j++)
                {
                    string tempVowel = name[j].ToString();
                    if (vowel.Contains(tempVowel))
                    {
                        isVowel = true;
                    }

                    if (isVowel)
                    {
                        sum += name[j] * name.Length;
                    }
                    else
                    {
                        sum += name[j] / name.Length;
                    }

                    isVowel = false;
                    
                }
                sequence[i] = sum;
            }
            Array.Sort(sequence);
            Console.WriteLine(string.Join($"\n", sequence));

        }

    }
}
