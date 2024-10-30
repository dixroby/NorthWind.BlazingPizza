using NothWind.BlazingPizza.GetSpecials.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NothWind.BlazingPizza.GetSpecials.BusinnesObjects.Interfaces
{
    public interface IGetSpecialsRepository
    {
        Task<IEnumerable<PizzaSpecialDto>> GetSpecialsSortedDesendingPriceAsync();
    }
}
