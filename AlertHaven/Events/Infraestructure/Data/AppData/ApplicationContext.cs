using Events.Domain.Entities;
using Events.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Events.Infraestructure.Data.AppData
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // AlertaEntity enums
            modelBuilder.Entity<AlertaEntity>()
                .Property(a => a.NivelAlerta)
                .HasConversion(
                    v => v.ToString(),
                    v => (NivelAlerta)Enum.Parse(typeof(NivelAlerta), v))
                .HasColumnType("VARCHAR2(255)");

            // IotEntity enums
            modelBuilder.Entity<IotEntity>()
                .Property(i => i.TipoIot)
                .HasConversion(
                    v => v.ToString(),
                    v => (TipoIot)Enum.Parse(typeof(TipoIot), v))
                .HasColumnType("VARCHAR2(255)");

            modelBuilder.Entity<IotEntity>()
                .Property(i => i.UnidadeMedidaIot)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnidadeMedidaIot)Enum.Parse(typeof(UnidadeMedidaIot), v))
                .HasColumnType("VARCHAR2(255)");

            modelBuilder.Entity<IotEntity>()
                .Property(i => i.StatusIot)
                .HasConversion(
                    v => v.ToString(),
                    v => (StatusIot)Enum.Parse(typeof(StatusIot), v))
                .HasColumnType("VARCHAR2(255)");

            // EventoEntity enums
            modelBuilder.Entity<EventoEntity>()
                .Property(e => e.TipoEvento)
                .HasConversion(
                    v => v.ToString(),
                    v => (TipoEvento)Enum.Parse(typeof(TipoEvento), v))
                .HasColumnType("VARCHAR2(255)");

            modelBuilder.Entity<EventoEntity>()
                .Property(e => e.IntensidadeEvento)
                .HasConversion(
                    v => v.ToString(),
                    v => (IntensidadeEvento)Enum.Parse(typeof(IntensidadeEvento), v))
                .HasColumnType("VARCHAR2(255)");
        }


        public DbSet<IotEntity> IotEntities { get; set; }
        public DbSet<EventoEntity> EventoEntities { get; set; }
        public DbSet<AlertaEntity> AlertaEntities { get; set; }
    }
}
