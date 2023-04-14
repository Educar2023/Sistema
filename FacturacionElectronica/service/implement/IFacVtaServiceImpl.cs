using FacturacionElectronica.modelos;
using FacturacionElectronica.repository.interfaces;
using FacturacionElectronica.service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacturacionElectronica.service.implement
{
    public class IFacVtaServiceImpl : IIFacVtaService
    {
        IIFacVtaRepository iIFacVtaRepository;

        public IFacVtaServiceImpl(IIFacVtaRepository iIFacVtaRepository)
        {
            this.iIFacVtaRepository = iIFacVtaRepository;

        }

        public List<dynamic> ListPendingInvoice()
        {
            return iIFacVtaRepository.ListPendingInvoice();
        }

        public DocumentoElectronico generateElectronicInvoice(dynamic invoice, List<dynamic> lines)
        {
            DocumentoElectronico documento = new DocumentoElectronico();
            documento.FechaEmision = invoice.FechaDoc.ToString("yyyy-MM-dd");
            documento.HoraEmision = invoice.FechaDoc.ToString("HH:mm:ss");

            documento.IdDocumento = invoice.NroDoc;
            documento.Moneda = invoice.CodMoneda;
            documento.TipoDocumento = invoice.CodDoc;
            documento.FormaPago = invoice.FormaPago;
            documento.CondidionVenta = invoice.Condicion;
            documento.TipoOperacion = invoice.Tipo;
            documento.CalculoDetraccion = invoice.PorcentajeDetraccion;
            documento.MontoDetraccion = invoice.MontoDetraccion;
            documento.ObservacionCabecera = invoice.Observacion;
            documento.FormaPagoDetraccion = invoice.MedioPagoDetraccion;
            if (documento.TipoDocumento == "07" || documento.TipoDocumento == "08")
                GetNoteData(ref documento, invoice);

            GetDataSupplier(ref documento);
            GetDataCustomer(ref documento, invoice.CodCliente);
            GetDataGuia(ref documento, invoice);
            GetLines(ref documento, lines);
            GetTotals(ref documento);
            return documento;
        }

        public dynamic GetDataSupplier()
        {
            return iIFacVtaRepository.GetDataSupplier();
        }
        private void GetDataSupplier(ref DocumentoElectronico documento)
        {
            dynamic emisor = GetDataSupplier();

            documento.Emisor = new Contribuyente
            {
                Departamento = emisor.Departamento,
                Direccion = emisor.Direccion,
                Distrito = emisor.Distrito,
                NombreComercial = emisor.RazonSocial,
                NombreLegal = emisor.RazonSocial,
                NroDocumento = emisor.Ruc,
                Provincia = emisor.Provincia,
                TipoDocumento = "6",
                Ubigeo = emisor.Ubigeo,
                Urbanizacion = ""
            };
        }

        private void GetDataCustomer(ref DocumentoElectronico documento, string codCliente)
        {
            dynamic customer = iIFacVtaRepository.GetDataCustomer(codCliente);

            documento.Receptor = new Contribuyente
            {
                NombreComercial = customer.NombreComercial,
                NombreLegal = customer.RazonSocial,
                NroDocumento = customer.Ruc,
                TipoDocumento = Convert.ToInt32(customer.Tipodocumento).ToString(),
                Direccion = customer.Direccion
            };
        }

        public dynamic GetDataCustomer(string codCliente)
        {
            return iIFacVtaRepository.GetDataCustomer(codCliente);


        }


        public List<string> getemailsCustomer(string codCliente)
        {
            return iIFacVtaRepository.GetEmailCustomer(codCliente);
        }

        private void GetDataGuia(ref DocumentoElectronico documento, dynamic iFacVta)
        {
            dynamic guia = iIFacVtaRepository.GetDataGuia(iFacVta);

            if (guia != null)
            {
                documento.Relacionados = new List<DocumentoRelacionado>
                {
                    new DocumentoRelacionado
                    {
                        NroDocumento = guia.Numero,
                        TipoDocumento = guia.Codigo
                    }
                };
            }

        }

        private void GetLines(ref DocumentoElectronico documento, List<dynamic> lines)
        {
            int i = 1;
            foreach (var item in lines)
            {
                Descuento descuento = new Descuento
                {
                    Importe = item.ValorDcto,
                    ImporteBase = item.ValorVenta + item.ValorDcto,
                    Porcentaje = item.ValorDcto == 0 ? 0 : ((item.ValorVenta + item.ValorDcto) / 100.00m) / item.ValorDcto
                };

                documento.Items.Add(new DetalleDocumento
                {
                    Id = i,
                    Cantidad = item.Cantidad,
                    UnidadMedidaSunat = item.UnidadMedidaSunat,
                    CodigoItem = item.CoItem,
                    Descripcion = item.DesItem,
                    Descuento = descuento,
                    Impuesto = item.ValorIgv,
                    ValorUnitario = item.ValorUnitario,
                    PrecioVenta = item.ValorReferencial > 0 ? (item.ValorReferencial + item.ValorIgvReferencial) : (item.ValorUnitario * (item.PorcentajeIgv / 100.00m)) + item.ValorUnitario,
                    TipoImpuesto = item.TipoAfectacion,
                    TipoPrecio = item.CodigoPrecio,
                    UnidadMedida = item.UnidadMedida,
                    TotalVenta = item.ValorReferencial > 0 ? item.ValorReferencial + item.ValorIgvReferencial : item.PrecioVenta,
                    ValorVenta = item.ValorReferencial > 0 ? item.ValorReferencial : item.ValorVenta,
                    ValorReferencial = item.ValorReferencial,
                    IgvReferencial = item.ValorIgvReferencial,
                    Observacion = item.Observacion
                });

                i++;
            }


        }

        private void GetTotals(ref DocumentoElectronico documento)
        {
            documento.TotalIgv = documento.Items.Sum(d => d.Impuesto);
            documento.TotalIsc = documento.Items.Sum(d => d.ImpuestoSelectivo);
            documento.TotalOtrosTributos = documento.Items.Sum(d => d.OtroImpuesto);

            documento.Gravadas = documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("1"))
                .Sum(d => d.ValorVenta);

            documento.Exoneradas = documento.Items
                .Where(d => d.TipoImpuesto.Contains("20"))
                .Sum(d => d.TotalVenta);

            if (documento.Items.Sum(x => x.ValorReferencial) > 0)
            {
                documento.Inafectas = 0;

                documento.Gratuitas = documento.Items
                    .Where(d => d.TipoImpuesto.StartsWith("3") || d.TipoImpuesto.Contains("40"))
                    .Sum(d => d.TotalVenta);

                documento.TotalVenta = 0;

                documento.TotalDescuentos = documento.Items.Sum(x => x.Descuento.Importe);
                documento.TotalValorVenta = 0;
                documento.TotalPrecioVenta = 0;

            }
            else
            {
                documento.Inafectas = documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("3") || d.TipoImpuesto.Contains("40"))
                .Sum(d => d.TotalVenta);

                documento.Gratuitas = 0;

                documento.TotalVenta = documento.Gravadas + documento.Exoneradas + documento.Inafectas +
                                    documento.TotalIgv + documento.TotalIsc + documento.TotalOtrosTributos;

                documento.TotalDescuentos = documento.Items.Sum(x => x.Descuento.Importe);
                documento.TotalValorVenta = documento.Items.Sum(x => x.ValorVenta) + documento.TotalDescuentos;
                documento.TotalPrecioVenta = documento.TotalValorVenta + documento.TotalIgv;

            }



            // Cuando existe ISC se debe recalcular el IGV.
            if (documento.TotalIsc > 0)
            {
                documento.TotalIgv = (documento.Gravadas + documento.TotalIsc) * documento.CalculoIgv;
                // Se recalcula nuevamente el Total de Venta.
            }



        }

        private void GetNoteData(ref DocumentoElectronico documento, dynamic invoice)
        {
            string desMotivo = "";
            string codNotaCredito = invoice.CodMotivoDevolucion.ToString();
            switch (codNotaCredito)
            {
                case "01":
                    desMotivo = "Anulación de la operación";
                    break;
                case "02":
                    desMotivo = "Anulación por error en el RUC";
                    break;
                case "03":
                    desMotivo = "Corrección por error en la descripción";
                    break;
                case "04":
                    desMotivo = "Descuento global";
                    break;
                case "05":
                    desMotivo = "Descuento por ítem";
                    break;
                case "06":
                    desMotivo = "Devolución tota";
                    break;
                case "07":
                    desMotivo = "Devolución por ítem";
                    break;
                case "08":
                    desMotivo = "Bonificación";
                    break;
                case "09":
                    desMotivo = "Disminución en el valor";
                    break;
                case "10":
                    desMotivo = "Otros Conceptos";
                    break;

            }

            documento.Discrepancias = new List<Discrepancia>
            {
                new Discrepancia
                {
                    Descripcion = desMotivo,
                    Tipo = codNotaCredito,
                    NroReferencia = invoice.NroRef,
                    FechaEmision = invoice.FechaRef.ToString()
                }
            };

            documento.Relacionados = new List<DocumentoRelacionado>
            {
                new DocumentoRelacionado
                {
                    NroDocumento = invoice.NroRef,
                    TipoDocumento = invoice.CodRef
                }
            };
        }

        public dynamic GetInvoice(dynamic iFacVta)
        {
            return iIFacVtaRepository.GetInvoice(iFacVta);
        }

        public void UpdateStateSend(dynamic iFacVta)
        {
            iIFacVtaRepository.UpdateStateSend(iFacVta);
        }

        public List<dynamic> ListSendingInvoice(string año, string mes)
        {
            return iIFacVtaRepository.ListSendingInvoice(año, mes);
        }

        public List<string> LoadYears()
        {
            return iIFacVtaRepository.loadYears();
        }

        public List<dynamic> ListPendingInvoiceBoleta()
        {
            return iIFacVtaRepository.ListPendingInvoiceBoleta();
        }

        public List<dynamic> ListPendingInvoiceBoletaBajas()
        {
            return iIFacVtaRepository.ListPendingInvoiceBoletaBajas();
        }
        public void UpdateStateVoided(dynamic iFacVta)
        {
            iIFacVtaRepository.UpdateStateVoided(iFacVta);
        }

        public dynamic ListPendingInvoice(string nroDoc, string codDoc)
        {
            return iIFacVtaRepository.ListPendingInvoice(nroDoc, codDoc);
        }

        public List<dynamic> ListPendingInvoiceBajas()
        {
            return iIFacVtaRepository.ListPendingInvoiceBajas();
        }
    }
}
