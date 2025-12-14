namespace Villa.Web.ViewModels
{
    public class CreateVillaVM
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Sqft { get; set; }
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; }



    }
}
