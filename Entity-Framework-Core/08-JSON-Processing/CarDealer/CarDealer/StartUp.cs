using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

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

            //Problem 12 string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            //Problem 12 string result = ImportCustomers(context, inputJson);

            //Problem 13 string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //Problem 13 string result = ImportSales(context, inputJson);

            //Problem 14 string result = GetOrderedCustomers(context);

            //Problem 15 string result = GetCarsFromMakeToyota(context);

            //Problem 16 string result = GetLocalSuppliers(context);

            //Problem 17 string result = GetCarsWithTheirListOfParts(context);

            //Problem 18 string result = GetTotalSalesByCustomer(context);

            string result = GetSalesWithAppliedDiscount(context);
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
                if (!context.Suppliers.Any(s => s.Id == partDto.SupplierId))
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
                    TraveledDistance = carDto.TraveledDistance
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


        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            IContractResolver contractResolver = CammelCaseContractResolver();

            ImportSaleDto[]? saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });

            Sale[] sales = mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";

        }


        //14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }


        //15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .AsNoTracking()
                .ToArray();



            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }


        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .ToArray();


            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }


        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    })
                })
                .AsNoTracking()
                .ToArray();


            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }


        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            IContractResolver contractResolver = CammelCaseContractResolver();

            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = Math.Round(c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price)).Sum(), 2, MidpointRounding.AwayFromZero)
                })
                .AsNoTracking()
                .ToArray()
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars);


            return JsonConvert.SerializeObject(customers, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });
        }


        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {

            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)).ToString("f2")
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
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