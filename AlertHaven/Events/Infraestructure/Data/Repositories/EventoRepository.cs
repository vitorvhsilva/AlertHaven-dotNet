using Events.Domain.Entities;
using Events.Domain.Interface;
using Events.Infraestructure.Data.AppData;

namespace Events.Infraestructure.Data.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationContext _context;

        public EventoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public EventoEntity AtualizarEvento(EventoEntity EventoEntity, string id)
        {
            throw new NotImplementedException();
        }

        public EventoEntity DeletarEvento(string id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteEventoPorId(string Id)
        {
            throw new NotImplementedException();
        }

        public EventoEntity ObterEventoPorId(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventoEntity> ObterTodosOsEventos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventoEntity> ObterTodosOsEventosPorIot(string IdIot)
        {
            throw new NotImplementedException();
        }

        public EventoEntity PersistirEvento(EventoEntity EventoEntity)
        {
            throw new NotImplementedException();
        }
    }
}
