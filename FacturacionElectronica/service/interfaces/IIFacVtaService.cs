using FacturacionElectronica.modelos;
using System.Collections.Generic;

namespace FacturacionElectronica.service.interfaces
{
    public interface IIFacVtaService
    {
        List<dynamic> ListPendingInvoice();
        List<dynamic> ListPendingInvoiceBoleta();
        List<dynamic> ListPendingInvoiceBoletaBajas();
        List<dynamic> ListSendingInvoice(string año, string mes);
        DocumentoElectronico generateElectronicInvoice(dynamic invoice, List<dynamic> lines);
        dynamic GetInvoice(dynamic iFacVta);
        List<string> getemailsCustomer(string codCliente);
        void UpdateStateSend(dynamic iFacVta);
        dynamic GetDataSupplier();
        dynamic GetDataCustomer(string codCliente);
        List<string> LoadYears();
        void UpdateStateVoided(dynamic iFacVta);
        dynamic ListPendingInvoice(string nroDoc, string codDoc);
        List<dynamic> ListPendingInvoiceBajas();
    }
}
