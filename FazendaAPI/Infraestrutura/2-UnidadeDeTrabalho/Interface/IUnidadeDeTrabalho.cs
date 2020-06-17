using Dominio._0_Repositório;
using Dominio._1_Entidades;

namespace Infraestrutura._2_UnidadeDeTrabalho.Interface
{
    public interface IUnidadeDeTrabalho
    {
        IRepositorioGenerico<Animal> AnimalRepositorio { get; }
        void Commit();
    }
}
