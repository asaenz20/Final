using Apolo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apolo.Controllers
{
    public class ImagenController : ApiController
    {
        [HttpGet]
       public IHttpActionResult Imagen(int tipo,int idP,int idO)
        {
            //IdP es el id del perfilm e IdO es el id ya sea el lugar o la aficion segun corresponda.
            // 1 Obtener la foto de un perfil
            // 2 Obtener la imagen de una afición
            // 3 Obtener la imagen de un lugar
            byte[] b;
            switch (tipo)
            {
                case 1:
                    b = PerfilDB.ObtenerFotoPerfil(idP);
                    if (b != null)
                        return Ok(b);
                    else
                    {
                        return Ok("No se encontraron fotos con los datos admnistrados");
                    }
                case 2:
                    b = PerfilDB.ObtenerFotoAficion(idP,idO);
                    if (b != null)
                        return Ok(b);
                    else
                    {
                        return Ok("No se encontraron fotos con los datos admnistrados");
                    }
                case 3:
                    b = PerfilDB.ObtenerFotoLugar(idP, idO);
                    if (b != null)
                        return Ok(b);
                    else
                    {
                        return Ok("No se encontraron fotos con los datos admnistrados");
                    }
                default:
                    return BadRequest("Debe enviar un tipo de consulta válido");
            }
        }
    }
}
