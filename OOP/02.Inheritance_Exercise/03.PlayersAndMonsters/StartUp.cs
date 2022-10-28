using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new Hero("Ivan", 0);
            Elf elf = new Elf("Gosho", 12);
            MuseElf museElf = new MuseElf("elfy", 1);


            Console.WriteLine(hero);
            Console.WriteLine(elf);
            Console.WriteLine(museElf);
        }
    }
}