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
            throw new NotImplementedException();
        }

        public AlertaEntity DeletarAlerta(string id)
        {
            throw new NotImplementedException();
        }

        public AlertaEntity ObterAlertaPorId(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AlertaEntity> ObterTodosOsAlertas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AlertaEntity> ObterTodosOsAlertasPorEvento(string IdEvento)
        {
            throw new NotImplementedException();
        }

        public AlertaEntity PersistirAlerta(AlertaEntity AlertaEntity)
        {
            throw new NotImplementedException();
        }
    }
}
