using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class ThankYouModel : CheckoutModel
    {
        private readonly ApplicationDbContext _context;
        public ThankYouModel(ApplicationDbContext context)
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
            PizzaOrder pizzaOrder = new PizzaOrder();
            pizzaOrder.PizzaName = PizzaName;
            pizzaOrder.BasePrice = PizzaPrice;
            pizzaOrder.Contents = Contents;
            _context.PizzaOrders.Add(pizzaOrder);
            _context.SaveChanges();
        }
    }
}
