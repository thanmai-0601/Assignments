using ProductsAPI.Models;
using ProductsAPI.DTOs;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>
        {
            new Product{ Id = 1, Name = "Television", Price = 50000},
            new Product{ Id = 2, Name = "Washing Machine", Price = 40000}
        };

        // GET ALL
        public List<ProductReadDTO> GetAll()
        {
            return products.Select(p => new ProductReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = (decimal)p.Price
            }).ToList();
        }

        // GET BY ID
        public ProductReadDTO? GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;

            return new ProductReadDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = (decimal)product.Price
            };
        }

        //POST
        public ProductReadDTO Create(ProductCreateDTO dto)
        {
            var newProduct = new Product
            {
                Id = products.Max(p => p.Id) + 1,
                Name = dto.Name,
                Price = dto.Price
            };

            products.Add(newProduct);

            return new ProductReadDTO
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = (decimal)newProduct.Price
            };
        }

        // PUT: Full Update
        public bool UpdatePut(int id, ProductUpdateDTO dto)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Price = dto.Price;

            return true;
        }

        // PATCH: Partial Update
        public bool UpdatePatch(int id, ProductUpdateDTO dto)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            if (dto.Name != null)
                product.Name = dto.Name;

            if (dto.Price != 0)
                product.Price = dto.Price;

            return true;
        }

        // DELETE
        public bool Delete(ProductDeleteDTO dto)
        {
            var product = products.FirstOrDefault(p => p.Id == dto.Id);
            if (product == null) return false;

            products.Remove(product);
            return true;
        }
    }
}
