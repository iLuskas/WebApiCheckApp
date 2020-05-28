using System;

namespace webApiCheckApp.Application.DTO.DTO
{
    public class Equipamento_SegurancaDTO : BaseDTO
    {
        public int Tipo_equipamentoId { get; set; }
        public int EmpresaClienteId { get; set; }
        public string Localizacao_equipamento { get; set; }
        public string QrCode { get; set; }
        public DateTime? Qrcode_data_geracao { get; set; }
        public DateTime DataCriacao_equipamento { get; set; }
        public ExtintorDTO ExtintorDTO { get; set; }
    }
}