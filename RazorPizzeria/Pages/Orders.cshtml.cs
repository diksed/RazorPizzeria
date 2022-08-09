using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages
{
    [Authorize(Policy = "MustBelongToHRDepartment")]    
    [BindProperties(SupportsGet = true)]
    public class OrdersModel : PageModel
    {
        public int Id { get; set; }
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
        public void OnGetOrder()
        {
            PizzaOrder pizzaOrder = new PizzaOrder();
            pizzaOrder.Id = Id;
            pizzaOrder.PizzaName = PizzaName;
            pizzaOrder.BasePrice = PizzaPrice;
            pizzaOrder.Contents = Contents;
            _context.PizzaOrders.Remove(pizzaOrder);
            _context.SaveChanges();
            PastOrder pastOrder = new PastOrder();
            pastOrder.Id = Id;
            pastOrder.PizzaName = PizzaName;
            pastOrder.BasePrice = PizzaPrice;
            pastOrder.Contents = Contents;
            _context.PastOrders.Add(pastOrder);
            _context.SaveChanges();
            pizzaOrders = _context.PizzaOrders.ToList();
            pastOrders = _context.PastOrders.ToList();
        }
    }
}
