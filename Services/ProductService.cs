using AppMvc.Net.Models;

namespace AppMvc.Net.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]
            {
                new ProductModel() {Id = 1, Name = "iPhone X", Price = 1000},
                new ProductModel() {Id = 2, Name = "iPhone 11", Price = 2000},
                new ProductModel() {Id = 3, Name = "iPhone 12", Price = 3000},
                new ProductModel() {Id = 4, Name = "iPhone 13", Price = 4000},
            });
        }
    }
}
