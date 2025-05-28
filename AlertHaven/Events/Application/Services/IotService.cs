using Events.Application.Interfaces;
using Events.Domain.Entities;
using Events.Domain.Interface;
using Events.Domain.Entities.Enums;

namespace Events.Application.Services
{
    public class IotService : IIotService
    {

        private readonly IIotRepository _repository;

        public IotService(IIotRepository repository)
        {
            _repository = repository;
        }

        public IotEntity AtualizarIot(IotEntity IotEntity, string id)
        {
            return _repository.AtualizarIot(IotEntity, id);
        }

        public IotEntity DeletarIot(string id)
        {
            return _repository.DeletarIot(id);
        }

        public IotEntity ObterIotPorId(string Id)
        {
            return _repository.ObterIotPorId(Id);
        }

        public IEnumerable<IotEntity> ObterTodosOsIots()
        {
            return _repository.ObterTodosOsIots();
        }

        public IotEntity PersistirIot(IotEntity IotEntity)
        {

            string IdIot = null;
            do
            {
                IdIot = Guid.NewGuid().ToString();
            } while (_repository.ExisteIotPorId(IdIot));

            IotEntity entity = new IotEntity
            {
                IdIot = IdIot,
                StatusIot = StatusIot.ATIVO,
                TipoIot = IotEntity.TipoIot,
                UnidadeMedidaIot = IotEntity.UnidadeMedidaIot
            };

            return _repository.PersistirIot(entity);
        }
    }
}
