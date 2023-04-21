namespace ProductShop;

using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

public class ProductShopProfile : Profile
{
    public ProductShopProfile() 
    {
        this.CreateMap<ImportUserDto, User>();

        this.CreateMap<ImportProductDto, Product>();

        this.CreateMap<Product, ExportProductInRangeDto>();
        //this below is in case we not work with anonymous object
        //.ForMember(dst=>dst.ProductName, opt=>opt.MapFrom(src=>src.Name))
        //.ForMember(dst=>dst.ProductPrice, opt=>opt.MapFrom(src=>src.Price))
        //.ForMember(dst=>dst.SellerFullName, opt=>opt.MapFrom(src=>$"{src.Seller.FirstName} {src.Seller.LastName}"));

        this.CreateMap<ImportCategoryDto, Category>();

        this.CreateMap<ImportCategoryProductDto, CategoryProduct> ();

    }
}
