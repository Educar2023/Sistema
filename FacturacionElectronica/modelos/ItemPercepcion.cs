
namespace FacturacionElectronica.modelos
{
    public class ItemPercepcion : ItemSunatBase
    {

        public decimal ImporteSinPercepcion { get; set; }

        public decimal ImportePercibido { get; set; }

        public string FechaPercepcion { get; set; }
    }
}