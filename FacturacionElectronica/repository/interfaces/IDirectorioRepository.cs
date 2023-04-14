using System.Collections.Generic;

namespace FacturacionElectronica.repository.interfaces
{
    public interface IDirectorioRepository
    {
        List<dynamic> getAll();
        void UpdateIdResumen(string code);
    }
}
