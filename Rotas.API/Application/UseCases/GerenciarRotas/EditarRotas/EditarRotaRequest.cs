﻿using System.Text.Json.Serialization;

namespace Rotas.API.Application.UseCases.GerenciarRotas.EditarRotas
{
    public class EditarRotaRequest
    {
        [JsonIgnore]
        public int RotaId { get; set; }
        public required string Origem { get; set; }
        public required string Destino { get; set; }
        public decimal Valor { get; set; }
    }
}