using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace DataEntity.Models
{
    public class ContactContext : DbContext
    {
        //private ContactContext db = new ContactContext();

        public ContactContext() : base("ContactContext")
        {
        }

        public DbSet<ContactModel> Contact { get; set; }

        public static explicit operator ContactContext(DbSet<ContactView> v)
        {
            throw new NotImplementedException();
        }

        public DbSet<ContactViewAudit> ContactAudit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            Database.SetInitializer<ContactContext>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactModel>()
            .HasKey(o => o.ContactID);

            modelBuilder.Entity<ContactModel>()
            .Property(c => c.ContactID)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }

    }
}
