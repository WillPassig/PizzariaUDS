using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PizzariaUDS.Domain.Models;
using PizzariaUDS.Infra.Data.Mappings;

namespace PizzariaUDS.Infra.Data.Context
{
    public class PizzariaUDSContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public PizzariaUDSContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public DbSet<Order> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
