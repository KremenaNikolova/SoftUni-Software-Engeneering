using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < numberOfArticles; i++)
            {
                List<string> newArticle = Console.ReadLine().Split(", ").ToList();
                Article article = new Article(newArticle[0], newArticle[1], newArticle[2]);

                articles.Add(article);
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
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

            //public void Edit(string content) => Content = content;
            //public void ChangeAuthor(string author) => Author = author;
            //public void Rename(string title) => Title = title;

            public override string ToString() => $"{Title} - {Content}: {Author}";

        }
    }
}
