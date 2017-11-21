using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _153264_152728.Models
{
    public class Produtos
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int qtde { get; set; }
        public virtual ICollection<LanPro> LanPro { get; set; }
    }
}