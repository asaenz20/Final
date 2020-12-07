using System;
using System.Configuration;

public class Conexion
{
    private static BaseDatos bd;

    public static BaseDatos Conectar()
    {
        try
        {
            if (Conexion.bd != null || ConfigurationManager.ConnectionStrings.Count <= 0)
                return Conexion.bd;
            Conexion.bd = new BaseDatos();
            Conexion.bd.CadenaConexion = ConfigurationManager.ConnectionStrings["cnCitas"].ConnectionString;
            return Conexion.bd.Conectar() ? Conexion.bd : (BaseDatos)null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al acceder la base de datos\n" + ex.Message);
        }
    }
}
