using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _152728_153264.Models
{
    public class PedidoLanche
    {
        public int PedidoLancheId { get; set; }
        [DisplayName("Pedido")]
        [Required]
        public int PedidoId { get; set; }
        [Required]
        [DisplayName("Lanche")]
        public int LancheId { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Lanche Lanche { get; set; }
    }
}