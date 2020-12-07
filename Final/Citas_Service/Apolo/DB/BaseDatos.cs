
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Profile;

public class BaseDatos
{
    private SqlConnection cn;
    private string strConexion;

    public string CadenaConexion
    {
        get
        {
            return this.strConexion;
        }
        set
        {
            this.strConexion = value;
            cn = (SqlConnection)null;
        }
    }

    public SqlConnection Conexion
    {
        get
        {
            return cn;
        }
    }

    public BaseDatos()
    {
        this.strConexion = "";
    }

    public BaseDatos(string strConexion)
    {
        this.strConexion = strConexion;
    }

    public bool Conectar()
    {
        try
        {
            if (cn == null || cn.State == ConnectionState.Closed)
            {
                cn = new SqlConnection(strConexion);
                cn.Open();
            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al conectarse a la base de datos:\n" + ex.Message);
        }
    }//Conectar

    public bool Cerrar()
    {
        try
        {
            cn.Close();
            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al cerrar la conexión a la base de datos:\n" + ex.Message);
        }
    }

  
    public DataTable PerfilId(int id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da=null;
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            da = new SqlDataAdapter("spObtenerPerfil", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int);
            da.SelectCommand.Parameters["@Id"].Value = id;
            da.Fill(dt);
            return dt;
        }
        catch(Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }
    public DataTable PerfilCorreo(String correo)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = null;
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            da = new SqlDataAdapter("spObtenerPerfilEmail", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@Email"].Value = correo;
            da.Fill(dt);
            return dt;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }
    public DataTable Aflicionesdt(int id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = null;
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            da = new SqlDataAdapter("spListarPerfilAficion", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdPerfil", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdPerfil"].Value = id;
            da.Fill(dt);
            return dt;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }
    public DataTable Lugaresdt(int id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = null;
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            da = new SqlDataAdapter("spListarPerfilLugar", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdPerfil", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdPerfil"].Value = id;
            da.Fill(dt);
            return dt;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }
    public DataTable validar(String correo,String Password)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = null;
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            da = new SqlDataAdapter("spValidarAcceso", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Usuario", SqlDbType.NVarChar);
            da.SelectCommand.Parameters.Add("@Clave", SqlDbType.NVarChar);
            da.SelectCommand.Parameters["@Usuario"].Value = correo;
            da.SelectCommand.Parameters["@Clave"].Value = Password;
            da.Fill(dt);
            return dt;

        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataTable FotoPerfil(int Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = null;
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            da = new SqlDataAdapter("spObtenerFoto", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int);
            da.SelectCommand.Parameters["@Id"].Value = Id;
            da.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataTable FotoAficion(int IdP,int IdO)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = null;
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            da = new SqlDataAdapter("spObtenerImagenAficion", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdPerfil", SqlDbType.Int);
            da.SelectCommand.Parameters.Add("@IdAficion", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdPerfil"].Value = IdP;
            da.SelectCommand.Parameters["@IdAficion"].Value = IdO;
            da.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataTable FotoLugar(int IdP, int IdO)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = null;
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            da = new SqlDataAdapter("spObtenerImagenLugar", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdPerfil", SqlDbType.Int);
            da.SelectCommand.Parameters.Add("@IdLugar", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdPerfil"].Value = IdP;
            da.SelectCommand.Parameters["@IdLugar"].Value = IdO;
            da.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataTable Consultar(string strConsulta)
    {
        SqlDataAdapter da = null;
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            DataTable dataTable = new DataTable();
            da = new SqlDataAdapter(strConsulta, cn);
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dataTable);
            return dataTable;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al consultar la base de datos:\n" + ex.Message);
        }
        finally
        {
            if (cn != null)
                cn.Dispose();
            if (da != null)
                da.Dispose();
        }
    }//Consultar

    public DataSet ConsultarDS(string strConsulta)
    {
        DataSet ds = new DataSet();
        if (!this.Conectar())
            return (DataSet)null;
        try
        {
            new SqlDataAdapter(strConsulta, cn).Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al consultar la base de datos:\n" + ex.Message);
        }
        finally
        {
            if (cn != null)
                cn.Dispose();
            if (ds != null)
                ds.Dispose();
        }
    }

    public DataTable Consultar(string strConsulta, SqlTransaction t)
    {
        if (!this.Conectar())
            return (DataTable)null;
        try
        {
            DataTable dataTable = new DataTable();
            new SqlDataAdapter(strConsulta, cn)
            {
                SelectCommand =
                {
                    Transaction = t
                }
            }.Fill(dataTable);
            return dataTable;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al consultar la base de datos:\n" + ex.Message);
        }
        finally
        {
            if (cn != null)
                cn.Dispose();
        }
    }

    public DataSet ConsultarDS(string strConsulta, SqlTransaction t)
    {
        if (!this.Conectar())
            return (DataSet)null;
        try
        {
            DataSet dataSet = new DataSet();
            new SqlDataAdapter(strConsulta, cn)
            {
                SelectCommand =
                {
                    Transaction = t
                }
            }.Fill(dataSet);
            return dataSet;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al consultar la base de datos:\n" + ex.Message);
        }
        finally
        {
            if (cn != null)
                cn.Dispose();
        }
    }

    public bool Actualizar(string strConsulta)
    {
        if (!this.Conectar())
            return false;
        try
        {
            SqlCommand sqlCommand = new SqlCommand(strConsulta, cn);
            sqlCommand.CommandTimeout = 1200;
            sqlCommand.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al actualizar la base de datos:\n" + ex.Message);
        }
        finally
        {
            if (cn != null)
                cn.Dispose();
        }
    }

    public bool Actualizar(string strConsulta, SqlTransaction t)
    {
        if (!this.Conectar())
            return false;
        try
        {
            SqlCommand sqlCommand = new SqlCommand(strConsulta, cn);
            sqlCommand.CommandTimeout = 1200;
            sqlCommand.Transaction = t;
            sqlCommand.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al actualizar la base de datos:\n" + ex.Message);
        }
        finally
        {
            if (cn != null)
                cn.Dispose();
        }
    }

  
  
    public int ObtenerId(string strConsulta)
    {
        try
        {
            DataTable dataTable = this.Consultar(strConsulta);
            if (dataTable != null && dataTable.Rows.Count > 0)
                return (int)dataTable.Rows[0][0];
            return -1;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al obtener clave primaria:\n" + ex.Message);
        }
    }

    public int ObtenerId(string strConsulta, SqlTransaction t)
    {
        try
        {
            DataTable dataTable = this.Consultar(strConsulta, t);
            if (dataTable != null && dataTable.Rows.Count > 0)
                return (int)dataTable.Rows[0]["Id"];
            return -1;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al obtener clave primaria:\n" + ex.Message);
        }
    }

    public bool Existe(string strConsulta)
    {
        try
        {
            DataTable dataTable = this.Consultar(strConsulta);
            return dataTable != null && dataTable.Rows.Count > 0;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al verificar consulta:\n" + ex.Message);
        }
    }
}