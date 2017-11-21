using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _153264_152728.Models
{
    public class ProLan
    {
        public int ProLanId { get; set; }

        public int IdProduto { get; set; }

        public virtual Produto Produto { get; set; }


    }
}