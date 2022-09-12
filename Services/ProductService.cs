using ProductManager.Models;
 
namespace ProductManager.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            // product.Category = _context.Category.FirstOrDefault(p => p.Id == product.CategoryId);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var existedProduct = GetProductById(id);
            if(existedProduct == null) return;
            else
            {
                _context.Products.Remove(existedProduct);
            }
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Category.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            var updateProduct = GetProductById(product.Id);
            if(updateProduct == null) return;
            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;
            updateProduct.Quantity = product.Quantity;
            updateProduct.CategoryId = product.CategoryId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
        }

       
    }
}
