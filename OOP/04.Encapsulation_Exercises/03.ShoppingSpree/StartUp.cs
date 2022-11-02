using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Person> people = new List<Person>();
            try
            {
                string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < peopleInput.Length; i++)
                {
                    string[] peopleTokens = peopleInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                    Person person = new Person(peopleTokens[0], decimal.Parse(peopleTokens[1]));
                    people.Add(person);
                }


                string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productsInput.Length; i++)
                {
                    string[] productsTokens = productsInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                    Product product = new Product(productsTokens[0], decimal.Parse(productsTokens[1]));
                    products.Add(product);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }



            while (true)
            {
                string commands = Console.ReadLine();
                if (commands == "END") break;

                string[] cmdTokens = commands.Split();
                string personName = cmdTokens[0];
                string productName = cmdTokens[1];

                var person = people.Find(p => p.Name == personName);
                var product = products.Find(p => p.Name == productName);

                if (person != null && product != null)
                {
                    person.BuyProduct(product);
                }

            }

            foreach (var person in people)
            {
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                }
            }
        }
    }
}
