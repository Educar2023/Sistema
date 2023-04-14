using System.Collections.Generic;


namespace FacturacionElectronica.modelos
{
    public class ResumenDiario : DocumentoResumen
    {
        public List<GrupoResumen> Resumenes { get; set; }
    }
}