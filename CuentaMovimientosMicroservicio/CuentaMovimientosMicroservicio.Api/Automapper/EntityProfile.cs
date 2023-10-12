using AutoMapper;
using CuentaMovimientosMicroservicio.Application.Cuentas;
using CuentaMovimientosMicroservicio.Application.Movimientos;
using CuentaMovimientosMicroservicio.Domain.Dtos;
using CuentaMovimientosMicroservicio.Domain.Entities;

namespace CuentaMovimientosMicroservicio.Api.Automapper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Cuenta, CuentaRegisterCommand>().ReverseMap();
            CreateMap<Cuenta, CuentaUpdateCommand>().ReverseMap();
            CreateMap<Cuenta, CuentaDeleteCommand>().ReverseMap();
            CreateMap<Cuenta, CuentaDto>().ReverseMap();

            CreateMap<Movimiento, MovimientoRegisterCommand>().ReverseMap();
            CreateMap<Movimiento, MovimientoUpdateCommand>().ReverseMap();
            CreateMap<Movimiento, MovimientoDeleteCommand>().ReverseMap();
            CreateMap<Movimiento, MovimientoDto>().ReverseMap();
        }
    }
}
