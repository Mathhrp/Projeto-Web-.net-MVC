using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _152728_153264.Models
{
    public class LancheProduto
    {
        public int LancheProdutoId { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int qtde { get; set; }
        [DisplayName("Produto")]
        [Required]
        public int ProdutoId{ get; set; }
        [Required]
        [DisplayName("Lanche")]
        public int LancheId { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Lanche Lanche { get; set; }
    }
}