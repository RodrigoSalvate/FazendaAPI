﻿using Dominio._1_Entidades.Base;
using System;

namespace Dominio._1_Entidades
{
    public class Animal : EntidadeBase
    {
        public Animal(string cor, string caracteristicaFisica, double peso)
        {
            if (string.IsNullOrEmpty(cor))
                throw new ArgumentException("Cor Inválida");

            if (peso <= 0)
                throw new ArgumentException("Peso Inválido");

            Cor = cor;
            CaracteristicaFisica = caracteristicaFisica;
            Peso = peso;
        }

        public virtual string Cor { get; set; }
        public virtual string CaracteristicaFisica { get; set; }
        public virtual double Peso { get; set; }
        public virtual byte[] Foto { get; set; }
    }
}
