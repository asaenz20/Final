using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apolo.Models
{
    public class Aficion
    {
        [Required]
        public int id { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public byte[] Foto { get; set; }
        public Aficion(String Ida,int id)
        {
            this.nombre = Ida;
            this.id = id;
        }
    }
}