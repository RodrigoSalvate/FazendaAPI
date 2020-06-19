using AutoMapper;
using Bogus;
using Dominio._0_Repositório;
using Dominio._1_Entidades;
using Infraestrutura._2_UnidadeDeTrabalho.Interface;
using Moq;
using Negocio.AutoMapper.Profiles;
using Negocio.DTOs;
using Negocio.Serviço;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testes.AnimalTeste
{
    public class AtualizacaoAnimalTeste
    {
        private readonly AnimalDTO animalDTO;
        private readonly Mock<IUnidadeDeTrabalho> mockUdt;
        private readonly Mock<IRepositorioGenerico<Animal>> mockRepositorio;
        private readonly IMapper Mapper;
        private readonly AnimalService animalService;

        public AtualizacaoAnimalTeste()
        {
            var faker = new Faker();
            mockUdt = new Mock<IUnidadeDeTrabalho>();
            mockRepositorio = new Mock<IRepositorioGenerico<Animal>>();
            mockUdt.Setup(s => s.AnimalRepositorio).Returns(mockRepositorio.Object);
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<AnimalProfile>()));

            animalDTO = new AnimalDTO()
            {
                Id = faker.Random.Int(1, 100),
                Cor = faker.Internet.Color(),
                CaracteristicaFisica = faker.Lorem.Paragraph(),
                Peso = faker.Random.Double(30, 500),
                Foto = faker.Random.Bytes(10)
            };
            animalService = new AnimalService(mockUdt.Object, Mapper);
        }


        [Fact]
        public void DeveAtualizarUmAnimal()
        {
            animalService.Atualizar(animalDTO);

            mockUdt.Verify(v => v.AnimalRepositorio.Atualizar
            (
                It.Is<Animal>(a =>
                a.Id == animalDTO.Id &&
                a.Cor == animalDTO.Cor &&
                a.CaracteristicaFisica == animalDTO.CaracteristicaFisica &&
                a.Peso == animalDTO.Peso &&
                a.Foto.Length == animalDTO.Foto.Length
              )
            ));
        }
    }
}
