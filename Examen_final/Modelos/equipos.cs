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
    internal class equipos
    {
        public static DataTable obtener()
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "SELECT * FROM equipos";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los equipos: " + ex.Message);
                return null;
            }
            finally
            {
                cnn.desconectar();
            }

        }
        public static bool Crear(string no_serie, string nombre, string marca, string modelo, string fecha_adquirida, string valor)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "INSERT INTO equipos ( no_serie,nombre, marca, modelo,fecha_adquirida,valor ) " +
                                  "VALUES (@no_serie,@nombre, @marca, @modelo, @fecha_adquirida,@valor )";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@no_serie", no_serie);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@marca", marca); 
                cmd.Parameters.AddWithValue("@modelo", modelo);
                cmd.Parameters.AddWithValue("@fecha_aquirida", fecha_adquirida);
                cmd.Parameters.AddWithValue("@valor", valor);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el equipos: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Editar(int equipos_id, string no_serie, string nombre, string marca, string modelo, string fecha_adquirida, string valor)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "UPDATE equipos SET  no_serie=@no_serie,nombre=@nombre, fecha_adquirida=@fecha_adquirida, " +
                                  "marca=@marca, modelo=@modelo, valor=@valor WHERE autores_id=@autores_id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                    cmd.Parameters.AddWithValue("@no_serie", no_serie); 
                cmd.Parameters.AddWithValue("@nombres", nombre);
                cmd.Parameters.AddWithValue("@marca", marca);
                cmd.Parameters.AddWithValue("@modelo", modelo);
                cmd.Parameters.AddWithValue("@fecha_adquirida", fecha_adquirida );
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@equipos_id", equipos_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el equipos: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Eliminar(int equipos_id)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "DELETE FROM equipos WHERE equipos_id=@equipos_id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@equipos_id", equipos_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el equipos: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
    }
}
