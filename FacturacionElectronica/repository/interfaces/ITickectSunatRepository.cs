using System;
using System.Collections.Generic;

namespace FacturacionElectronica.repository.interfaces
{
    public interface ITickectSunatRepository
    {
        void Insertar(dynamic ticket);
        List<dynamic> Listar(string tipo, DateTime fechaDe, DateTime fechaHasta);
        void Update(dynamic ticket);

    }
}
