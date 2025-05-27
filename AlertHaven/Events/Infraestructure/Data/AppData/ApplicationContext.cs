using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infraestructure.Data.AppData
{
    public class ApplicationContext: DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


        public DbSet<IotEntity> IotEntities { get; set; }
        public DbSet<EventoEntity> EventoEntities { get; set; }
        public DbSet<AlertaEntity> AlertaEntities { get; set; }
    }
}
