using FacturacionElectronica.modelos;

namespace FacturacionElectronica.intercambio
{
    public class CodigoBarrasRequest
    {
        public string RutaGuardar { get; set; }

        public string TextoCodigo { get; set; }

        public string PathArchivoPdf { get; set; }

        public string ValorResumen { get; set; }

        public string IdDocumento { get; set; }

        public byte[] CodigoBarrasBytes { get; set; }

        public string RutaXml { get; set; }

        public TipoOperacion TipoOperacion { get; set; }
    }
}
