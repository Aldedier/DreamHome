namespace Datos.DreamHome.ConexionOracle
{
    using System.Configuration;
    public class Utilidades
    {
        public string GetConnectionStringByName(string name)
        {
            string returnValue = null;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}
