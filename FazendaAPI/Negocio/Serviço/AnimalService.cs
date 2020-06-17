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

        public void Atualizar(AnimalDTO Dto)
        {
            throw new NotImplementedException();
        }

        public void Inserir(AnimalDTO Dto)
        {
            var entidade = mapper.Map<AnimalDTO, Animal>(Dto);

            Udt.AnimalRepositorio.Inserir(entidade);
            Udt.Commit();
        }

        public IEnumerable<AnimalDTO> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(AnimalDTO Dto)
        {
            throw new NotImplementedException();
        }

        public void Remover(object id)
        {
            throw new NotImplementedException();
        }

        public void Validar(AnimalDTO Dto)
        {
            throw new NotImplementedException();
        }
    }
}
