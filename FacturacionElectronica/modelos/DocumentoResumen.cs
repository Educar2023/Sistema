using FacturacionElectronica.contratos;

namespace FacturacionElectronica.modelos
{
    public abstract class DocumentoResumen : IDocumentoElectronico
    {
        public string IdDocumento { get; set; }

        public string FechaEmision { get; set; }

        public string FechaReferencia { get; set; }

        public Contribuyente Emisor { get; set; }
    }
}