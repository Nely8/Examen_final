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
    internal class edificio
    {
        public static DataTable obtener()
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "SELECT * FROM edificios";
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
        public static bool Crear(string nombre, string direccion)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "INSERT INTO edificios (nombre,direccion) " +
                                  "VALUES (@nombre, @direccion)";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@direccion", direccion);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el edificio: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Editar(int edificios_id, string nombre, string direccion)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "UPDATE edificio SET nombre=@nombre, direccion=@direccion" +
                                  " WHERE edificios_id=@edificios_id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@edificios_id", edificios_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el edificios: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Eliminar(int edificios_id)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "DELETE FROM edificios WHERE edificios_id=@edificio_id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@edificios_id", edificios_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar edificios: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
    }
}
