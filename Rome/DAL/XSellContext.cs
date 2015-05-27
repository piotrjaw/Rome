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
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Client>().HasKey(t => t.ClientId);

            modelBuilder.Entity<Base>().HasKey(t => t.BaseId);

            modelBuilder.Entity<BaseAssignment>().HasKey(t => t.BaseAssignmentId);
            modelBuilder.Entity<BaseAssignment>()
                .HasRequired(b => b.Base);
            modelBuilder.Entity<BaseAssignment>()
                .HasRequired(b => b.Client);

            modelBuilder.Entity<Event>().HasKey(t => t.EventId);
            modelBuilder.Entity<Event>()
                .HasRequired(e => e.Base);
            modelBuilder.Entity<Event>()
                .HasRequired(e => e.Client);

        }
    }
}