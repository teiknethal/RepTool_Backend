using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using RepToolService.DataObjects;

namespace RepToolService.Models
{
    public class RepToolContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public RepToolContext() : base(connectionStringName)
        {
        } 
        public DbSet<Action> Actions { get; set; }
        public DbSet<ActionCode> ActionCodes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Namelist> Namelists { get; set; }
        public DbSet<Names> Names { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<OrderStatus> OrderStatusCodes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rep> Reps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }
    }

}
