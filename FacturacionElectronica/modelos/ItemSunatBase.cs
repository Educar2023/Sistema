
namespace FacturacionElectronica.modelos
{
    public class ItemSunatBase : DocumentoRelacionado
    {
        public string FechaEmision { get; set; }

        public decimal ImporteTotal { get; set; }

        public string MonedaDocumentoRelacionado { get; set; }

        public int NumeroPago { get; set; }

        public decimal ImporteTotalNeto { get; set; }

        public string FechaPago { get; set; }

        public decimal TipoCambio { get; set; }

        public string FechaTipoCambio { get; set; }
    }
}