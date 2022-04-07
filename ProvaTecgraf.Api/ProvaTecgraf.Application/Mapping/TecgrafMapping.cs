using AutoMapper;
using ProvaTecgraf.Application.Dto;
using ProvaTecgraf.Domain;
using ProvaTecgraf.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecgraf.Application.Mapping
{
    public class TecgrafMapping : Profile
    {
        public TecgrafMapping()
        {
            CreateMap<Empregado, EmpregadoDto>().ReverseMap();
            CreateMap<Empregado, EmpregadoUpdateDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }        
    }
}
