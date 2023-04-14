using System.Data;
using System.Data.SqlClient;

namespace FacturacionElectronica.repository
{
    public class DBHelper : DataAcces
    {

        public static SqlParameter MakeParam(string paramName, object objValue)
        {
            SqlParameter param;
            param = new SqlParameter(paramName, objValue);
            param.Value = objValue;
            return param;
        }

        public static int ExecuteProcedure(string query, SqlParameter[] dbParams)
        {

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                if (dbParams != null)
                {
                    foreach (SqlParameter dbParam in dbParams)
                    {
                        cmd.Parameters.Add(dbParam);
                    }
                }
                return cmd.ExecuteNonQuery();

            }
        }

        public static SqlDataReader ExecuteDataReaderProcedure(string query)
        {
            SqlDataReader dr;

            SqlConnection cn = new SqlConnection(ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1200;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public static SqlDataReader ExecuteDataReaderProcedure(string query, SqlParameter[] parametros)
        {
            SqlDataReader dr;

            SqlConnection cn = new SqlConnection(ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1200;
            if (parametros != null)
            {
                foreach (SqlParameter parametro in parametros)
                {
                    cmd.Parameters.Add(parametro);
                }
            }
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dr;
        }

        public static object ExecuteScalarProcedure(string query)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;
                return cmd.ExecuteScalar();
            }
        }

        public static object ExecuteScalarProcedure(string query, SqlParameter[] parametros)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 1200;
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (SqlParameter parametro in parametros)
                    {
                        cmd.Parameters.Add(parametro);
                    }
                }

                return cmd.ExecuteScalar();
            }
        }

    }
}
