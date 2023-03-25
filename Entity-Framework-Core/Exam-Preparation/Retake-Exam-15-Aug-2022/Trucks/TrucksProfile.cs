namespace Trucks
{
    using AutoMapper;
    using Trucks.Data.Models;
    using Trucks.DataProcessor.ImportDto;

    public class TrucksProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TrucksProfile()
        {
            this.CreateMap<ImportDespatcherDto, Despatcher>()
                .ForMember(dto=>dto.Name, opt=>opt.MapFrom(src=>src.Name))
                .ForMember(dto=>dto.Position, opt=>opt.MapFrom(src=>src.Position))
                .ForMember(dto=>dto.Trucks, opt=>opt.MapFrom(src=>src.Trucks));
            

            this.CreateMap<ImportDespatcherTruckDto, Truck>();
        }
    }
}
