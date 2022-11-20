namespace Database.Tests
{
    using System;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        }

        [Test]
        public void Test_DatabaseConstructor()
        {
            TestDelegate action = () =>
                database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,17);

           Assert.Throws<InvalidOperationException>(action, "It is possible to add more than 16 integers.");
        }

        [Test]
        public void Test_DatabaseCountShouldWork()
        {
            Assert.AreEqual(16, database.Count);
        }

        [Test]
        public void Test_AddMethodShouldIncreaseCountByOne()
        {
            database = new Database(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15);

            database.Add(16);

            Assert.AreEqual(16,database.Count, "Add operation doesn't increase count");
        }

        [Test]
        public void Test_AddMethodShouldThrowExceptionIfDatabaseCountIs16()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(17), "You can add more than 16 elements.");
        }

        [Test]
        public void Test_RemoveShouldDecreaseCountByOne()
        {
            database.Remove();
            Assert.AreEqual(15,database.Count,"Remove method does not decrease count");
        }

        [Test]
        public void Test_IndexThatIsRemovedShouldBeEqualToZero()
        {
            int[] data = new int[database.Count];
            database.Remove();

            Assert.AreEqual(0, data[database.Count], "Index is not set to zero");
        }

        [Test]
        public void Test_RemoveShouldThrowExceptionWhenCountIsZero()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove(),
                "You can remove elements if there are none ");
        }

        [Test]
        public void Test_FetchMethodShouldCopyTheExactDatabase()
        {
            int[] expectedFetch = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[] databaseArray = database.Fetch();

            Assert.AreEqual(expectedFetch, databaseArray, "Fetch does not return correct elements.");
        }
    }
}
