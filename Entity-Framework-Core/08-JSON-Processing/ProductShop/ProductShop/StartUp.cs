namespace ProductShop;

using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        string inputJson = File.ReadAllText(@"../../../Datasets/users.json");

        string result = ImportUsers(context, inputJson);

        Console.WriteLine(result);
    }

    //01. Import Users

    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();
        IContractResolver camelCaseConfiguration = CamelCaseNaming();

        
        ImportUserDto[]? userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson, new JsonSerializerSettings() 
        {
            ContractResolver = camelCaseConfiguration
        });

        ICollection<User> validUsers = new HashSet<User>();
        foreach (ImportUserDto userDto in userDtos!)
        {
            User user = mapper.Map<User>(userDto);

            validUsers.Add(user);
        }

        context.Users.AddRange(validUsers);
        context.SaveChanges();

        return $"Successfully imported {validUsers.Count}";


    }

    //Mapper
    private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));
    }

    //CamelCaseConfiguration
    private static IContractResolver CamelCaseNaming()
    {
        return new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy(false, true) 
        };
    }


}



