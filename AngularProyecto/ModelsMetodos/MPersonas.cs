using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularProyecto.Models;
using AngularProyecto.ModelsMetodos;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AngularProyecto.ModelsMetodos
{
    public class MPersonas
    {
        public DataSet dt = new DataSet();
        private SqlConnection conext = new SqlConnection(MConexion.GetCadenaConexion());
        private List<SpParametros> Parametros = new List<SpParametros>();
        public List<Personas> GetPersonas()
        {
            List<Personas> Resultado = new List<Personas>();
            try
            {
                dt.Clear();
                using (SqlCommand sqlCommand = new SqlCommand("GetPersonas", conext))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    conext.Open();
                    var adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    Resultado = (from DataRow dr in dt.Tables[0].Rows
                                 select new Personas()
                                 {
                                     IdPersona = int.Parse(dr["IdPersona"].ToString()),
                                     Cedula = dr["Cedula"].ToString(),
                                     PNombre = dr["PNombre"].ToString(),
                                     SNombre = dr["SNombre"].ToString(),
                                     PApellido = dr["PApellido"].ToString(),
                                     SApelldio = dr["SApellido"].ToString(),
                                     Sexo = dr["Sexo"].ToString(),
                                     FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                                     Celular = int.Parse(dr["Celular"].ToString()),
                                     Correo = dr["Correo"].ToString(),
                                     EstadoCivil = dr["EstadoCivil"].ToString(),
                                     Direccion = dr["Direccion"].ToString(),
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
        public string InsertPersonas(Personas personas)
        {
            string Resultado;
            try
            {
                dt.Clear();
                Type t = personas.GetType();
                PropertyInfo[] props =t.GetProperties();
                using (SqlCommand sqlCommand = new SqlCommand("InsertPersona", conext))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                   Parametros = new MParametros().ConsultaParametros("InsertPersona");
                    foreach (var item in Parametros)
                    {
                        foreach (var item2 in props)
                        {
                            if(item.Parametro == "@"+item2.Name)
                            {
                                var value = item2.GetValue(personas);
                                var op = item.Parametro.ToString();
                                sqlCommand.Parameters.AddWithValue(item.Parametro.ToString(), item2.GetValue(personas));
                            }
                        }
                    }
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
