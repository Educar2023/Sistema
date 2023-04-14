using FacturacionElectronica.repository.interfaces;
using FacturacionElectronica.service.interfaces;
using System.Collections.Generic;

namespace FacturacionElectronica.service.implement
{
    public class TFacVtaServiceImpl : ITFacVtaService
    {
        ITFacVtaRepository iTFacVtaRepository;

        public TFacVtaServiceImpl(ITFacVtaRepository iTFacVtaRepository)
        {
            this.iTFacVtaRepository = iTFacVtaRepository;
        }

        public List<dynamic> getDetails(dynamic iFacVta)
        {
            return iTFacVtaRepository.getDetails(iFacVta);
        }

    }
}
