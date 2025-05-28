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

        public IotEntity AtualizarIot(IotEntity IotEntity)
        {
            throw new NotImplementedException();
        }

        public void DeletarIot(IotEntity IotEntity)
        {
            throw new NotImplementedException();
        }

        public IotEntity ObterIotPorId(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IotEntity> ObterTodosOsIots()
        {
            throw new NotImplementedException();
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
