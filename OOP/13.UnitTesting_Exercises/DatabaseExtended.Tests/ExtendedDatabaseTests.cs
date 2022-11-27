namespace DatabaseExtended.Tests
{
    using System;
    using System.Security.Cryptography;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            Person[] people = new Person[14];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, ((char)('A' + i)).ToString());
            }

            database = new Database(people);

        }

        [Test]
        public void ConstructorShouldThrowExceptionIfTakesMoreThan16People()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, ((char)('A' + i)).ToString());
            }

            Assert.Throws<ArgumentException>(() =>
            {
                database = new Database(people);
            });
        }

        [Test]
        public void CountShouldBeEqualAsDatabaseLength()
        {
            
            Assert.AreEqual(14, database.Count);
        }

        [Test]
        public void AddCommandShouldThrowExceptionWhenDataLengthIsMoreThan16()
        {
            database.Add(new Person(213, "asdasd"));
            database.Add(new Person(2123, "312312"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(8253, "iwefds")));
        }

        [Test]
        public void AddCommandShouldThrowExceptionIfSameUsernameIsAdded()
        {
            database.Add(new Person(213,"Ivan"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(21213, "Ivan")));
        }

        [Test]
        public void AddCommandShouldThrowExceptionIfSameIDIsAdded()
        {
            database.Add(new Person(213, "Ivan"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(213, "Petkan")));
        }

        [Test]
        public void AddCommandShouldIncreaseCount()
        {
            int expectedCount = database.Count+1;
            database.Add(new Person(12312,"Ivan"));

            Assert.AreEqual(expectedCount,database.Count);

        }

        [Test]
        public void RemoveShouldThrowExceptionWhenNothingToRemove()
        {
            Person[] people = new Person[0];

            database = new Database(people);

            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }

        [Test]
        public void RemoveShouldDecreaseCountByOne()
        {
            int expectedCount = database.Count-1;
            database.Remove();

            Assert.AreEqual(expectedCount,database.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameShouldThrowExceptionWhenNameIsNullOrEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenNoUsernameIsPresented()
        {
            Assert.Throws<InvalidOperationException>((() => database.FindByUsername("Dragan")));
        }

        [TestCase(" ")]
        [TestCase("normalUsername")]
        [TestCase("VeryVeryVeryVeryVeryVeryVeryVeryVeryVeryVeryVeryVeryVeryVeryVeryVeryVeryLONGUserName")]
        public void FindByUsernameShouldReturnPersonByItsUsername(string username)
        {
            Person person = new Person(213213, username);

            database.Add(person);

            Person expectedPerson = database.FindByUsername(username);

            Assert.AreEqual(expectedPerson, person);
        }

        [Test]
        public void FindByIDShouldThrowExceptionIfIDIsBelowZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>((() => database.FindById(-1)));
        }

        [Test]
        public void FindByIDShouldThrowExceptionIfIDIsNotPresented()
        {
            Assert.Throws<InvalidOperationException>((() => database.FindById(12879123712312)));
        }

        [TestCase(16)]
        [TestCase(21)]
        [TestCase(129837129873)]
        public void FindByIDShouldReturnPersonByItsID(long id)
        {
            Person person = new Person(id, "Ivan");
            database.Add(person);
            Person expectedPerson = database.FindById(id);

            Assert.AreEqual(expectedPerson,person);
        }
    }
}