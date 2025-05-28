using Events.Domain.Entities;

namespace Events.Domain.Interface
{
    public interface IEventoRepository
    {
        EventoEntity ObterEventoPorId(string Id);
        IEnumerable<EventoEntity> ObterTodosOsEventos();
        IEnumerable<EventoEntity> ObterTodosOsEventosPorIot(string IdIot);
        EventoEntity PersistirEvento(EventoEntity EventoEntity);
        EventoEntity AtualizarEvento(EventoEntity EventoEntity, string id);
        EventoEntity DeletarEvento(string id);
        bool ExisteEventoPorId(string Id);
    }
}
