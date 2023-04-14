using FacturacionElectronica.contratos;
using System.Collections.Generic;

namespace FacturacionElectronica.modelos
{
    public class DocumentoRetencion : DocumentoSunatBase, IDocumentoElectronico
    {
        public string RegimenRetencion { get; set; }

        public decimal TasaRetencion { get; set; }

        public decimal ImporteTotalRetenido { get; set; }

        public decimal ImporteTotalPagado { get; set; }

        public List<ItemRetencion> DocumentosRelacionados { get; set; }
    }
}