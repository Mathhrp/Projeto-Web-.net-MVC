using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _153264_152728.Models
{
    public class LanPro
    {
        public int LanProId { get; set; }

        public int IdProduto { get; set; }

        public virtual Produtos Produtos { get; set; }
    }
}