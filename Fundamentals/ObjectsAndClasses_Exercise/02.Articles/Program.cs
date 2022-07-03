using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articles = Console.ReadLine().Split(", ").ToArray();
            Article article = new Article(articles[0], articles[1], articles[2]);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] commands = Console.ReadLine().Split(": ").ToArray();

                switch (commands[0])
                {
                    case "Edit":
                        article.Edit(commands[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(commands[1]);
                        break;
                    case "Rename":
                        article.Rename(commands[1]);
                        break;
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");

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

        public  string Edit(string content)
        {
            this.Content = content;
            return this.Content;
        }

        public string ChangeAuthor(string author)
        {
            this.Author = author; 
            return this.Author;
        }

        public string Rename(string title)
        {
            this.Title = title;
            return this.Title;
        }
    }
}
