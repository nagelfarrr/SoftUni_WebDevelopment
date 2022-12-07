namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Book book;
        private string footNoteText;
        private int footNoteNumber;

        [SetUp]
        public void SetUp()
        {
            book = new Book("Pet Cemetery", "Stephen King");

            footNoteText = "TEST TEXT";
            footNoteNumber = 1;
        }


        [Test]
        public void ConstructorShouldInitializeWithProperParameters()
        {
            string bookName = "Kniga";
            string author = "Avtor";

            Book book = new Book(bookName, author);

            Assert.AreEqual(bookName,book.BookName);
            Assert.AreEqual(author,book.Author);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Book_NameShouldThrowExceptionWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "avtor");
            });
        }

        [TestCase(null)]
        [TestCase("")]
        public void Book_AuthorShouldThrowExceptionWhenNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("ime", author);
            });
        }


        [Test]
        public void Book_FootnoteCountShouldEqualsThePrivateCollectionCount()
        {
            book.AddFootnote(footNoteNumber, footNoteText);
           
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, book.FootnoteCount);
        }

        [Test]
        public void Book_ShouldNotAddFootnoteWhenKeyPairAlreadyExists()
        {
            

            book.AddFootnote(footNoteNumber,footNoteText);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(footNoteNumber, "another test text");
            });
        }

        [Test]
        public void Book_AddFootnoteShouldAddSuccessfullyWhenFootnoteDoesntExist()
        {
            book.AddFootnote(footNoteNumber,footNoteText);
            book.AddFootnote(0,"another test text");

            int expectedCount = 2;

            Assert.AreEqual(expectedCount,book.FootnoteCount);
        }

        [Test]
        public void Book_ShouldThrowExceptionWhenCantFindFootNoteNumber()
        {
            book.AddFootnote(footNoteNumber,footNoteText);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(10);
            });
        }

        [Test]
        public void Book_ShouldReturnProperStringWhenFootnoteIsFound()
        {
            book.AddFootnote(footNoteNumber,footNoteText);

            string expectedOutput = $"Footnote #{this.footNoteNumber}: {this.footNoteText}";

            Assert.AreEqual(expectedOutput,book.FindFootnote(footNoteNumber));
        }

        [Test]
        public void Book_ShouldThrowExceptionWhenCantFindFootNoteToAlter()
        {
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(footNoteNumber,footNoteText);
            });
        }

        [Test]
        public void Book_AlterFootnoteShouldChangeTextToGivenIndex()
        {
            string newText = "NEW TEST TEXT";

            book.AddFootnote(footNoteNumber,footNoteText);

            string expectedOutput = $"Footnote #{this.footNoteNumber}: {newText}";

            book.AlterFootnote(footNoteNumber,newText);

            Assert.AreEqual(expectedOutput, book.FindFootnote(footNoteNumber));
        }
    }
}