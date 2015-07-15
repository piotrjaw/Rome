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

        public DbSet<Base> Bases { get; set; }
        public DbSet<BaseAssignment> BaseAssignments { get; set; }
        public DbSet<BaseOptionSet> BaseOptionSets { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventTypeSet> EventSets { get; set; }
        public DbSet<EventTypeAssignment> EventAssignments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAssignment> ProductAssignments { get; set; }
        public DbSet<ProductSet> ProductSets { get; set; }
        public DbSet<ResignationReason> ResignationReasons { get; set; }
        public DbSet<ResignationReasonSet> ResignationReasonSets { get; set; }
        public DbSet<ResignationReasonAssignment> ResignationReasonAssignments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultAssignment> ResultAssignments { get; set; }
        public DbSet<ResultSet> ResultSets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StatusAssignment> StatusAssignments { get; set; }
        public DbSet<StatusSet> StatusSets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAssignment> UserAssignments { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Base>().HasKey(b => b.BaseId);
            modelBuilder.Entity<Base>().HasRequired(b => b.BaseOptionSet);

            modelBuilder.Entity<BaseAssignment>().HasKey(b => new { b.ClientId, b.BaseId });
            modelBuilder.Entity<BaseAssignment>().HasRequired(b => b.User);
            modelBuilder.Entity<BaseAssignment>().HasRequired(b => b.Status);

            modelBuilder.Entity<BaseOptionSet>().HasKey(r => r.BaseOptionSetId);
            modelBuilder.Entity<BaseOptionSet>().HasRequired(r => r.EventTypeSet);
            modelBuilder.Entity<BaseOptionSet>().HasRequired(r => r.ResultSet);
            modelBuilder.Entity<BaseOptionSet>().HasRequired(r => r.ResignationReasonSet);
            modelBuilder.Entity<BaseOptionSet>().HasRequired(r => r.ProductSet);
            modelBuilder.Entity<BaseOptionSet>().HasRequired(r => r.StatusSet);

            modelBuilder.Entity<Client>().HasKey(c => c.ClientId);

            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().HasRequired(e => e.User);
            modelBuilder.Entity<Event>().HasRequired(e => e.Base);
            modelBuilder.Entity<Event>().HasRequired(e => e.Status);
            modelBuilder.Entity<Event>().HasOptional(e => e.ResignationReason).WithMany().HasForeignKey(e => e.ResignationReasonId);
            modelBuilder.Entity<Event>().HasRequired(e => e.Result);
            modelBuilder.Entity<Event>().HasRequired(e => e.Client);
            modelBuilder.Entity<Event>().HasRequired(e => e.EventType).WithMany().HasForeignKey(e => e.EventTypeId);
            modelBuilder.Entity<Event>().HasOptional(e => e.SetEventType).WithMany().HasForeignKey(e => e.SetEventTypeId);

            modelBuilder.Entity<EventType>().HasKey(e => e.EventTypeId);
            modelBuilder.Entity<EventTypeSet>().HasKey(e => e.EventTypeSetId);

            modelBuilder.Entity<EventTypeAssignment>().HasKey(e => new { e.EventTypeId, e.EventTypeSetId });
            modelBuilder.Entity<EventTypeAssignment>().HasRequired(e => e.EventType);
            modelBuilder.Entity<EventTypeAssignment>().HasRequired(e => e.EventTypeSet);

            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<ProductSet>().HasKey(p => p.ProductSetId);

            modelBuilder.Entity<ProductAssignment>().HasKey(p => new { p.ProductId, p.ProductSetId });
            modelBuilder.Entity<ProductAssignment>().HasRequired(p => p.Product);
            modelBuilder.Entity<ProductAssignment>().HasRequired(p => p.ProductSet);


            modelBuilder.Entity<ResignationReason>().HasKey(r => r.ResignationReasonId);

            modelBuilder.Entity<ResignationReasonAssignment>().HasKey(r => new { r.ResignationReasonId, r.ResignationReasonSetId });
            modelBuilder.Entity<ResignationReasonAssignment>().HasRequired(r => r.ResignationReason);
            modelBuilder.Entity<ResignationReasonAssignment>().HasRequired(r => r.ResignationReasonSet);

            modelBuilder.Entity<ResignationReasonSet>().HasKey(r => r.ResignationReasonSetId);

            modelBuilder.Entity<Result>().HasKey(r => r.ResultId);
            modelBuilder.Entity<ResultSet>().HasKey(r => r.ResultSetId);

            modelBuilder.Entity<ResultAssignment>().HasKey(r => new { r.ResultId, r.ResultSetId });
            modelBuilder.Entity<ResultAssignment>().HasRequired(r => r.Result);
            modelBuilder.Entity<ResultAssignment>().HasRequired(r => r.ResultSet);

            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);

            modelBuilder.Entity<Session>().HasKey(s => s.SessionId);
            modelBuilder.Entity<Session>().HasRequired(s => s.User);

            modelBuilder.Entity<Status>().HasKey(s => s.StatusId);
            modelBuilder.Entity<StatusSet>().HasKey(s => s.StatusSetId);

            modelBuilder.Entity<StatusAssignment>().HasKey(s => new { s.StatusId, s.StatusSetId });
            modelBuilder.Entity<StatusAssignment>().HasRequired(s => s.Status);
            modelBuilder.Entity<StatusAssignment>().HasRequired(s => s.StatusSet);

            modelBuilder.Entity<Unit>().HasKey(u => u.UnitId);
            modelBuilder.Entity<Unit>().HasRequired(u => u.UnitType);
            modelBuilder.Entity<Unit>().HasOptional(u => u.SuperiorUnit).WithMany().HasForeignKey(u => u.SuperiorUnitId);

            modelBuilder.Entity<UnitType>().HasKey(u => u.UnitTypeId);
            modelBuilder.Entity<UnitType>().HasOptional(u => u.SuperiorUnitType).WithMany().HasForeignKey(u => u.SuperiorUnitTypeId);

            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            modelBuilder.Entity<UserAssignment>().HasKey(u => new { u.UserId, u.UnitId });
            modelBuilder.Entity<UserAssignment>().HasRequired(u => u.Unit);
            modelBuilder.Entity<UserAssignment>().HasRequired(u => u.Role);

        }

    }
}