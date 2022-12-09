using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository repository;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero("Petkan", 2);
        repository = new HeroRepository();
    }

    [Test]
    public void Hero_ConstructorShouldInitializeProperly()
    {
        string heroName = "Ivan";
        int heroLevel = 2;

        Hero heroToTest = new Hero(heroName, heroLevel);

        Assert.AreEqual(heroName,heroToTest.Name);
        Assert.AreEqual(heroLevel,heroToTest.Level);
    }

    [Test]
    public void Repository_CannotCreateNonExistingHero()
    {
        Hero nullHero = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Create(nullHero);
        });
    }

    [Test]
    public void Repository_CannotCreateAlreadyCreatedHero()
    {
        repository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            repository.Create(hero);
        });
    }

    [Test]
    public void Repository_CreateShouldAddHeroInTheRepository()
    {
        repository.Create(hero);

        var heroTakenFromRepository = repository.GetHero(hero.Name);

        Assert.AreSame(hero,heroTakenFromRepository);
    }

    [Test]
    public void Repository_CreateShouldReturnProperString()
    {
        string expectedString = $"Successfully added hero {hero.Name} with level {hero.Level}";

        Assert.AreEqual(expectedString,repository.Create(hero));

    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("           ")]
    public void Repository_CannotRemoveNullNamedHero(string name)
    {
        repository.Create(hero);

        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Remove(name);
        });
    }

    [Test]
    public void Repository_RemoveShouldReturnTrueIfHeroIsRemoved()
    {
        repository.Create(hero);

        Assert.IsTrue(repository.Remove("Petkan"));
    }

    [TestCase("Ivan")]
    [TestCase("Dragan")]
    [TestCase("Oleg")]
    public void Repository_RemoveShouldReturnFalseIfHeroDoesntExist(string name)
    {
        repository.Create(hero);

        Assert.IsFalse(repository.Remove(name));
    }

    [Test]
    public void Repository_GetHeroWithHighestLevelShouldReturnHighestLevelHero()
    {
        Hero hero2 = new Hero("Ivan", 3);
        Hero highestHero = new Hero("Dragan", 102);

        repository.Create(hero);
        repository.Create(hero2);
        repository.Create(highestHero);

        var actualHero = repository.GetHeroWithHighestLevel();

        Assert.AreEqual(highestHero,actualHero);
    }

    [Test]
    public void Repository_GetHeroShouldReturnHeroWithTheGivenName()
    {
        repository.Create(hero);

        Assert.AreEqual(hero,repository.GetHero("Petkan"));
    }

    [Test]
    public void Repository_CollectionIsReadOnly()
    {
        Assert.True(repository.Heroes is IReadOnlyCollection<Hero>);
    }
}