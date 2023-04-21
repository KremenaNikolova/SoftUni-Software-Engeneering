using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            //print on the console information about each method that is written by someone
            //"{methodName} is written by {authorName}". 

            Type classType = typeof(StartUp);
            Type authorType = typeof(AuthorAttribute);
            MethodInfo[] allMethods= classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);


            foreach (MethodInfo method in allMethods)
            {
                if (method.CustomAttributes.Any(x=>x.AttributeType == authorType))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
                
            }
        }
    }
}
