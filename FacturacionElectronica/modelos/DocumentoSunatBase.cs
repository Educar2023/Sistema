
namespace FacturacionElectronica.modelos
{
    public class DocumentoSunatBase
    {
        public string IdDocumento { get; set; }

        public string FechaEmision { get; set; }

        public Contribuyente Emisor { get; set; }

        public Contribuyente Receptor { get; set; }

        public string Moneda { get; set; }

        public string Observaciones { get; set; }
    }
}