using FacturacionElectronica.repository.interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;

namespace FacturacionElectronica.repository.implement
{
    public class TFacVtaRepositoryImpl : ITFacVtaRepository
    {
        public List<dynamic> getDetails(dynamic iFacVta)
        {
            List<dynamic> lista = new List<dynamic>();
            string query = "MOSTRAR_DETALLES_TFACT_FE";

            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@FE_AÑO",iFacVta.Año),
                DBHelper.MakeParam("@FE_MES",iFacVta.Mes),
                DBHelper.MakeParam("@COD_SUCURSAL",iFacVta.CoSucursal),
                DBHelper.MakeParam("@COD_CLASE",iFacVta.CodClase),
                DBHelper.MakeParam("@COD_PER",iFacVta.CodCliente),
                DBHelper.MakeParam("@NRO_DOC",iFacVta.NroDoc),
                DBHelper.MakeParam("@COD_DOC",iFacVta.CodDoc),
                DBHelper.MakeParam("@ORIGEN",iFacVta.Origen)
            };

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dynamic line = new ExpandoObject();

                        line.CoItem = dr[0];
                        line.DesItem = dr[1];
                        line.UnidadMedida = dr[2];
                        line.NumeroParte = dr[3];
                        line.Cantidad = dr[4];
                        line.ValorUnitario = dr[5];
                        line.CodigoPrecio = dr[6];
                        line.PorcentajeIgv = dr[7];
                        line.ValorIgv = dr[8];
                        line.ValorDcto = dr[9];
                        line.ValorVenta = dr[10];
                        line.PrecioVenta = dr[11];
                        line.TipoAfectacion = dr[12];
                        line.ValorReferencial = dr[13];
                        line.ValorIgvReferencial = dr[14];
                        line.Observacion = dr[15];
                        line.UnidadMedidaSunat = dr[16];
                        lista.Add(line);
                    }
                }
            }

            return lista;
        }



        public List<dynamic> getExportCharges(dynamic iFacVta)
        {
            List<dynamic> lista = new List<dynamic>();
            string query = "MOSTRAR_DETALLES_TFACT_FE";

            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@FE_AÑO",iFacVta.Año),
                DBHelper.MakeParam("@FE_MES",iFacVta.Mes),
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
                    while (dr.Read())
                    {
                        dynamic line = new ExpandoObject();

                        line.CoItem = dr[0];
                        line.DesItem = dr[1];
                        line.UnidadMedida = dr[2];
                        line.Cantidad = dr[3];
                        line.ValorUnitario = dr[4];
                        line.CodigoPrecio = dr[5];
                        line.PorcentajeIgv = dr[6];
                        line.ValorIgv = dr[7];
                        line.ValorDcto = dr[8];
                        line.ValorVenta = dr[9];
                        line.PrecioVenta = dr[10];
                        line.TipoAfectacion = dr[11];
                        line.ValorReferencial = dr[12];
                        line.ValorIgvReferencial = dr[13];
                        lista.Add(line);
                    }
                }
            }

            return lista;
        }
    }
}
