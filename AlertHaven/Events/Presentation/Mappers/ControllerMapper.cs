﻿using AutoMapper;
using Events.Application.Dto.Iot;
using Events.Application.Dto.Evento;
using Events.Application.Dto.Alerta;
using Events.Domain.Entities;

namespace Events.Presentation.Mappers
{
    public class ControllerMapper: Profile
    {
        public ControllerMapper()
        {
            CreateMap<PersistirIotInputDTO, IotEntity>();
            CreateMap<IotEntity, PersistirIotOutputDTO>();
            CreateMap<IotEntity, ObterIotCompletoDTO>();
            CreateMap<IotEntity, ObterIotSimplesDTO>();
            CreateMap<AtualizarIotInputDTO, IotEntity>();

            CreateMap<PersistirEventoInputDTO, EventoEntity>();
            CreateMap<EventoEntity, PersistirEventoOutputDTO>();
            CreateMap<EventoEntity, ObterEventoCompletoDTO>();
            CreateMap<EventoEntity, ObterEventoSimplesDTO>();
            CreateMap<AtualizarEventoInputDTO, EventoEntity>();

            CreateMap<PersistirAlertaInputDTO, AlertaEntity>();
            CreateMap<AlertaEntity, PersistirAlertaOutputDTO>();
            CreateMap<AlertaEntity, ObterAlertaCompletoDTO>();
            CreateMap<AlertaEntity, ObterAlertaSimplesDTO>();
            CreateMap<AtualizarAlertaInputDTO, AlertaEntity>();

            CreateMap<IotEntity, IotEntityDTO>();
            CreateMap<EventoEntity, EventoEntityDTO>();
            CreateMap<AlertaEntity, AlertaEntityDTO>();
        }
    }
}
