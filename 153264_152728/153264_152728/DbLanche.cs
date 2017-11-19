namespace _153264_152728
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbLanche : DbContext
    {
        // Your context has been configured to use a 'DbLanche' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_153264_152728.DbLanche' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbLanche' 
        // connection string in the application configuration file.
        public DbLanche()
            : base("name=DbLanche")
        {
        }

        public System.Data.Entity.DbSet<_153264_152728.Models.Pedido> Pedidoes { get; set;}

        public System.Data.Entity.DbSet<_153264_152728.Models.Comidas> Comidas { get; set; }

        public System.Data.Entity.DbSet<_153264_152728.Models.Produto> Produtoes { get; set; }



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