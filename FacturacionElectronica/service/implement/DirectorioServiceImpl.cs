using FacturacionElectronica.repository.interfaces;
using FacturacionElectronica.service.interfaces;
using System.Collections.Generic;

namespace FacturacionElectronica.service.implement
{
    public class DirectorioServiceImpl : IDirectorioService
    {
        IDirectorioRepository iDirectorioRepository;

        public DirectorioServiceImpl(IDirectorioRepository iDirectorioRepository)
        {
            this.iDirectorioRepository = iDirectorioRepository;

        }

        public List<dynamic> getAll()
        {
            return iDirectorioRepository.getAll();
        }

        public void UpdateIdResumen(string code)
        {
            iDirectorioRepository.UpdateIdResumen(code);
        }
    }
}
