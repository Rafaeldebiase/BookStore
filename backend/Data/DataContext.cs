using bookstore.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace bookstore.data
{
    public partial class DataContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=bookstore;User Id=SA;Password=Bookstore2020!;"
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}