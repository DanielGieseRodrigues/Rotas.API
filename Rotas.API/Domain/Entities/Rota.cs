namespace Rotas.API.Domain.Entities
{
    public class Rota
    {
        public int Id { get; set; }
        public required string Origem { get; set; }
        public required string Destino { get; set; }
        public decimal Valor { get; set; }
    }
}
