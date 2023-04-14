namespace FacturacionElectronica.modelos
{
    public class DetalleGuia
    {
        public int Correlativo { get; set; }

        public string CodigoItem { get; set; }

        public string Descripcion { get; set; }

        public string UnidadMedida { get; set; }

        public decimal Cantidad { get; set; }

        public int LineaReferencia { get; set; }
    }
}