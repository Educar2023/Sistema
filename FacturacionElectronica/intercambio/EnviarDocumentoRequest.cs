namespace FacturacionElectronica.intercambio
{
    public class EnviarDocumentoRequest : EnvioDocumentoComun
    {
        public string TramaXmlFirmado { get; set; }

        public string RutaXml { get; set; }

        public string RutaCdr { get; set; }

        public string RutaPdf { get; set; }

        public string RutaImagen { get; set; }

        public string Moneda { get; set; }

        public string Smpt { get; set; }

        public int PuertoSmtp { get; set; }

        public bool EsConexionsegura { get; set; }
    }
}