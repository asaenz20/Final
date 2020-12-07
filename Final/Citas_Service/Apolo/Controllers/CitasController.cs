using Apolo.DB;
using Apolo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Apolo.Controllers
{
    [EnableCors(origins: "*",headers:"*", methods: "*")]
    public class CitasController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Obtener(int tipo,String correo,String password)
        {
            //1 validacion de existencia del usuario y token login
            //2 Consultar un perfil con todo lo que necesite 
            //3.Listar las aficiones de un perfil
            //4.Listar los lugares de un perfil
            int b = PerfilDB.Validacion(correo,password);
            Perfil p;
            Lugar[] l;
            Aficion[] m;
            switch (tipo)
            {
                case 1:
                    if (b != 0)
                        return Ok("Ok");
                    else
                    {
                        return Ok("No existe");
                    }
                case 2:
                    if (b != 0)
                    {
                        l = PerfilDB.Lugares(b);
                        m = PerfilDB.Afliciones(b);
                        p = PerfilDB.buscarPerfil(b,l,m);
                        return Ok(p);
                    }
                    else
                    {
                        return Ok("La clave o correo asociados son incorrectos");
                    }
                case 3:
                    if (b != 0)
                    {
                        m = PerfilDB.Afliciones(b);
                        return Ok(m);
                    }
                    else
                    {
                        return Ok("La clave o correo asociados son incorrectos");
                    }
                case 4:
                    if (b != 0)
                    {
                        l = PerfilDB.Lugares(b);
                        return Ok(l);
                    }
                    else
                    {
                        return Ok("La clave o correo asociados son incorrectos");
                    }
                default:
                    return BadRequest("Debe enviar un tipo de consulta válido");
            }
           
        }
    }
}
