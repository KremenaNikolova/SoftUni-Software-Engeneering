namespace _01_MVC_Intro.Controllers
{
    using _01_MVC_Intro.Models.Product;
    using Microsoft.AspNetCore.Mvc;
    using System.IO.Pipes;
    using System.Text;
    using System.Text.Json;
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
        public IActionResult AllAsJson()
        {
            return Json(Products, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }

        public IActionResult AllAsText()
        {
            StringBuilder sb = new StringBuilder();

            int counter = 0;
            foreach (var product in Products)
            {
                counter++;
                sb.AppendLine($"Product {counter}: {product.Name} - {product.Price} lv.");
            }

            return Content(sb.ToString());
        }
    }

    
}
