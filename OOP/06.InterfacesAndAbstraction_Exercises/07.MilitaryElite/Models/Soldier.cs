namespace _07.MilitaryElite.Models
{
    using Contracts;

    public class Soldier :ISoldier
    {
        public Soldier(string id, string firstName,string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }


        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
