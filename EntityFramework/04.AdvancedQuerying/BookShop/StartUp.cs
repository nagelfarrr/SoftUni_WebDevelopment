namespace BookShop
{
    using System.Net.Http.Headers;
    using System.Text;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //int input = int.Parse(Console.ReadLine());

            Console.WriteLine(CountCopiesByAuthor(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction enumValue = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books.ToList()
                .Where(b => b.AgeRestriction == enumValue)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();



            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            

            var titles = context.Books
                    .AsNoTracking()
                    .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToArray();


            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            
                var books = context.Books
                    .Where(b => b.Price > 40)
                    .OrderByDescending(b=> b.Price)
                    .Select(b => new
                    {
                        Title = b.Title,
                        Price = b.Price,
                    })
                    .ToArray();

                foreach (var book in books)
                {
                    sb.AppendLine($"{book.Title} - ${book.Price:F2}");
                }
                    
            

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var books = context.Books
                .OrderBy(b=> b.BookId)
                .Where(b=> b.ReleaseDate.Value.Year != year)
                .Select(b=> b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] inputCategories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var categories = context.BooksCategories
                .Where(bc => inputCategories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(t => t)
                .ToList();

            return string.Join(Environment.NewLine, categories);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime datetime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < datetime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    Edition = b.EditionType,
                    Price = $"${b.Price:F2}"
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Edition.ToString()} - {book.Price}");
            }

            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a=> a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName,
                })
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} ({b.Author})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authorCopies = context.Authors
                .Select(ac => new
                {
                    AuthorName = ac.FirstName + " " + ac.LastName,
                    TotalCopies = ac.Books.Sum(b => b.Copies),
                })
                .OrderByDescending(ac => ac.TotalCopies)
                .ToList();

            foreach (var ac in authorCopies)
            {
                sb.AppendLine($"{ac.AuthorName} - {ac.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }



    }
}


