using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _152728_153264.Models
{
    public class Lanche
    {
        public int LancheID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Preco { get; set; }

        public virtual ICollection<LancheProduto> LancheProduto { get; set; }
        public virtual ICollection<PedidoLanche> PedidoLanche { get; set; }
    }
}