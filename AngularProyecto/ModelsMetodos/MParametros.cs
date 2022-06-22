using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularProyecto.Models;
using AngularProyecto.ModelsMetodos;
using System.Data;
using System.Data.SqlClient;

namespace AngularProyecto.ModelsMetodos
{
    public class MParametros
    {
        public DataSet dt = new DataSet();
        private SqlConnection conext = new SqlConnection(MConexion.GetCadenaConexion());
        public List<SpParametros> ConsultaParametros(string valor)
        {
            List<SpParametros> Resultado = new List<SpParametros>();
            try
            {
                dt.Clear();
                using (SqlCommand sqlCommand = new SqlCommand("ConsultarParametros", conext))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@valor",valor);
                    conext.Open();
                    var adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    Resultado = (from DataRow dr in dt.Tables[0].Rows
                                 select new SpParametros()
                                 {
                                     Parametro = dr["Parametro"].ToString(),
                                     Tipo = dr["Tipo"].ToString(),
                                     Esquema= dr["Esquema"].ToString(),
                                     NombreSp = dr["NombreSp"].ToString()
                                 }).ToList();
                    conext.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                dt.Clear();
            }
            return Resultado;
        }
    }
}
