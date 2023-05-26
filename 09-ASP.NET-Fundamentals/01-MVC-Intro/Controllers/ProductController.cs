namespace _01_MVC_Intro.Controllers
{
    using _01_MVC_Intro.Models.Product;
    using Microsoft.AspNetCore.Mvc;

    using static _01_MVC_Intro.Seeding.ProductsData;

    public class ProductController : Controller
    {
        public IActionResult All()
        {
            return View(Products);
        }

        public IActionResult ById(Guid id)
        {
            ProductViewModel? product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            return View(product);
        }
    }

    
}
