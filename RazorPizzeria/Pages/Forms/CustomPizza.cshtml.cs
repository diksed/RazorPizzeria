using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Forms
{
    public class CustomPizzaModel : PageModel
    {
        [BindProperty]
        public PizzasModel Pizza { get; set; }
        public float PizzaPrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            string contents = "";
            PizzaPrice = Pizza.BasePrice;
            if (Pizza.TomatoSauce)
            {
                contents += " Tomato -";
                PizzaPrice += 1;
            }
            if (Pizza.Cheese)
            {
                contents += " Cheese -";
                PizzaPrice += 1;
            }
            if (Pizza.Peperoni)
            {
                contents += " Peperoni -";
                PizzaPrice += 1;
            }
            if (Pizza.Mushroom)
            {
                contents += " Mushroom -";
                PizzaPrice += 1;
            }
            if (Pizza.Tuna)
            {
                contents += " Tuna -";
                PizzaPrice += 1;
            }
            if (Pizza.Pineapple)
            {
                contents += " Pineapple -";
                PizzaPrice += 10;
            }
            if (Pizza.Ham)
            {
                contents += " Ham -";
                PizzaPrice += 1;
            }
            if (Pizza.Beef)
            {
                contents += " Beef -";
                PizzaPrice += 1;
            }
            return RedirectToPage("/Checkout/Checkout", new {Pizza.PizzaName, PizzaPrice, contents });
        }
    }
}
