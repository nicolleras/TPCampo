using System.Data.SqlClient;

namespace TPCampo.Data
{
    public class Connection
    {
        private string stringSQL = string.Empty;

        public Connection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build(); //Se obtiene la connection string a la DB que se encuentra en el archivo appsettings.json

            stringSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value; //Obtengo el connection string que se encuentra en el appsettings.json
        }

        public string getStringSQL()
        {
            return stringSQL;
        }
    }
}
