namespace BookShop;

using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new BookShopContext();
        //DbInitializer.ResetDatabase(dbContext);

        //Problem 02 string input = Console.ReadLine()!;
        //Problem 02 string output = GetBooksByAgeRestriction(dbContext, input);

        //Problem 03 string output = GetGoldenBooks(dbContext);

        //Problem 04 string output = GetBooksByPrice(dbContext);

        //Problem 05 int input = int.Parse(Console.ReadLine()!);
        //Problem 05 string output = GetBooksNotReleasedIn(dbContext, input);

        //Problem 06 string input = Console.ReadLine()!;
        //Problem 06 string output = GetBooksByCategory(dbContext, input);

        //Problem 07 string input = Console.ReadLine()!;
        //Problem 07 string output = GetBooksReleasedBefore(dbContext, input);

        //Problem 08 string input = Console.ReadLine()!;
        //Problem 08 string output = GetAuthorNamesEndingIn(dbContext, input);

        //Problem 09 string input = Console.ReadLine()!;
        //Problem 09 string output = GetBookTitlesContaining(dbContext, input);

        string input = Console.ReadLine()!;
        string output = GetBooksByAuthor(dbContext, input);

        Console.WriteLine(output);
    }

    //02. Age Restriction
    public static string GetBooksByAgeRestriction(BookShopContext dbContext, string command)
    {
        AgeRestriction coomandToEnum = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

        string[] bookTitles = dbContext.Books
            .Where(b => b.AgeRestriction == coomandToEnum)
            .Select(s => s.Title)
            .AsNoTracking()
            .OrderBy(s => s)
            .ToArray();

        return string.Join(Environment.NewLine, bookTitles);
    }


    //03. Golden Books
    public static string GetGoldenBooks(BookShopContext dbContext)
    {
        string[] goldenEditionBooksTitle = dbContext.Books
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
            .AsNoTracking()
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, goldenEditionBooksTitle);
    }


    //04. Books by Price
    public static string GetBooksByPrice(BookShopContext dbContext)
    {
        StringBuilder sb = new StringBuilder();

        var booksTitleAndPrice = dbContext.Books
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => new
            {
                b.Title,
                b.Price
            })
            .AsNoTracking()
            .ToArray();

        foreach (var book in booksTitleAndPrice)
        {
            sb.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }


    //05. Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {

        string[] notReleasedInThatYearBooksTitle = context.Books
            .Where(b=>b.ReleaseDate!.Value.Year!=year)
            .OrderBy(b=>b.BookId)
            .Select(b=>b.Title)
            .AsNoTracking()
            .ToArray();

        return string.Join(Environment.NewLine, notReleasedInThatYearBooksTitle);
    }


    //06. Book Titles by Category
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] categories = input
            .ToLower()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string[] booksTitle = context.Books
            .Where(b=>b.BookCategories.Any(bc=> categories.Contains(bc.Category.Name.ToLower())))
            .Select(b=>b.Title)
            .OrderBy(b=>b)
            .AsNoTracking()
            .ToArray();

        return string.Join(Environment.NewLine, booksTitle);
    }


    //07. Released Before Date
    public static string GetBooksReleasedBefore(BookShopContext dbContext, string date)
    {
        string dateTimeFormat = "dd-MM-yyyy";
        DateTime releaseDate = DateTime.ParseExact(date, dateTimeFormat, CultureInfo.InvariantCulture);

        StringBuilder sb = new StringBuilder();

        var booksReleased = dbContext.Books
            .Where(b => b.ReleaseDate < releaseDate)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price
            })
            .AsNoTracking()
            .ToArray();

        foreach (var book in booksReleased)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }


    //08. Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        string[] authors = context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .Select(a => $"{a.FirstName} {a.LastName}")
            .AsNoTracking()
            .ToArray();

        return string.Join(Environment.NewLine, authors);
    }

    //09. Book Search
    public static string GetBookTitlesContaining(BookShopContext dbContext, string input)
    {
        string[] books = dbContext.Books
            .Where(b=>b.Title.ToLower().Contains(input.ToLower()))
            .Select(b=>b.Title)
            .OrderBy(b=>b)
            .AsNoTracking()
            .ToArray();

        return string.Join(Environment.NewLine, books); 
    }


    //10. Book Search by Author
    public static string GetBooksByAuthor(BookShopContext dbContext, string input)
    {
        StringBuilder sb = new StringBuilder();

        var books = dbContext.Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                b.Title,
                AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
            })
            .AsNoTracking()
            .ToArray();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} ({book.AuthorName})");
        }

        return sb.ToString().TrimEnd();
    }

}


