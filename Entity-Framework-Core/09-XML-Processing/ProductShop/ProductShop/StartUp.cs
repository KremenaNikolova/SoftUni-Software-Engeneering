using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {

            using ProductShopContext context = new ProductShopContext();

            //Problem 01 string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");
            //Problem 01 string result = ImportUsers(context, inputXml);

            string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
            string result = ImportProducts(context, inputXml);

            Console.WriteLine(result);

        }


        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);

            ImportUserDto[] userDtos = (ImportUserDto[])xmlSerializer.Deserialize(reader)!;

            ICollection<User> validUsers = new HashSet<User>();

            foreach (ImportUserDto userDto in userDtos)
            {
                if (string.IsNullOrEmpty(userDto.FirstName) || string.IsNullOrEmpty(userDto.LastName))
                {
                    continue;
                }

                User user = mapper.Map<User>(userDto);
                validUsers.Add(user);

            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";

        }


        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), xmlRoot);
            using StringReader reader = new StringReader(inputXml);

            ImportProductDto[] productDtos = (ImportProductDto[])serializer.Deserialize(reader)!;

            ICollection<Product> products = new HashSet<Product>();
            foreach (ImportProductDto productDto in productDtos)
            {
                if (string.IsNullOrEmpty(productDto.Name))
                {
                    continue;
                }

                Product product = mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }







        //Mapper
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(mc =>
            {
                mc.AddProfile<ProductShopProfile>();
            }));
        }
    }
}