using Microsoft.EntityFrameworkCore;

namespace UploadFilesandSaveinDatabase.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
        public DbSet<Files> Files { get; set; }
    }
}
