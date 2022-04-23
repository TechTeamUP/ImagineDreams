using ImagineDreams.Mapping;
using ImagineDreams.Repositories;
using ImagineDreams.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ImagineDreams.Services
{
    public interface IProductServices
    {
        Task<ProductEntity> getProduct(int id);
        Task<ProductEntity> createProduct(Product product);
        Task<IActionResult> listProduct();
        Task<Product> updateProduct(Product product);
    }

    public class ProductServices : IProductServices
    {
        private readonly DatabaseConentext _databaseConentext;
        public ProductServices(DatabaseConentext databaseConentext)
        {
            _databaseConentext = databaseConentext;
        }


        public async Task<ProductEntity> getProduct(int id)
        {
            var product = await _databaseConentext.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product ?? throw new Exception("The Product user does not exist.");
        }


        public async Task<ProductEntity> createProduct(Product product)
        {
            ProductEntity entity = new ProductEntity()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };

            EntityEntry<ProductEntity> response = await _databaseConentext.Products.AddAsync(entity);
            await _databaseConentext.SaveChangesAsync();
            return await getProduct(response.Entity.Id);
        }


        public async Task<IActionResult> listProduct()
        {
            var response = _databaseConentext.Products.Select(x => x.ToModel()).ToList();
            return new ObjectResult(response);
        }


        public async Task<Product> updateProduct(Product product)
        {
            var entity = await getProduct(product.Id);

            if (entity == null)
            {
                return null;
            }

            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.Price = product.Price;
            entity.Stock = product.Stock;
            entity.CategoryId = product.CategoryId;

            _databaseConentext.Update(entity);
            return entity.ToModel();
        }
    }
}