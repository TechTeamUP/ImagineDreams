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
        Task<ProductEntity> createProduct(CreateProduct product);
        Task<IActionResult> listProduct();
        Task<ProductEntity> updateProduct(ProductModel product);
        Task<bool> deleteProduct(int id);
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


        public async Task<ProductEntity> createProduct(CreateProduct product)
        {
            ProductEntity entity = new ProductEntity()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                UserId = product.UserId
            };

            EntityEntry<ProductEntity> response = await _databaseConentext.Products.AddAsync(entity);
            await _databaseConentext.SaveChangesAsync();
            return await getProduct(response.Entity.Id ?? throw new Exception("The Product user does not exist."));
        }


        public async Task<IActionResult> listProduct()
        {
            var response = _databaseConentext.Products.Select(x => x.ToModel()).ToList();
            return new ObjectResult(response);
        }


        public async Task<ProductEntity> updateProduct(ProductModel product)
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
            entity.UserId = product.UserId;

            _databaseConentext.Update(entity);
            await _databaseConentext.SaveChangesAsync();
            return entity;
        }


        public async Task<bool> deleteProduct(int id)
        {
            ProductEntity product = await getProduct(id);

            if(product == null)
            {
                return false;
            }

            _databaseConentext.Remove(product);
            await _databaseConentext.SaveChangesAsync();
            return true;
        }
    }
}