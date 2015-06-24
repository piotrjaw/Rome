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
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Base> Bases { get; set; }
        public DbSet<BaseAssignment> BaseAssignments { get; set; }
        public DbSet<EventAction> EventActions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<UnitRelation> UnitRelations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<BaseOptionSet> BaseOptionSets { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResignationReason> ResignationReasons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ResultSet> ResultSets { get; set; }
        public DbSet<ResignationReasonSet> ResignationReasonSets { get; set; }
        public DbSet<ProductSet> ProductSets { get; set; }
        public DbSet<ResultAssignment> ResultAssignments { get; set; }
        public DbSet<ResignationReasonAssignment> ResignationReasonAssignments { get; set; }
        public DbSet<ProductAssignment> ProductAssignments { get; set; }
        public DbSet<EventSet> EventSets { get; set; }
        public DbSet<EventAssignment> EventAssignments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Base>().HasKey(b => b.BaseId);
            modelBuilder.Entity<Base>().HasRequired(b => b.BaseOptionSet);

            modelBuilder.Entity<BaseAssignment>().HasKey(b => b.BaseAssignmentId);
            modelBuilder.Entity<BaseAssignment>().HasRequired(b => b.Base);
            modelBuilder.Entity<BaseAssignment>().HasRequired(b => b.Client);

            modelBuilder.Entity<Client>().HasKey(c => c.ClientId);

            modelBuilder.Entity<EventAction>().HasKey(e => e.EventActionId);
            modelBuilder.Entity<EventAction>().HasRequired(e => e.Base);
            modelBuilder.Entity<EventAction>().HasRequired(e => e.Client);
            modelBuilder.Entity<EventAction>().HasRequired(e => e.Event);

            modelBuilder.Entity<Event>().HasKey(e => e.EventId);

            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);

            modelBuilder.Entity<RoleAssignment>().HasKey(r => r.RoleAssignmentId);
            modelBuilder.Entity<RoleAssignment>().HasRequired(r => r.Unit);
            modelBuilder.Entity<RoleAssignment>().HasRequired(r => r.User);
            modelBuilder.Entity<RoleAssignment>().HasRequired(r => r.Role);

            modelBuilder.Entity<Unit>().HasKey(u => u.UnitId);

            modelBuilder.Entity<UnitRelation>().HasKey(u => u.UnitRelationId);

            modelBuilder.Entity<UnitType>().HasKey(u => u.UnitTypeId);

            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            modelBuilder.Entity<Session>().HasKey(s => s.SessionId);
            
            modelBuilder.Entity<BaseOptionSet>().HasKey(r => r.BaseOptionSetId);
            modelBuilder.Entity<BaseOptionSet>().HasRequired(r => r.ResultSet);
            modelBuilder.Entity<BaseOptionSet>().HasRequired(r => r.ResignationReasonSet);
            modelBuilder.Entity<BaseOptionSet>().HasRequired(r => r.ProductSet);
            modelBuilder.Entity<BaseOptionSet>().HasRequired(r => r.EventSet);

            modelBuilder.Entity<ResultSet>().HasKey(r => r.ResultSetId);
            modelBuilder.Entity<ResignationReasonSet>().HasKey(r => r.ResignationReasonSetId);
            modelBuilder.Entity<ProductSet>().HasKey(p => p.ProductSetId);
            modelBuilder.Entity<EventSet>().HasKey(e => e.EventSetId);

            modelBuilder.Entity<ResultAssignment>().HasKey(r => r.ResultAssignmentId);
            modelBuilder.Entity<ResultAssignment>().HasRequired(r => r.Result);
            modelBuilder.Entity<ResultAssignment>().HasRequired(r => r.ResultSet);
            modelBuilder.Entity<ResignationReasonAssignment>().HasKey(r => r.ResignationReasonAssignmentId);
            modelBuilder.Entity<ResignationReasonAssignment>().HasRequired(r => r.ResignationReason);
            modelBuilder.Entity<ResignationReasonAssignment>().HasRequired(r => r.ResignationReasonSet);
            modelBuilder.Entity<ProductAssignment>().HasKey(p => p.ProductAssignmentId);
            modelBuilder.Entity<ProductAssignment>().HasRequired(p => p.Product);
            modelBuilder.Entity<ProductAssignment>().HasRequired(p => p.ProductSet);
            modelBuilder.Entity<EventAssignment>().HasKey(e => e.EventAssignmentId);
            modelBuilder.Entity<EventAssignment>().HasRequired(e => e.Event);
            modelBuilder.Entity<EventAssignment>().HasRequired(e => e.EventSet);

            modelBuilder.Entity<Result>().HasKey(r => r.ResultId);
            modelBuilder.Entity<ResignationReason>().HasKey(r => r.ResignationReasonId);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        }

    }
}