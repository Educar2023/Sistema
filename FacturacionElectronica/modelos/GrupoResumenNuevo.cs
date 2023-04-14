namespace FacturacionElectronica.modelos
{
    public class GrupoResumenNuevo : GrupoResumen
    {

        public string IdDocumento { get; set; }

        public string TipoDocumentoReceptor { get; set; }

        public string NroDocumentoReceptor { get; set; }

        public int CodigoEstadoItem { get; set; }

        public string DocumentoRelacionado { get; set; }

        public string TipoDocumentoRelacionado { get; set; }
    }
}