using Microsoft.Extensions.Logging;
using NothWind.BlazingPizza.GetSpecials.Entities.Dtos;
using NothWind.BlazingPizza.GetSpecials.Entities.ValueObjectes;
using System.Net.Http.Json;

namespace NorthWind.BlazingPizza.Proxies;
public class GetSpeacialsProxy(HttpClient client, ILogger logger)
{
    public async Task<IEnumerable<PizzaSpecialDto>> GetPizzaSpecialsAsync()
    {
        IEnumerable<PizzaSpecialDto> specials = null;
		try
		{
			var response = await client.GetAsync(EndPoint.GetSpecial);
			var responseText = await response.Content.ReadAsStringAsync();

			logger.LogInformation("HTTP Status Code: {code}", response.StatusCode);
			logger.LogInformation("HTTP Response Content: {content}", responseText);

			if (response.IsSuccessStatusCode)
			{
				specials = await response.Content.ReadFromJsonAsync<IEnumerable<PizzaSpecialDto>>();
			}
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Error during GetPizzaSpecialsAsync");
		}
		return specials ?? new List<PizzaSpecialDto>();
    }
}