using NothWind.BlazingPizza.GetSpecials.BusinnesObjects.Interfaces;

namespace NorthWind.BlazingPizza.GetSpeacials.Core.Interactors;
internal class GetSpecialsInteractor(IGetSpecialsRepository repository,
                                     IGetSpecialsOutputPort presenter,
                                     IGetSpecialsCache cache) : IGetSpecialInputPort
{
    public async Task GetSpecialAsync()
    {
        var result = await cache.GetPizzaSpecialsAsync();
        if (result == null)
        {
            result = await repository
                .GetSpecialsSortedDesendingPriceAsync();
            await cache.SetSpecialAsync(result);
        }
        await presenter.HandleResultAsync(result);
    }
}