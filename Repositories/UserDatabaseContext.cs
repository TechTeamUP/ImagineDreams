using Microsoft.EntityFrameworkCore;
using ImagineDreams.Models;
using ImagineDreams.Mapping;
using ImagineDreams.Services;


namespace ImagineDreams.Repositories
{
    public class UserDatabaseContext : DbContext
    {
        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : base(options)
        {  }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ProductEntity> Products { set; get; }  

        public DbSet<Category> Category { set; get; }

    }
}
