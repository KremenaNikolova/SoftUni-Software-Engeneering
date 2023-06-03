using _01_MVC_Intro.Models.Product;

namespace _01_MVC_Intro.Seeding
{
    public static class ProductsData
    {
        public static IEnumerable<ProductViewModel> Products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = Guid.NewGuid(),
                Name = "Cheese",
                Price = 7.00m
            },
            new ProductViewModel()
            {
                Id = Guid.NewGuid(),
                Name = "Ham",
                Price = 5.50m
            },
            new ProductViewModel()
            {
                Id= Guid.NewGuid(),
                Name = "Bread",
                Price = 1.50m
            }
        };
    }
}
