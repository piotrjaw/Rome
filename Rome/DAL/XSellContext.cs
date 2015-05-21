using Rome.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace Rome.DAL
{
    public class XSellContext : DbContext
    {
        public XSellContext() : base("XSellContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Base> Bases { get; set; }
        public DbSet<BaseAssignment> BaseAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}