using Microsof.EntityFrameworkCore;

namespace Veterinaria.App.Persistencia;
{
    public class    AppContext : DbContext
    {
        public DbSet<Persona> Personas {get;set;}
        public DbSet<Veterinario> Veterinarios {get; set;}        
        public DbSet<DuenioMascota> DueniosMascotas {get; set;}
        
    }
    protected override void OnConfiguring(DbContextOptionBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
       {
           
        optionsBuilder
        .UseSqlServer("Data Source = (localdo)\\MSSQLLocalDB; Initial Catalog =Veterinaria App")
       }
    }
}