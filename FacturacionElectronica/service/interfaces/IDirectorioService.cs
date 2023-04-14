using System.Collections.Generic;

namespace FacturacionElectronica.service.interfaces
{
    public interface IDirectorioService
    {
        List<dynamic> getAll();
        void UpdateIdResumen(string code);
    }
}
