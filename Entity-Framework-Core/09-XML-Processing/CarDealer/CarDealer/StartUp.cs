namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            //Problem 01 string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            //Problem 01 string result = ImportSuppliers(context, inputXml);

            //Problem 02 string inputXml = File.ReadAllText(@"../../../Datasets/parts.xml");
            //Problem 02 string result = ImportParts(context, inputXml);

            string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            string result = ImportCars(context, inputXml);

            Console.WriteLine(result);
        }


        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportSupplierDto[] summplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader)!;

            Supplier[] suppliers = mapper.Map<Supplier[]>(summplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }


        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportPartDto[] partDtos = (ImportPartDto[])xmlSerializer.Deserialize(reader)!;

            ICollection<Part> parts = new HashSet<Part>();
            foreach (var partDto in partDtos)
            {
                if (!context.Suppliers.Any(s=>s.Id==partDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }


        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper= CreateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportCarDto[] carDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader)!;

            ICollection<Car> cars = new HashSet<Car>();
            foreach (var carDto in carDtos)
            {
                Car car = mapper.Map<Car>(carDto);
                cars.Add(car);

                foreach (var partDto in carDto.Parts.DistinctBy(p=>p.PartId))
                {
                    if (!context.Parts.Any(p=>p.Id==partDto.PartId))
                    {
                        continue;
                    }

                    PartCar part = new PartCar()
                    {
                        PartId = partDto.PartId,
                    };

                    car.PartsCars.Add(part);
                }
                
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }



        //Mapper
        public static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}