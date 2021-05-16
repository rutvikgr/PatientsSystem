using PatientSystem.DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.DB.Context
{
    /// <summary>
    /// Database context to access all database tables for various operations
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        //public DatabaseContext() : base("data source = localhost; initial catalog = PatientSystem; App=EntityFramework;integrated security = True; MultipleActiveResultSets=True;")
        public DatabaseContext() : base("DefaultConnection")

        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        /// <summary>
        /// Table: RelationShips
        /// </summary>
        public DbSet<RelationShips> RelationShips { get; set; }

        /// <summary>
        /// Table: Patients
        /// </summary>
        public DbSet<Patients> Patients { get; set; }

        /// <summary>
        /// Table: NOKDetails
        /// </summary>
        public DbSet<NOKDetails> NOKDetails { get; set; }

        /// <summary>
        /// Table: PropertyItems
        /// </summary>
        public DbSet<PropertyItems> PropertyItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Add(new DataTypePropertyAttributeConvention());
        }
    }

    public class DataTypePropertyAttributeConvention : PrimitivePropertyAttributeConfigurationConvention<DataTypeAttribute>
    {
        public override void Apply(ConventionPrimitivePropertyConfiguration configuration, DataTypeAttribute attribute)
        {
            if (attribute.DataType == DataType.Date)
            {
                configuration.HasColumnType("Date");
            }
        }
    }
}
