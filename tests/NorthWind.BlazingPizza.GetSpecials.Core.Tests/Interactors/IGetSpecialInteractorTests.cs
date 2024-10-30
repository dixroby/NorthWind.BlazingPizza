using NorthWind.BlazingPizza.GetSpeacials.Core.Interactors;

namespace NorthWind.BlazingPizza.GetSpecials.Core.Tests.Interactors;
public class IGetSpecialInteractorTests
{
    [Fact]
    public async Task GetSpecialAsync__ShouldInvokerdHandleResultAsync__WithPizzaSpecials()
    {
        // Arrange
        var Reportory = Substitute.For<IGetSpecialsRepository>();
        var Presenter = Substitute.For<IGetSpecialsOutputPort>();
        var cache = Substitute.For<IGetSpecialsCache>();


        var Iteractor = new GetSpecialsInteractor(Reportory, Presenter, cache);

        var ExpectedSpeacials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(1, "s1", 30, "d1", "i1"),
            new PizzaSpecialDto(2, "s2", 30, "d2", "i2"),
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
        };

        cache.GetPizzaSpecialsAsync().Returns(ExpectedSpeacials);

        Reportory.GetSpecialsSortedDesendingPriceAsync().Returns(ExpectedSpeacials);

        // Act

        await Iteractor.GetSpecialAsync();

        // Assert
        await Presenter
            .Received(1)
            .HandleResultAsync(Arg.Is<IEnumerable<PizzaSpecialDto>>(specials => specials == ExpectedSpeacials));

    }
    [Fact]
    async Task GetSpecialAsync__Should_GetFromCache_When_CacheHasData()
    {
        // Arrange
        var Reportory = Substitute.For<IGetSpecialsRepository>();
        var Presenter = Substitute.For<IGetSpecialsOutputPort>();
        var cache = Substitute.For<IGetSpecialsCache>();


        var Iteractor = new GetSpecialsInteractor(Reportory, Presenter, cache);

        var ExpectedSpeacials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(1, "s1", 30, "d1", "i1"),
            new PizzaSpecialDto(2, "s2", 30, "d2", "i2"),
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
        };

        cache.GetPizzaSpecialsAsync().Returns((IEnumerable<PizzaSpecialDto>)null);
        Reportory.GetSpecialsSortedDesendingPriceAsync().Returns(ExpectedSpeacials);

        var interactor = new GetSpecialsInteractor(Reportory, Presenter, cache);

        // Act

        await Iteractor.GetSpecialAsync();

        // Assert
        await cache.Received(1).GetPizzaSpecialsAsync();
        await Reportory.Received(1).GetSpecialsSortedDesendingPriceAsync();
        await cache.SetSpecialAsync(ExpectedSpeacials);
    }

    //[Fact]
    //async Task GetSpecialAsync__Should_GetFromRepository_When_CacheHasData()
    //{

    //}
}