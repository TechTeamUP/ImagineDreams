using ImagineDreams.Repositories;
using ImagineDreams.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ImagineDreams.Services
{
    public interface ISalesServices
    {
        Task<SalesEntity> getSales(int id);
        Task<SalesEntity> createSales(CreateSale sales);
    
    }

    public class SalesServices : ISalesServices
    {
        private readonly DatabaseConentext _databaseConentext;
        public SalesServices(DatabaseConentext databaseConentext)
        {
            _databaseConentext = databaseConentext;
        }

        public async Task<SalesEntity> getSales(int id)
        {
            var sales = await _databaseConentext.Sales.FirstOrDefaultAsync(x => x.Id == id);
            return sales ?? throw new Exception("The sale does not exist.");
        }

        public async Task<SalesEntity> createSales(CreateSale sales)
        {
            SalesEntity entity = new SalesEntity()
            {
                Quantity = sales.Quantity,
                Total = sales.Total,
                UserId = sales.UserIdBuyer,
                ProductId = sales.ProductId

            };

            EntityEntry<SalesEntity> response = await _databaseConentext.Sales.AddAsync(entity);
            await _databaseConentext.SaveChangesAsync();
            return await getSales(response.Entity.Id ?? throw new Exception("the sale could not be registered."));
        }
       
    }
}