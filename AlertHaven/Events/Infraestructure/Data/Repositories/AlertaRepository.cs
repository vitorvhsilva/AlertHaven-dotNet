using Events.Domain.Entities;
using Events.Domain.Interface;
using Events.Infraestructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace Events.Infraestructure.Data.Repositories
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly ApplicationContext _context;

        public AlertaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public AlertaEntity AtualizarAlerta(AlertaEntity AlertaEntity, string id)
        {
            var entity = ObterAlertaPorId(id);

            entity.NivelAlerta = AlertaEntity.NivelAlerta;
            entity.MensagemAlerta = AlertaEntity.MensagemAlerta;

            _context.SaveChanges();

            return entity;
        }

        public AlertaEntity DeletarAlerta(string id)
        {
            var entity = _context.AlertaEntities.FirstOrDefault(a => a.IdAlerta == id);

            if (entity is null)
            {
                return null;
            }

            _context.AlertaEntities.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool ExisteAlertaPorId(string Id)
        {
            try
            {
                return _context.AlertaEntities.Where(a => a.IdAlerta == Id).Any();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public AlertaEntity ObterAlertaPorId(string Id)
        {
            return _context.AlertaEntities
                .Include(a => a.Evento)
                .FirstOrDefault(a => a.IdAlerta == Id);
        }

        public IEnumerable<AlertaEntity> ObterTodosOsAlertas()
        {
            return _context.AlertaEntities.ToList();
        }

        public IEnumerable<AlertaEntity> ObterTodosOsAlertasPorEvento(string IdEvento)
        {
            return _context.AlertaEntities.Where(a => a.IdEvento == IdEvento);
        }

        public AlertaEntity PersistirAlerta(AlertaEntity AlertaEntity)
        {
            _context.AlertaEntities.Add(AlertaEntity);
            _context.SaveChanges();

            return ObterAlertaPorId(AlertaEntity.IdAlerta);
        }
    }
}
