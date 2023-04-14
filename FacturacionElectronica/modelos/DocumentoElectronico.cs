using FacturacionElectronica.contratos;
using System.Collections.Generic;

namespace FacturacionElectronica.modelos
{
    public class DocumentoElectronico : IDocumentoElectronico
    {

        public string IdDocumento { get; set; }

        public string TipoDocumento { get; set; }

        public Contribuyente Emisor { get; set; }

        public Contribuyente Receptor { get; set; }

        public string FechaEmision { get; set; }

        public string HoraEmision { get; set; }

        public string Moneda { get; set; }

        public string TipoOperacion { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Gratuitas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exoneradas { get; set; }

        public List<DetalleDocumento> Items { get; set; }

        public decimal TotalVenta { get; set; }

        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosTributos { get; set; }

        public string MontoEnLetras { get; set; }

        public string PlacaVehiculo { get; set; }

        public decimal MontoPercepcion { get; set; }

        public decimal MontoDetraccion { get; set; }

        public List<DatoAdicional> DatoAdicionales { get; set; }

        public string TipoDocAnticipo { get; set; }

        public string DocAnticipo { get; set; }

        public string MonedaAnticipo { get; set; }

        public decimal MontoAnticipo { get; set; }

        public DatosGuia DatosGuiaTransportista { get; set; }

        public List<DocumentoRelacionado> Relacionados { get; set; }

        public List<Discrepancia> Discrepancias { get; set; }

        public decimal CalculoIgv { get; set; }

        public decimal CalculoIsc { get; set; }

        public decimal CalculoDetraccion { get; set; }
        public decimal TotalDescuentos { get; set; }

        public List<DocumentoAnticipo> Anticipos { get; set; }

        /// <summary>
        /// Estandar Ubl 2.1
        /// </summary>
        public string OrdenCompra { get; set; }

        /// <summary>
        /// Estandar Ubl 2.1
        /// </summary>
        public Descuento DescuentoGlobal { get; set; }

        /// <summary>
        /// Estandar Ubl 2.1 - 
        /// importe total de la venta sin considerar los descuentos, impuestos u otros tributos
        /// pero que incluye cualquier monto de redondeo aplicable.
        /// </summary>
        public decimal TotalValorVenta { get; set; }

        /// <summary>
        /// Estandar Ubl 2.1 - 
        /// valor de venta total de la operación incluido los impuestos.
        /// </summary>
        public decimal TotalPrecioVenta { get; set; }

        /// <summary>
        /// Estandar Ubl 2.1 -
        /// Corresponde al total de otros cargos cobrados al adquirente o usuario y que no forman parte de la operación que se factura, es decir no forman 
        ///parte del(os) valor(es) de ventas señaladas anteriormente, pero sí forman parte del importe total de la Venta (Ejemplo: propinas, garantías para
        ///devolución de envases, etc.)
        /// </summary>
        public decimal TotalOtrosCargos { get; set; }

        public bool EsServicio { get; set; }

        /// <summary>
        /// Estandar ubl 2.1
        /// </summary>
        public string CuentaBancoNacion { get; set; }

        /// <summary>
        /// Estandar ubl 2.1
        /// Códigos de bienes y servicios sujetos a detracción catalogo 54
        /// </summary>
        public string CodigoDetraccion { get; set; }


        //PDF
        public string CondidionVenta { get; set; }
        public string FormaPago { get; set; }
        public string ObservacionCabecera { get; set; }

        public List<GatosExportacion> GastosExportacion { get; set; }

        public string FormaPagoDetraccion { get; set; }

        public DocumentoElectronico()
        {
            Emisor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.
            };
            Receptor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.
            };
            CalculoIgv = 18.00m;
            CalculoIsc = 0.10m;
            CalculoDetraccion = 0.04m;
            Items = new List<DetalleDocumento>();
            DatoAdicionales = new List<DatoAdicional>();
            Relacionados = new List<DocumentoRelacionado>();
            Discrepancias = new List<Discrepancia>();
            Anticipos = new List<DocumentoAnticipo>();
            DescuentoGlobal = new Descuento();
            TipoDocumento = "01"; // Factura.
            TipoOperacion = "01"; // Venta Interna.
            Moneda = "PEN"; // Soles.
            GastosExportacion = new List<GatosExportacion>();
        }
    }
}