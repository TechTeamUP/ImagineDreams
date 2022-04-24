using Microsoft.EntityFrameworkCore;
using ImagineDreams.Models;



namespace ImagineDreams.Repositories
{
    public class DatabaseConentext : DbContext
    {
        public DatabaseConentext(DbContextOptions<DatabaseConentext> options) : base(options)
        {  }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ProductEntity> Products { set; get; }  

        public DbSet<CategoryEntity> Category { set; get; }

    }
}
