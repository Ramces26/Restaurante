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
    public class MPermisos
    {
        public DataSet dt = new DataSet();
        //private SqlConnection conext = new SqlConnection( new MConexion().GetCadenaConexion());
        private SqlConnection conext = new SqlConnection(MConexion.GetCadenaConexion());
        public List<Permisos> GetPermisos()
        {
            List<Permisos> Resultado = new List<Permisos>();
            try
            {
                dt.Clear();
                using (SqlCommand sqlCommand = new SqlCommand("GetPermisos", conext))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    conext.Open();
                    var adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    Resultado = (from DataRow dr in dt.Tables[0].Rows
                                 select new Permisos()
                                 {
                                     IdPermisos = int.Parse(dr["IdPermisos"].ToString()),
                                     Descripcion = dr["Descripcion"].ToString(),
                                     Estado = bool.Parse(dr["Estado"].ToString())
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

        public string InsertarPermiso(string valor)
        {
            string Resultado;
            try
            {
                dt.Clear();
                using (SqlCommand sqlCommand = new SqlCommand("InsertPermiso", conext))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Descripcion",valor);
                    conext.Open();
                    var adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    Resultado = (from DataRow dr in dt.Tables[0].Rows
                                 select dr["ResultadoFinal"].ToString()).FirstOrDefault();
                    conext.Close();
                }
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
            }
            return Resultado;
        }

        public string AnularPermiso(int id)
        {
            string Resultado;
            try
            {
                dt.Clear();
                using (SqlCommand sqlCommand = new SqlCommand("AnularPermiso", conext))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    conext.Open();
                    var adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    Resultado = (from DataRow dr in dt.Tables[0].Rows
                                 select dr["ResultadoFinal"].ToString()).FirstOrDefault();
                    conext.Close();
                }
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
            }
            return Resultado;
        }
    }
}
