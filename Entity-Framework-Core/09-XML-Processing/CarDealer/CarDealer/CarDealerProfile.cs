using AutoMapper;
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

            //Part
            this.CreateMap<ImportPartDto, Part>(); //Problem 10

            //Car
            this.CreateMap<ImportCarDto, Car>(); //Problem 11
            this.CreateMap<PartDto, Car>(); //Problem 11
        }
    }
}
