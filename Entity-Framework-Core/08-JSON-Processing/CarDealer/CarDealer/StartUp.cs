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

            //Problem 09 string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //Problem 09 string result = ImportSuppliers(context, inputJson);

            string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            string result = ImportParts(context, inputJson);

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