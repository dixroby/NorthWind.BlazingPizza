using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using NorthWind.BlazingPizza.GetSpeacials.Core.Cache;

namespace NorthWind.BlazingPizza.GetSpecials.Core.Tests.Cache;
public class GetSpecialsCacheTest
{
    [Fact]
    public async Task Set_SpecialsAsync_Should_Save_And_GetSpecialAsync_Should_Return_Same_Value_From_Cache()
    {
        //Arrange
        var speacials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(1, "s1", 30, "d1", "i1"),
            new PizzaSpecialDto(2, "s2", 30, "d2", "i2"),
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
        };

        var cacheOptions = Options.Create(new MemoryDistributedCacheOptions());

        // Microsoft.Extensions.Caching.Memory
        IDistributedCache cache = new MemoryDistributedCache(cacheOptions);

        ILogger<GetSpecialsCache> logger = new NullLogger<GetSpecialsCache>();

        var getSpecialsCache = new GetSpecialsCache(cache, logger);

        // Act
        await getSpecialsCache.SetSpecialAsync(speacials);
        var result = await getSpecialsCache.GetPizzaSpecialsAsync();

        // Assert

        Assert.Equal(speacials.Count, result.Count());

        var pairs = speacials
                    .Zip(result, (expected, actual) =>
                            new { expected, actual }
                        );
        Assert
            .All(pairs,
                 pair => Assert
                            .True(pair.expected.Id == pair.actual.Id
                                  && pair.expected.Name == pair.actual.Name
                                  && pair.expected.BasePrice == pair.actual.BasePrice
                                  && pair.expected.Description == pair.actual.Description
                                  && pair.expected.ImageUrl == pair.actual.ImageUrl
                                  )
            );
    }

}