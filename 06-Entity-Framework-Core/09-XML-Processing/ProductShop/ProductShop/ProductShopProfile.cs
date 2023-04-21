namespace ProductShop
{
 using AutoMapper;
    using ProductShop.DTOs.Export;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //User
            this.CreateMap<ImportUserDto, User>(); //Problem 01

            this.CreateMap<User, ExportSoldProductDto>(); //Problem 05


            //Product
            this.CreateMap<ImportProductDto, Product>(); //Problem 02

            this.CreateMap<Product, ExportProductDto>() //Problem 06
                .ForMember(dto => dto.Buyer, opt => opt.MapFrom(src => $"{src.Buyer.FirstName} {src.Buyer.LastName}"));

            this.CreateMap<Product, ProductDto>(); //Problem 06
            

            //Categiry
            this.CreateMap<ImportCategoryDto, Category>(); //Problem 03

            this.CreateMap<Category, ExportCategoryByProductsDto>() //Problem 07
                .ForMember(dto=>dto.Count, opt=>opt.MapFrom(src=>src.CategoryProducts.Count))
                .ForMember(dto=>dto.AvaragePrice, opt=>opt.MapFrom(src=>src.CategoryProducts.Average(cp=>cp.Product.Price)))
                .ForMember(dto=>dto.TotalRevenue, opt=>opt.MapFrom(src=>src.CategoryProducts.Sum(cp=>cp.Product.Price)));


            //CategoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>(); //Problem 04

            
        }
    }
}
