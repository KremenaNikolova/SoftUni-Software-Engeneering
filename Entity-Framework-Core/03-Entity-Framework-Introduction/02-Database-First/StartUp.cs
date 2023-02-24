using SoftUni.Data;

namespace SoftUni;

internal class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        Console.WriteLine("Connection success!");
    }
}