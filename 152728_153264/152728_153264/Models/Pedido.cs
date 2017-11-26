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
<<<<<<< HEAD
        public DateTime Data { get; set; }
=======
        [System.Web.Mvc.HiddenInput(DisplayValue =false)]
        public DataType Data { get; set; }
>>>>>>> e176fdd3a9ca0d54986575dc07965d2da4d198ea

        [Required]
        public string Endereco { get; set; }

        public virtual ICollection<PedidoLanche> PedidoLanche { get; set; }



    }
}