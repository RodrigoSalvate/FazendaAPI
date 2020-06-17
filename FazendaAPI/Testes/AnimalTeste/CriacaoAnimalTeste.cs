using System;
using ExpectedObjects;
using Bogus;
using Dominio._1_Entidades;
using Xunit;
using Testes._Construtor;
using Testes._Util;

namespace Testes.AnimalTeste
{
    public class CriacaoAnimalTeste : IDisposable
    {
        private string _cor = "Amarelo";
        private string _caracteristicaFisica = "Sem pelo na perna direita";
        private double _peso = 155.8;

        public CriacaoAnimalTeste()
        {
            var faker = new Faker();

            _cor = faker.Internet.Color();
            _caracteristicaFisica = faker.Lorem.Paragraph();
            _peso = faker.Random.Double(30, 500);
        }

        public void Dispose()
        {
        }

        [Fact]
        public void DeveCriarAnimal()
        {
            var animalEsperado = new
            {
                Cor = _cor,
                CaracteristicaFisica = _caracteristicaFisica,
                Peso = _peso
            };

            var animal = new Animal(animalEsperado.Cor, animalEsperado.CaracteristicaFisica, animalEsperado.Peso);

            animalEsperado.ToExpectedObject().ShouldMatch(animal);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DevePossuirUmaCor(string cor)
        {
            Assert.Throws<ArgumentException>(() => AnimalConstrutor.Novo().ComCor(cor).Construir()).ComMensagem("Cor Inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-16)]
        public void DevePossuirUmPesoMaiorQueZero(double peso)
        {
            Assert.Throws<ArgumentException>(() => AnimalConstrutor.Novo().ComPeso(peso).Construir()).ComMensagem("Peso Inválido");
        }
    }
}
