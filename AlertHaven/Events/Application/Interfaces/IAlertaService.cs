﻿using Events.Domain.Entities;

namespace Events.Application.Interfaces
{
    public interface IAlertaService
    {
        AlertaEntity ObterAlertaPorId(string Id);
        IEnumerable<AlertaEntity> ObterTodosOsAlertas();
        IEnumerable<AlertaEntity> ObterTodosOsAlertasPorEvento(string IdEvento);
        AlertaEntity PersistirAlerta(AlertaEntity AlertaEntity);
        AlertaEntity AtualizarAlerta(AlertaEntity AlertaEntity, string id);
        AlertaEntity DeletarAlerta(string id);
    }
}
