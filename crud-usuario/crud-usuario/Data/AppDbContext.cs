using crud_usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_usuario.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
