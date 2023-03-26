//Resharper disable InconsistentNaming, CheckNamespace

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Footballers;
using Footballers.Data;
using Footballers.DataProcessor;

[TestFixture]
public class Export_000_001
{
    private IServiceProvider serviceProvider;
    private static Assembly CurrentAssembly;

    [SetUp]
    public void Setup()
    {
        CurrentAssembly = typeof(StartUp).Assembly;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<FootballersProfile>();
        });

        this.serviceProvider = ConfigureServices<FootballersContext>("Footballers");
    }

    [Test]
    public void ExportTeamsWithMostFootballersZeroTest()
    {
        var context = serviceProvider.GetService<FootballersContext>();

        SeedDatabase(context);
        DateTime dateTime = DateTime.ParseExact("31/03/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        var actualOutputValue = Serializer.ExportTeamsWithMostFootballers(context, dateTime);
        var actualOutput = JToken.Parse(actualOutputValue);

        var expectedOutputValue =
            "[{\"Name\":\"Manchester City F.C.\",\"Footballers\":[{\"FootballerName\":\"Phil Foden\",\"ContractStartDate\":\"12/30/2021\",\"ContractEndDate\":\"04/13/2025\",\"BestSkillType\":\"Dribble\",\"PositionType\":\"Midfielder\"},{\"FootballerName\":\"Ederson\",\"ContractStartDate\":\"06/14/2021\",\"ContractEndDate\":\"09/26/2024\",\"BestSkillType\":\"Defence\",\"PositionType\":\"Goalkeeper\"},{\"FootballerName\":\"Ilkay Gundogan\",\"ContractStartDate\":\"06/20/2020\",\"ContractEndDate\":\"07/29/2024\",\"BestSkillType\":\"Pass\",\"PositionType\":\"Midfielder\"},{\"FootballerName\":\"Kevin De Bruyne\",\"ContractStartDate\":\"09/29/2020\",\"ContractEndDate\":\"04/21/2024\",\"BestSkillType\":\"Pass\",\"PositionType\":\"Midfielder\"},{\"FootballerName\":\"Bernardo Silva\",\"ContractStartDate\":\"06/20/2020\",\"ContractEndDate\":\"12/07/2022\",\"BestSkillType\":\"Pass\",\"PositionType\":\"Midfielder\"}]},{\"Name\":\"Liverpool F.C.\",\"Footballers\":[{\"FootballerName\":\"Alisson\",\"ContractStartDate\":\"01/01/2022\",\"ContractEndDate\":\"08/28/2026\",\"BestSkillType\":\"Defence\",\"PositionType\":\"Goalkeeper\"},{\"FootballerName\":\"Sadio Mane\",\"ContractStartDate\":\"06/08/2020\",\"ContractEndDate\":\"02/02/2025\",\"BestSkillType\":\"Shoot\",\"PositionType\":\"Forward\"},{\"FootballerName\":\"Andrew Robertson\",\"ContractStartDate\":\"06/13/2021\",\"ContractEndDate\":\"11/30/2023\",\"BestSkillType\":\"Pass\",\"PositionType\":\"Defender\"}]},{\"Name\":\"Tottenham Hotspur F.C.\",\"Footballers\":[{\"FootballerName\":\"Harry Kane\",\"ContractStartDate\":\"12/29/2021\",\"ContractEndDate\":\"02/06/2026\",\"BestSkillType\":\"Shoot\",\"PositionType\":\"Forward\"},{\"FootballerName\":\"Hugo Lloris\",\"ContractStartDate\":\"06/10/2020\",\"ContractEndDate\":\"07/19/2024\",\"BestSkillType\":\"Defence\",\"PositionType\":\"Goalkeeper\"},{\"FootballerName\":\"Son Heung-Min\",\"ContractStartDate\":\"06/18/2020\",\"ContractEndDate\":\"01/09/2024\",\"BestSkillType\":\"Speed\",\"PositionType\":\"Forward\"}]},{\"Name\":\"Juventus F.C.\",\"Footballers\":[{\"FootballerName\":\"Dusan Vlahovic\",\"ContractStartDate\":\"07/25/2020\",\"ContractEndDate\":\"06/29/2025\",\"BestSkillType\":\"Shoot\",\"PositionType\":\"Forward\"},{\"FootballerName\":\"Wojiech Szczesny\",\"ContractStartDate\":\"07/28/2020\",\"ContractEndDate\":\"01/14/2023\",\"BestSkillType\":\"Defence\",\"PositionType\":\"Goalkeeper\"}]},{\"Name\":\"Olympique Lyonnais\",\"Footballers\":[{\"FootballerName\":\"Romain Faivre\",\"ContractStartDate\":\"01/01/2022\",\"ContractEndDate\":\"12/06/2026\",\"BestSkillType\":\"Dribble\",\"PositionType\":\"Midfielder\"},{\"FootballerName\":\"Moussa Dembele\",\"ContractStartDate\":\"06/14/2021\",\"ContractEndDate\":\"12/01/2023\",\"BestSkillType\":\"Shoot\",\"PositionType\":\"Forward\"}]}]";
        var expectedOutput = JToken.Parse(expectedOutputValue);

        var expected = expectedOutput.ToString(Formatting.None);
        var actual = actualOutput.ToString(Formatting.None);
        ;
        Assert.That(actual, Is.EqualTo(expected).NoClip,
            $"{nameof(Serializer.ExportTeamsWithMostFootballers)} output is incorrect!");
    }

    private static void SeedDatabase(FootballersContext context)
    {
        var datasetsJson = "{\"Coach\":[{\"Id\":1,\"Name\":\"Bruno Genesio\",\"Nationality\":\"France\"},{\"Id\":2,\"Name\":\"Philippe Clement\",\"Nationality\":\"Belgium\"},{\"Id\":3,\"Name\":\"Peter Bosz\",\"Nationality\":\"The Netherlands\"},{\"Id\":4,\"Name\":\"Pep Guardiola\",\"Nationality\":\"Spain\"},{\"Id\":5,\"Name\":\"Olivier DallOglio\",\"Nationality\":\"France\"},{\"Id\":6,\"Name\":\"Mauricio Pochettino\",\"Nationality\":\"Argentina\"},{\"Id\":7,\"Name\":\"Massimiliano Allegri\",\"Nationality\":\"Chile\"},{\"Id\":8,\"Name\":\"Luciano Spalletti\",\"Nationality\":\"Italy\"},{\"Id\":9,\"Name\":\"Jurgen Klopp\",\"Nationality\":\"Germany\"},{\"Id\":10,\"Name\":\"Jose Mourinho\",\"Nationality\":\"Portugal\"},{\"Id\":11,\"Name\":\"Jose Luis Mendilibar\",\"Nationality\":\"Spain\"},{\"Id\":12,\"Name\":\"Ivan Juric\",\"Nationality\":\"Croatia\"},{\"Id\":13,\"Name\":\"Gerardo Seoane\",\"Nationality\":\"Spain\"},{\"Id\":14,\"Name\":\"Gerald Baticle\",\"Nationality\":\"France\"},{\"Id\":15,\"Name\":\"Edin Terzic\",\"Nationality\":\"Germany\"},{\"Id\":16,\"Name\":\"Eddie Howe\",\"Nationality\":\"The United Kingdom\"},{\"Id\":17,\"Name\":\"Diego Simeone\",\"Nationality\":\"Spain\"},{\"Id\":18,\"Name\":\"Christian Streich\",\"Nationality\":\"Germany\"},{\"Id\":19,\"Name\":\"Carlo Ancelotti\",\"Nationality\":\"Italy\"},{\"Id\":20,\"Name\":\"Antonio Conte\",\"Nationality\":\"Italy\"},{\"Id\":21,\"Name\":\"Thomas Frank\",\"Nationality\":\"Denmark\"},{\"Id\":22,\"Name\":\"Thomas Tuchel\",\"Nationality\":\"Germany\"}],\"Footballer\":[{\"Id\":1,\"Name\":\"Benjamin Bourigeaud\",\"ContractStartDate\":\"2020-03-22T00:00:00\",\"ContractEndDate\":\"2025-02-24T00:00:00\",\"BestSkillType\":2,\"PositionType\":2},{\"Id\":2,\"Name\":\"Wojiech Szczesny\",\"ContractStartDate\":\"2020-07-28T00:00:00\",\"ContractEndDate\":\"2023-01-14T00:00:00\",\"BestSkillType\":0,\"PositionType\":0},{\"Id\":3,\"Name\":\"Lionel Messi\",\"ContractStartDate\":\"2020-03-21T00:00:00\",\"ContractEndDate\":\"2023-07-04T00:00:00\",\"BestSkillType\":1,\"PositionType\":1},{\"Id\":4,\"Name\":\"Neymar\",\"ContractStartDate\":\"2021-06-10T00:00:00\",\"ContractEndDate\":\"2026-02-04T00:00:00\",\"BestSkillType\":1,\"PositionType\":3},{\"Id\":5,\"Name\":\"Marco Verratti\",\"ContractStartDate\":\"2020-03-25T00:00:00\",\"ContractEndDate\":\"2022-09-11T00:00:00\",\"BestSkillType\":1,\"PositionType\":2},{\"Id\":6,\"Name\":\"Keylor Navas\",\"ContractStartDate\":\"2021-07-08T00:00:00\",\"ContractEndDate\":\"2025-01-28T00:00:00\",\"BestSkillType\":0,\"PositionType\":0},{\"Id\":7,\"Name\":\"Teji Savanier\",\"ContractStartDate\":\"2020-06-07T00:00:00\",\"ContractEndDate\":\"2025-05-12T00:00:00\",\"BestSkillType\":2,\"PositionType\":2},{\"Id\":8,\"Name\":\"Kevin De Bruyne\",\"ContractStartDate\":\"2020-09-29T00:00:00\",\"ContractEndDate\":\"2024-04-21T00:00:00\",\"BestSkillType\":2,\"PositionType\":2},{\"Id\":9,\"Name\":\"Phil Foden\",\"ContractStartDate\":\"2021-12-30T00:00:00\",\"ContractEndDate\":\"2025-04-13T00:00:00\",\"BestSkillType\":1,\"PositionType\":2},{\"Id\":10,\"Name\":\"Bernardo Silva\",\"ContractStartDate\":\"2020-06-20T00:00:00\",\"ContractEndDate\":\"2022-12-07T00:00:00\",\"BestSkillType\":2,\"PositionType\":2},{\"Id\":11,\"Name\":\"Ilkay Gundogan\",\"ContractStartDate\":\"2020-06-20T00:00:00\",\"ContractEndDate\":\"2024-07-29T00:00:00\",\"BestSkillType\":2,\"PositionType\":2},{\"Id\":12,\"Name\":\"Ederson\",\"ContractStartDate\":\"2021-06-14T00:00:00\",\"ContractEndDate\":\"2024-09-26T00:00:00\",\"BestSkillType\":0,\"PositionType\":0},{\"Id\":13,\"Name\":\"Lucas Paqueta\",\"ContractStartDate\":\"2020-03-24T00:00:00\",\"ContractEndDate\":\"2023-10-15T00:00:00\",\"BestSkillType\":1,\"PositionType\":3},{\"Id\":14,\"Name\":\"Moussa Dembele\",\"ContractStartDate\":\"2021-06-14T00:00:00\",\"ContractEndDate\":\"2023-12-01T00:00:00\",\"BestSkillType\":3,\"PositionType\":3},{\"Id\":15,\"Name\":\"Romain Faivre\",\"ContractStartDate\":\"2022-01-01T00:00:00\",\"ContractEndDate\":\"2026-12-06T00:00:00\",\"BestSkillType\":1,\"PositionType\":2},{\"Id\":16,\"Name\":\"Aurelien Tchouameni\",\"ContractStartDate\":\"2020-03-23T00:00:00\",\"ContractEndDate\":\"2024-11-17T00:00:00\",\"BestSkillType\":2,\"PositionType\":2},{\"Id\":17,\"Name\":\"Dusan Vlahovic\",\"ContractStartDate\":\"2020-07-25T00:00:00\",\"ContractEndDate\":\"2025-06-29T00:00:00\",\"BestSkillType\":3,\"PositionType\":3},{\"Id\":18,\"Name\":\"Alisson\",\"ContractStartDate\":\"2022-01-01T00:00:00\",\"ContractEndDate\":\"2026-08-28T00:00:00\",\"BestSkillType\":0,\"PositionType\":0},{\"Id\":19,\"Name\":\"Andrew Robertson\",\"ContractStartDate\":\"2021-06-13T00:00:00\",\"ContractEndDate\":\"2023-11-30T00:00:00\",\"BestSkillType\":2,\"PositionType\":1},{\"Id\":20,\"Name\":\"Sadio Mane\",\"ContractStartDate\":\"2020-06-08T00:00:00\",\"ContractEndDate\":\"2025-02-02T00:00:00\",\"BestSkillType\":3,\"PositionType\":3},{\"Id\":21,\"Name\":\"Martin Terrier\",\"ContractStartDate\":\"2021-12-29T00:00:00\",\"ContractEndDate\":\"2024-06-16T00:00:00\",\"BestSkillType\":2,\"PositionType\":3},{\"Id\":22,\"Name\":\"Son Heung-Min\",\"ContractStartDate\":\"2020-06-18T00:00:00\",\"ContractEndDate\":\"2024-01-09T00:00:00\",\"BestSkillType\":4,\"PositionType\":3},{\"Id\":23,\"Name\":\"Harry Kane\",\"ContractStartDate\":\"2021-12-29T00:00:00\",\"ContractEndDate\":\"2026-02-06T00:00:00\",\"BestSkillType\":3,\"PositionType\":3},{\"Id\":24,\"Name\":\"Hugo Lloris\",\"ContractStartDate\":\"2020-06-10T00:00:00\",\"ContractEndDate\":\"2024-07-19T00:00:00\",\"BestSkillType\":0,\"PositionType\":0},{\"Id\":25,\"Name\":\"Karim Benzema\",\"ContractStartDate\":\"2020-06-17T00:00:00\",\"ContractEndDate\":\"2025-05-22T00:00:00\",\"BestSkillType\":3,\"PositionType\":3},{\"Id\":26,\"Name\":\"Thibaut Courtois\",\"ContractStartDate\":\"2020-10-03T00:00:00\",\"ContractEndDate\":\"2025-09-09T00:00:00\",\"BestSkillType\":0,\"PositionType\":0},{\"Id\":27,\"Name\":\"Nico Schlotterbeck\",\"ContractStartDate\":\"2020-07-25T00:00:00\",\"ContractEndDate\":\"2025-03-21T00:00:00\",\"BestSkillType\":0,\"PositionType\":1},{\"Id\":28,\"Name\":\"Ivan Toney\",\"ContractStartDate\":\"2020-03-24T00:00:00\",\"ContractEndDate\":\"2024-05-02T00:00:00\",\"BestSkillType\":3,\"PositionType\":3},{\"Id\":29,\"Name\":\"Jan Oblak\",\"ContractStartDate\":\"2020-06-09T00:00:00\",\"ContractEndDate\":\"2025-02-03T00:00:00\",\"BestSkillType\":0,\"PositionType\":0},{\"Id\":30,\"Name\":\"Erling Haland\",\"ContractStartDate\":\"2020-07-24T00:00:00\",\"ContractEndDate\":\"2025-06-28T00:00:00\",\"BestSkillType\":3,\"PositionType\":3},{\"Id\":31,\"Name\":\"Marco Reus\",\"ContractStartDate\":\"2020-06-08T00:00:00\",\"ContractEndDate\":\"2025-05-13T00:00:00\",\"BestSkillType\":2,\"PositionType\":2},{\"Id\":32,\"Name\":\"Sofiane Boufal\",\"ContractStartDate\":\"2021-06-13T00:00:00\",\"ContractEndDate\":\"2025-07-22T00:00:00\",\"BestSkillType\":2,\"PositionType\":2},{\"Id\":33,\"Name\":\"Patrik Schick\",\"ContractStartDate\":\"2020-06-06T00:00:00\",\"ContractEndDate\":\"2022-11-23T00:00:00\",\"BestSkillType\":3,\"PositionType\":3},{\"Id\":34,\"Name\":\"Bremer\",\"ContractStartDate\":\"2020-07-27T00:00:00\",\"ContractEndDate\":\"2024-09-04T00:00:00\",\"BestSkillType\":0,\"PositionType\":1},{\"Id\":35,\"Name\":\"Joselu\",\"ContractStartDate\":\"2021-12-31T00:00:00\",\"ContractEndDate\":\"2025-04-14T00:00:00\",\"BestSkillType\":3,\"PositionType\":3},{\"Id\":36,\"Name\":\"Lorenzo Pellegrini\",\"ContractStartDate\":\"2021-12-30T00:00:00\",\"ContractEndDate\":\"2024-06-17T00:00:00\",\"BestSkillType\":2,\"PositionType\":2},{\"Id\":37,\"Name\":\"Bruno Guimaraes\",\"ContractStartDate\":\"2020-06-21T00:00:00\",\"ContractEndDate\":\"2024-07-30T00:00:00\",\"BestSkillType\":1,\"PositionType\":2},{\"Id\":38,\"Name\":\"Reece James\",\"ContractStartDate\":\"2020-07-26T00:00:00\",\"ContractEndDate\":\"2025-03-22T00:00:00\",\"BestSkillType\":4,\"PositionType\":1}],\"Team\":[{\"Id\": 1,\"Name\": \"Real Madrid CF Spain\",\"Nationality\": \"Spain\",\"Trophies\": 93},{\"Id\": 2,\"Name\": \"Liverpool F.C.\",\"Nationality\": \"The United Kingdom\",\"Trophies\": 69},{\"Id\": 3,\"Name\": \"Manchester City F.C.\",\"Nationality\": \"The United Kingdom\",\"Trophies\": 36},{\"Id\": 4,\"Name\": \"Tottenham Hotspur F.C.\",\"Nationality\": \"The United Kingdom\",\"Trophies\": 26},{\"Id\": 5,\"Name\": \"Angers SCO\",\"Nationality\": \"France\",\"Trophies\": 1},{\"Id\": 6,\"Name\": \"AS Monaco\",\"Nationality\": \"France\",\"Trophies\": 16},{\"Id\": 7,\"Name\": \"Montpellier Herault SC\",\"Nationality\": \"France\",\"Trophies\": 3},{\"Id\": 8,\"Name\": \"Olympique de Marseille\",\"Nationality\": \"France\",\"Trophies\": 25},{\"Id\": 9,\"Name\": \"Olympique Lyonnais\",\"Nationality\": \"France\",\"Trophies\": 20},{\"Id\": 10,\"Name\": \"Paris Saint-Germain F.C.\",\"Nationality\": \"France\",\"Trophies\": 44},{\"Id\": 11,\"Name\": \"RC Lens\",\"Nationality\": \"France\",\"Trophies\": 2},{\"Id\": 12,\"Name\": \"Stade Rennais F.C.\",\"Nationality\": \"France\",\"Trophies\": 3},{\"Id\": 13,\"Name\": \"Bayer 04 Leverkusen\",\"Nationality\": \"Germany\",\"Trophies\": 3},{\"Id\": 14,\"Name\": \"FC Bayern Munich\",\"Nationality\": \"Germany\",\"Trophies\": 3},{\"Id\": 15,\"Name\": \"RB Leipzig\",\"Nationality\": \"Germany\",\"Trophies\": 4},{\"Id\": 16,\"Name\": \"SC Freiburg\",\"Nationality\": \"Germany\",\"Trophies\": 6},{\"Id\": 17,\"Name\": \"A.C. Milan\",\"Nationality\": \"Italy\",\"Trophies\": 52},{\"Id\": 18,\"Name\": \"A.S. Roma\",\"Nationality\": \"Italy\",\"Trophies\": 17},{\"Id\": 19,\"Name\": \"Juventus F.C.\",\"Nationality\": \"Italy\",\"Trophies\": 70},{\"Id\": 20,\"Name\": \"Torino F.C.\",\"Nationality\": \"Italy\",\"Trophies\": 16},{\"Id\": 21,\"Name\": \"Atletico de Madrid\",\"Nationality\": \"Spain\",\"Trophies\": 32},{\"Id\": 22,\"Name\": \"Deportivo Alaves\",\"Nationality\": \"Spain\",\"Trophies\": 4},{\"Id\": 23,\"Name\": \"Chelsea F.C.\",\"Nationality\": \"The United Kingdom\",\"Trophies\": 34},{\"Id\": 24,\"Name\": \"Brentford F.C.\",\"Nationality\": \"The United Kingdom\",\"Trophies\": 5}],\"TeamFootballer\":[{\"Id\": 1,\"TeamId\": 12,\"FootballerId\": 1},{\"Id\": 2,\"TeamId\": 19,\"FootballerId\": 2},{\"Id\": 3,\"TeamId\": 10,\"FootballerId\": 3},{\"Id\": 4,\"TeamId\": 10,\"FootballerId\": 4},{\"Id\": 5,\"TeamId\": 10,\"FootballerId\": 5},{\"Id\": 6,\"TeamId\": 10,\"FootballerId\": 6},{\"Id\": 7,\"TeamId\": 7,\"FootballerId\": 7},{\"Id\": 8,\"TeamId\": 3,\"FootballerId\": 8},{\"Id\": 9,\"TeamId\": 3,\"FootballerId\": 9},{\"Id\": 10,\"TeamId\": 3,\"FootballerId\": 10},{\"Id\": 11,\"TeamId\": 3,\"FootballerId\": 11},{\"Id\": 12,\"TeamId\": 3,\"FootballerId\": 12},{\"Id\": 13,\"TeamId\": 9,\"FootballerId\": 13},{\"Id\": 14,\"TeamId\": 9,\"FootballerId\": 14},{\"Id\": 15,\"TeamId\": 9,\"FootballerId\": 15},{\"Id\": 16,\"TeamId\": 6,\"FootballerId\": 16},{\"Id\": 17,\"TeamId\": 19,\"FootballerId\": 17},{\"Id\": 18,\"TeamId\": 2,\"FootballerId\": 18},{\"Id\": 19,\"TeamId\": 2,\"FootballerId\": 19},{\"Id\": 20,\"TeamId\": 2,\"FootballerId\": 20},{\"Id\": 21,\"TeamId\": 12,\"FootballerId\": 21},{\"Id\": 22,\"TeamId\": 4,\"FootballerId\": 22},{\"Id\": 23,\"TeamId\": 4,\"FootballerId\": 23},{\"Id\": 24,\"TeamId\": 4,\"FootballerId\": 24},{\"Id\": 25,\"TeamId\": 1,\"FootballerId\": 25},{\"Id\": 26,\"TeamId\": 1,\"FootballerId\": 26},{\"Id\": 27,\"TeamId\": 16,\"FootballerId\": 27},{\"Id\": 28,\"TeamId\": 24,\"FootballerId\": 28},{\"Id\": 29,\"TeamId\": 21,\"FootballerId\": 29},{\"Id\": 30,\"TeamId\": 5,\"FootballerId\": 32},{\"Id\": 31,\"TeamId\": 13,\"FootballerId\": 33},{\"Id\": 32,\"TeamId\": 20,\"FootballerId\": 34},{\"Id\": 33,\"TeamId\": 22,\"FootballerId\": 35},{\"Id\": 34,\"TeamId\": 18,\"FootballerId\": 36},{\"Id\": 35,\"TeamId\": 23,\"FootballerId\": 38}]}";
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