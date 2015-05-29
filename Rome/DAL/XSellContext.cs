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
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Administration> Administrations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Client>().HasKey(c => c.ClientId);

            modelBuilder.Entity<Base>().HasKey(b => b.BaseId);

            modelBuilder.Entity<BaseAssignment>().HasKey(b => b.BaseAssignmentId);
            modelBuilder.Entity<BaseAssignment>().HasRequired(b => b.Base);
            modelBuilder.Entity<BaseAssignment>().HasRequired(b => b.Client);

            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().HasRequired(e => e.Base);
            modelBuilder.Entity<Event>().HasRequired(e => e.Client);

            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            modelBuilder.Entity<Branch>().HasKey(b => b.BranchId);
            modelBuilder.Entity<Branch>().HasRequired(b => b.Region);

            modelBuilder.Entity<Region>().HasKey(r => r.RegionId);
            modelBuilder.Entity<Region>().HasRequired(b => b.Network);

            modelBuilder.Entity<Network>().HasKey(n => n.NetworkId);
            modelBuilder.Entity<Network>().HasRequired(b => b.Company);

            modelBuilder.Entity<Company>().HasKey(c => c.CompanyId);
            modelBuilder.Entity<Company>().HasRequired(c => c.Administration);

            modelBuilder.Entity<Administration>().HasKey(a => a.AdministrationId);


        }
    }
}