namespace DataAccess_CF {
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class model1 : DbContext {
        // Your context has been configured to use a 'model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccess_CF.model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'model1' 
        // connection string in the application configuration file.
        public model1()
            : base("name=model1") {
            
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<NewRequest> Request { get; set; }
        public virtual DbSet<UserInfo> Users { get; set; }
        public virtual DbSet<UpdatedRequest> UpdatedReq  { get; set; }
        public virtual DbSet<TrainerInfo> Trainers { get; set; }
    }

    
}