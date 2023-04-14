
namespace FacturacionElectronica.modelos
{
    public class ItemRetencion : ItemSunatBase
    {
        public decimal ImporteSinRetencion { get; set; }

        public decimal ImporteRetenido { get; set; }

        public string FechaRetencion { get; set; }
    }
}