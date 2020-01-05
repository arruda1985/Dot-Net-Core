using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        private void ConfiguraCliente(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<Paciente>(etd =>
            {
                etd.ToTable("Pacientes");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                etd.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(100);
                etd.Property(c => c.Cpf).HasColumnName("Cpf").HasMaxLength(30);
            });
        }

        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.UseIdentityColumns();
            construtorDeModelos.HasDefaultSchema("dbo");

            ConfiguraCliente(construtorDeModelos);
        }
    }
}
