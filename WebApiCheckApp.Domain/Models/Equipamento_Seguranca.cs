using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Equipamento_Seguranca : Base
    {
        public int IdTipo { get; set; }
        public virtual Tipo_equipamento Tipo { get; set; }
        public int IdEmpresa { get; set; }
        public virtual EmpresaCliente EmpresaCliente { get; set; }
        public string Localizacao_equipamento { get; set; }
        public string QrCode { get; set; }
        public DateTime Qrcode_data_geracao { get; set; }
    }
}
