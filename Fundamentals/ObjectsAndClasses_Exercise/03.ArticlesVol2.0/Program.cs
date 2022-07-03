using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ArticlesVol2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();

                Article article = new Article(input[0], input[1], input[2]);
                articles.Add(article);
            }

            string lastInput = Console.ReadLine();

            foreach (var article in articles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }
        }
    }

    public class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }


        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
