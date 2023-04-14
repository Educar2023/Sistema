
namespace FacturacionElectronica.intercambio
{
    public class ConsultaTicketRequest : EnvioDocumentoComun
    {
        public string NroTicket { get; set; }

        public string Ruta { get; set; }
    }
}