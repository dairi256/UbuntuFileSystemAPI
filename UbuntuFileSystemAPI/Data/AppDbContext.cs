using Microsoft.EntityFrameworkCore;
using UbuntuFileSystemAPI.Models;

namespace UbuntuFileSystemAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<FileRecord> Files => Set<FileRecord>();

    }
}
