namespace NorthWind.BlazingPizza.GetSpeacials.Core.Controller
{
    internal class GetSpecialsController(IGetSpecialInputPort inputPort,
                                        IGetSpecialsOutputPort presenter) : IGetSpecialsController
    {
        public async Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync()
        {
            await inputPort.GetSpecialAsync();
            return presenter.PizzaSpecials;
        }
    }
}

