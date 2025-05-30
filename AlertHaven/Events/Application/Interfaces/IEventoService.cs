﻿using Events.Domain.Entities;

namespace Events.Application.Interfaces
{
    public interface IEventoService
    {
        EventoEntity ObterEventoPorId(string Id);
        IEnumerable<EventoEntity> ObterTodosOsEventos();
        IEnumerable<EventoEntity> ObterTodosOsEventosPorIot(string IdIot);
        EventoEntity PersistirEvento(EventoEntity EventoEntity);
        EventoEntity AtualizarEvento(EventoEntity EventoEntity, string id);
        EventoEntity DeletarEvento(string id);
    }
}
