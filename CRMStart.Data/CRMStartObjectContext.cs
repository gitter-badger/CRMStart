using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using CRMStart.Core.Domain.Security;
using CRMStart.Core.Extensions;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.Namespace.HasValue() &&
                      t.BaseType != null &&
                      t.BaseType.IsGenericType
                let genericType = t.BaseType.GetGenericTypeDefinition()
                where
                    genericType == typeof (EntityTypeConfiguration<>) ||
                    genericType == typeof (ComplexTypeConfiguration<>)
                select t;

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic) configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public static CrmStartObjectContext Create()
        {
            return new CrmStartObjectContext();
        }
    }
}