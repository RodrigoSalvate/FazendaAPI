using AutoMapper;
using Dominio._1_Entidades;
using Infraestrutura._2_UnidadeDeTrabalho.Interface;
using Negocio.DTOs;
using Negocio.Serviço.Interface;
using System;
using System.Collections.Generic;

namespace Negocio.Serviço
{
    public class AnimalService : IServiceBase<AnimalDTO>
    {
        private readonly IUnidadeDeTrabalho Udt;
        private readonly IMapper mapper;
        public AnimalService(IUnidadeDeTrabalho _udt, IMapper _mapper)
        {
            Udt = _udt;
            mapper = _mapper;
        }

        public AnimalDTO ObterPorId(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnimalDTO> ObterTodos()
        {
            return mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalDTO>>(Udt.AnimalRepositorio.ObterTodos());
        }

        public void Atualizar(AnimalDTO Dto)
        {
            Udt.AnimalRepositorio.Atualizar(mapper.Map<AnimalDTO, Animal>(Dto));
            Udt.Commit();
        }

        public void Inserir(AnimalDTO Dto)
        {
            Udt.AnimalRepositorio.Inserir(mapper.Map<AnimalDTO, Animal>(Dto));
            Udt.Commit();
        }

        public void Remover(AnimalDTO Dto)
        {
            Udt.AnimalRepositorio.Remover(mapper.Map<AnimalDTO, Animal>(Dto));
            Udt.Commit();
        }

        public void Remover(object id)
        {
            Udt.AnimalRepositorio.Remover(id);
            Udt.Commit();
        }

        public void Validar(AnimalDTO Dto)
        {
            throw new NotImplementedException();
        }
    }
}
