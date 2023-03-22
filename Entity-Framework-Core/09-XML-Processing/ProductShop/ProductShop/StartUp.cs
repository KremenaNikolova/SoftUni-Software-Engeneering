using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Text;
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

            //Problem 04 string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
            //Problem 04 string result = ImportCategoryProducts(context, inputXml);

            //Problem 05 string result = GetProductsInRange(context);
            //Problem 05 File.WriteAllText(@"../../../Results/products-in-range.xml", result);

            //Problem 06 string result = GetSoldProducts(context);
            //Problem 06 File.WriteAllText(@"../../../Results/sold-products.xml", result);

            string result = GetCategoriesByProductsCount(context);
            File.WriteAllText(@"../../../Results/categories-by-products-count.xml",result);

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


        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();

            ExportProductDto[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductDto[]), xmlRoot);

            using StringWriter writter = new StringWriter(sb);
            serializer.Serialize(writter, products, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }


        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();

            ExportSoldProductDto[] soldProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                //.Select(u => new ExportSoldProductDto() ----> without AutoMapper
                //{
                //    FirstName = u.FirstName,
                //    LastName = u.LastName,
                //    ProductsSold = u.ProductsSold.Select(ps => new ProductDto()
                //    {
                //        Name = ps.Name,
                //        Price = ps.Price,
                //    }).ToArray()
                //})
                .ProjectTo<ExportSoldProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSoldProductDto[]), xmlRoot);

            XmlSerializerNamespaces xmlNamespace = new XmlSerializerNamespaces();
            xmlNamespace.Add(string.Empty, string.Empty);

            using StringWriter writter = new StringWriter(sb);
            xmlSerializer.Serialize(writter, soldProducts, xmlNamespace);

            return sb.ToString().TrimEnd();

        }


        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();

            ExportCategoryByProductsDto[] categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ThenBy(c => c.CategoryProducts.Sum(cp => cp.Product.Price))
                //.Select(c => new ExportCategoryByProductsDto() ----> without AutoMapper
                //{
                //    Name= c.Name,
                //    Count = c.CategoryProducts.Count,
                //    AvaragePrice = c.CategoryProducts.Average(cp=>cp.Product.Price),
                //    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                //})
                .ProjectTo<ExportCategoryByProductsDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoryByProductsDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, categories, namespaces);

            return sb.ToString().TrimEnd();
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