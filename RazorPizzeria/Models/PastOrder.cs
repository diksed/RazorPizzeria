namespace RazorPizzeria.Models
{
    public class PastOrder
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public string? Contents { get; set; }
        public float BasePrice { get; set; }
    }
}
