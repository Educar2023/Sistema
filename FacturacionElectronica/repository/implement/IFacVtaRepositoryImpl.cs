using FacturacionElectronica.constant;
using FacturacionElectronica.repository.interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;

namespace FacturacionElectronica.repository.implement
{
    public class IFacVtaRepositoryImpl : IIFacVtaRepository
    {
        public List<dynamic> ListPendingInvoice()
        {
            List<dynamic> lista = new List<dynamic>();

            string query = "MOSTRAR_IFACT_VTA_FE_PENDIENTE";

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dynamic factura = new ExpandoObject();


                        factura.CoSucursal = dr[0];
                        factura.DesSucursal = dr[1];
                        factura.CodClase = dr[2];
                        factura.DesClase = dr[3];
                        factura.CodDoc = dr[4];
                        factura.NroDoc = dr[5];
                        factura.FechaDoc = dr[6];
                        factura.CodCliente = dr[7];
                        factura.DesCliente = dr[8];
                        factura.DocCliente = dr[9];
                        factura.CodMoneda = dr[10];
                        factura.DesMoneda = dr[11];
                        factura.Observacion = dr[12];
                        factura.Año = dr[13];
                        factura.Mes = dr[14];
                        factura.Tipo = dr[15];
                        factura.CodRef = dr[16];
                        factura.NroRef = dr[17];
                        factura.FechaRef = dr[18];
                        factura.Condicion = dr[19];
                        factura.FormaPago = dr[20];
                        factura.NroPedido = dr[21];
                        factura.Origen = dr[22];
                        factura.NroGuia = dr[23];
                        factura.Id = dr[24];
                        factura.CodMotivoDevolucion = dr[25];
                        factura.PorcentajeDetraccion = dr[26];
                        factura.MontoDetraccion = dr[27];
                        factura.MedioPagoDetraccion = dr[28];

                        lista.Add(factura);
                    }
                }
            }

            return lista;
        }

        public dynamic ListPendingInvoice(string nroDoc, string codDoc)
        {
            dynamic factura = new ExpandoObject();


            string query = "MOSTRAR_IFACT_VTA_FE_NRO_DOC";


            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@NRO_DOC", nroDoc),
                DBHelper.MakeParam("@COD_DOC", codDoc)

            };

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {


                        factura.CoSucursal = dr[0];
                        factura.DesSucursal = dr[1];
                        factura.CodClase = dr[2];
                        factura.DesClase = dr[3];
                        factura.CodDoc = dr[4];
                        factura.NroDoc = dr[5];
                        factura.FechaDoc = dr[6];
                        factura.CodCliente = dr[7];
                        factura.DesCliente = dr[8];
                        factura.DocCliente = dr[9];
                        factura.CodMoneda = dr[10];
                        factura.DesMoneda = dr[11];
                        factura.Observacion = dr[12];
                        factura.Año = dr[13];
                        factura.Mes = dr[14];
                        factura.Tipo = dr[15];
                        factura.CodRef = dr[16];
                        factura.NroRef = dr[17];
                        factura.FechaRef = dr[18];
                        factura.Condicion = dr[19];
                        factura.FormaPago = dr[20];
                        factura.NroPedido = dr[21];
                        factura.Origen = dr[22];
                        factura.NroGuia = dr[23];
                        factura.Id = dr[24];
                        factura.CodMotivoDevolucion = dr[25];
                        factura.PorcentajeDetraccion = dr[26];
                        factura.MontoDetraccion = dr[27];
                        factura.MedioPagoDetraccion = dr[28];

                    }
                }
            }

            return factura;
        }

        public List<dynamic> ListPendingInvoiceBoleta()
        {
            List<dynamic> lista = new List<dynamic>();

            string query = "MOSTRAR_IFACT_VTA_FE_BOLETA_PENDIENTE";

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dynamic factura = new ExpandoObject();


                        factura.CoSucursal = dr[0];
                        factura.DesSucursal = dr[1];
                        factura.CodClase = dr[2];
                        factura.DesClase = dr[3];
                        factura.CodDoc = dr[4];
                        factura.NroDoc = dr[5];
                        factura.FechaDoc = dr[6];
                        factura.CodCliente = dr[7];
                        factura.DesCliente = dr[8];
                        factura.DocCliente = dr[9];
                        factura.CodMoneda = dr[10];
                        factura.DesMoneda = dr[11];
                        factura.Observacion = dr[12];
                        factura.Año = dr[13];
                        factura.Mes = dr[14];
                        factura.Tipo = dr[15];
                        factura.CodRef = dr[16];
                        factura.NroRef = dr[17];
                        factura.FechaRef = dr[18];
                        factura.Condicion = dr[19];
                        factura.FormaPago = dr[20];
                        factura.NroPedido = dr[21];
                        factura.Origen = dr[22];
                        factura.NroGuia = dr[23];
                        factura.Id = dr[24];
                        factura.CodMotivoDevolucion = dr[25];
                        factura.PorcentajeDetraccion = dr[26];
                        factura.MontoDetraccion = dr[27];
                        factura.MedioPagoDetraccion = dr[28];

                        lista.Add(factura);
                    }
                }
            }

            return lista;
        }

        public List<dynamic> ListPendingInvoiceBoletaBajas()
        {
            List<dynamic> lista = new List<dynamic>();

            string query = "MOSTRAR_IFACT_VTA_FE_BOLETA_BAJA";

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dynamic factura = new ExpandoObject();


                        factura.CoSucursal = dr[0];
                        factura.DesSucursal = dr[1];
                        factura.CodClase = dr[2];
                        factura.DesClase = dr[3];
                        factura.CodDoc = dr[4];
                        factura.NroDoc = dr[5];
                        factura.FechaDoc = dr[6];
                        factura.CodCliente = dr[7];
                        factura.DesCliente = dr[8];
                        factura.DocCliente = dr[9];
                        factura.CodMoneda = dr[10];
                        factura.DesMoneda = dr[11];
                        factura.Observacion = dr[12];
                        factura.Año = dr[13];
                        factura.Mes = dr[14];
                        factura.Tipo = dr[15];
                        factura.CodRef = dr[16];
                        factura.NroRef = dr[17];
                        factura.FechaRef = dr[18];
                        factura.Condicion = dr[19];
                        factura.FormaPago = dr[20];
                        factura.NroPedido = dr[21];
                        factura.Origen = dr[22];
                        factura.NroGuia = dr[23];
                        factura.Id = dr[24];
                        factura.CodMotivoDevolucion = dr[25];
                        factura.PorcentajeDetraccion = dr[26];
                        factura.MontoDetraccion = dr[27];
                        factura.MedioPagoDetraccion = dr[28];

                        lista.Add(factura);
                    }
                }
            }

            return lista;
        }

        public List<dynamic> ListPendingInvoiceBajas()
        {
            List<dynamic> lista = new List<dynamic>();

            string query = "MOSTRAR_IFACT_VTA_FE_FACTURA_BAJA";

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dynamic factura = new ExpandoObject();


                        factura.CoSucursal = dr[0];
                        factura.DesSucursal = dr[1];
                        factura.CodClase = dr[2];
                        factura.DesClase = dr[3];
                        factura.CodDoc = dr[4];
                        factura.NroDoc = dr[5];
                        factura.FechaDoc = dr[6];
                        factura.CodCliente = dr[7];
                        factura.DesCliente = dr[8];
                        factura.DocCliente = dr[9];
                        factura.CodMoneda = dr[10];
                        factura.DesMoneda = dr[11];
                        factura.Observacion = dr[12];
                        factura.Año = dr[13];
                        factura.Mes = dr[14];
                        factura.Tipo = dr[15];
                        factura.CodRef = dr[16];
                        factura.NroRef = dr[17];
                        factura.FechaRef = dr[18];
                        factura.Condicion = dr[19];
                        factura.FormaPago = dr[20];
                        factura.NroPedido = dr[21];
                        factura.Origen = dr[22];
                        factura.NroGuia = dr[23];
                        factura.Id = dr[24];
                        factura.CodMotivoDevolucion = dr[25];
                        factura.PorcentajeDetraccion = dr[26];
                        factura.MontoDetraccion = dr[27];
                        factura.MedioPagoDetraccion = dr[28];

                        lista.Add(factura);
                    }
                }
            }

            return lista;
        }
        public dynamic GetDataCustomer(string codCliente)
        {
            dynamic cliente = new ExpandoObject();
            string query = "MOSTRAR_DATOS_CLIENTE";

            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@COD_PER", codCliente)

            };


            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cliente.Codigo = dr[0];
                        cliente.Tipodocumento = dr[1];
                        cliente.Ruc = dr[2];
                        cliente.RazonSocial = dr[3];
                        cliente.NombreComercial = dr[4];
                        cliente.Email = dr[5];
                        cliente.Direccion = dr[6];
                    }
                }
            }

            return cliente;
        }

        public dynamic GetDataSupplier()
        {
            dynamic emisor = new ExpandoObject();
            string query = "ObtenerDatosEmpresaFE";

            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@COD_EMPRESA", DBCredential.CodBase)
            };


            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        emisor.Ubigeo = dr[0];
                        emisor.Direccion = dr[1];
                        emisor.Departamento = dr[2];
                        emisor.Provincia = dr[3];
                        emisor.Distrito = dr[4];
                        emisor.Ruc = dr[5];
                        emisor.RazonSocial = dr[6];
                        emisor.Telefonos = dr[7];
                    }
                }
            }
            return emisor;
        }

        public dynamic GetDataGuia(dynamic iFacVta)
        {
            dynamic guia = null;

            string query = "MOSTRAR_DATOS_GUIA_FE";

            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@COD_SUCURSAL",iFacVta.CoSucursal),
                DBHelper.MakeParam("@COD_CLASE",iFacVta.CodClase),
                DBHelper.MakeParam("@COD_PER",iFacVta.CodCliente),
                DBHelper.MakeParam("@NRO_DOC",iFacVta.NroDoc),
                DBHelper.MakeParam("@COD_DOC",iFacVta.CodDoc)
            };

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    guia = new ExpandoObject();
                    while (dr.Read())
                    {
                        guia.Numero = dr[0];
                        guia.Codigo = dr[1];
                    }
                }
            }

            return guia;
        }

        public dynamic GetInvoice(dynamic iFacVta)
        {
            dynamic factura = new ExpandoObject();


            string query = "ObtenerIFactVta";

            SqlParameter[] param = new SqlParameter[]
           {
                DBHelper.MakeParam("@COD_SUCURSAL",iFacVta.CoSucursal),
                DBHelper.MakeParam("@COD_CLASE",iFacVta.CodClase),
                DBHelper.MakeParam("@COD_PER",iFacVta.CodCliente),
                DBHelper.MakeParam("@NRO_DOC",iFacVta.NroDoc),
                DBHelper.MakeParam("@COD_DOC",iFacVta.CodDoc),
                DBHelper.MakeParam("@FE_AÑO",iFacVta.Año),
                DBHelper.MakeParam("@FE_MES",iFacVta.Mes),
           };

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {


                        factura.CoSucursal = dr[0];
                        factura.DesSucursal = dr[1];
                        factura.CodClase = dr[2];
                        factura.DesClase = dr[3];
                        factura.CodDoc = dr[4];
                        factura.NroDoc = dr[5];
                        factura.FechaDoc = dr[6];
                        factura.CodCliente = dr[7];
                        factura.DesCliente = dr[8];
                        factura.DocCliente = dr[9];
                        factura.CodMoneda = dr[10];
                        factura.DesMoneda = dr[11];
                        factura.Observacion = dr[12];
                        factura.Año = dr[13];
                        factura.Mes = dr[14];
                        factura.Tipo = dr[15];
                        factura.CodRef = dr[16];
                        factura.NroRef = dr[17];
                        factura.FechaRef = dr[18];
                        factura.Condicion = dr[19];
                        factura.FormaPago = dr[20];
                        factura.NroPedido = dr[21];
                        factura.Origen = dr[22];
                        factura.NroGuia = dr[23];
                        factura.Id = dr[24];
                        factura.CodMotivoDevolucion = dr[25];
                        factura.PorcentajeDetraccion = dr[26];
                        factura.MontoDetraccion = dr[27];
                        factura.MedioPagoDetraccion = dr[28];
                    }
                }
            }

            return factura;
        }

        public List<string> GetEmailCustomer(string codCliente)
        {
            List<string> emails = new List<string>();
            string query = "MOSTRAR_EMAIL_FE_CLIENTE";

            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@COD_PER", codCliente)

            };


            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        emails.Add(dr[0].ToString());
                    }
                }
            }

            return emails;
        }

        public void UpdateStateSend(dynamic iFacVta)
        {
            dynamic factura = new ExpandoObject();

            string query = "ACTUALIZAR_ENVIO_FE";


            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@COD_SUCURSAL",iFacVta.CoSucursal),
                DBHelper.MakeParam("@COD_CLASE",iFacVta.CodClase),
                DBHelper.MakeParam("@COD_PER",iFacVta.CodCliente),
                DBHelper.MakeParam("@NRO_DOC",iFacVta.NroDoc),
                DBHelper.MakeParam("@COD_DOC",iFacVta.CodDoc),
                DBHelper.MakeParam("@FE_AÑO",iFacVta.Año),
                DBHelper.MakeParam("@FE_MES",iFacVta.Mes),
            };

            DBHelper.ExecuteProcedure(query, param);
        }

        public void UpdateStateVoided(dynamic iFacVta)
        {
            dynamic factura = new ExpandoObject();

            string query = "ACTUALIZAR_BAJAS_FE";


            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@COD_SUCURSAL",iFacVta.CoSucursal),
                DBHelper.MakeParam("@COD_CLASE",iFacVta.CodClase),
                DBHelper.MakeParam("@COD_PER",iFacVta.CodCliente),
                DBHelper.MakeParam("@NRO_DOC",iFacVta.NroDoc),
                DBHelper.MakeParam("@COD_DOC",iFacVta.CodDoc),
                DBHelper.MakeParam("@FE_AÑO",iFacVta.Año),
                DBHelper.MakeParam("@FE_MES",iFacVta.Mes),
            };

            DBHelper.ExecuteProcedure(query, param);
        }

        public List<dynamic> ListSendingInvoice(string año, string mes)
        {
            List<dynamic> lista = new List<dynamic>();

            string query = "MOSTRAR_IFACT_VTA_FE_ENVIADOS";

            SqlParameter[] param = new SqlParameter[]
          {

                DBHelper.MakeParam("@FE_AÑO",año),
                DBHelper.MakeParam("@FE_MES",mes),
          };

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dynamic factura = new ExpandoObject();


                        factura.CoSucursal = dr[0];
                        factura.DesSucursal = dr[1];
                        factura.CodClase = dr[2];
                        factura.DesClase = dr[3];
                        factura.CodDoc = dr[4];
                        factura.NroDoc = dr[5];
                        factura.FechaDoc = dr[6];
                        factura.CodCliente = dr[7];
                        factura.DesCliente = dr[8];
                        factura.DocCliente = dr[9];
                        factura.CodMoneda = dr[10];
                        factura.DesMoneda = dr[11];
                        factura.Observacion = dr[12];
                        factura.Año = dr[13];
                        factura.Mes = dr[14];
                        factura.Tipo = dr[15];
                        factura.CodRef = dr[16];
                        factura.NroRef = dr[17];
                        factura.FechaRef = dr[18];
                        factura.Condicion = dr[19];
                        factura.FormaPago = dr[20];
                        factura.NroPedido = dr[21];
                        factura.Origen = dr[22];
                        factura.NroGuia = dr[23];
                        factura.Id = dr[24];
                        factura.CodMotivoDevolucion = dr[25];
                        factura.PorcentajeDetraccion = dr[26];
                        factura.MontoDetraccion = dr[27];
                        factura.MedioPagoDetraccion = dr[28];

                        lista.Add(factura);
                    }
                }
            }

            return lista;
        }

        public List<string> loadYears()
        {
            List<string> años = new List<string>();
            string query = "CARGAR_AÑO";

            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@COD_MODULO", "FVT")

            };


            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        años.Add(dr[0].ToString());
                    }
                }
            }

            return años;
        }
    }
}
