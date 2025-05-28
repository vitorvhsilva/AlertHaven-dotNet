using AutoMapper;
using Events.Application.Dto;
using Events.Domain.Entities;

namespace Events.Presentation.Mappers
{
    public class ControllerMapper: Profile
    {
        public ControllerMapper()
        {
            CreateMap<PersistirIotInputDTO, IotEntity>();
            CreateMap<IotEntity, PersistirIotOutputDTO>();
             
        }
    }
}
