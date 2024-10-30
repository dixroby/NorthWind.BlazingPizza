namespace NothWind.BlazingPizza.GetSpecials.Entities.Dtos
{
    public class PizzaSpecialDto(int id,
                                 string name,
                                 float basePrice,
                                 string description,
                                 string imageUrl)
    {
        // se hace asi por que esta clase la estamos definiendo de solo lectura, solo se contruye mediante el contructor
        public int Id => id;
        public string Name => name;
        public float BasePrice => basePrice;
        public string Description => description;
        public string ImageUrl => imageUrl;
    }
}
