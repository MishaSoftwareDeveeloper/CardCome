using Microsoft.Extensions.Configuration;
using System.IO;


namespace DAL.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration() { 
            var configBuilder = new ConfigurationBuilder();
            var parrent = Directory.GetParent(Directory.GetCurrentDirectory());
            var path = Path.Combine($"{parrent.FullName}\\WebApi", "appsettings.json");
            configBuilder.AddJsonFile(path,false);
            var root = configBuilder.Build();
            var appsettings = root.GetSection("ConnectionStrings:localDB");
            sqlConnectionString = appsettings.Value;
        }
        public string sqlConnectionString { get; set; }
    }

}
