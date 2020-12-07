using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apolo.Models
{
    public class Lugar
    {
        [Required]
        public int id { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public byte[] Foto { get; set; }
        public Lugar(String name,int id)
        {
            this.nombre = name;
            this.id = id;
        }
    }
}