﻿namespace FacturacionElectronica.intercambio
{
    public class EnviarDocumentoResponse : RespuestaComunConArchivo
    {
        public string CodigoRespuesta { get; set; }

        public string MensajeRespuesta { get; set; }

        public string TramaZipCdr { get; set; }

        public string ErrorEmail { get; set; }

        public string ErrorArchivos { get; set; }
    }
}