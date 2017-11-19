using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _153264_152728.Models
{
    public class ProdutoLanche
    {
        [Key]
        public int ProdutoLancheId { get; set; }
        public int qtde { get; set; }
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        [ForeignKey("Comidas")]
        public int ComidaId { get; set; }
        public Comidas Comida { get; set; }

    }
}