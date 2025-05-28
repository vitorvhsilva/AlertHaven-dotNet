using Events.Domain.Entities;
using Events.Domain.Entities.Enums;

namespace Events.Application.Interfaces
{
    public interface IIotService
    {
        IotEntity ObterIotPorId(string Id); 
        IEnumerable<IotEntity> ObterTodosOsIots(); 
        IotEntity PersistirIot(IotEntity IotEntity); 
        IotEntity AtualizarIot(IotEntity IotEntity, string id); 
        void DeletarIot(IotEntity IotEntity);
    }
}
