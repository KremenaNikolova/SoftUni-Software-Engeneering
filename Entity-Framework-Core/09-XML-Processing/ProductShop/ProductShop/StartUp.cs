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

            //Problem 02 string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
            //Problem 02 string result = ImportProducts(context, inputXml);

            //Problem 03 string inputXml = File.ReadAllText(@"../../../Datasets/categories.xml");
            //Problem 03 string result = ImportCategories(context, inputXml);

            string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
            string result = ImportCategoryProducts(context, inputXml);

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


        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), xmlRoot);
            using StringReader reader = new StringReader(inputXml);

            ImportCategoryDto[] categoryDtos = (ImportCategoryDto[])serializer.Deserialize(reader)!;

            ICollection<Category> categories = new HashSet<Category>();
            foreach (ImportCategoryDto categoryDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(categoryDto.Name))
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
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportCategoryProductDto[] cateogryProductDtos = (ImportCategoryProductDto[])serializer.Deserialize(reader)!;

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();
            foreach (ImportCategoryProductDto cateogryProductDto in cateogryProductDtos)
            {
                if (cateogryProductDto?.ProductId == null || cateogryProductDto?.CategoryId == null)
                {
                    continue;
                }

                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(cateogryProductDto);
                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
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