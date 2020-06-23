using AutoMapper;
using Dominio._1_Entidades;
using Infraestrutura._2_UnidadeDeTrabalho.Interface;
using Negocio._Util;
using Negocio.DTOs;
using Negocio.Serviço.Interface;
using Negocio.Validacao;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Negocio.Serviço
{
    public class AnimalService : IServiceBase<AnimalDTO>
    {
        private readonly IUnidadeDeTrabalho Udt;
        private readonly IMapper mapper;
        private readonly IValidacaoService validacaoService;
        public AnimalService(IUnidadeDeTrabalho _udt, IMapper _mapper, IValidacaoService _validacaoService)
        {
            Udt = _udt;
            mapper = _mapper;
            validacaoService = _validacaoService;
        }

        public AnimalDTO ObterPorId(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnimalDTO> ObterTodos()
        {
            return mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalDTO>>(Udt.AnimalRepositorio.ObterTodos());
        }

        public AnimalDTO Atualizar(AnimalDTO Dto)
        {
            var animalBanco = Udt.AnimalRepositorio.Atualizar(mapper.Map<AnimalDTO, Animal>(Dto));
            Udt.Commit();

            return mapper.Map<Animal, AnimalDTO>(animalBanco);
        }

        public AnimalDTO Inserir(AnimalDTO Dto)
        {
            var animalBanco = Udt.AnimalRepositorio.Inserir(mapper.Map<AnimalDTO, Animal>(Dto));
            Udt.Commit();

            return mapper.Map<Animal, AnimalDTO>(animalBanco);
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

        public List<RetornoValidacao> Validar(AnimalDTO Dto)
        {
            validacaoService.ValidarVazioOuNulo(Dto.Cor, ReflectionUtil.ObterNomePropriedade(() => Dto.Cor));
            validacaoService.ValidarVazioOuNulo(Dto.Peso, ReflectionUtil.ObterNomePropriedade(() => Dto.Peso));

            return validacaoService.validacoes;
        }
    }
}
