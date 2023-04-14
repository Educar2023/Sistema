using FacturacionElectronica.repository.interfaces;
using FacturacionElectronica.service.interfaces;
using System;
using System.Collections.Generic;

namespace FacturacionElectronica.service.implement
{
    public class TicketSunatServicesImpl : ITicketSunatServices
    {
        ITickectSunatRepository iTickectSunatRepository;

        public TicketSunatServicesImpl(ITickectSunatRepository iTickectSunatRepository)
        {
            this.iTickectSunatRepository = iTickectSunatRepository;

        }

        public void Insertar(dynamic ticket)
        {
            iTickectSunatRepository.Insertar(ticket);
        }

        public List<dynamic> Listar(string tipo, DateTime fechaDe, DateTime fechaHasta)
        {
            return iTickectSunatRepository.Listar(tipo, fechaDe, fechaHasta);
        }

        public void Update(dynamic ticket)
        {
            iTickectSunatRepository.Update(ticket);
        }
    }
}
