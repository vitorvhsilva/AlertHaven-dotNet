using Events.Domain.Entities;

namespace Events.Domain.Interface
{
    public interface IIotRepository
    {
        IotEntity ObterIotPorId(string Id);
        IEnumerable<IotEntity> ObterTodosOsIots();
        IotEntity PersistirIot(IotEntity IotEntity);
        IotEntity AtualizarIot(IotEntity IotEntity, string id);
        IotEntity DeletarIot(string id);
        bool ExisteIotPorId(string Id);
    }
}
