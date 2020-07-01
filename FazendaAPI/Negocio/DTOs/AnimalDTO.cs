using Negocio.HATOAS;
using System;

namespace Negocio.DTOs
{
    public class AnimalDTO : RecursoLink
    {
        public Guid Id { get; set; }
        public string Cor { get; set; }
        public string CaracteristicaFisica { get; set; }
        public double Peso { get; set; }
        public byte[] Foto { get; set; }
    }
}
