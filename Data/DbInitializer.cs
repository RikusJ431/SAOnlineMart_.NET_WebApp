using SAOnlineMart.Models;

namespace SAOnlineMart.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
            new Product{Name="Necklace",Description="Beautiful handcrafted necklace.",Price=50.00M,Stock=20, ImageUrl="necklace.jpg"},
            new Product{Name="Wallet",Description="Durable leather wallet.",Price=80.00M,Stock=15, ImageUrl="wallet.jpg"},
            new Product{Name="T-Shirt",Description="100% organic cotton t-shirt.",Price=25.00M,Stock=50, ImageUrl="tshirt.jpg"}
            };

            foreach (var p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
