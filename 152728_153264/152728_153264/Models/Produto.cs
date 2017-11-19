using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _152728_153264.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int qtde { get; set; }

        public virtual ICollection<LancheProduto> LancheProduto { get; set; }
    }
}