
namespace FacturacionElectronica.intercambio
{
    public class ConsultaConstanciaRequest : EnvioDocumentoComun
    {
        public string Serie { get; set; }

        public int Numero { get; set; }
    }
}