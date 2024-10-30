using Microsoft.Extensions.Options;

namespace NorthWind.BlazingPizza.GetSpeacials.Core.Presenter
{
    internal class GetSpecialPresenter(IOptions<GetSpecialsOptions> options) : IGetSpecialsOutputPort
    {
        public IEnumerable<PizzaSpecialDto> PizzaSpecials { get; private set; }

        public Task HandleResultAsync(IEnumerable<PizzaSpecialDto> pizzaSpecials)
        {
            PizzaSpecials =
                pizzaSpecials
                .Select(
                    s => new PizzaSpecialDto(s.Id,
                                             s.Name,
                                             s.BasePrice,
                                             s.Description,
                                             $"{options.Value.ImageUrlBase}/{s.ImageUrl}"));
            return Task.CompletedTask;
        }
    }
}
