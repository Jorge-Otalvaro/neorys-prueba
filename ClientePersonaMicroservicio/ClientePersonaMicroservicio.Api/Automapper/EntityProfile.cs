using AutoMapper;
using ClientePersonaMicroservicio.Domain.Dtos;
using ClientePersonaMicroservicio.Domain.Entities;

namespace ClientePersonaMicroservicio.Api.Automapper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            //CreateMap<Cuenta, CuentaRegisterCommand>().ReverseMap();
            //CreateMap<Cuenta, CuentaUpdateCommand>().ReverseMap();
            //CreateMap<Cuenta, CuentaDeleteCommand>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();

            //CreateMap<Movimiento, MovimientoRegisterCommand>().ReverseMap();
            //CreateMap<Movimiento, MovimientoUpdateCommand>().ReverseMap();
            //CreateMap<Movimiento, MovimientoDeleteCommand>().ReverseMap();
            //CreateMap<Persona, MovimientoDto>().ReverseMap();
        }
    }
}
