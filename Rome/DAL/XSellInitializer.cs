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
                new Result {ResultId = 1, ResultName = "Telefon w przyszłości", ResultingActionId = 1, ResultingStatusId = 3},
                new Result {ResultId = 2, ResultName = "Umówione spotkanie", ResultingActionId = 2, ResultingStatusId = 4},
                new Result {ResultId = 3, ResultName = "Nie odebrano", SpecificToActionId = 1, ResultingStatusId = 2},
                new Result {ResultId = 4, ResultName = "Nie odbyło się", SpecificToActionId = 2, ResultingStatusId = 4},
                new Result {ResultId = 5, ResultName = "Out", IsNegativeEnding = true, ResultingStatusId = 7},
                new Result {ResultId = 6, ResultName = "In", IsPositiveEnding = true, ResultingStatusId = 6}
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

            var eventtypes = new List<EventType>
            {
                new EventType {EventTypeId = 1, EventTypeName = "Telefon"},
                new EventType {EventTypeId = 2, EventTypeName = "Spotkanie"},
                new EventType {EventTypeId = 3, EventTypeName = "Lead"}
            };
            eventtypes.ForEach(e => context.EventTypes.Add(e));
            context.SaveChanges();

            var eventtypesets = new List<EventTypeSet>
            {
                new EventTypeSet {EventTypeSetId = 1, EventTypeSetDescription = "Standardowy zestaw zdarzeń"}
            };
            eventtypesets.ForEach(e => context.EventSets.Add(e));
            context.SaveChanges();

            var eventassignments = new List<EventTypeAssignment>
            {
                new EventTypeAssignment {EventTypeId = 1, EventTypeSetId = 1},
                new EventTypeAssignment {EventTypeId = 2, EventTypeSetId = 1}
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
                new BaseOptionSet {BaseOptionSetId = 1, BaseOptionSetDescription = "Standardowy zestaw opcji", ProductSetId = 1, ResignationReasonSetId = 1, ResultSetId = 1, EventTypeSetId = 1, StatusSetId = 1}
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

            var events = new List<Event>
            {
                new Event {ClientId = 1, BaseId = 1, EventDate = DateTime.Parse("2015-05-23 12:00:00"), UserId = 19, EventTypeId = 1, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 1, BaseId = 3, EventDate = DateTime.Parse("2015-04-24 14:00:00"), UserId = 19, EventTypeId = 1, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 1, BaseId = 1, EventDate = DateTime.Parse("2015-05-15 09:30:00"), UserId = 19, EventTypeId = 2, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 1, BaseId = 3, EventDate = DateTime.Parse("2015-04-20 15:30:00"), UserId = 19, EventTypeId = 1, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 1, BaseId = 1, EventDate = DateTime.Parse("2015-05-17 12:30:00"), UserId = 19, EventTypeId = 2, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 2, BaseId = 3, EventDate = DateTime.Parse("2015-04-13 15:30:00"), UserId = 19, EventTypeId = 1, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 2, BaseId = 2, EventDate = DateTime.Parse("2015-05-28 11:30:00"), UserId = 19, EventTypeId = 2, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 2, BaseId = 3, EventDate = DateTime.Parse("2015-04-26 10:00:00"), UserId = 19, EventTypeId = 1, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 2, BaseId = 2, EventDate = DateTime.Parse("2015-05-24 11:00:00"), UserId = 19, EventTypeId = 2, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 2, BaseId = 3, EventDate = DateTime.Parse("2015-05-23 08:30:00"), UserId = 19, EventTypeId = 1, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 4, BaseId = 3, EventDate = DateTime.Parse("2015-05-23 12:30:00"), UserId = 19, EventTypeId = 1, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4},
                new Event {ClientId = 5, BaseId = 3, EventDate = DateTime.Parse("2015-05-23 12:45:00"), UserId = 19, EventTypeId = 2, ResultId = 2, SetEventTypeId = 2, SetEventDate = DateTime.Parse("2015-07-15 12:00:00"), StatusId = 4}
            };
            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role {RoleId = 1, RoleName = "Manager"},
                new Role {RoleId = 2, RoleName = "DeputyManager"},
                new Role {RoleId = 3, RoleName = "Advisor"}
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var unittypes = new List<UnitType>
            {
                new UnitType {UnitTypeId = 1, FirstRoleName = "Administrator", SecondRoleName = "", ThirdRoleName = "", UnitTypeName = "Administration"},
                new UnitType {UnitTypeId = 2, FirstRoleName = "Prezes Zarządu", SecondRoleName = "Wiceprezes Zarządu", ThirdRoleName = "Członek Zarządu", UnitTypeName = "Company", SuperiorUnitTypeId = 1},
                new UnitType {UnitTypeId = 3, FirstRoleName = "Dyrektor Sieci", SecondRoleName = "Zastępca Dyrektora Sieci", ThirdRoleName = "", UnitTypeName = "Network", SuperiorUnitTypeId = 2},
                new UnitType {UnitTypeId = 4, FirstRoleName = "Dyrektor Regionu", SecondRoleName = "Zastępca Dyrektora Regionu", ThirdRoleName = "", UnitTypeName = "Region", SuperiorUnitTypeId = 3},
                new UnitType {UnitTypeId = 5, FirstRoleName = "Dyrektor Oddziału", SecondRoleName = "Zastępca Dyrektora Oddziału", ThirdRoleName = "Doradca", UnitTypeName = "Branch", SuperiorUnitTypeId = 4}
            };
            unittypes.ForEach(u => context.UnitTypes.Add(u));
            context.SaveChanges();

            var units = new List<Unit>
            {
                new Unit {UnitId = 1, UnitTypeId = 1, UnitName = "Adminitstration"},
                new Unit {UnitId = 2, SuperiorUnitId = 1, UnitTypeId = 2, UnitName = "Tax Care SA"},
                new Unit {UnitId = 3, SuperiorUnitId = 1, UnitTypeId = 2, UnitName = "Idea Bank SA"},
                new Unit {UnitId = 4, SuperiorUnitId = 2, UnitTypeId = 3, UnitName = "TCS"},
                new Unit {UnitId = 5, SuperiorUnitId = 2, UnitTypeId = 3, UnitName = "TCP"},
                new Unit {UnitId = 6, SuperiorUnitId = 3, UnitTypeId = 3, UnitName = "IBS"},
                new Unit {UnitId = 7, SuperiorUnitId = 4, UnitTypeId = 4, UnitName = "Region 1"},
                new Unit {UnitId = 8, SuperiorUnitId = 4, UnitTypeId = 4, UnitName = "Region 2"},
                new Unit {UnitId = 9, SuperiorUnitId = 5, UnitTypeId = 4, UnitName = "Region 1"},
                new Unit {UnitId = 10, SuperiorUnitId = 5, UnitTypeId = 4, UnitName = "Region 2"},
                new Unit {UnitId = 11, SuperiorUnitId = 6, UnitTypeId = 4, UnitName = "Region 1"},
                new Unit {UnitId = 12, SuperiorUnitId = 6, UnitTypeId = 4, UnitName = "Region 2"},
                new Unit {UnitId = 13, SuperiorUnitId = 7, UnitTypeId = 5, UnitName = "TAXBIA1"},
                new Unit {UnitId = 14, SuperiorUnitId = 7, UnitTypeId = 5, UnitName = "TAXGDA1"},
                new Unit {UnitId = 15, SuperiorUnitId = 8, UnitTypeId = 5, UnitName = "TAXKRA1"},
                new Unit {UnitId = 16, SuperiorUnitId = 8, UnitTypeId = 5, UnitName = "TAXSOS1"},
                new Unit {UnitId = 17, SuperiorUnitId = 9, UnitTypeId = 5, UnitName = "TCPBIA1"},
                new Unit {UnitId = 18, SuperiorUnitId = 9, UnitTypeId = 5, UnitName = "TCPSUW1"},
                new Unit {UnitId = 19, SuperiorUnitId = 10, UnitTypeId = 5, UnitName = "TCPWAW1"},
                new Unit {UnitId = 20, SuperiorUnitId = 10, UnitTypeId = 5, UnitName = "TCPPIA1"},
                new Unit {UnitId = 21, SuperiorUnitId = 11, UnitTypeId = 5, UnitName = "TCIB WAW1"},
                new Unit {UnitId = 22, SuperiorUnitId = 11, UnitTypeId = 5, UnitName = "TCIB WAW6"},
                new Unit {UnitId = 23, SuperiorUnitId = 12, UnitTypeId = 5, UnitName = "TCIB KRA1"},
                new Unit {UnitId = 24, SuperiorUnitId = 12, UnitTypeId = 5, UnitName = "TCIB WRO2"}
            };
            units.ForEach(u => context.Units.Add(u));
            context.SaveChanges();

            var userassignments = new List<UserAssignment>
            {
                new UserAssignment {UserId = 1, UnitId = 2, RoleId = 1},
                new UserAssignment {UserId = 2, UnitId = 2, RoleId = 1},
                new UserAssignment {UserId = 3, UnitId = 4, RoleId = 1},
                new UserAssignment {UserId = 4, UnitId = 5, RoleId = 1},
                new UserAssignment {UserId = 5, UnitId = 1, RoleId = 1},
                new UserAssignment {UserId = 6, UnitId = 6, RoleId = 1},
                new UserAssignment {UserId = 7, UnitId = 7, RoleId = 1},
                new UserAssignment {UserId = 8, UnitId = 7, RoleId = 2},
                new UserAssignment {UserId = 9, UnitId = 7, RoleId = 2},
                new UserAssignment {UserId = 10, UnitId = 8, RoleId = 1},
                new UserAssignment {UserId = 11, UnitId = 8, RoleId = 2},
                new UserAssignment {UserId = 12, UnitId = 8, RoleId = 2},
                new UserAssignment {UserId = 13, UnitId = 13, RoleId = 1},
                new UserAssignment {UserId = 14, UnitId = 13, RoleId = 2},
                new UserAssignment {UserId = 15, UnitId = 13, RoleId = 2},
                new UserAssignment {UserId = 16, UnitId = 13, RoleId = 3},
                new UserAssignment {UserId = 17, UnitId = 13, RoleId = 3},
                new UserAssignment {UserId = 18, UnitId = 13, RoleId = 3},
                new UserAssignment {UserId = 19, UnitId = 13, RoleId = 3}
            };
            userassignments.ForEach(u => context.UserAssignments.Add(u));
            context.SaveChanges();
        }
    }
}