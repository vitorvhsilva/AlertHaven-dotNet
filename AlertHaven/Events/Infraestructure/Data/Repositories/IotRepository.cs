using Events.Domain.Entities;
using Events.Domain.Interface;
using Events.Infraestructure.Data.AppData;

namespace Events.Infraestructure.Data.Repositories
{
    public class IotRepository : IIotRepository
    {
        private readonly ApplicationContext _context;

        public IotRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IotEntity AtualizarIot(IotEntity IotEntity, string id)
        {
            var entity = ObterIotPorId(id);

            if (entity is null)
            {
                return null;
            }

            entity.TipoIot = IotEntity.TipoIot;
            entity.UnidadeMedidaIot = IotEntity.UnidadeMedidaIot;

            _context.SaveChanges();

            return entity;
        }

        public IotEntity DeletarIot(string id)
        {
            var entity = _context.IotEntities.FirstOrDefault(i => i.IdIot == id);

            if (entity is null)
            {
                return null;
            }

            _context.IotEntities.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        public IotEntity ObterIotPorId(string Id)
        {
            return _context.IotEntities.FirstOrDefault(i => i.IdIot == Id);
        }

        public IEnumerable<IotEntity> ObterTodosOsIots()
        {
            return _context.IotEntities.ToList();
        }

        public IotEntity PersistirIot(IotEntity IotEntity)
        {
            _context.IotEntities.Add(IotEntity);
            _context.SaveChanges();

            return ObterIotPorId(IotEntity.IdIot);
        }

        public bool ExisteIotPorId(string Id)
        {
            try
            {
                return _context.IotEntities.Where(i => i.IdIot == Id).Any();
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
