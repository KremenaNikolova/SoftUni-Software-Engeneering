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
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<User, ExportSoldProductDto>();

            //Product
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductDto>()
                .ForMember(dto => dto.Buyer, opt => opt.MapFrom(src => $"{src.Buyer.FirstName} {src.Buyer.LastName}"));
            this.CreateMap<Product, ProductDto>();
            

            //Categiry
            this.CreateMap<ImportCategoryDto, Category>();


            //CategoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            
        }
    }
}
