using System.Collections.Generic;

namespace FacturacionElectronica.repository.interfaces
{
    public interface ITFacVtaRepository
    {
        List<dynamic> getDetails(dynamic iFacVta);
        List<dynamic> getExportCharges(dynamic iFacVta);
    }
}
