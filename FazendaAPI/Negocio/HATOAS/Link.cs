
namespace Negocio.HATOAS
{
    public class Link
    {
        public Link(string href, string rel, string metodo)
        {
            Href = href;
            Rel = rel;
            Metodo = metodo;
        }

        public string Href { get; private set; }
        public string Rel { get; private set; }
        public string Metodo { get; private set; }
    }
}
