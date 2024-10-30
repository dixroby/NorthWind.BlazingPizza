namespace NorthWind.BlazingPizza.GetSpeacials.Repositories.Entities
{
    public class PizzaSpecial
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Description { get; set; }
        public float BasePrice { get; set; }
        public string ImageUrl { get; set; }
    }
}