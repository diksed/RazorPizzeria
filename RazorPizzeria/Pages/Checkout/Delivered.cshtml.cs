using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class DeliveredModel : CheckoutModel
    {
        private readonly ApplicationDbContext _context;
        public DeliveredModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(PizzaName))
            {
                PizzaName = "Custom";
            }
            if (string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }
            PastOrder pastOrder = new PastOrder();
            pastOrder.Id = Id;
            pastOrder.PizzaName = PizzaName;
            pastOrder.BasePrice = PizzaPrice;
            pastOrder.Contents = Contents;
            _context.PastOrders.Add(pastOrder);
            _context.SaveChanges();

            PizzaOrder pizzaOrder = new PizzaOrder();
            pizzaOrder.Id = Id;
            pizzaOrder.PizzaName = PizzaName;
            pizzaOrder.BasePrice = PizzaPrice;
            pizzaOrder.Contents = Contents;
            _context.PizzaOrders.Remove(pizzaOrder);
            _context.SaveChanges();
        }
    }
}
