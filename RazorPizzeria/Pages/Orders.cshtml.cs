using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages
{
    [BindProperties(SupportsGet = true)]
    public class OrdersModel : PageModel
    {
        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string Contents { get; set; }
        public List<PizzaOrder> pizzaOrders = new List<PizzaOrder>();
        public List<PastOrder> pastOrders = new List<PastOrder>();
        private readonly ApplicationDbContext _context;
        public OrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            pizzaOrders = _context.PizzaOrders.ToList();
            pastOrders = _context.PastOrders.ToList();
        }
        public void Order()
        {
            PizzaOrder pizzaOrder = new PizzaOrder();
            pizzaOrder.PizzaName = PizzaName;
            pizzaOrder.BasePrice = PizzaPrice;
            pizzaOrder.Contents = Contents;
            _context.PizzaOrders.Add(pizzaOrder);
            _context.SaveChanges();
        }
    }
}
