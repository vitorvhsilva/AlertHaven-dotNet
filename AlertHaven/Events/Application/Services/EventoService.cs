using Events.Application.Interfaces;
using Events.Domain.Entities;
using Events.Domain.Interface;

namespace Events.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _repository;

        public EventoService(IEventoRepository repository)
        {
            _repository = repository;
        }

        public EventoEntity AtualizarEvento(EventoEntity EventoEntity, string id)
        {
            throw new NotImplementedException();
        }

        public EventoEntity DeletarEvento(string id)
        {
            throw new NotImplementedException();
        }

        public EventoEntity ObterEventoPorId(string Id)
        {
            return _repository.ObterEventoPorId(Id);
        }

        public IEnumerable<EventoEntity> ObterTodosOsEventos()
        {
            return _repository.ObterTodosOsEventos();
        }

        public IEnumerable<EventoEntity> ObterTodosOsEventosPorIot(string IdIot)
        {
            return _repository.ObterTodosOsEventosPorIot(IdIot);
        }

        public EventoEntity PersistirEvento(EventoEntity EventoEntity)
        {

            string IdEvento = null;
            do
            {
                IdEvento = Guid.NewGuid().ToString();
            } while (_repository.ExisteEventoPorId(IdEvento));

            EventoEntity.IdEvento = IdEvento;

            var entity = _repository.PersistirEvento(EventoEntity);

            return entity;
        }
    }
}
