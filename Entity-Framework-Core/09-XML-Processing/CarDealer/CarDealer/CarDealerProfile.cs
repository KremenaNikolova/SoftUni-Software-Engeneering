using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>(); //Problem 09

            this.CreateMap<Supplier, ExportLocalSupplierDto>()  //Problem 16
                .ForMember(dto=>dto.PartsCount, opt=>opt
                .MapFrom(src=>src.Parts.Count)); 

            //Part
            this.CreateMap<ImportPartDto, Part>(); //Problem 10

            this.CreateMap<Part, CarPartsDto>(); //Problem 17

            //Car
            this.CreateMap<ImportCarDto, Car>(); //Problem 11
            this.CreateMap<PartDto, Car>(); //Problem 11

            this.CreateMap<Car, ExportCarDto>(); //Problem 14

            this.CreateMap<Car, ExportBmwCarDto>(); //Problem 15

            this.CreateMap<Car, ExportCarWithPartsDto>()  //Problem 17
                .ForMember(dto=>dto.CarParts, opt=>opt
                .MapFrom(src=>src.PartsCars.Select(pc=>pc.Part)
                .OrderByDescending(p=>p.Price))); 


            //Customer
            this.CreateMap<ImportCustomerDto, Customer>(); //Problem 12


            //Sale
            this.CreateMap<ImportSaleDto, Sale>(); //Problem 13
        }
    }
}
