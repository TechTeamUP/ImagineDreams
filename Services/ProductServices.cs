using ImagineDreams.Repositories;
using ImagineDreams.Models;
using ImagineDreams.Request;
using ImagineDreams.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ImagineDreams.Services
{
    public interface IProductServices
    {
        Task<ProductEntity> getProduct(int id);
        Task<ProductCreateResponse> createProduct(ProductCreateRequest product);
        Task<IActionResult> listProduct();
        Task<ProductEntity> updateProduct(ProductModel product);
        Task<bool> deleteProduct(int id);
    }

    public class ProductServices : IProductServices
    {
        private readonly DatabaseConentext _databaseConentext;
        private readonly IUserServices _userServices;
        public ProductServices(DatabaseConentext databaseConentext, IUserServices userServices)
        {
            _databaseConentext = databaseConentext;
            _userServices = userServices;
        }


        public async Task<ProductEntity> getProduct(int id)
        {
            var product = await _databaseConentext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product == null)
            {
                return product ?? throw new Exception("The provided product does not exist.");
            }
            return new ProductEntity()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Img = product.Img,
                Price = product.Price,
                Stock = product.Stock,
                UserId = product.UserId,
                CategoryId = product.CategoryId
            };
        }


        public async Task<ProductCreateResponse> createProduct(ProductCreateRequest product)
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
            return new ProductCreateResponse()
            {
                Code = 201,
                Create = true,
                Message = "Product created successfully!",
                Error = new List<string>()
            };
        }


        public async Task<IActionResult> listProduct()
        {
            var response = _databaseConentext.Products.Select(x => x).ToList();
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
            entity.Update_Date = DateTime.Now;

            _databaseConentext.Update(entity);
            await _databaseConentext.SaveChangesAsync();
            return entity;
        }


        public async Task<bool> deleteProduct(int id)
        {
            ProductEntity product = await getProduct(id);

            if (product == null)
            {
                return false;
            }

            _databaseConentext.Remove(product);
            await _databaseConentext.SaveChangesAsync();
            return true;
        }
    }
}