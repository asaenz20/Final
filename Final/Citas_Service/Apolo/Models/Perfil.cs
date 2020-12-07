using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apolo.Models
{
    public class Perfil
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public Aficion[] Aficiones { get; set; }
        [Required]
        public DateTime nacimiento { get; set; }
        [Required]
        public String correo { get; set; }
        [Required]
        public String educacion { get; set; }
        [Required]
        public String contextura { get; set; }
        [Required]
        public byte[] foto { get; set; }
        [Required]
        public String sexo { get; set; }
        [Required]
        public String pais { get; set; }
        [Required]
        public String sexInt { get; set; }
        [Required]
        public String contexInt { get; set; }
        [Required]
        public Lugar[] lugares { get; set; }
        [Required]
        private String clave { get; set; }
        public Perfil(int Id,string nombre,DateTime naci,
            String correo,String edu,String con,String sex,String pai,String sexinn,
            String contexin)
        {
            this.nombre = nombre;
            this.id = Id;
            this.nacimiento = naci;
            this.correo = correo;
            this.educacion = edu;
            this.contextura = con;
            this.sexo = sex;
            this.pais = pai;
            this.sexInt = sexinn;
            this.contexInt = contexin;
            this.clave = clave;
        }

    }
}