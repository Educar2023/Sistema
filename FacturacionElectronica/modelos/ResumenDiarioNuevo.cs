using System.Collections.Generic;

namespace FacturacionElectronica.modelos
{
    public class ResumenDiarioNuevo : DocumentoResumen
    {
        public List<GrupoResumenNuevo> Resumenes { get; set; }
    }
}