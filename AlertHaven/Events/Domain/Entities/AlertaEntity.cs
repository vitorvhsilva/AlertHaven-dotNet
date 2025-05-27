using Events.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Domain.Entities
{
    [Table("TB_ALERTA")]
    public class AlertaEntity
    {
        [Key]
        [Column(TypeName = "VARCHAR2(255)")]
        public string IdAlerta { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public NivelAlerta NivelAlerta { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public string MensagemAlerta { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public DateTime DataHoraAlerta { get; set; }

        public virtual EventoEntity Evento { get; set; }
    }
}
