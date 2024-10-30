namespace NorthWind.BlazingPizza.GetSpeacials.Repositories
{
    public class GetSpeacialsRepository(GetSpecialsContext context) : IGetSpecialsRepository
    {
        public async Task<IEnumerable<PizzaSpecialDto>> GetSpecialsSortedDesendingPriceAsync()
        =>  await context
            .PizzaSpecial
            .OrderByDescending(S => S.BasePrice)
            .Select(x => new PizzaSpecialDto(
                    x.Id,
                    x.Name,
                    x.BasePrice,
                    x.Description,
                    x.ImageUrl))
            .ToListAsync();
    }
}