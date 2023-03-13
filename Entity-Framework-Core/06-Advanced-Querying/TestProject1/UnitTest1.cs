using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using BookShop;
using BookShop.Data;
using BookShop.Initializer;
using System.IO;
using BookShop.Models;
using BookShop.Models.Enums;

[TestFixture]
public class Test_014_000_001
{
    private IServiceProvider serviceProvider;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<BookShopContext>()
            .UseInMemoryDatabase(databaseName: "BookShop")
            .Options;

        var services = new ServiceCollection()
            .AddDbContext<BookShopContext>(b => b.UseInMemoryDatabase("BookShop"));

        serviceProvider = services.BuildServiceProvider();
    }

    [Test]
    public void ValidateOutput()
    {
        var service = serviceProvider.GetService<BookShopContext>();

        DbInitializer.Seed(service);

        var assertService = serviceProvider.GetService<BookShopContext>();

        string result = StartUp.GetMostRecentBooks(assertService).Trim();

        string expectedResult = "--Action\r\nBrandy of the Damned (2015)\r\nBonjour Tristesse (2013)\r\nBy Grand Central Station I Sat Down and Wept (2010)\r\n--Adventure\r\nThe Cricket on the Hearth (2013)\r\nDance Dance Dance (2002)\r\nCover Her Face (2000)\r\n--Art\r\nShall not Perish (2012)\r\nRecalled to Life (2010)\r\nPrecious Bane (2010)\r\n--Biographies\r\nDominations (2009)\r\nTime of our Darkness (2005)\r\nTo a God Unknown (2004)\r\n--Children's\r\nThe Last Temptation (2012)\r\nJesting Pilate (2011)\r\nLet Us Now Praise Famous Men (2005)\r\n--Comics\r\nThe Parliament of Man (2014)\r\nOf Human Bondage (2013)\r\nPale Kings and Princes (2012)\r\n--Cookbooks\r\nStranger in a Strange Land (2006)\r\nSuch Were the Joys (2000)\r\nA Summer Bird-Cage (2000)\r\n--Drama\r\nBeneath the Bleeding (2012)\r\nBehold the Man (2011)\r\nA Time to Kill (2006)\r\n--Fantasy\r\nWaiting for the Barbarians (2011)\r\nThe Waste Land (2010)\r\nTo Your Scattered Bodies Go (2004)\r\n--Health\r\nHow Sleep the Brave (2014)\r\nThe House of Mirth (2010)\r\nHave His Carcase (2006)\r\n--History\r\nA Monstrous Regiment of Women (2013)\r\nThe Moon by Night (2013)\r\nThe Moving Toyshop (2012)\r\n--Horror\r\nGreat Work of Time (2014)\r\nThe Glory and the Dream (2011)\r\nThe Golden Bowl (2004)\r\n--Journals\r\nSurprised by Joy (2014)\r\nThis Side of Paradise (2013)\r\nThings Fall Apart (2008)\r\n--Mystery\r\nFear and Trembling (2013)\r\nFair Stood the Wind for France (2013)\r\nFor Whom the Bell Tolls (2010)\r\n--Poetry\r\nNo Highway (2013)\r\nNo Longer at Ease (2011)\r\nNo Country for Old Men (2010)\r\n--Romance\r\nThe Doors of Perception (2013)\r\nEgo Dominus Tuus (2010)\r\nEndless Night (2009)\r\n--Science\r\nLook Homeward (2014)\r\nA Many-Splendoured Thing (2012)\r\nLook to Windward (2011)\r\n--Science Fiction\r\nAlien CornÂ (play) (2014)\r\nThe Alien CornÂ (short story) (2003)\r\nAlone on a Wide (2000)\r\n--Travel\r\nI Sing the Body Electric (2014)\r\nIn Dubious Battle (2008)\r\nIn a Dry Season (2006)";


        Assert.AreEqual(expectedResult, result, "Returned value is incorrect!");
    }
}