using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Datos
{
    public class DConexion
    {
        public static IConfiguration Configuration { get; set; }

        public SqlConnection ConectarBD_PRUEBA()
        {
            SqlConnection cn = new();
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                Configuration = builder.Build();

                string server = Decoder_BL.BL.Crypto.Decrypt(Configuration.GetSection("CredentialBD").GetSection("serverSURA").Value);
                string database = Decoder_BL.BL.Crypto.Decrypt(Configuration.GetSection("CredentialBD").GetSection("bdSURA").Value);
                string user = Decoder_BL.BL.Crypto.Decrypt(Configuration.GetSection("CredentialBD").GetSection("usuarioSURA").Value);
                string password = Decoder_BL.BL.Crypto.Decrypt(Configuration.GetSection("CredentialBD").GetSection("passwordSURA").Value);

                string cadenaConexion = Configuration.GetConnectionString("conexionBD").ToString();
                cn.ConnectionString = string.Format(cadenaConexion, server, database, user, password, false);
            }
            catch (Exception)
            {
                throw;
            }
            return cn;
        }
    }
}
