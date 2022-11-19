namespace ValidationAttributes
{
    using ValidationAttributes.Attributes;

    public class Person
    {
        public Person(string fullName,int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequiredAttribute]
        public string FullName { get; set; }

        [MyRangeAttribute(12,90)]
        public int Age { get; set; }
    }
}
