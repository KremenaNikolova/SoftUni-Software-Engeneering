namespace BookShop;

using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new BookShopContext();
        DbInitializer.ResetDatabase(dbContext);

        //Problem 02 string input = Console.ReadLine()!;
        //Problem 02 string output = GetBooksByAgeRestriction(dbContext, input);

        string output = GetGoldenBooks(dbContext);

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
        var booksTitleAndPrice = dbContext.Books

    }

}


