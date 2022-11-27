using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TeaApi.Models;

namespace TeaApi.Models
{
    public class TeaApiDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public TeaApiDbContext(DbContextOptions<TeaApiDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("Bruh");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<Tea> Tea { get; set; } = null!;
    }
}
