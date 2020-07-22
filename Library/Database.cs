using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public partial class Database : DbContext
    {
        public Database()
            : base("DefaultConnection")
        {

            //  Database.SetInitializer<DbContext>(null);
           // System.Data.Entity.Database.SetInitializer<Database>(null);
        }

        public class MyMigration : DbMigrationsConfiguration<DbContext>
        {
            public MyMigration()
            {
                this.AutomaticMigrationsEnabled = true;
                this.AutomaticMigrationDataLossAllowed = true;
            }
        }

        public void MarkAsAdded(object entity)
        {
            SetEntityState(entity, EntityState.Added);
        }

        public virtual void MarkAsDeleted(object entity)
        {
            SetEntityState(entity, EntityState.Deleted);
        }

        public void SetEntityState(object entity, EntityState value)
        {
            this.Entry(entity).State = value;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //http://blogs.msmvps.com/ricardoperes/2015/01/26/custom-entity-framework-code-first-convention-for-discriminator-values/

        //    //modelBuilder.Conventions.Add(new DiscriminatorConvention(modelBuilder));

        //    //modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());



        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
