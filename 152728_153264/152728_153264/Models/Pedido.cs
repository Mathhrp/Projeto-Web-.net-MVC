using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _152728_153264.Models
{
    public class Pedido
    {

        public int PedidoId { get; set; }
        [Required]
        [DisplayName("Cod")]
        public string Nome { get; set; }
        [Required]
        [DataType("DateTime")]
        public string Data { get; set; }

        [Required]
        public string Endereco { get; set; }

        public virtual ICollection<PedidoLanche> PedidoLanche { get; set; }



    }
}