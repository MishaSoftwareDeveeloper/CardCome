using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DataBaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }

            public DbContextOptionsBuilder<DataBaseContext> opsBuilder { get; set; }
            public DbContextOptions<DataBaseContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }

        }
        public static OptionsBuild ops = new OptionsBuild();
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
