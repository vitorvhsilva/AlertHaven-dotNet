using Events.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Events.Domain.Entities
{
    [Table("TB_EVENTO")]
    public class EventoEntity
    {
        [Key]
        [Column(TypeName = "VARCHAR2(255)")]
        public string IdEvento { get; set; }
        [ForeignKey("Iot")]
        [Column(TypeName = "VARCHAR2(255)")]
        public string IdIot { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public TipoEvento TipoEvento { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public IntensidadeEvento IntensidadeEvento { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public string? LatitudeEvento{ get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public string? LongitudeEvento{ get; set; }
        [Column(TypeName = "TIMESTAMP")]
        public DateTime? DataHoraEvento{ get; set; }


        public virtual ICollection<AlertaEntity>? Alertas { get; set; }
        public virtual IotEntity? Iot { get; set; }
    }
}
