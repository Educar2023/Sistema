

using FacturacionElectronica.contratos;
using System.Collections.Generic;

namespace FacturacionElectronica.modelos
{
    public class DocumentoPercepcion : DocumentoSunatBase, IDocumentoElectronico
    {
        public string RegimenPercepcion { get; set; }

        public decimal TasaPercepcion { get; set; }

        public decimal ImporteTotalPercibido { get; set; }

        public decimal ImporteTotalCobrado { get; set; }

        public List<ItemPercepcion> DocumentosRelacionados { get; set; }
    }
}