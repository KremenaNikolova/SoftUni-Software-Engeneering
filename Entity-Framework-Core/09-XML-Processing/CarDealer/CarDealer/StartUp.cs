namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.DTOs.Export;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using System.Text;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            //Problem 09 string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            //Problem 09 string result = ImportSuppliers(context, inputXml);

            //Problem 10 string inputXml = File.ReadAllText(@"../../../Datasets/parts.xml");
            //Problem 10 string result = ImportParts(context, inputXml);

            //Problem 11 string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            //Problem 11 string result = ImportCars(context, inputXml);

            //Problem 12 string inputXml = File.ReadAllText(@"../../../Datasets/customers.xml");
            //Problem 12 string result = ImportCustomers(context, inputXml);

            //Problem 13 string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");
            //Problem 13 string result = ImportSales(context, inputXml);

            //Problem 14 string result = GetCarsWithDistance(context);
            //Problem 14 File.WriteAllText(@"../../../Results/cars-with-distance.xml", result);

            //Problem 15 string result = GetCarsFromMakeBmw(context);
            //Problem 15 File.WriteAllText(@"../../../Results/cars-model-BWM.xml", result);

            //Problem 16 string result = GetLocalSuppliers(context);
            //Problem 16 File.WriteAllText(@"../../../Results/local-suppliers.xml", result);

            //Problem 17 string result = GetCarsWithTheirListOfParts(context);
            //Problem 17 File.WriteAllText(@"../../../Results/cars-with-their-parts.xml", result);

            string result = GetTotalSalesByCustomer(context);
            File.WriteAllText(@"../../../Results/total-sales-by-customers.xml", result);

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


        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Customers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportCustomerDto[] customerDtos = (ImportCustomerDto[])serializer.Deserialize(reader)!;

            Customer[] customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }


        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportSaleDto[] saleDtos = (ImportSaleDto[])serializer.Deserialize(reader)!;

            ICollection<Sale> sales = new HashSet<Sale>();
            foreach (var saleDto in saleDtos)
            {
                if (!context.Cars.Any(c=>c.Id==saleDto.CarId))
                {
                    continue;
                }

                Sale sale = mapper.Map<Sale>(saleDto);
                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }


        //14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();

            ExportCarDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .Take(10)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarDto[]), xmlRoot);

            using StringWriter writer= new StringWriter(sb);
            serializer.Serialize(writer, cars, namespaces);

            return sb.ToString().TrimEnd();
        }


        //15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();

            ExportBmwCarDto[] cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportBmwCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportBmwCarDto[]), xmlRoot);

            using StringWriter writer= new StringWriter(sb);
            serializer.Serialize(writer, cars, namespaces);

            return sb.ToString().TrimEnd();
        }


        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();

            ExportLocalSupplierDto[] summplierDtos = context.Suppliers
                .Where(s=>s.IsImporter==false)
                //.Select(s=> new ExportLocalSupplierDto() ----> if u dont use AutoMapper
                //{
                //    Id = s.Id,
                //    Name = s.Name,
                //    PartsCount = s.Parts.Count   
                //})
                .ProjectTo<ExportLocalSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), xmlRoot);

            using StringWriter writer= new StringWriter(sb);
            serializer.Serialize(writer, summplierDtos, namespaces);

            return sb.ToString().TrimEnd(); 
        }


        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();

            ExportCarWithPartsDto[] carWithPartsDtos = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                //.Select(c => new ExportCarWithPartsDto()  ----> if u dont use AutoMapper
                //{
                //    Make = c.Make,
                //    Model= c.Model,
                //    TraveledDistance= c.TraveledDistance,
                //    CarParts = c.PartsCars.Select(pc=> new CarPartsDto()
                //    {
                //        Name = pc.Part.Name,
                //        Price= pc.Part.Price
                //    })
                //    .OrderByDescending(pc=>pc.Price)
                //    .ToArray()
                //})
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializerNamespaces namespaces= new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarWithPartsDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, carWithPartsDtos, namespaces);

            return sb.ToString().TrimEnd();

        }


        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();

            ExportCustomerDto[] customerDtos = context.Sales
                .Where(s=>s.Customer.Sales.Any())
                .ToArray()
                .Select(s=> new ExportCustomerDto()
                {
                    Name= s.Customer.Name,
                    BoughtCars = s.Customer.Sales.Count,
                    SpendMoney = s.Customer.IsYoungDriver 
                    ? s.Car.PartsCars.Sum(pc => Math.Round(pc.Part.Price * 0.95m, 2))
                    : s.Car.PartsCars.Sum(pc => Math.Round(pc.Part.Price, 2))

                })
                .OrderByDescending(pc=>pc.SpendMoney)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("customers");
            XmlSerializerNamespaces namespaces= new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCustomerDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, customerDtos, namespaces);

            return sb.ToString().TrimEnd(); 
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