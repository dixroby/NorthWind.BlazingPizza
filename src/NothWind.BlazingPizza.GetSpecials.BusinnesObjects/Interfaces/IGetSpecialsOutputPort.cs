using NothWind.BlazingPizza.GetSpecials.Entities.Dtos;

namespace NothWind.BlazingPizza.GetSpecials.BusinnesObjects.Interfaces
{
    public interface IGetSpecialsOutputPort
    {
        IEnumerable<PizzaSpecialDto> PizzaSpecials { get; }

        Task HandleResultAsync(IEnumerable<PizzaSpecialDto> PizzaSpecials);

    }
}