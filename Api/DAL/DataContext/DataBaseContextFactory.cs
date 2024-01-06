using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace DAL.DataContext
{
    public class DataBaseContextFactory:IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            opsBuilder.UseSqlServer(appConfiguration.sqlConnectionString);
            return new DataBaseContext(opsBuilder.Options);
        }
    }
}
