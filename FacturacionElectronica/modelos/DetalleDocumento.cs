namespace FacturacionElectronica.modelos
{
    public class DetalleDocumento
    {

        public int Id { get; set; }

        public decimal Cantidad { get; set; }

        public string UnidadMedida { get; set; }

        public string CodigoItem { get; set; }
        public string UnidadMedidaSunat { get; set; }


        public string Descripcion { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal PrecioVenta { get; set; }

        public string TipoPrecio { get; set; }

        public string TipoImpuesto { get; set; }

        public decimal Impuesto { get; set; }

        public decimal ImpuestoSelectivo { get; set; }

        public decimal OtroImpuesto { get; set; }

        public Descuento Descuento { get; set; }

        public decimal TotalVenta { get; set; }

        public decimal Suma { get; set; }

        public decimal ValorReferencial { get; set; }
        public decimal IgvReferencial { get; set; }

        public decimal ValorVenta { get; set; }

        /// <summary>
        /// Es el monto correspondiente al precio unitario facturado del bien vendido o servicio vendido. Este monto es la suma total que queda obligado a pagar 
        /// el adquirente o usuario por cada bien o servicio. Esto incluye los tributos (IGV, ISC y otros Tributos) y la deducción de descuentos por ítem.
        /// </summary>
        public decimal PrecioVentaUnitario { get; set; }

        /// <summary>
        /// Estandar Ubl 2.1
        /// </summary>
        public string CodigoInternacional { get; set; }
        public string Observacion { get; set; }


        public DetalleDocumento()
        {
            Id = 1;
            UnidadMedida = "NIU";
            TipoPrecio = "01";
            TipoImpuesto = "10";
            Descuento = new Descuento();
        }
    }
}