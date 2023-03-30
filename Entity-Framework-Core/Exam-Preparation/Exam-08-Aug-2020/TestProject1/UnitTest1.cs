//Resharper disable InconsistentNaming, CheckNamespace

using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using VaporStore;
using VaporStore.Data;

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
            cfg.AddProfile<VaporStoreProfile>();
        });

        this.serviceProvider = ConfigureServices<VaporStoreDbContext>("VaporStore");
    }

    [Test]
    public void ImportUsersZeroTest()
    {
        var context = this.serviceProvider.GetService<VaporStoreDbContext>();

        var inputJson =
            @"[{'FullName':'','Username':'invalid','Email':'invalid@invalid.com','Age':20,'Cards':[{'Number':'1111 1111 1111 1111','CVC':'111','Type':'Debit'}]},{'FullName':'Invalid Invalidman','Username':'','Email':'invalid@invalid.com','Age':20,'Cards':[{'Number':'1111 1111 1111 1111','CVC':'111','Type':'Debit'}]},{'FullName':'Invalid Invalidman','Username':'invalid','Email':'','Age':20,'Cards':[{'Number':'1111 1111 1111 1111','CVC':'111','Type':'Debit'}]},{'FullName':'Invalid Invalidman','Username':'invalid','Email':'invalid@invalid.com','Age':2,'Cards':[{'Number':'1111 1111 1111 1111','CVC':'111','Type':'Debit'}]},{'FullName':'Invalid Invalidman','Username':'invalid','Email':'invalid@invalid.com','Age':104,'Cards':[{'Number':'1111 1111 1111 1111','CVC':'111','Type':'Debit'}]},{'FullName':'Lorrie Silbert','Username':'lsilbert','Email':'lsilbert@yahoo.com','Age':33,'Cards':[{'Number':'1833 5024 0553 6211','CVC':'903','Type':'Debit'},{'Number':'5625 0434 5999 6254','CVC':'570','Type':'Credit'},{'Number':'4902 6975 5076 5316','CVC':'091','Type':'Debit'}]},{'FullName':'Anita Ruthven','Username':'aruthven','Email':'aruthven@gmail.com','Age':75,'Cards':[{'Number':'5208 8381 5687 8508','CVC':'624','Type':'Debit'}]}]";

        var actualOutput =
            VaporStore.DataProcessor.Deserializer.ImportUsers(context, inputJson).TrimEnd();
        var expectedOutput =
            "Invalid Data\r\nInvalid Data\r\nInvalid Data\r\nInvalid Data\r\nInvalid Data\r\nImported lsilbert with 3 cards\r\nImported aruthven with 1 cards";

        var assertContext = this.serviceProvider.GetService<VaporStoreDbContext>();

        const int expectedUserCount = 2;
        var actualUserCount = assertContext.Users.Count();

        Assert.That(actualUserCount, Is.EqualTo(expectedUserCount),
            $"Inserted {nameof(context.Users)} count is incorrect!");

        const int expectedCardCount = 4;
        var actualCardCount = assertContext.Cards.Count();

        Assert.That(actualCardCount, Is.EqualTo(expectedCardCount),
            $"Inserted {nameof(context.Cards)} count is incorrect!");

        Assert.That(actualOutput, Is.EqualTo(expectedOutput).NoClip,
            $"{nameof(VaporStore.DataProcessor.Deserializer.ImportGames)} output is incorrect!");
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
        var services = new ServiceCollection();

        services
            .AddDbContext<TContext>(
                options => options
                    .UseInMemoryDatabase(databaseName)
                    .UseLazyLoadingProxies(useLazyLoading)
            );

        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}