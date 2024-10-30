using Microsoft.Extensions.Options;
using NorthWind.BlazingPizza.GetSpeacials.Core.Presenter;
using NothWind.BlazingPizza.GetSpecials.BusinnesObjects.Options;
using NothWind.BlazingPizza.GetSpecials.Entities.Dtos;

namespace NorthWind.BlazingPizza.GetSpecials.Core.Tests.Presenters
{
    public class GetSpecialsPresenterTests
    {
        [Fact]
        public async Task HandlerResultAsync_Should_Set_PizzaSpecials()
        {
            // Arrange
            IOptions<GetSpecialsOptions> getSpecialOptions =
                Options
                .Create<GetSpecialsOptions>(
                    new GetSpecialsOptions()
                    {
                        ImageUrlBase = "https://test"
                    }
                );

            var presenter = new GetSpecialPresenter(getSpecialOptions);

            var speacials = new List<PizzaSpecialDto>
            {
                new PizzaSpecialDto(1, "s1", 30, "d1", "i1"),
                new PizzaSpecialDto(2, "s2", 30, "d2", "i2"),
                new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
            };

            // Act
            await presenter.HandleResultAsync(speacials);

            // Assert 
            Assert.Equal(speacials.Count, presenter.PizzaSpecials.Count());

            for (int i = 0; i < speacials.Count; i++)
            {
                var ExpectedImageUrl =
                    $"{getSpecialOptions.Value.ImageUrlBase}/{speacials[i].ImageUrl}";

                Assert.Equal(ExpectedImageUrl, presenter.PizzaSpecials.ElementAt(i).ImageUrl);
            }

        }
    }
}
