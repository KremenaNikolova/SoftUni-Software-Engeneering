﻿namespace ProductShop;

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

        string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
        string result = ImportProducts(context, inputJson);

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



