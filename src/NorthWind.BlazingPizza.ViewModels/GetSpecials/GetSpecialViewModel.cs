using NorthWind.BlazingPizza.Proxies;
using NothWind.BlazingPizza.GetSpecials.Entities.Dtos;

namespace NorthWind.BlazingPizza.ViewModels.GetSpecials;

public class GetSpecialViewModel(GetSpeacialsProxy proxy)
{
    public IEnumerable<PizzaSpecialDto> Specials { get; private set; }

    public async Task GetSpecialsAsync() => Specials = await proxy.GetPizzaSpecialsAsync();
}
