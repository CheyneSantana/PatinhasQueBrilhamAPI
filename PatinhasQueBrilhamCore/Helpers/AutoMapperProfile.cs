using AutoMapper;
using PatinhasQueBrilham.DTO;
using PatinhasQueBrilham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<FormularioDTO, Adotante>();
            CreateMap<Adotante, FormularioDTO>();
        }
    }
}
