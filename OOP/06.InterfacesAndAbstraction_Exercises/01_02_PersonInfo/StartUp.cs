namespace PersonInfo
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                string id = Console.ReadLine();
                string birthdate = Console.ReadLine();
                IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
                IBirthable birthable = new Citizen(name, age, id, birthdate);
                Console.WriteLine(identifiable.Id);
                Console.WriteLine(birthable.Birthdate);

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            
            }
            
        }
    }
}
