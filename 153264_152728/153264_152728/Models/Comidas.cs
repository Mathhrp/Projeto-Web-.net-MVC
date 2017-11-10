using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _153264_152728.Models
{
    public class Comidas
    {
        [Key]
        public int IdComida { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}