using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_final
{
    internal class conexion
    {
        SqlConnection cnn = new SqlConnection(
           "data source=192.168.10.2;user id=sa;Password=Hyp3r10nPr0_;database=inventario_edif;TrustServerCertificate=true");
        public SqlConnection conectar()
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
            {
                cnn.Open();
            }
            return cnn;
        }
        public void desconectar()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                cnn.Close();
            }
        }
    }
}
