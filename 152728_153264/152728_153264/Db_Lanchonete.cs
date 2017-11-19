namespace _152728_153264
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Db_Lanchonete : DbContext
    {
        // Your context has been configured to use a 'Db_Lanchonete' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_152728_153264.Db_Lanchonete' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Db_Lanchonete' 
        // connection string in the application configuration file.
        public Db_Lanchonete()
            : base("name=Db_Lanchonete")
        {
        }

        public System.Data.Entity.DbSet<_152728_153264.Models.Pedido> Pedidoes { get; set; }
        public System.Data.Entity.DbSet<_152728_153264.Models.Produto> Produtoes { get; set; }
        public System.Data.Entity.DbSet<_152728_153264.Models.LancheProduto> LancheProdutoes { get; set; }
        public System.Data.Entity.DbSet<_152728_153264.Models.PedidoLanche> PedidoLanches { get; set; }

        public System.Data.Entity.DbSet<_152728_153264.Models.Lanche> Lanches { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}