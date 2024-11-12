using Rotas.API.Domain.Entities;
using Rotas.API.Domain.Interfaces;

namespace Rotas.API.Application.UseCases.CalcularMelhorRota
{
    public class CalcularMelhorRotaUseCase
    {
        private readonly IRotaRepository _rotaRepository;

        public CalcularMelhorRotaUseCase(IRotaRepository rotaRepository)
        {
            _rotaRepository = rotaRepository;
        }

        public async Task<CalcularMelhorRotaResponse> ExecuteAsync(CalcularMelhorRotaRequest request)
        {
            var rotas = await _rotaRepository.GetAllAsync();

            if (rotas.Where(p => p.Destino == request.Destino.ToUpper()).Count() < 1)
                return new CalcularMelhorRotaResponse { MelhorRota = "Destino não existe no banco de dados!" };

            if (rotas.Where(p => p.Origem == request.Origem.ToUpper()).Count() < 1)
                return new CalcularMelhorRotaResponse { MelhorRota = "Origem não existe no banco de dados!" };

            var grafo = MontarGrafo(rotas); 

            var melhorRota = CalcularMelhorRota(grafo, request.Origem.ToUpper(), request.Destino.ToUpper());
            string cidadesFormatadas = string.Join(" - ", melhorRota.Cidades);
            return new CalcularMelhorRotaResponse { MelhorRota = $"{cidadesFormatadas} ao custo de $ {melhorRota.CustoTotal}" };
        }

        private Dictionary<string, List<Aresta>> MontarGrafo(IEnumerable<Rota> rotas)
        {
            var grafo = new Dictionary<string, List<Aresta>>();

            foreach (var rota in rotas)
            {
                if (!grafo.ContainsKey(rota.Origem))
                    grafo[rota.Origem] = new List<Aresta>();

                grafo[rota.Origem].Add(new Aresta(rota.Destino, rota.Valor));

                if (!grafo.ContainsKey(rota.Destino))
                    grafo[rota.Destino] = new List<Aresta>();
            }
            return grafo;
        }

        // Baseado no algoritmo de Dijkstra para calcular a melhor rota.
        private RotaResultado CalcularMelhorRota(Dictionary<string, List<Aresta>> grafo, string origem, string destino)
        {
            var distancias = new Dictionary<string, decimal>();
            var predecessores = new Dictionary<string, string>();
            var cidadesNaoVisitadas = new HashSet<string>(grafo.Keys);

            foreach (var cidade in grafo.Keys)
            {
                distancias[cidade] = cidade == origem ? 0 : decimal.MaxValue;
                predecessores[cidade] = null;
            }

            while (cidadesNaoVisitadas.Any())
            {
                var cidadeAtual = cidadesNaoVisitadas.OrderBy(c => distancias[c]).First();
                cidadesNaoVisitadas.Remove(cidadeAtual);

                if (cidadeAtual == destino) break; 

                foreach (var aresta in grafo[cidadeAtual])
                {
                    var novaDistancia = distancias[cidadeAtual] + aresta.Valor;
                    if (novaDistancia < distancias[aresta.Destino])
                    {
                        distancias[aresta.Destino] = novaDistancia;
                        predecessores[aresta.Destino] = cidadeAtual;
                    }
                }
            }

            var caminho = new List<string>();
            var cidadeNoCaminho = destino;

            while (cidadeNoCaminho != null)
            {
                caminho.Insert(0, cidadeNoCaminho);
                cidadeNoCaminho = predecessores[cidadeNoCaminho];
            }

            return new RotaResultado
            {
                Cidades = caminho,
                CustoTotal = distancias[destino]
            };
        }
    }
}
