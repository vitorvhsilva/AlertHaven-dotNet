using Events.Domain.Entities.Enums;

namespace Events.Domain.Entities
{
    public class AlertaEntity
    {
        public string IdAlerta { get; set; }
        public NivelAlerta NivelAlerta { get; set; }
        public string MensagemAlerta { get; set; }
        public DateTime DataHoraAlerta { get; set; }
    }
}
