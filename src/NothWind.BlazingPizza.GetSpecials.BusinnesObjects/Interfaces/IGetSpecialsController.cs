using NothWind.BlazingPizza.GetSpecials.Entities.Dtos;

namespace NothWind.BlazingPizza.GetSpecials.BusinnesObjects.Interfaces
{
    public interface IGetSpecialsController
    {
        Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync();
    }
}