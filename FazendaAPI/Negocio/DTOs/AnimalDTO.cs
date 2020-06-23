namespace Negocio.DTOs
{
    public class AnimalDTO
    {
        public int? Id { get; set; }
        public string Cor { get; set; }
        public string CaracteristicaFisica { get; set; }
        public double Peso { get; set; }
        public byte[] Foto { get; set; }
    }
}
