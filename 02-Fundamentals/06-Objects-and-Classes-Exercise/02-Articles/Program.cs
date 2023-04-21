using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Article article = new Article(input[0], input[1], input[2]);
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                if (command[0] == "Edit")
                {
                    article.Edit(command[1]);
                }
                else if (command[0]== "ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }
                else
                {
                    article.Rename(command[1]);
                }
            }

            Console.WriteLine(article);

        }
    }

    public class Article
    {

        public Article (string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content) => Content = content;
        public void ChangeAuthor(string author) => Author = author;
        public void Rename(string title)=>Title = title;

        public override string ToString() => $"{Title} - {Content}: {Author}";

    }

}
