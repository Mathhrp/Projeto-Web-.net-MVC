using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _153264_152728.Models
{
    public class ProdutoLanchesContext : DbContext
    {
        public ProdutoLanchesContext() : base("DbLanche2")
        {

        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            // Primary keys
            builder.Entity<Produto>().HasKey(q => q.IdProduto);
            builder.Entity<Comidas>().HasKey(q => q.IdComida);
            builder.Entity<ProdutoLanche>().HasKey(q =>
                new {
                    q.ProdutoId,
                    q.ComidaId
                });

            // Relationships
            builder.Entity<ProdutoLanche>()
                .HasRequired(t => t.Produto)
                .WithMany(t => t.ProdutoLanches)
                .HasForeignKey(t => t.ProdutoId);

        builder.Entity<ProdutoLanche>()
            .HasRequired(t => t.Comida)
            .WithMany(t => t.ProdutoLanche)
            .HasForeignKey(t => t.ComidaId);
        }
    }
}