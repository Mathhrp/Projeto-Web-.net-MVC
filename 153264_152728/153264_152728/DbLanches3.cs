namespace _153264_152728
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbLanches3 : DbContext
    {
        // Your context has been configured to use a 'DbLanches3' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_153264_152728.DbLanches3' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbLanches3' 
        // connection string in the application configuration file.
        public DbLanches3()
            : base("name=DbLanches3")
        {
        }
        public System.Data.Entity.DbSet<_153264_152728.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<_153264_152728.Models.Comidas> Comidas { get; set; }

        public System.Data.Entity.DbSet<_153264_152728.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<_153264_152728.Models.ProLan> ProLans { get; set; }

        public System.Data.Entity.DbSet<_153264_152728.Models.Produtos> Produtos { get; set; }

        public System.Data.Entity.DbSet<_153264_152728.Models.LanPro> LanProes { get; set; }


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