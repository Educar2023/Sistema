using System.Collections.Generic;

namespace FacturacionElectronica.repository.interfaces
{
    public interface IIFacVtaRepository
    {
        List<dynamic> ListPendingInvoice();
        List<dynamic> ListPendingInvoiceBoleta();
        List<dynamic> ListPendingInvoiceBoletaBajas();
        List<dynamic> ListSendingInvoice(string año, string mes);
        dynamic GetInvoice(dynamic iFacVta);
        dynamic GetDataCustomer(string codCliente);
        List<string> GetEmailCustomer(string codCliente);
        dynamic GetDataSupplier();
        dynamic GetDataGuia(dynamic iFacVta);
        void UpdateStateSend(dynamic iFacVta);
        void UpdateStateVoided(dynamic iFacVta);
        List<string> loadYears();
        dynamic ListPendingInvoice(string nroDoc, string codDoc);

        List<dynamic> ListPendingInvoiceBajas();
    }
}
