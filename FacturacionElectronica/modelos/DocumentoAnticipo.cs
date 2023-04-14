
namespace FacturacionElectronica.modelos
{
    public class DocumentoAnticipo
    {
        public string IdDocumento { get; set; }
        public decimal Monto { get; set; }
        public string TipoDocumento { get; set; }
        public string Moneda { get; set; }
    }
}
