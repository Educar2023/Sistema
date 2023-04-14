using FacturacionElectronica.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;

namespace FacturacionElectronica.repository.implement
{
    public class TickectSunatRepositoryImpl : ITickectSunatRepository
    {
        public void Insertar(dynamic ticket)
        {
            string query = "INSERTAR_TICKET_SUNAT";
            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@NRO_TICKET",ticket.NroTicket),
                DBHelper.MakeParam("@TIPO_DOC",ticket.TipoDoc),
                DBHelper.MakeParam("@NRO_DOC",ticket.NroDoc),
                DBHelper.MakeParam("@TIPO",ticket.Tipo),
                DBHelper.MakeParam("@ESTADO",ticket.Estado),
                DBHelper.MakeParam("@ARCHIVO_XML",ticket.ArchivoXml),
                DBHelper.MakeParam("@ARCHIVO_CDR",ticket.ArchivoCdr),
                DBHelper.MakeParam("@FECHA",DateTime.Now)

            };

            DBHelper.ExecuteProcedure(query, param);
        }

        public void Update(dynamic ticket)
        {
            string query = "UPDATE_TICKET_SUNAT";
            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@NRO_TICKET",ticket.NroTicket),
                DBHelper.MakeParam("@ESTADO",ticket.Estado),
                DBHelper.MakeParam("@ARCHIVO_CDR",ticket.ArchivoCdr)
            };

            DBHelper.ExecuteProcedure(query, param);
        }


        public List<dynamic> Listar(string tipo, DateTime fechaDe, DateTime fechaHasta)
        {
            string query = "LISTAR_TICKET_SUNAT";
            List<dynamic> lista = new List<dynamic>();

            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@FECHA_INICIO",fechaDe),
                DBHelper.MakeParam("@FECHA_FIN",fechaHasta),
                DBHelper.MakeParam("@TIPO",tipo)
            };

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query, param))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dynamic ticketSunat = new ExpandoObject();
                        ticketSunat.Id = dr[0];
                        ticketSunat.NroTicket = dr[1];
                        ticketSunat.NroDoc = dr[2];
                        ticketSunat.TipoDoc = dr[3];
                        ticketSunat.Tipo = dr[4];
                        ticketSunat.Estado = dr[5];
                        ticketSunat.ArchivoXml = dr[6];
                        ticketSunat.ArchivoCdr = dr[7];
                        ticketSunat.Fecha = dr[8];
                        lista.Add(ticketSunat);
                    }
                }
            }

            return lista;
        }
    }
}
