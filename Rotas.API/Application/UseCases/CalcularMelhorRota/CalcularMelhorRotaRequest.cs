namespace Rotas.API.Application.UseCases.CalcularMelhorRota
{
    public class CalcularMelhorRotaRequest
    {
        public required string Destino { get; set; }
        public required string Origem { get;  set; }
    }
}
