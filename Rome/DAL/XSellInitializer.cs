using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DAL
{
    public class XSellInitializer : System.Data.Entity.DropCreateDatabaseAlways<XSellContext>
    {
        protected override void Seed(XSellContext context)
        {
            var clients = new List<Client>
            {
                new Client{ClientId=1,Owner="Jan Kowalski",CompanyName="ABC"},
                new Client{ClientId=2,Owner="Roman Nowak",CompanyName="DEF"},
                new Client{ClientId=3,Owner="Marian Szpak",CompanyName="123"},
                new Client{ClientId=4,Owner="Katarzyna Psztynk",CompanyName="321"},
                new Client{ClientId=5,Owner="Roman Wiśniewski",CompanyName="ZZZ SA"},
                new Client{ClientId=6,Owner="Janusz Malarczyk",CompanyName="Petroinvest Sp. z o.o."},
                new Client{ClientId=7,Owner="Wojciech Murawski",CompanyName="Wojciech Murawski"},
                new Client{ClientId=8,Owner="Piotr Małowiejski",CompanyName="emp.pl"},
                new Client{ClientId=9,Owner="Ryszarda Ochódzka",CompanyName="Pluszowe Misie"},
                new Client{ClientId=10,Owner="Stefan Małolepszy",CompanyName="Stefan Małolepszy"},
                new Client{ClientId=11,Owner="Marta Mariolska",CompanyName="Lorem Ipsum S.A."},
                new Client{ClientId=12,Owner="Bron Shogun",CompanyName="straconeszanse.pl"},
                new Client{ClientId=13,Owner="Andrzej Dudek",CompanyName="Expect Sp. z o.o."},
                new Client{ClientId=14,Owner="Irena Kwiatkowska",CompanyName="Kobieta Pracująca"},
                new Client{ClientId=15,Owner="Marcin Daniec",CompanyName="Śmichy S.A."}
            };
            clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();

            var results = new List<Result>
            {
                new Result {ResultId = 1, ResultName = "Telefon w przyszłości", ResultingEventId = 1},
                new Result {ResultId = 2, ResultName = "Umówione spotkanie", ResultingEventId = 2},
                new Result {ResultId = 3, ResultName = "Nie odebrano", SpecificToEventId = 1},
                new Result {ResultId = 4, ResultName = "Nie odbyło się", SpecificToEventId = 2},
                new Result {ResultId = 5, ResultName = "Out", IsNegativeEnding = true},
                new Result {ResultId = 6, ResultName = "In", IsPositiveEnding = true}
            };
            results.ForEach(r => context.Results.Add(r));
            context.SaveChanges();

            var resultsets = new List<ResultSet>
            {
                new ResultSet {ResultSetId = 1, ResultSetDescription = "Standardowy proces sprzedażowy (oddziały)"}
            };
            resultsets.ForEach(r => context.ResultSets.Add(r));
            context.SaveChanges();

            var resultassignments = new List<ResultAssignment>
            {
                new ResultAssignment {ResultId = 1, ResultSetId = 1},
                new ResultAssignment {ResultId = 2, ResultSetId = 1},
                new ResultAssignment {ResultId = 3, ResultSetId = 1},
                new ResultAssignment {ResultId = 4, ResultSetId = 1},
                new ResultAssignment {ResultId = 5, ResultSetId = 1},
                new ResultAssignment {ResultId = 6, ResultSetId = 1}
            };
            resultassignments.ForEach(r => context.ResultAssignments.Add(r));
            context.SaveChanges();

            var resignationreasons = new List<ResignationReason>
            {
                new ResignationReason {ResignationReasonId = 1, ResignationReasonDescription = "Błędne dane"},
                new ResignationReason {ResignationReasonId = 2, ResignationReasonDescription = "Nie spełnia warunków oferty"},
                new ResignationReason {ResignationReasonId = 3, ResignationReasonDescription = "Niezadowolony z ceny"},
                new ResignationReason {ResignationReasonId = 4, ResignationReasonDescription = "Niezadowolony z warunków"},
                new ResignationReason {ResignationReasonId = 5, ResignationReasonDescription = "Niezadowolony z obsługi w Tax Care"},
                new ResignationReason {ResignationReasonId = 5, ResignationReasonDescription = "Niezadowolony z obsługi w Grupie"},
            };
            resignationreasons.ForEach(r => context.ResignationReasons.Add(r));
            context.SaveChanges();

            var resignationsets = new List<ResignationReasonSet>
            {
                new ResignationReasonSet {ResignationReasonSetId = 1, ResignationReasonSetDescription = "Standardowa lista rezygnacji"}
            };
            resignationsets.ForEach(r => context.ResignationReasonSets.Add(r));
            context.SaveChanges();

            var resignationreasoassignments = new List<ResignationReasonAssignment>
            {
                new ResignationReasonAssignment {ResignationReasonId = 1, ResignationReasonSetId = 1},
                new ResignationReasonAssignment {ResignationReasonId = 2, ResignationReasonSetId = 1},
                new ResignationReasonAssignment {ResignationReasonId = 3, ResignationReasonSetId = 1},
                new ResignationReasonAssignment {ResignationReasonId = 4, ResignationReasonSetId = 1},
                new ResignationReasonAssignment {ResignationReasonId = 5, ResignationReasonSetId = 1},
                new ResignationReasonAssignment {ResignationReasonId = 6, ResignationReasonSetId = 1},
            };
            resignationreasoassignments.ForEach(r => context.ResignationReasonAssignments.Add(r));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {ProductId = 1, ProductName = "Abonament Księgowy"},
                new Product {ProductId = 2, ProductName = "Abonament Prawny"},
                new Product {ProductId = 3, ProductName = "Kontomierz"},
                new Product {ProductId = 4, ProductName = "Limit"},
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            var productsets = new List<ProductSet>
            {
                new ProductSet {ProductSetId = 1, ProductSetDescription = "Standardowy zestaw produktów"},
            };
            productsets.ForEach(p => context.ProductSets.Add(p));
            context.SaveChanges();

            var productassignments = new List<ProductAssignment>
            {
                new ProductAssignment {ProductId = 1, ProductSetId = 1},
                new ProductAssignment {ProductId = 2, ProductSetId = 1},
                new ProductAssignment {ProductId = 3, ProductSetId = 1},
                new ProductAssignment {ProductId = 4, ProductSetId = 1}
            };
            productassignments.ForEach(p => context.ProductAssignments.Add(p));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event {EventId = 1, EventName = "Telefon"},
                new Event {EventId = 2, EventName = "Spotkanie"},
                new Event {EventId = 3, EventName = "Lead"}
            };
            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var eventsets = new List<EventSet>
            {
                new EventSet {EventSetId = 1, EventSetDescription = "Standardowy zestaw zdarzeń"}
            };
            eventsets.ForEach(e => context.EventSets.Add(e));
            context.SaveChanges();

            var eventassignments = new List<EventAssignment>
            {
                new EventAssignment {EventId = 1, EventSetId = 1},
                new EventAssignment {EventId = 2, EventSetId = 1}
            };
            eventassignments.ForEach(e => context.EventAssignments.Add(e));
            context.SaveChanges();

            var statuses = new List<Status>
            {
                new Status {StatusId = 1, StatusName = "Nowy", StatusValue = 1},
                new Status {StatusId = 2, StatusName = "Brak kontaktu", StatusValue = 2},
                new Status {StatusId = 3, StatusName = "Umówiony telefon", StatusValue = 3},
                new Status {StatusId = 4, StatusName = "Umówione spotkanie", StatusValue = 4},
                new Status {StatusId = 5, StatusName = "Odbyte spotkanie", StatusValue = 5},
                new Status {StatusId = 6, StatusName = "In", StatusValue = 6},
                new Status {StatusId = 7, StatusName = "Out", StatusValue = 7},
                new Status {StatusId = 8, StatusName = "Lead przekazany", StatusValue = 6}
            };
            statuses.ForEach(s => context.Statuses.Add(s));
            context.SaveChanges();

            var statussets = new List<StatusSet>
            {
                new StatusSet {StatusSetId = 1, StatusSetDescription = "Standardowy zestaw statusów"}
            };
            statussets.ForEach(s => context.StatusSets.Add(s));
            context.SaveChanges();

            var statusassignments = new List<StatusAssignment>
            {
                new StatusAssignment {StatusId = 1, StatusSetId = 1},
                new StatusAssignment {StatusId = 2, StatusSetId = 1},
                new StatusAssignment {StatusId = 3, StatusSetId = 1},
                new StatusAssignment {StatusId = 4, StatusSetId = 1},
                new StatusAssignment {StatusId = 5, StatusSetId = 1},
                new StatusAssignment {StatusId = 6, StatusSetId = 1},
                new StatusAssignment {StatusId = 7, StatusSetId = 1}
            };
            statusassignments.ForEach(s => context.StatusAssignments.Add(s));
            context.SaveChanges();

            var baseoptionsets = new List<BaseOptionSet>
            {
                new BaseOptionSet {BaseOptionSetId = 1, BaseOptionSetDescription = "Standardowy zestaw opcji", ProductSetId = 1, ResignationReasonSetId = 1, ResultSetId = 1, EventSetId = 1, StatusSetId = 1}
            };
            baseoptionsets.ForEach(p => context.BaseOptionSets.Add(p));
            context.SaveChanges();

            var bases = new List<Base>
            {
                new Base{BaseId=1,BaseName="Upsell BKI",BaseStart=DateTime.Parse("2015-05-20"),BaseEnd=DateTime.Parse("2015-07-20"), BaseOptionSetId = 1},
                new Base{BaseId=2,BaseName="Odnowienie limitów",BaseStart=DateTime.Parse("2015-04-23"),BaseEnd=DateTime.Parse("2015-06-21"), BaseOptionSetId = 1},
                new Base{BaseId=3,BaseName="Taniej z Księgowością 2",BaseStart=DateTime.Parse("2015-04-25"),BaseEnd=DateTime.Parse("2015-06-24"), BaseOptionSetId = 1},
                new Base{BaseId=3,BaseName="Taniej z Księgowością 1",BaseStart=DateTime.Parse("2015-04-20"),BaseEnd=DateTime.Parse("2015-05-29"), BaseOptionSetId = 1}
            };
            bases.ForEach(b => context.Bases.Add(b));
            context.SaveChanges();

            var users = new List<User>
            {
                new User {UserId = 1, UserFirstName = "Adam", UserSurname = "Głos", UserName = "aglos", Email = "adam.glos@taxcare.pl", Password = "abc123"},
                new User {UserId = 2, UserFirstName = "Grzegorz", UserSurname = "Grodek", UserName = "ggrodek", Email = "grzegorz.grodek@taxcare.pl", Password = "abc123"},
                new User {UserId = 3, UserFirstName = "Jacek", UserSurname = "Birlet", UserName = "jbirlet", Email = "jacek.birlet@taxcare.pl", Password = "abc123"},
                new User {UserId = 4, UserFirstName = "Marcin", UserSurname = "Kononiuk", UserName = "mkononiuk", Email = "marcin.kononiuk@taxcare.pl", Password = "abc123"},
                new User {UserId = 5, UserFirstName = "Piotr", UserSurname = "Jaworski", UserName = "pjaworski", Email = "piotr.jaworski2@taxcare.pl", Password = "test1234"},
                new User {UserId = 6, UserFirstName = "Marta", UserSurname = "Marczak", UserName = "mmarczak", Email = "marta.marczak@taxcare.pl", Password = "abc123"},
                new User {UserId = 7, UserFirstName = "Katarzyna", UserSurname = "Pełka", UserName = "kpelka", Email = "katarzyna.pelka@taxcare.pl", Password = "abc123"},
                new User {UserId = 8, UserFirstName = "Roman", UserSurname = "Gmoch", UserName = "rgmoch", Email = "roman.gmoch@taxcare.pl", Password = "abc123"},
                new User {UserId = 9, UserFirstName = "Tomasz", UserSurname = "Niewierz", UserName = "tniewierz", Email = "tomasz.niewierz@taxcare.pl", Password = "abc123"},
                new User {UserId = 10, UserFirstName = "Sławomir", UserSurname = "Sarnecki", UserName = "ssarnecki", Email = "slawomir.sarnecki@taxcare.pl", Password = "abc123"},
                new User {UserId = 11, UserFirstName = "Magdalena", UserSurname = "Miłkowska", UserName = "mmilkowska", Email = "magdalena.milkowska@taxcare.pl", Password = "abc123"},
                new User {UserId = 12, UserFirstName = "Zuzanna", UserSurname = "Kowalska", UserName = "zkowalska", Email = "zuzanna.kowalska@taxcare.pl", Password = "abc123"},
                new User {UserId = 13, UserFirstName = "Tymoteusz", UserSurname = "Łęcki", UserName = "tlecki", Email = "tymoteusz.lecki@taxcare.pl", Password = "abc123"},
                new User {UserId = 14, UserFirstName = "Piotr", UserSurname = "Pasowski", UserName = "ppasowski", Email = "piotr.pasowski@taxcare.pl", Password = "abc123"},
                new User {UserId = 15, UserFirstName = "Pawel", UserSurname = "Tymański", UserName = "ptymanski", Email = "pawel.tymanski@taxcare.pl", Password = "abc123"},
                new User {UserId = 16, UserFirstName = "Andrzej", UserSurname = "Merski", UserName = "amerski", Email = "andrzej.merski@taxcare.pl", Password = "abc123"},
                new User {UserId = 17, UserFirstName = "Agata", UserSurname = "Młynarska", UserName = "amlynarska", Email = "agata.mlynarska@taxcare.pl", Password = "abc123"},
                new User {UserId = 18, UserFirstName = "Zdzisław", UserSurname = "Jurek", UserName = "zjurek", Email = "zdzislaw.jurek@taxcare.pl", Password = "abc123"},
                new User {UserId = 19, UserFirstName = "Anna", UserSurname = "Masztalerz", UserName = "amasztalerz", Email = "anna.masztalerz@taxcare.pl", Password = "abc123"}
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var baseAssignments = new List<BaseAssignment>
            {
                new BaseAssignment {ClientId = 1, BaseId = 1, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 2, BaseId = 2, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 3, BaseId = 2, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 4, BaseId = 1, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 5, BaseId = 2, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 6, BaseId = 1, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 7, BaseId = 1, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 8, BaseId = 2, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 9, BaseId = 2, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 10, BaseId = 1, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 11, BaseId = 1, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 12, BaseId = 1, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 13, BaseId = 2, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 14, BaseId = 2, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 15, BaseId = 1, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 1, BaseId = 3, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 2, BaseId = 3, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 3, BaseId = 3, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 4, BaseId = 3, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 5, BaseId = 3, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 6, BaseId = 3, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 7, BaseId = 3, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 8, BaseId = 3, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 9, BaseId = 3, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 10, BaseId = 4, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 11, BaseId = 4, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 12, BaseId = 4, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 13, BaseId = 4, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 14, BaseId = 4, UserId = 19, StatusId = 1},
                new BaseAssignment {ClientId = 15, BaseId = 4, UserId = 19, StatusId = 1}
            };
            baseAssignments.ForEach(b => context.BaseAssignments.Add(b));
            context.SaveChanges();

            var eventactions = new List<EventAction>
            {
                new EventAction {ClientId = 1, BaseId = 1, EventActionDate = DateTime.Parse("2015-05-23 12:00:00"), UserId = 19, EventId = 1, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 1, BaseId = 3, EventActionDate = DateTime.Parse("2015-04-24 14:00:00"), UserId = 19, EventId = 1, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 1, BaseId = 1, EventActionDate = DateTime.Parse("2015-05-15 09:30:00"), UserId = 19, EventId = 2, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 1, BaseId = 3, EventActionDate = DateTime.Parse("2015-04-20 15:30:00"), UserId = 19, EventId = 1, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 1, BaseId = 1, EventActionDate = DateTime.Parse("2015-05-17 12:30:00"), UserId = 19, EventId = 2, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 2, BaseId = 3, EventActionDate = DateTime.Parse("2015-04-13 15:30:00"), UserId = 19, EventId = 1, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 2, BaseId = 2, EventActionDate = DateTime.Parse("2015-05-28 11:30:00"), UserId = 19, EventId = 2, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 2, BaseId = 3, EventActionDate = DateTime.Parse("2015-04-26 10:00:00"), UserId = 19, EventId = 1, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 2, BaseId = 2, EventActionDate = DateTime.Parse("2015-05-24 11:00:00"), UserId = 19, EventId = 2, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 2, BaseId = 3, EventActionDate = DateTime.Parse("2015-05-23 08:30:00"), UserId = 19, EventId = 1, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 4, BaseId = 3, EventActionDate = DateTime.Parse("2015-05-23 12:30:00"), UserId = 19, EventId = 1, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new EventAction {ClientId = 5, BaseId = 3, EventActionDate = DateTime.Parse("2015-05-23 12:45:00"), UserId = 19, EventId = 2, ResultId = 2, SetEventId = 2, SetEventActionDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4}
            };
            eventactions.ForEach(e => context.EventActions.Add(e));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role {RoleId = 1, RoleName = "Manager"},
                new Role {RoleId = 2, RoleName = "DeputyManager"},
                new Role {RoleId = 3, RoleName = "Advisor"}
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var units = new List<Unit>
            {
                new Unit {UnitId = 1, UnitTypeId = 1, UnitName = "Adminitstration"},
                new Unit {UnitId = 2, UnitTypeId = 2, UnitName = "Tax Care SA"},
                new Unit {UnitId = 3, UnitTypeId = 2, UnitName = "Idea Bank SA"},
                new Unit {UnitId = 4, UnitTypeId = 3, UnitName = "TCS"},
                new Unit {UnitId = 5, UnitTypeId = 3, UnitName = "TCP"},
                new Unit {UnitId = 6, UnitTypeId = 3, UnitName = "IBS"},
                new Unit {UnitId = 7, UnitTypeId = 4, UnitName = "Region 1"},
                new Unit {UnitId = 8, UnitTypeId = 4, UnitName = "Region 2"},
                new Unit {UnitId = 9, UnitTypeId = 4, UnitName = "Region 1"},
                new Unit {UnitId = 10, UnitTypeId = 4, UnitName = "Region 2"},
                new Unit {UnitId = 11, UnitTypeId = 4, UnitName = "Region 1"},
                new Unit {UnitId = 12, UnitTypeId = 4, UnitName = "Region 2"},
                new Unit {UnitId = 13, UnitTypeId = 5, UnitName = "TAXBIA1"},
                new Unit {UnitId = 14, UnitTypeId = 5, UnitName = "TAXGDA1"},
                new Unit {UnitId = 15, UnitTypeId = 5, UnitName = "TAXKRA1"},
                new Unit {UnitId = 16, UnitTypeId = 5, UnitName = "TAXSOS1"},
                new Unit {UnitId = 17, UnitTypeId = 5, UnitName = "TCPBIA1"},
                new Unit {UnitId = 18, UnitTypeId = 5, UnitName = "TCPSUW1"},
                new Unit {UnitId = 19, UnitTypeId = 5, UnitName = "TCPWAW1"},
                new Unit {UnitId = 20, UnitTypeId = 5, UnitName = "TCPPIA1"},
                new Unit {UnitId = 21, UnitTypeId = 5, UnitName = "TCIB WAW1"},
                new Unit {UnitId = 22, UnitTypeId = 5, UnitName = "TCIB WAW6"},
                new Unit {UnitId = 23, UnitTypeId = 5, UnitName = "TCIB KRA1"},
                new Unit {UnitId = 24, UnitTypeId = 5, UnitName = "TCIB WRO2"}
            };
            units.ForEach(u => context.Units.Add(u));
            context.SaveChanges();

            var unitrelations = new List<UnitRelation>
            {
                new UnitRelation {UnitId = 1, ChildUnitId = 2},
                new UnitRelation {UnitId = 1, ChildUnitId = 3},
                new UnitRelation {UnitId = 2, ChildUnitId = 4},
                new UnitRelation {UnitId = 2, ChildUnitId = 5},
                new UnitRelation {UnitId = 3, ChildUnitId = 6},
                new UnitRelation {UnitId = 4, ChildUnitId = 7},
                new UnitRelation {UnitId = 4, ChildUnitId = 8},
                new UnitRelation {UnitId = 5, ChildUnitId = 9},
                new UnitRelation {UnitId = 5, ChildUnitId = 10},
                new UnitRelation {UnitId = 6, ChildUnitId = 11},
                new UnitRelation {UnitId = 6, ChildUnitId = 12},
                new UnitRelation {UnitId = 7, ChildUnitId = 13},
                new UnitRelation {UnitId = 7, ChildUnitId = 14},
                new UnitRelation {UnitId = 8, ChildUnitId = 15},
                new UnitRelation {UnitId = 8, ChildUnitId = 16},
                new UnitRelation {UnitId = 9, ChildUnitId = 17},
                new UnitRelation {UnitId = 9, ChildUnitId = 18},
                new UnitRelation {UnitId = 10, ChildUnitId = 19},
                new UnitRelation {UnitId = 10, ChildUnitId = 20},
                new UnitRelation {UnitId = 11, ChildUnitId = 21},
                new UnitRelation {UnitId = 11, ChildUnitId = 22},
                new UnitRelation {UnitId = 12, ChildUnitId = 23},
                new UnitRelation {UnitId = 12, ChildUnitId = 24}
            };
            unitrelations.ForEach(u => context.UnitRelations.Add(u));
            context.SaveChanges();

            var unittypes = new List<UnitType>
            {
                new UnitType {UnitTypeId = 1, UnitTypeName = "Administration"},
                new UnitType {UnitTypeId = 2, UnitTypeName = "Company"},
                new UnitType {UnitTypeId = 3, UnitTypeName = "Network"},
                new UnitType {UnitTypeId = 4, UnitTypeName = "Region"},
                new UnitType {UnitTypeId = 5, UnitTypeName = "Branch"}
            };
            unittypes.ForEach(u => context.UnitTypes.Add(u));
            context.SaveChanges();

            var roleassignments = new List<RoleAssignment>
            {
                new RoleAssignment {RoleAssignmentId = 1, UnitId = 2, RoleId = 1, UserId = 1},
                new RoleAssignment {RoleAssignmentId = 2, UnitId = 2, RoleId = 1, UserId = 2},
                new RoleAssignment {RoleAssignmentId = 3, UnitId = 4, RoleId = 1, UserId = 3},
                new RoleAssignment {RoleAssignmentId = 4, UnitId = 5, RoleId = 1, UserId = 4},
                new RoleAssignment {RoleAssignmentId = 5, UnitId = 1, RoleId = 1, UserId = 5},
                new RoleAssignment {RoleAssignmentId = 6, UnitId = 6, RoleId = 1, UserId = 6},
                new RoleAssignment {RoleAssignmentId = 7, UnitId = 7, RoleId = 1, UserId = 7},
                new RoleAssignment {RoleAssignmentId = 8, UnitId = 7, RoleId = 2, UserId = 8},
                new RoleAssignment {RoleAssignmentId = 9, UnitId = 7, RoleId = 2, UserId = 9},
                new RoleAssignment {RoleAssignmentId = 10, UnitId = 8, RoleId = 1, UserId = 10},
                new RoleAssignment {RoleAssignmentId = 11, UnitId = 8, RoleId = 2, UserId = 11},
                new RoleAssignment {RoleAssignmentId = 12, UnitId = 8, RoleId = 2, UserId = 12},
                new RoleAssignment {RoleAssignmentId = 13, UnitId = 13, RoleId = 1, UserId = 13},
                new RoleAssignment {RoleAssignmentId = 14, UnitId = 13, RoleId = 2, UserId = 14},
                new RoleAssignment {RoleAssignmentId = 15, UnitId = 13, RoleId = 2, UserId = 15},
                new RoleAssignment {RoleAssignmentId = 16, UnitId = 13, RoleId = 3, UserId = 16},
                new RoleAssignment {RoleAssignmentId = 17, UnitId = 13, RoleId = 3, UserId = 17},
                new RoleAssignment {RoleAssignmentId = 18, UnitId = 13, RoleId = 3, UserId = 18},
                new RoleAssignment {RoleAssignmentId = 18, UnitId = 13, RoleId = 3, UserId = 19}
            };
            roleassignments.ForEach(r => context.RoleAssignments.Add(r));
            context.SaveChanges();
        }
    }
}