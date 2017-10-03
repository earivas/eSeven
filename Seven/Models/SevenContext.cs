using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Seven.Models
{
    public class SevenContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SevenContext() : base("name=SevenContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         //   modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
         //   modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }
        public System.Data.Entity.DbSet<Seven.Models.Supervisor> Supervisors { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.ModelPerson> ModelPersons { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.ModelContract> ModelContracts { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.Afp> Afps { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.Arl> Arls { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.Compensation> Compensations { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.Eps> Eps { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.ModelType> ModelTypes { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.Organitation> Organitations { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.ProfitCenter> ProfitCenters { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.Page> Pages { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.PageType> PageTypes { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.Bank> Banks { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Seven.Models.OrderDetail> OrderDetails { get; set; }
    }
}
