namespace ProductShop;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();

        //Problem 01 string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
        //Problem 01 string result = ImportUsers(context, inputJson);

        //Problem 02 string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
        //Problem 02 string result = ImportProducts(context, inputJson);

        //Problem 03 string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
        //Problem 03 string result = ImportCategories(context, inputJson);

        //Problem 04 string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
        //Problem 04 string result = ImportCategoryProducts(context, inputJson);

        string result = GetProductsInRange(context);
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


    //04. Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportCategoryProductDto[]? categoriesProdyctDto = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

        ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

        foreach (ImportCategoryProductDto pcategoryDto in categoriesProdyctDto!)
        {
            CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(pcategoryDto);

            categoryProducts.Add(categoryProduct);
        }

        context.CategoriesProducts.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Count()}";
    }


    //05. Export Products In Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        //IMapper mapper = CreateMapper() need for "ProjectTo" in case when we not work with anonymous object

        var products = context.Products
            .Where(p=>p.Price>=500 && p.Price<=1000)
            .OrderBy(p=>p.Price)
            .Select(p=> new
            {
                name = p.Name,
                price = p.Price,
                seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
            })
            .AsNoTracking()
            //.ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider) - in case when we not work with anonymous object
            .ToArray();

        return JsonConvert.SerializeObject(products);
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



