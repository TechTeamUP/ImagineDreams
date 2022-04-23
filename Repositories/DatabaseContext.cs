using Microsoft.EntityFrameworkCore;
using ImagineDreams.Models;
using ImagineDreams.Mapping;
using ImagineDreams.Services;


namespace ImagineDreams.Repositories
{
    public class DatabaseConentext : DbContext
    {
        public DatabaseConentext(DbContextOptions<DatabaseConentext> options) : base(options)
        {  }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ProductEntity> Products { set; get; }  

        public DbSet<Category> Category { set; get; }

    }
}
