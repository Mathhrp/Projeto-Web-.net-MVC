using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _153264_152728.Models
{
    public class Pedido
    {
 
        [Key]
        public int IdPedido { get; set; }
        public string Nome { get; set; }
        public double Total { get; set; }
        [DataType("DateTime")]
        public string Data { get; set; }
        public string Endereco { get; set; }


        public List<Comidas> Lanches {get;set;}
    }
}