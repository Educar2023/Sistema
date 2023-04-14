using System.Collections.Generic;

namespace FacturacionElectronica.modelos
{
    public class ComunicacionBaja : DocumentoResumen
    {

        public List<DocumentoBaja> Bajas { get; set; }
    }
}