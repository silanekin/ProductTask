namespace ProductTask.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double PopularityScore { get; set; }
        public double Weight { get; set; }
        public Images images { get; set; }

        public double Price { get; set; }

    }
}
