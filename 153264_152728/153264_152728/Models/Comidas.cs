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
        
        public Comidas()
        {
            this.Produtos = new HashSet<Produto>();
            this.Pedidos = new HashSet<Pedido>();
        }

        [Key]
        public int IdComida { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}