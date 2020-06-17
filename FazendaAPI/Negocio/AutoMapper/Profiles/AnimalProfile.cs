using AutoMapper;
using Dominio._1_Entidades;
using Negocio.DTOs;

namespace Negocio.AutoMapper.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalDTO>().ReverseMap();
        }
    }
}
