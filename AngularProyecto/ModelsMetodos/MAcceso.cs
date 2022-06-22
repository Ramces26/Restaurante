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
    public class MAcceso
    {
        public DataSet dt = new DataSet();
        private SqlConnection conext = new SqlConnection(MConexion.GetCadenaConexion());
        public Acceso.AcceResultado GetLogeo(string usu,string contra)
        {
            Acceso.AcceResultado Resultado = new Acceso.AcceResultado();
            try
            {
                dt.Clear();
                using (SqlCommand sqlCommand = new SqlCommand("GetLogin", conext))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Usuario", usu);
                    sqlCommand.Parameters.AddWithValue("@Contraseña", contra);
                    conext.Open();
                    var adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    Resultado = (from DataRow dr in dt.Tables[0].Rows
                                 select new Acceso.AcceResultado()
                                 {
                                     ResultadoFinal = dr["ResultadoFinal"].ToString(),
                                     IdAcceso = int.Parse(dr["IdAcceso"].ToString()),
                                     Usuario = dr["Usuario"].ToString(),
                                     IdPersona = int.Parse(dr["IdPersona"].ToString()),
                                     PNombre = dr["PNombre"].ToString(),
                                     SNombre = dr["SNombre"].ToString(),
                                     PApellido = dr["PApellido"].ToString(),
                                     SApellido = dr["SApellido"].ToString(),
                                     IdPermiso = int.Parse(dr["IdPermiso"].ToString()),
                                     Descripcion = dr["Descripcion"].ToString()
                                 }).FirstOrDefault();
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
