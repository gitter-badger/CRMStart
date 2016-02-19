using System.Data.Entity;
using CRMStart.Core.Domain.Customer;
using CRMStart.Core.Domain.KnowledgeBase;
using CRMStart.Core.Domain.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CRMStart.Data
{
    public class CrmStartObjectContext : IdentityDbContext<CrmStartUser>
    {
        public CrmStartObjectContext()
            : base(
                @"data source=.\SQLEXPRESS;initial catalog=CRMStart.Domain;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"
                ,true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public static CrmStartObjectContext Create()
        {
            return new CrmStartObjectContext();
        }

        //public DbSet<Core.Domain.KnowledgeBase.Section> Sections { get; set; }
        //public DbSet<Core.Domain.KnowledgeBase.Section> Sections { get; set; }
        //public DbSet<Core.Domain.KnowledgeBase.Section> Sections { get; set; }
        //public DbSet<Core.Domain.KnowledgeBase.Section> Sections { get; set; }
        //public DbSet<Core.Domain.KnowledgeBase.Section> Sections { get; set; }
        //public DbSet<Core.Domain.KnowledgeBase.Section> Sections { get; set; }
        //public DbSet<Core.Domain.KnowledgeBase.Section> Sections { get; set; }
        //public DbSet<Core.Domain.KnowledgeBase.Section> Sections { get; set; }
        //public DbSet<Core.Domain.KnowledgeBase.Section> Sections { get; set; }

        //Security
        public DbSet<UserProfile> UsersProfile { get; set; }
        public DbSet<PreviousPassword> PreviousUserPasswords { get; set; }
        

        ////HelpDesk
        public DbSet<Section> Sections { get; set; }
        public DbSet <Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }



      //  protected override void OnModelCreating(DbModelBuilder modelBuilder)
      //{
      //      base.OnModelCreating(modelBuilder);
      //      // Configure Code First to ignore PluralizingTableName convention 
      //      // If you keep this convention then the generated tables will have pluralized names. 
      //      // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            
      //}
    }
}