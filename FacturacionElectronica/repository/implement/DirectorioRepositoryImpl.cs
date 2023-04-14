using FacturacionElectronica.repository.interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;

namespace FacturacionElectronica.repository.implement
{
    public class DirectorioRepositoryImpl : IDirectorioRepository
    {
        public List<dynamic> getAll()
        {
            List<dynamic> lista = new List<dynamic>();

            string query = "ListarParametrosFE";

            using (SqlDataReader dr = DBHelper.ExecuteDataReaderProcedure(query))
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dynamic directorio = new ExpandoObject();


                        directorio.Codigo = dr[0];
                        directorio.Descripcion = dr[1];
                        lista.Add(directorio);
                    }
                }
            }

            return lista;
        }

        public void UpdateIdResumen(string code)
        {
            string query = "ActualizarCorrelativoResumen";
            SqlParameter[] param = new SqlParameter[]
            {
                DBHelper.MakeParam("@Codigo",code)
            };

            DBHelper.ExecuteProcedure(query, param);
        }
    }
}
