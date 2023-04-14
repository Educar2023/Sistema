using FacturacionElectronica.contratos;

namespace FacturacionElectronica.intercambio
{
    public class PdfRequest
    {
        public string RutaPdf { get; set; }
        public string ResumenFirma { get; set; }
        public string ValorFirma { get; set; }
        public string RutaImagen { get; set; }
        public IDocumentoElectronico Documento { get; set; }
        public string RutaCertificado { get; set; }
        public string ClaveCertificado { get; set; }
    }
}
