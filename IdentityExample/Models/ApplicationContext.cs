using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IdentityExample.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityExample.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("OracleDbContext")
        {
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public DbSet<RegisterModel> RegisterModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ASPNET");
            //modelBuilder.Types().Configure(c => c.);
            modelBuilder.Types().Configure(c => c.ToTable(c.ClrType.Name.ToUpper(), "ASPNET"));

            modelBuilder.Properties().Configure(c => c.HasColumnName(c.ClrPropertyInfo.Name.ToUpper()));

            base.OnModelCreating(modelBuilder);
        }
    }
}