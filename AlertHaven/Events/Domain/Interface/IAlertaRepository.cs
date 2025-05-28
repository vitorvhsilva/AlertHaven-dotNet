using Events.Domain.Entities;

namespace Events.Domain.Interface
{
    public interface IAlertaRepository
    {
        AlertaEntity ObterAlertaPorId(string Id);
        IEnumerable<AlertaEntity> ObterTodosOsAlertas();
        IEnumerable<AlertaEntity> ObterTodosOsAlertasPorEvento(string IdEvento);
        AlertaEntity PersistirAlerta(AlertaEntity AlertaEntity);
        AlertaEntity AtualizarAlerta(AlertaEntity AlertaEntity, string id);
        AlertaEntity DeletarAlerta(string id);
        bool ExisteAlertaPorId(string Id);
    }
}
