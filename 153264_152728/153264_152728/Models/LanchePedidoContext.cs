using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _153264_152728.Models
{
    public class LanchePedidoContext : DbContext
    {
        public LanchePedidoContext() : base("DbLanchonete") 
         {
         }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Comidas> Lanches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}