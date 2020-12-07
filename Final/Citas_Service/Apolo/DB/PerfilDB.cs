using Apolo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Apolo.DB
{
    public class PerfilDB
    {
        //Crea una lista con las Afliciones de un perfil 
        public static Aficion[] Afliciones(int id)
        {
            BaseDatos db = Conexion.Conectar();
            DataTable dt = db.Aflicionesdt(id);
            Aficion[] b = new Aficion[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                b[i] = new Aficion(dr["Aficion"].ToString(),(int)dr["Id"]);
            }
            return b;
        }
        //Crea una lista con los lugares que ha visitado un perfil
        public static Lugar[] Lugares(int id)
        {
            BaseDatos db = Conexion.Conectar();
            DataTable dt = db.Lugaresdt(id);
            Lugar[] b = new Lugar[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                b[i] = new Lugar(dr["Lugar"].ToString(),(int)dr["Id"]);
            }
            return b;
        }
        //Busca un perfil modelandolo y creandolo
        public static Perfil buscarPerfil(int id, Lugar[] l, Aficion[] m)
        {
            BaseDatos db = Conexion.Conectar();
            try
            {
                DataTable dt = db.PerfilId(id);
                DataRow dr = dt.Rows[0];
                //Se crea el objeto perfil encontrado
                Perfil p = new Perfil(id,(String)dr["Nombre"], (DateTime)dr["FechaNacimiento"], (String)dr["Correo"],
                    (String)dr["Educacion"], (String)dr["Contextura"], (String)dr["Sexo"], (String)dr["Pais"],
                    (String)dr["SexoInteres"], (String)dr["ContexturaInteres"]);

                //Se obtiene la foto del perfil 
                DataTable dtfotoperfil = db.FotoPerfil(id);
                if (dtfotoperfil.Rows.Count == 0)
                    p.foto = null;
                else
                {
                    DataRow rw = dtfotoperfil.Rows[0];
                    p.foto = (byte[])rw["Foto"];
                }
  
                //Se obtienen las fotos del perfil asignado lugar
                for (int i = 0; i < l.Length; i++)
                {
                    DataTable dtl = db.FotoLugar(id,l[i].id);
                        DataRow drl = dtl.Rows[0];
                        l[i].Foto = (byte[])drl["Foto"]; 
                }
                p.lugares = l;
                //Se obtienen las fotos del perfil asignado aficion
                for (int i = 0; i < m.Length; i++)
                {
                    DataTable dtl = db.FotoAficion(id, m[i].id);
                    DataRow drl = dtl.Rows[0];
                    m[i].Foto = (byte[])drl["Foto"];
                }
                p.Aficiones = m;
                return p;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }
        //Obtiene la foto de un perfil en base 64
        public static byte[] ObtenerFotoPerfil(int Id)
        {
            BaseDatos db = Conexion.Conectar();
            try
            {
                DataTable dt = db.FotoPerfil(Id);
                if (dt != null && dt.Rows.Count > 0)
                    return (byte[])dt.Rows[0]["Foto"];
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la foto de perfil\n" + ex.Message);
            }
        }
        //Obtiene la foto de una aficion segun el id del perfil en base 64
        public static byte[] ObtenerFotoAficion(int Id,int IdO)
        {
            BaseDatos db = Conexion.Conectar();
            try
            {
                DataTable dt = db.FotoAficion(Id, IdO);
                if (dt != null && dt.Rows.Count > 0)
                    return (byte[])dt.Rows[0]["Foto"];
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la foto de la aficion\n" + ex.Message);
            }
           
        }
        //Obtiene la foto de un lugar segun el id del perfil en base 64
        public static byte[] ObtenerFotoLugar(int Id, int IdO)
        {
            BaseDatos db = Conexion.Conectar();
            try
            {
                DataTable dt = db.FotoLugar(Id, IdO);
                if (dt != null && dt.Rows.Count > 0)
                    return (byte[])dt.Rows[0]["Foto"];
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la foto del lugar\n" + ex.Message);
            }

        }
        //Valida la existencia de un perfil segun su correo y contraseña
        public static int Validacion(String correo,String password)
        {
            if(correo==null && password == null)
            {
                return 0;
            }
            else
            {
                BaseDatos db = Conexion.Conectar();
                try
                {
                    DataTable dt = db.validar(correo, password);
                    int b = 0;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        return b = (int)dr["Id"];
                    }
                    else
                    {
                        return b;
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }

            }
        }
    }
    
}