using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_crud_mvc.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=Pizza; Integrated Security=True; TrustServerCertificate=True");
        }
    }
}
