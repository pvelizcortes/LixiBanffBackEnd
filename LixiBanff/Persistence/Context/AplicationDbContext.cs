using LixiBanff.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LixiBanff.Persistence.Context
{
    public class AplicationDbContext:DbContext
    {
        #region Add Here Tables/Class
        // Add Here the Table's
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Pila> Pila { get; set; }
        public DbSet<Pano> Pano { get; set; }
        public DbSet<TipoNodo> TipoNodo { get; set; }
        public DbSet<Nodo> Nodo { get; set; }
        public DbSet<Sensor> Sensor { get; set; }
        // End 
        #endregion

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
