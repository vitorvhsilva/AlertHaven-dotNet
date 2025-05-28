using Events.Domain.Entities;
using Events.Domain.Interface;
using Events.Infraestructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

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
            var entity = ObterEventoPorId(id);

            entity.IntensidadeEvento = EventoEntity.IntensidadeEvento;
            entity.TipoEvento = EventoEntity.TipoEvento;

            _context.SaveChanges();

            return entity;
        }

        public EventoEntity DeletarEvento(string id)
        {
            var entity = _context.EventoEntities.FirstOrDefault(e => e.IdEvento == id);

            if (entity is null)
            {
                return null;
            }

            _context.EventoEntities.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool ExisteEventoPorId(string Id)
        {
            try
            {
                return _context.EventoEntities.Where(e => e.IdEvento == Id).Any();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public EventoEntity ObterEventoPorId(string Id)
        {
            return _context.EventoEntities
                .Include(e => e.Iot)
                .FirstOrDefault(e => e.IdEvento == Id);
        }

        public IEnumerable<EventoEntity> ObterTodosOsEventos()
        {
            return _context.EventoEntities.ToList();
        }

        public IEnumerable<EventoEntity> ObterTodosOsEventosPorIot(string IdIot)
        {
            return _context.EventoEntities.Where(e => e.IdIot == IdIot);
        }

        public EventoEntity PersistirEvento(EventoEntity EventoEntity)
        {
            _context.EventoEntities.Add(EventoEntity);
            _context.SaveChanges();

            return ObterEventoPorId(EventoEntity.IdEvento);
        }
    }
}
