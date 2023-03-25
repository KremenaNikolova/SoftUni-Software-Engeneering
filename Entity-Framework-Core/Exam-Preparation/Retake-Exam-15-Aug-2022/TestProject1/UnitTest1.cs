//Resharper disable InconsistentNaming, CheckNamespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using NUnit.Framework;

using Trucks;
using Trucks.Data;

[TestFixture]
public class Import_000_002
{
    private IServiceProvider serviceProvider;

    private static readonly Assembly CurrentAssembly = typeof(StartUp).Assembly;

    [SetUp]
    public void Setup()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TrucksProfile>();
        });

        this.serviceProvider = ConfigureServices<TrucksContext>("Trucks");
    }

    [Test]
    public void ImportClientsZeroTest()
    {
        var context = this.serviceProvider.GetService<TrucksContext>();

        SeedDatabase(context);

        var inputJson =
            "[{\"Name\":\"Kuenehne + Nagel (AG & Co.) KGKuenehne + Nagel (AG & Co.) KGKuenehne + Nagel (AG & Co.) KG\",\"Nationality\":\"The Netherlands\",\"Type\":\"golden\",\"Trucks\":[1,68,73,17,98,98]},{\"Name\":\"DHL SERVICES LIMITED\",\"Nationality\":\"The United Kingdom\",\"Type\":\"golden\",\"Trucks\":[4,17,17,98]},{\"Name\":\"GLOU AVTO GmbH\",\"Nationality\":\"Germany\",\"Type\":\"usual\",\"Trucks\":[25,43,78,158,47,3]},{\"Name\":\"SCHENKER SP ZOO\",\"Nationality\":\"France\",\"Type\":\"platinum\",\"Trucks\":[53,51,56,4,98,78]},{\"Name\":\"Buchen UmweltService GmbH\",\"Nationality\":\"Belgium\",\"Type\":\"platinum\",\"Trucks\":[64,26,49,54,31]},{\"Name\":\"SPETSENERGOTRANS AO\",\"Nationality\":\"Denmark\",\"Type\":\"platinum\",\"Trucks\":[68,76,9]},{\"Name\":\"TOPPROM AO\",\"Nationality\":\"Italy\",\"Type\":\"usual\",\"Trucks\":[89,81,63,37]},{\"Name\":\"MCBURNEY HOLDINGS LIMITED\",\"Nationality\":\"Poland\",\"Type\":\"golden\",\"Trucks\":[1,65,25,10,25]},{\"Name\":\"ZMK AO\",\"Nationality\":\"The Netherlands\",\"Type\":\"platinum\",\"Trucks\":[58,90,32,51,1,24]},{\"Name\":\"Meopta – optika s.r.o.\",\"Nationality\":\"The United Kingdom\",\"Type\":\"platinum\",\"Trucks\":[83,4,48,60,35,53,45]},{\"Name\":\"Srg Holding AS\",\"Nationality\":\"Germany\",\"Type\":\"platinum\",\"Trucks\":[63,71,65]},{\"Name\":\"GEKSA-NETKANYE MATERIALY GmbH\",\"Nationality\":\"France\",\"Type\":\"silver\",\"Trucks\":[68,16,36,80]},{\"Name\":\"GROUPE DUPESSEY\",\"Nationality\":\"Belgium\",\"Type\":\"usual\",\"Trucks\":[44,56,87,2,1,3]},{\"Name\":\"SKA GmbH\",\"Nationality\":\"Denmark\",\"Type\":\"golden\",\"Trucks\":[10,11,95,73,158,124,101]},{\"Name\":\"PERGUILHEM SAS\",\"Nationality\":\"Italy\",\"Type\":\"usual\",\"Trucks\":[44,39,59,70,94]},{\"Name\":\"ZAKŁAD USLUGOWO HANDLOWY MIXPOL PAWEL MICHULEC\",\"Nationality\":\"Poland\",\"Type\":\"usual\",\"Trucks\":[89,69,40,23,89,86]},{\"Name\":\"SAFPLAST GmbH\",\"Nationality\":\"The Netherlands\",\"Type\":\"golden\",\"Trucks\":[93,59,97,27,69,18,53]},{\"Name\":\"PFEIFER & LANGEN ROMANIA S.R.L.\",\"Nationality\":\"The United Kingdom\",\"Type\":\"platinum\",\"Trucks\":[5,19,28]},{\"Name\":\"KOMPANIYA BIO GmbH\",\"Nationality\":\"Germany\",\"Type\":\"silver\",\"Trucks\":[89,31,17,20]},{\"Name\":\"ELEKTON AO\",\"Nationality\":\"France\",\"Type\":\"golden\",\"Trucks\":[19,65,41,79,3]},{\"Name\":\"TK AGROGRUPP GmbH\",\"Nationality\":\"Belgium\",\"Type\":\"silver\",\"Trucks\":[4,23,54,90,88,21]},{\"Name\":\"ABC-Logistik GmbH\",\"Nationality\":\"Denmark\",\"Type\":\"platinum\",\"Trucks\":[95,28,42,5,98,41,97]},{\"Name\":\"Schmidt Gastransporte GmbH & Co KG\",\"Nationality\":\"Italy\",\"Type\":\"golden\",\"Trucks\":[89,64,15,14,13]},{\"Name\":\"FIKS GRUPP GmbH\",\"Nationality\":\"Poland\",\"Type\":\"usual\",\"Trucks\":[30,39,64,39]},{\"Name\":\"BILLY BOWIE SPECIAL PROJECTS LIMITED\",\"Nationality\":\"The Netherlands\",\"Type\":\"silver\",\"Trucks\":[17,95,44,27,92]},{\"Name\":\"B.T. TRASPORTI SRL\",\"Nationality\":\"The United Kingdom\",\"Type\":\"golden\",\"Trucks\":[79,81,54,61,80,57]},{\"Name\":\"Gebr. Mayer GmbH & Co. KG\",\"Nationality\":\"Germany\",\"Type\":\"golden\",\"Trucks\":[33,34,97,41,35,51,79,4]},{\"Name\":\"DELTA GmbH\",\"Nationality\":\"France\",\"Type\":\"golden\",\"Trucks\":[12,74,87]},{\"Name\":\"Tekro spol. s r.o.\",\"Nationality\":\"Belgium\",\"Type\":\"platinum\",\"Trucks\":[34,33,88,77,46]},{\"Name\":\"VYMPEL PLYUS GmbH\",\"Nationality\":\"Denmark\",\"Type\":\"silver\",\"Trucks\":[30,60,24,53,85]},{\"Name\":\"KARAVAI GmbH\",\"Nationality\":\"Italy\",\"Type\":\"usual\",\"Trucks\":[15,41,97,35,82,48]},{\"Name\":\"KRIPTON GmbH\",\"Nationality\":\"Poland\",\"Type\":\"golden\",\"Trucks\":[59,86,24,83,65,57,55]},{\"Name\":\"NAZAROVOAGROSNAB AO\",\"Nationality\":\"The Netherlands\",\"Type\":\"platinum\",\"Trucks\":[20,72,45]},{\"Name\":\"Felbermayr Deutschland GmbH\",\"Nationality\":\"The United Kingdom\",\"Type\":\"golden\",\"Trucks\":[82,53,41,70]},{\"Name\":\"ECCO RAIL SP Z O O\",\"Nationality\":\"Germany\",\"Type\":\"golden\",\"Trucks\":[59,40,45,52,91]},{\"Name\":\"PEK GROUP a.s.\",\"Nationality\":\"France\",\"Type\":\"silver\",\"Trucks\":[78,4,22,59,78,71]},{\"Name\":\"North Sea Express\",\"Nationality\":\"Belgium\",\"Type\":\"platinum\",\"Trucks\":[91,47,71,49,48,31,63]},{\"Name\":\"PTS Packing Transport Services & Logistics GmbH\",\"Nationality\":\"Denmark\",\"Type\":\"golden\",\"Trucks\":[77,26,72]},{\"Name\":\"OLIVOMUNDO – SOCIEDADE AGRICOLA LDA\",\"Nationality\":\"Italy\",\"Type\":\"silver\",\"Trucks\":[6,7,12,8,8]},{\"Name\":\"HODLMAYR LOGISTICS BULGARIA EOOD\",\"Nationality\":\"Poland\",\"Type\":\"usual\",\"Trucks\":[59,60,61,62]},{\"Name\":\"Heinemann GmbH\",\"Nationality\":\"The Netherlands\",\"Type\":\"platinum\",\"Trucks\":[22,29,29,31,38,78,108]},{\"Name\":\"LOGISTICA AMBIENTALE SRL\",\"Nationality\":\"The United Kingdom\",\"Type\":\"silver\",\"Trucks\":[1,46,50,51,52,102]}]";

        var actualOutput =
           Trucks.DataProcessor.Deserializer.ImportClient(context, inputJson).TrimEnd();

        var expectedOutput =
            "Invalid data!\r\nInvalid data!\r\nSuccessfully imported client - DHL SERVICES LIMITED with 2 trucks.\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - SCHENKER SP ZOO with 4 trucks.\r\nSuccessfully imported client - Buchen UmweltService GmbH with 5 trucks.\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - SPETSENERGOTRANS AO with 1 trucks.\r\nInvalid data!\r\nSuccessfully imported client - MCBURNEY HOLDINGS LIMITED with 4 trucks.\r\nInvalid data!\r\nSuccessfully imported client - ZMK AO with 5 trucks.\r\nInvalid data!\r\nSuccessfully imported client - Meopta – optika s.r.o. with 6 trucks.\r\nInvalid data!\r\nSuccessfully imported client - Srg Holding AS with 2 trucks.\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - GEKSA-NETKANYE MATERIALY GmbH with 2 trucks.\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - SKA GmbH with 2 trucks.\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - SAFPLAST GmbH with 4 trucks.\r\nSuccessfully imported client - PFEIFER & LANGEN ROMANIA S.R.L. with 3 trucks.\r\nInvalid data!\r\nSuccessfully imported client - KOMPANIYA BIO GmbH with 3 trucks.\r\nInvalid data!\r\nSuccessfully imported client - ELEKTON AO with 4 trucks.\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - TK AGROGRUPP GmbH with 4 trucks.\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - ABC-Logistik GmbH with 4 trucks.\r\nInvalid data!\r\nSuccessfully imported client - Schmidt Gastransporte GmbH & Co KG with 4 trucks.\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - BILLY BOWIE SPECIAL PROJECTS LIMITED with 3 trucks.\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - B.T. TRASPORTI SRL with 3 trucks.\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - Gebr. Mayer GmbH & Co. KG with 6 trucks.\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - DELTA GmbH with 1 trucks.\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - Tekro spol. s r.o. with 3 trucks.\r\nInvalid data!\r\nSuccessfully imported client - VYMPEL PLYUS GmbH with 4 trucks.\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - KRIPTON GmbH with 5 trucks.\r\nInvalid data!\r\nSuccessfully imported client - NAZAROVOAGROSNAB AO with 2 trucks.\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - Felbermayr Deutschland GmbH with 2 trucks.\r\nInvalid data!\r\nSuccessfully imported client - ECCO RAIL SP Z O O with 4 trucks.\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - PEK GROUP a.s. with 3 trucks.\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - North Sea Express with 5 trucks.\r\nInvalid data!\r\nSuccessfully imported client - OLIVOMUNDO – SOCIEDADE AGRICOLA LDA with 4 trucks.\r\nInvalid data!\r\nInvalid data!\r\nInvalid data!\r\nSuccessfully imported client - Heinemann GmbH with 4 trucks.\r\nInvalid data!\r\nSuccessfully imported client - LOGISTICA AMBIENTALE SRL with 5 trucks.";

        var assertContext = this.serviceProvider.GetService<TrucksContext>();

        const int expectedClientsCount = 32;
        var actualClientsCount = assertContext.Clients.Count();

        const int expectedClientsTrucksCount = 113;
        var actualClientsTrucksCount = assertContext.ClientsTrucks.Count();

        Assert.That(actualClientsTrucksCount, Is.EqualTo(expectedClientsTrucksCount),
            $"Inserted {nameof(context.ClientsTrucks)} count is incorrect!");

        Assert.That(actualClientsCount, Is.EqualTo(expectedClientsCount),
            $"Inserted {nameof(context.Clients)} count is incorrect!");

        Assert.That(actualOutput, Is.EqualTo(expectedOutput).NoClip,
            $"{nameof(Trucks.DataProcessor.Deserializer.ImportClient)} output is incorrect!");
    }

    private static void SeedDatabase(TrucksContext context)
    {
        var datasetsJson = "{\"Despatcher\":[{\"Id\":1,\"Name\":\"Genadi Petrov\",\"Position\":\"Specialist\"},{\"Id\":2,\"Name\":\"Apostol Dobromirov\",\"Position\":\"Specialist\"},{\"Id\":3,\"Name\":\"Hristina Petrova\",\"Position\":\"Forwarder\"},{\"Id\":4,\"Name\":\"Ekaterina Hristova\",\"Position\":\"Trainee\"},{\"Id\":5,\"Name\":\"Petko Todorov\",\"Position\":\"Manager\"},{\"Id\":6,\"Name\":\"Todor Petrov\",\"Position\":\"Specialist\"},{\"Id\":7,\"Name\":\"Asen Hristov\",\"Position\":\"Trainee\"},{\"Id\":8,\"Name\":\"Georgi Atanasov\",\"Position\":\"Manager\"},{\"Id\":9,\"Name\":\"Vladislav Dobromirov\",\"Position\":\"Specialist\"},{\"Id\":10,\"Name\":\"Polina Kostadinova\",\"Position\":\"Forwarder\"},{\"Id\":11,\"Name\":\"Miahela Eneva\",\"Position\":\"Trainee\"},{\"Id\":12,\"Name\":\"Dobromir Plamenov\",\"Position\":\"Specialist\"},{\"Id\":13,\"Name\":\"Vladimir Hristov\",\"Position\":\"Forwarder\"},{\"Id\":14,\"Name\":\"Georgi Stefanov\",\"Position\":\"Trainee\"},{\"Id\":15,\"Name\":\"Atanas Petrov\",\"Position\":\"Manager\"},{\"Id\":16,\"Name\":\"Boris Todorov\",\"Position\":\"Trainee\"},{\"Id\":17,\"Name\":\"Ivan Borislavov\",\"Position\":\"Manager\"},{\"Id\":18,\"Name\":\"Borislav Petrov\",\"Position\":\"Specialist\"},{\"Id\":19,\"Name\":\"Ivan Petrov\",\"Position\":\"Forwarder\"},{\"Id\":20,\"Name\":\"Ivan Hristov\",\"Position\":\"Manager\"},{\"Id\":21,\"Name\":\"Hristo Ivanov\",\"Position\":\"Specialist\"},{\"Id\":22,\"Name\":\"Kalina Petrova\",\"Position\":\"Trainee\"},{\"Id\":23,\"Name\":\"Desislava Hristova\",\"Position\":\"Manager\"},{\"Id\":24,\"Name\":\"Ana Ivanova\",\"Position\":\"Forwarder\"},{\"Id\":25,\"Name\":\"Stela Stefanova\",\"Position\":\"Trainee\"},{\"Id\":26,\"Name\":\"Veselin Daskalov\",\"Position\":\"Manager\"},{\"Id\":27,\"Name\":\"Stefan Dragomirov\",\"Position\":\"Specialist\"},{\"Id\":28,\"Name\":\"Kosta Slavov\",\"Position\":\"Manager\"},{\"Id\":29,\"Name\":\"Grigor Petrov\",\"Position\":\"Manager\"},{\"Id\":30,\"Name\":\"Simeon Ivanov\",\"Position\":\"Trainee\"}],\"Truck\":[{\"Id\":1,\"RegistrationNumber\":\"CB0796TP\",\"VinNumber\":\"YS2R4X211D5318181\",\"TankCapacity\":1000,\"CargoCapacity\":23999,\"CategoryType\":0,\"MakeType\":3},{\"Id\":2,\"RegistrationNumber\":\"CT5209MM\",\"VinNumber\":\"WDB96341311261294\",\"TankCapacity\":1420,\"CargoCapacity\":28058,\"CategoryType\":2,\"MakeType\":4},{\"Id\":3,\"RegistrationNumber\":\"CT5210MM\",\"VinNumber\":\"WDB96341311261289\",\"TankCapacity\":1420,\"CargoCapacity\":28058,\"CategoryType\":0,\"MakeType\":3},{\"Id\":4,\"RegistrationNumber\":\"CT4453MP\",\"VinNumber\":\"WDB96341311269859\",\"TankCapacity\":1420,\"CargoCapacity\":28058,\"CategoryType\":1,\"MakeType\":1},{\"Id\":5,\"RegistrationNumber\":\"CT9054HM\",\"VinNumber\":\"WDB96341611356141\",\"TankCapacity\":990,\"CargoCapacity\":28399,\"CategoryType\":2,\"MakeType\":0},{\"Id\":6,\"RegistrationNumber\":\"CT9057HM\",\"VinNumber\":\"WDB96341611356142\",\"TankCapacity\":990,\"CargoCapacity\":28399,\"CategoryType\":0,\"MakeType\":1},{\"Id\":7,\"RegistrationNumber\":\"CT9049HM\",\"VinNumber\":\"WDB96341611356151\",\"TankCapacity\":990,\"CargoCapacity\":28399,\"CategoryType\":0,\"MakeType\":0},{\"Id\":8,\"RegistrationNumber\":\"CT1151HH\",\"VinNumber\":\"WDB96341611356438\",\"TankCapacity\":990,\"CargoCapacity\":28399,\"CategoryType\":2,\"MakeType\":4},{\"Id\":9,\"RegistrationNumber\":\"CT1160HH\",\"VinNumber\":\"WDB96341611356439\",\"TankCapacity\":990,\"CargoCapacity\":28399,\"CategoryType\":0,\"MakeType\":3},{\"Id\":10,\"RegistrationNumber\":\"CT1157HH\",\"VinNumber\":\"WDB96341311356127\",\"TankCapacity\":1420,\"CargoCapacity\":28097,\"CategoryType\":1,\"MakeType\":1},{\"Id\":11,\"RegistrationNumber\":\"CT1159HH\",\"VinNumber\":\"WDB96341611356143\",\"TankCapacity\":990,\"CargoCapacity\":28399,\"CategoryType\":1,\"MakeType\":0},{\"Id\":12,\"RegistrationNumber\":\"CT1143HH\",\"VinNumber\":\"WDB96341611356149\",\"TankCapacity\":991,\"CargoCapacity\":28399,\"CategoryType\":0,\"MakeType\":2},{\"Id\":13,\"RegistrationNumber\":\"CT1145HH\",\"VinNumber\":\"WDB96341311356138\",\"TankCapacity\":1420,\"CargoCapacity\":28097,\"CategoryType\":3,\"MakeType\":4},{\"Id\":14,\"RegistrationNumber\":\"CT5627PB\",\"VinNumber\":\"WDB96341311389285\",\"TankCapacity\":1420,\"CargoCapacity\":19156,\"CategoryType\":2,\"MakeType\":0},{\"Id\":15,\"RegistrationNumber\":\"CT5629PB\",\"VinNumber\":\"WDB96341311388385\",\"TankCapacity\":1420,\"CargoCapacity\":8752,\"CategoryType\":0,\"MakeType\":1},{\"Id\":16,\"RegistrationNumber\":\"CT5630PB\",\"VinNumber\":\"WDB96341311388386\",\"TankCapacity\":1420,\"CargoCapacity\":15083,\"CategoryType\":3,\"MakeType\":2},{\"Id\":17,\"RegistrationNumber\":\"CT5633PB\",\"VinNumber\":\"WDB96341311388387\",\"TankCapacity\":1420,\"CargoCapacity\":15837,\"CategoryType\":1,\"MakeType\":4},{\"Id\":18,\"RegistrationNumber\":\"CT5637PB\",\"VinNumber\":\"WDB96341311388389\",\"TankCapacity\":1420,\"CargoCapacity\":10623,\"CategoryType\":0,\"MakeType\":0},{\"Id\":19,\"RegistrationNumber\":\"CT5639PB\",\"VinNumber\":\"WDB96341311389271\",\"TankCapacity\":1420,\"CargoCapacity\":11073,\"CategoryType\":1,\"MakeType\":2},{\"Id\":20,\"RegistrationNumber\":\"CT5643PB\",\"VinNumber\":\"WDB96341311396613\",\"TankCapacity\":1420,\"CargoCapacity\":7108,\"CategoryType\":0,\"MakeType\":3},{\"Id\":21,\"RegistrationNumber\":\"CT5645PB\",\"VinNumber\":\"WDB96341311388186\",\"TankCapacity\":1420,\"CargoCapacity\":6036,\"CategoryType\":1,\"MakeType\":1},{\"Id\":22,\"RegistrationNumber\":\"CT5647PB\",\"VinNumber\":\"WDB96341311389272\",\"TankCapacity\":1420,\"CargoCapacity\":8614,\"CategoryType\":2,\"MakeType\":2},{\"Id\":23,\"RegistrationNumber\":\"CT5648PB\",\"VinNumber\":\"WDB96341311388187\",\"TankCapacity\":1420,\"CargoCapacity\":13039,\"CategoryType\":0,\"MakeType\":4},{\"Id\":24,\"RegistrationNumber\":\"CT5650PB\",\"VinNumber\":\"WDB96341311389276\",\"TankCapacity\":1420,\"CargoCapacity\":14798,\"CategoryType\":1,\"MakeType\":0},{\"Id\":25,\"RegistrationNumber\":\"CT5617PB\",\"VinNumber\":\"WDB96341311389277\",\"TankCapacity\":1420,\"CargoCapacity\":6421,\"CategoryType\":3,\"MakeType\":4},{\"Id\":26,\"RegistrationNumber\":\"CT5621PB\",\"VinNumber\":\"WDB96341311389279\",\"TankCapacity\":1420,\"CargoCapacity\":8306,\"CategoryType\":2,\"MakeType\":0},{\"Id\":27,\"RegistrationNumber\":\"CT5622PB\",\"VinNumber\":\"WDB96341311389281\",\"TankCapacity\":1420,\"CargoCapacity\":14970,\"CategoryType\":0,\"MakeType\":1},{\"Id\":28,\"RegistrationNumber\":\"CT5625PB\",\"VinNumber\":\"WDB96341311389283\",\"TankCapacity\":1420,\"CargoCapacity\":5358,\"CategoryType\":2,\"MakeType\":3},{\"Id\":29,\"RegistrationNumber\":\"CT3094CB\",\"VinNumber\":\"W1T96341311428767\",\"TankCapacity\":1420,\"CargoCapacity\":12817,\"CategoryType\":3,\"MakeType\":0},{\"Id\":30,\"RegistrationNumber\":\"CT6571CT\",\"VinNumber\":\"W1T96341311427814\",\"TankCapacity\":1420,\"CargoCapacity\":15795,\"CategoryType\":2,\"MakeType\":2},{\"Id\":31,\"RegistrationNumber\":\"CT5208MM\",\"VinNumber\":\"WDB96341311261288\",\"TankCapacity\":1420,\"CargoCapacity\":28058,\"CategoryType\":1,\"MakeType\":2},{\"Id\":32,\"RegistrationNumber\":\"CT4963PM\",\"VinNumber\":\"W1T96341311427817\",\"TankCapacity\":1420,\"CargoCapacity\":8168,\"CategoryType\":0,\"MakeType\":4},{\"Id\":33,\"RegistrationNumber\":\"CT5206MM\",\"VinNumber\":\"WDB96341311261287\",\"TankCapacity\":1420,\"CargoCapacity\":28058,\"CategoryType\":0,\"MakeType\":0},{\"Id\":34,\"RegistrationNumber\":\"CT5204MM\",\"VinNumber\":\"WDB96341311261293\",\"TankCapacity\":1420,\"CargoCapacity\":28058,\"CategoryType\":1,\"MakeType\":4},{\"Id\":35,\"RegistrationNumber\":\"CT2706TT\",\"VinNumber\":\"YS2R4X211D5333237\",\"TankCapacity\":1400,\"CargoCapacity\":27000,\"CategoryType\":0,\"MakeType\":4},{\"Id\":36,\"RegistrationNumber\":\"CB9655TX\",\"VinNumber\":\"YS2R4X211D5332926\",\"TankCapacity\":1400,\"CargoCapacity\":25000,\"CategoryType\":3,\"MakeType\":3},{\"Id\":37,\"RegistrationNumber\":\"CB8300XC\",\"VinNumber\":\"WDB9341621L884471\",\"TankCapacity\":990,\"CargoCapacity\":23738,\"CategoryType\":0,\"MakeType\":3},{\"Id\":38,\"RegistrationNumber\":\"CB0441XT\",\"VinNumber\":\"XLRTE47MS1G141844\",\"TankCapacity\":1290,\"CargoCapacity\":27317,\"CategoryType\":2,\"MakeType\":2},{\"Id\":39,\"RegistrationNumber\":\"CB2071XT\",\"VinNumber\":\"XLRTE47MS1G141194\",\"TankCapacity\":1290,\"CargoCapacity\":27317,\"CategoryType\":3,\"MakeType\":3},{\"Id\":40,\"RegistrationNumber\":\"CB2117XT\",\"VinNumber\":\"XLRTE47MS1G141136\",\"TankCapacity\":1290,\"CargoCapacity\":26317,\"CategoryType\":1,\"MakeType\":0},{\"Id\":41,\"RegistrationNumber\":\"CT6631TT\",\"VinNumber\":\"XLRTE47MS1G141929\",\"TankCapacity\":1200,\"CargoCapacity\":27303,\"CategoryType\":2,\"MakeType\":3},{\"Id\":42,\"RegistrationNumber\":\"CB6230XT\",\"VinNumber\":\"XLRTE47MS1G142311\",\"TankCapacity\":1290,\"CargoCapacity\":28315,\"CategoryType\":0,\"MakeType\":0},{\"Id\":43,\"RegistrationNumber\":\"CB7630XT\",\"VinNumber\":\"XLRTE47MS1G141917\",\"TankCapacity\":1200,\"CargoCapacity\":27303,\"CategoryType\":3,\"MakeType\":1},{\"Id\":44,\"RegistrationNumber\":\"CT1293HH\",\"VinNumber\":\"XLRTE47MS1G141111\",\"TankCapacity\":1290,\"CargoCapacity\":27317,\"CategoryType\":2,\"MakeType\":4},{\"Id\":45,\"RegistrationNumber\":\"CT1230BB\",\"VinNumber\":\"XLRTE47MS1G146164\",\"TankCapacity\":1290,\"CargoCapacity\":28295,\"CategoryType\":3,\"MakeType\":0},{\"Id\":46,\"RegistrationNumber\":\"CT1437BB\",\"VinNumber\":\"XLRTE47MS1G146235\",\"TankCapacity\":1290,\"CargoCapacity\":28295,\"CategoryType\":1,\"MakeType\":1},{\"Id\":47,\"RegistrationNumber\":\"CT1439BB\",\"VinNumber\":\"XLRTE47MS1G146275\",\"TankCapacity\":1200,\"CargoCapacity\":28295,\"CategoryType\":2,\"MakeType\":2},{\"Id\":48,\"RegistrationNumber\":\"CT1231BB\",\"VinNumber\":\"XLRTE47MS1G146652\",\"TankCapacity\":1290,\"CargoCapacity\":28307,\"CategoryType\":3,\"MakeType\":3},{\"Id\":49,\"RegistrationNumber\":\"CT3124BB\",\"VinNumber\":\"XLRTE47MS1G146169\",\"TankCapacity\":1200,\"CargoCapacity\":28295,\"CategoryType\":1,\"MakeType\":0},{\"Id\":50,\"RegistrationNumber\":\"CT3093BB\",\"VinNumber\":\"XLRTE47MS1G146691\",\"TankCapacity\":1290,\"CargoCapacity\":28307,\"CategoryType\":3,\"MakeType\":2},{\"Id\":51,\"RegistrationNumber\":\"CT2440BH\",\"VinNumber\":\"WMA13XZZ7FM681526\",\"TankCapacity\":960,\"CargoCapacity\":28416,\"CategoryType\":1,\"MakeType\":4},{\"Id\":52,\"RegistrationNumber\":\"CT8985BP\",\"VinNumber\":\"WMA13XZZ6GM685875\",\"TankCapacity\":960,\"CargoCapacity\":28431,\"CategoryType\":2,\"MakeType\":3},{\"Id\":53,\"RegistrationNumber\":\"CT8984BP\",\"VinNumber\":\"WMA13XZZ1GM685919\",\"TankCapacity\":960,\"CargoCapacity\":28441,\"CategoryType\":0,\"MakeType\":0},{\"Id\":54,\"RegistrationNumber\":\"CT4850CC\",\"VinNumber\":\"WMA13XZZ3GM685722\",\"TankCapacity\":960,\"CargoCapacity\":28441,\"CategoryType\":1,\"MakeType\":2},{\"Id\":55,\"RegistrationNumber\":\"CT7548TK\",\"VinNumber\":\"WMA13XZZ3GM685848\",\"TankCapacity\":960,\"CargoCapacity\":28451,\"CategoryType\":2,\"MakeType\":4},{\"Id\":56,\"RegistrationNumber\":\"CT8991BP\",\"VinNumber\":\"WMA13XZZ1GM685761\",\"TankCapacity\":960,\"CargoCapacity\":28441,\"CategoryType\":3,\"MakeType\":0},{\"Id\":57,\"RegistrationNumber\":\"CT2411BX\",\"VinNumber\":\"WMA13XZZ5GM689559\",\"TankCapacity\":960,\"CargoCapacity\":28431,\"CategoryType\":0,\"MakeType\":4},{\"Id\":58,\"RegistrationNumber\":\"CT0102MP\",\"VinNumber\":\"WMA13XZZ3GM689544\",\"TankCapacity\":960,\"CargoCapacity\":28441,\"CategoryType\":3,\"MakeType\":3},{\"Id\":59,\"RegistrationNumber\":\"CT4983HT\",\"VinNumber\":\"WMA13XZZ4GM689536\",\"TankCapacity\":960,\"CargoCapacity\":28446,\"CategoryType\":1,\"MakeType\":0},{\"Id\":60,\"RegistrationNumber\":\"CT7122KM\",\"VinNumber\":\"WMA13XZZ4GM689441\",\"TankCapacity\":960,\"CargoCapacity\":28441,\"CategoryType\":3,\"MakeType\":4},{\"Id\":61,\"RegistrationNumber\":\"CT2462BX\",\"VinNumber\":\"WMA13XZZ2GM689437\",\"TankCapacity\":960,\"CargoCapacity\":28441,\"CategoryType\":1,\"MakeType\":3},{\"Id\":62,\"RegistrationNumber\":\"CT2699CK\",\"VinNumber\":\"XLEG4X21115261281\",\"TankCapacity\":1235,\"CargoCapacity\":28921,\"CategoryType\":2,\"MakeType\":0},{\"Id\":63,\"RegistrationNumber\":\"CT5203MM\",\"VinNumber\":\"WDB96341311261291\",\"TankCapacity\":1420,\"CargoCapacity\":28058,\"CategoryType\":3,\"MakeType\":2},{\"Id\":64,\"RegistrationNumber\":\"CT5205MM\",\"VinNumber\":\"WDB96341311261296\",\"TankCapacity\":1420,\"CargoCapacity\":28058,\"CategoryType\":2,\"MakeType\":3},{\"Id\":65,\"RegistrationNumber\":\"CT4968PM\",\"VinNumber\":\"W1T96341311427813\",\"TankCapacity\":1420,\"CargoCapacity\":9196,\"CategoryType\":2,\"MakeType\":1}]}";
        var datasets = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<JObject>>>(datasetsJson);

        foreach (var dataset in datasets)
        {
            var entityType = GetType(dataset.Key);
            var entities = dataset.Value
                .Select(j => j.ToObject(entityType))
                .ToArray();

            context.AddRange(entities);
        }

        context.SaveChanges();
    }

    private static Type GetType(string modelName)
    {
        var modelType = CurrentAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == modelName);

        Assert.IsNotNull(modelType, $"{modelName} model not found!");

        return modelType;
    }

    private static IServiceProvider ConfigureServices<TContext>(string databaseName)
        where TContext : DbContext
    {
        var services = ConfigureDbContext<TContext>(databaseName);

        var context = services.GetService<TContext>();

        try
        {
            context.Model.GetEntityTypes();
        }
        catch (InvalidOperationException ex) when (ex.Source == "Microsoft.EntityFrameworkCore.Proxies")
        {
            services = ConfigureDbContext<TContext>(databaseName, useLazyLoading: true);
        }

        return services;
    }

    private static IServiceProvider ConfigureDbContext<TContext>(string databaseName, bool useLazyLoading = false)
        where TContext : DbContext
    {
        var services = new ServiceCollection()
           .AddDbContext<TContext>(t => t
           .UseInMemoryDatabase(Guid.NewGuid().ToString())
           );

        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}