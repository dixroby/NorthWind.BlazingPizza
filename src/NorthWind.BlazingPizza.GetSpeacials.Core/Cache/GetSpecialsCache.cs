using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace NorthWind.BlazingPizza.GetSpeacials.Core.Cache
{
    internal class GetSpecialsCache(IDistributedCache cache,
                                    ILogger<GetSpecialsCache> logger) : IGetSpecialsCache
    {
        const string CacheKey = "pizzaSpecials";
        public async Task<IEnumerable<PizzaSpecialDto>> GetPizzaSpecialsAsync()
        {
            IEnumerable<PizzaSpecialDto> specials = null;
            try
            {
                string specialJson = await cache.GetStringAsync(CacheKey);
                if (specialJson != null)
                {
                    specials = JsonSerializer.Deserialize<IEnumerable<PizzaSpecialDto>>(specialJson);
                    logger.LogInformation("Get specials from cache");
                }
            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message);
            }
            return specials;
        }

        public async Task SetSpecialAsync(IEnumerable<PizzaSpecialDto> pizzas)
        {
            try
            {
                string specialJson = JsonSerializer.Serialize(pizzas);
                await cache.SetStringAsync(CacheKey, specialJson);
                logger.LogInformation("Set specials from cache");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}