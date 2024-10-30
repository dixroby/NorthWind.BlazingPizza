namespace NothWind.BlazingPizza.GetSpecials.BusinnesObjects.Interfaces
{
    public interface IGetSpecialsCache
    {
        Task SetSpecialAsync(IEnumerable<PizzaSpecialDto> pizzas);
        Task<IEnumerable<PizzaSpecialDto>> GetPizzaSpecialsAsync();
    }
}