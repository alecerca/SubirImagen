using Microsoft.EntityFrameworkCore;
using SubirImagenAPI.Models;

namespace SubirImagenAPI
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Imagen> Imagenes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }


    }
}
