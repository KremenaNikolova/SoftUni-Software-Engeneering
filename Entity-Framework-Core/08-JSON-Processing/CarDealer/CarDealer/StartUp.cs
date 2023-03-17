using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Problem 09 string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //Problem 09 string result = ImportSuppliers(context, inputJson);

            //Problem 10 string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            //Problem 10 string result = ImportParts(context, inputJson);

            //Problem 11 string inputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            //Problem 11 string result = ImportCars(context, inputJson);

            string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            string result = ImportCustomers(context, inputJson);

            Console.WriteLine(result);
        }


        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            IContractResolver contractResolver = CammelCaseContractResolver();

            ImportSupplierDto[]? supplierDto = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });

            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }


        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            IContractResolver contractResolver = CammelCaseContractResolver();

            ImportPartDto[]? partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });

            ICollection<Part> parts = new HashSet<Part>(); 

            foreach (var partDto in partDtos!)
            {
                if (!context.Suppliers.Any(s=>s.Id == partDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }


        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IContractResolver contractResolver = CammelCaseContractResolver();

            List<ImportCarDto>? carDtos = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson, new JsonSerializerSettings() 
            { 
                ContractResolver = contractResolver 
            });

            List<Car> cars = new List<Car>();
            List<PartCar> partsCar = new List<PartCar>();

            foreach (var carDto in carDtos!)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                cars.Add(car);

                foreach (var part in carDto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part
                    };

                    partsCar.Add(partCar);
                }
                   
            }

            context.AddRange(cars);
            context.AddRange(partsCar);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }


        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            IContractResolver contractResolver = CammelCaseContractResolver();

            ImportCustomerDto[]? customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });

            Customer[] customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }



        //Mapper
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }

        //CammelCase Configuration Json
        private static IContractResolver CammelCaseContractResolver()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
        }

    }
}