using System;
using System.Collections.Generic;

namespace FacturacionElectronica.service.interfaces
{
    public interface ITicketSunatServices
    {
        void Insertar(dynamic ticket);
        List<dynamic> Listar(string tipo, DateTime fechaDe, DateTime fechaHasta);
        void Update(dynamic ticket);
    }
}
