using Events.Domain.Entities.Enums;

namespace Events.Domain.Entities
{
    public class EventoEntity
    {
        public string IdEvento { get; set; } 
        public TipoEvento TipoEvento { get; set; } 
        public IntensidadeEvento IntensidadeEvento { get; set; } 
        public string LatitudeEvento{ get; set; } 
        public string LongitudeEvento{ get; set; } 
        public DateTime DataHoraEvento{ get; set; }  
    }
}
