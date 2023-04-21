using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    string heroName = "Legolas";
    int level = 5;

    private Hero hero;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero(heroName, level);
        heroRepository = new HeroRepository();
    }

    [Test]
    public void Test_HeroRepository_Constructor_List()
    {
        heroRepository.Create(hero);

        int expectedCount = 1;

        Assert.AreEqual(expectedCount, heroRepository.Heroes.Count);
    }

    [Test]
    public void Test_HeroRepository_Create()
    {

        string expectedString = $"Successfully added hero {hero.Name} with level {hero.Level}";

        Assert.AreEqual(expectedString, heroRepository.Create(hero));
    }

    [Test]
    public void Test_HeroRepository_Create_ShouldThrowExceptionIfHeroIsNull()
    {
        Hero hero2 = null;
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(hero2);
        });
    }

    [Test]
    public void Test_HeroRepository_Create_ShouldThrowExceptionIfHeroAlreadyExist()
    {
        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void Test_HeroRepository_Remove()
    {
        heroRepository.Create(hero);

        Assert.IsTrue(heroRepository.Remove(hero.Name));
    }

    [TestCase("")]
    [TestCase("      ")]
    [TestCase(null)]
    public void Test_HeroRepository_Remove_ShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(name);
        });
    }

    [Test]
    public void Test_HeroRepository_GetHeroWithHighestLevel()
    {
        Hero expecredHero = new Hero("Aradia", 100);
        heroRepository.Create(hero);
        heroRepository.Create(expecredHero);

        Assert.AreEqual(expecredHero, heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void Test_HeroRepository_GetHero()
    {
        heroRepository.Create(hero);

        Assert.AreEqual(hero, heroRepository.GetHero(heroName));
    }
}