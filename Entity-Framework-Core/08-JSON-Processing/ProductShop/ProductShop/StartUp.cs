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

        //Problem 01 string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
        //Problem 01 string result = ImportUsers(context, inputJson);

        //Problem 02 string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
        //Problem 02 string result = ImportProducts(context, inputJson);

        string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
        string result = ImportCategories(context, inputJson);


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


    //02. Import Products
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportProductDto[]? validProducts = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
        Product[] products = mapper.Map<Product[]>(validProducts);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count()}";
    }


    //03. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();
        IContractResolver contractResolver= CamelCaseNaming();

        ImportCategoryDto[]? categoriesDto = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson, new JsonSerializerSettings
        {
            ContractResolver = contractResolver
        }) ;

        ICollection<Category> categories = new HashSet<Category>();
        foreach (var categoryDto in categoriesDto!)
        {
            if (categoryDto.Name == null)
            {
                continue;
            }
            Category category = mapper.Map<Category>(categoryDto);
            categories.Add(category);
        }

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
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



