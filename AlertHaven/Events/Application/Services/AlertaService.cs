using Events.Application.Interfaces;
using Events.Domain.Entities;
using Events.Domain.Interface;

namespace Events.Application.Services
{
    public class AlertaService : IAlertaService
    {
        private readonly IAlertaRepository _repository;

        public AlertaService(IAlertaRepository repository)
        {
            _repository = repository;
        }

        public AlertaEntity AtualizarAlerta(AlertaEntity AlertaEntity, string id)
        {
            return _repository.AtualizarAlerta(AlertaEntity, id);
        }

        public AlertaEntity DeletarAlerta(string id)
        {
            return _repository.DeletarAlerta(id);
        }

        public AlertaEntity ObterAlertaPorId(string Id)
        {
            return _repository.ObterAlertaPorId(Id);
        }

        public IEnumerable<AlertaEntity> ObterTodosOsAlertas()
        {
            return _repository.ObterTodosOsAlertas();
        }

        public IEnumerable<AlertaEntity> ObterTodosOsAlertasPorEvento(string IdEvento)
        {
            return _repository.ObterTodosOsAlertasPorEvento(IdEvento);
        }

        public AlertaEntity PersistirAlerta(AlertaEntity AlertaEntity)
        {

            string IdAlerta = null;
            do
            {
                IdAlerta = Guid.NewGuid().ToString();
            } while (_repository.ExisteAlertaPorId(IdAlerta));

            AlertaEntity.IdAlerta = IdAlerta;

            var entity = _repository.PersistirAlerta(AlertaEntity);

            return entity;
        }
    }
}
