using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_final.Modelos
{
    internal class mantenimientos
    {
        public static DataTable obtener()
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "SELECT * FROM mantenimientos";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los mantenimientos: " + ex.Message);
                return null;
            }
            finally
            {
                cnn.desconectar();
            }

        }
        public static bool Crear(string tipos, string detalles,string costo, string fechayhora_recepcion, string fechayhora_devolucion)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "INSERT INTO mantenimientos (tipos, detalles, costo, fechayhora_recepcion,fechayhora_devolucion) " +
                                  "VALUES (@tipos, @detalles, @costo, @fechayhora_recepcion, @fechayhora_devolucion)";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@tipos", tipos);
                cmd.Parameters.AddWithValue("@detalles", detalles);
                cmd.Parameters.AddWithValue("@costo", costo);
                cmd.Parameters.AddWithValue("@fechayhora_devolucion", fechayhora_devolucion);
                cmd.Parameters.AddWithValue("@fechayhora_recepcion", fechayhora_recepcion);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el autor: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Editar(int mantenimientos_id, string tipo, string detalles, string costo, string fechayhora_recepcion, string fechayhora_devolucion)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "UPDATE mantenimentos SET tipo=@tipo, detalles=@detalles, costo=@costo, " +
                                  "fechayhora_recepcion=@fechayhora_recepcion, fechayhora_devolucion=@fechayhora_devolucion WHERE mantenimientos_id=@mantenimientos_id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@detalles", detalles);
                cmd.Parameters.AddWithValue("@costo", costo);
                cmd.Parameters.AddWithValue("@fechayhora_recepcion", fechayhora_recepcion);
                cmd.Parameters.AddWithValue("@fechayhora_devolucion", fechayhora_devolucion);
                cmd.Parameters.AddWithValue("@mantenimientos_id", mantenimientos_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el Mantenimiento: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Eliminar(int mantenimientos_id)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "DELETE FROM mantenimientos WHERE mantenimientos_id=@mantenimientos_id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@mantenimientos_id", mantenimientos_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar mantenimiento: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
    }
}
