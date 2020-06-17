using Dominio._1_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testes._Construtor
{
    public class AnimalConstrutor
    {
        private string Cor = "Amarelo";
        private string CaracteristicaFisica = "Sem pelo na perna direita";
        private double Peso = 155.8;

        public static AnimalConstrutor Novo()
        {
            return new AnimalConstrutor();
        }

        public Animal Construir()
        {
            return new Animal(Cor, CaracteristicaFisica, Peso);
        }

        public AnimalConstrutor ComCor(string cor)
        {
            Cor = cor;
            return this;
        }
    }
}
