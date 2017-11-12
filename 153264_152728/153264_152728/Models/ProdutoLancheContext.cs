using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _153264_152728.Models
{
    public class ProdutoLancheContext : DbContext
    {
        public ProdutoLancheContext() :base("DbLanchonete")
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Comidas> Lanches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}