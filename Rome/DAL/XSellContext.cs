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
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<UnitRelation> UnitRelations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Base>().HasKey(b => b.BaseId);

            modelBuilder.Entity<BaseAssignment>().HasKey(b => b.BaseAssignmentId);
            modelBuilder.Entity<BaseAssignment>().HasRequired(b => b.Base);
            modelBuilder.Entity<BaseAssignment>().HasRequired(b => b.Client);

            modelBuilder.Entity<Client>().HasKey(c => c.ClientId);

            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().HasRequired(e => e.Base);
            modelBuilder.Entity<Event>().HasRequired(e => e.Client);

            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);

            modelBuilder.Entity<RoleAssignment>().HasKey(r => r.RoleAssignmentId);
            modelBuilder.Entity<RoleAssignment>().HasRequired(r => r.Unit);
            modelBuilder.Entity<RoleAssignment>().HasRequired(r => r.User);
            modelBuilder.Entity<RoleAssignment>().HasRequired(r => r.Role);

            modelBuilder.Entity<Unit>().HasKey(u => u.UnitId);

            modelBuilder.Entity<UnitRelation>().HasKey(u => u.UnitRelationId);

            modelBuilder.Entity<UnitType>().HasKey(u => u.UnitTypeId);

            modelBuilder.Entity<User>().HasKey(u => u.UserId);
        }
    }
}