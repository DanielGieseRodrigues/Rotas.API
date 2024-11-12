namespace Rotas.API.Domain.Entities
{
    public class Aresta
    {
        public string Destino { get; }
        public decimal Valor { get; }
        public Aresta(string destino, decimal valor)
        {
            Destino = destino;
            Valor = valor;
        }
    }
}

