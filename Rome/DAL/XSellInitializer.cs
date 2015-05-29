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

            var bases = new List<Base>
            {
                new Base{BaseId=1,BaseName="Upsell BKI",BaseStart=DateTime.Parse("2015-05-20"),BaseEnd=DateTime.Parse("2015-07-20")},
                new Base{BaseId=2,BaseName="Odnowienie limitów",BaseStart=DateTime.Parse("2015-04-23"),BaseEnd=DateTime.Parse("2015-06-21")},
                new Base{BaseId=3,BaseName="Taniej z Księgowością 2",BaseStart=DateTime.Parse("2015-04-25"),BaseEnd=DateTime.Parse("2015-06-24")},
                new Base{BaseId=3,BaseName="Taniej z Księgowością 1",BaseStart=DateTime.Parse("2015-04-20"),BaseEnd=DateTime.Parse("2015-05-29")}
            };
            bases.ForEach(b => context.Bases.Add(b));
            context.SaveChanges();

            var baseAssignments = new List<BaseAssignment>
            {
                new BaseAssignment {ClientId = 1, BaseId = 1},
                new BaseAssignment {ClientId = 2, BaseId = 2},
                new BaseAssignment {ClientId = 3, BaseId = 2},
                new BaseAssignment {ClientId = 4, BaseId = 1},
                new BaseAssignment {ClientId = 5, BaseId = 2},
                new BaseAssignment {ClientId = 6, BaseId = 1},
                new BaseAssignment {ClientId = 7, BaseId = 1},
                new BaseAssignment {ClientId = 8, BaseId = 2},
                new BaseAssignment {ClientId = 9, BaseId = 2},
                new BaseAssignment {ClientId = 10, BaseId = 1},
                new BaseAssignment {ClientId = 11, BaseId = 1},
                new BaseAssignment {ClientId = 12, BaseId = 1},
                new BaseAssignment {ClientId = 13, BaseId = 2},
                new BaseAssignment {ClientId = 14, BaseId = 2},
                new BaseAssignment {ClientId = 15, BaseId = 1},
                new BaseAssignment {ClientId = 1, BaseId = 3},
                new BaseAssignment {ClientId = 2, BaseId = 3},
                new BaseAssignment {ClientId = 3, BaseId = 3},
                new BaseAssignment {ClientId = 4, BaseId = 3},
                new BaseAssignment {ClientId = 5, BaseId = 3},
                new BaseAssignment {ClientId = 6, BaseId = 3},
                new BaseAssignment {ClientId = 7, BaseId = 3},
                new BaseAssignment {ClientId = 8, BaseId = 3},
                new BaseAssignment {ClientId = 9, BaseId = 3},
                new BaseAssignment {ClientId = 10, BaseId = 4},
                new BaseAssignment {ClientId = 11, BaseId = 4},
                new BaseAssignment {ClientId = 12, BaseId = 4},
                new BaseAssignment {ClientId = 13, BaseId = 4},
                new BaseAssignment {ClientId = 14, BaseId = 4},
                new BaseAssignment {ClientId = 15, BaseId = 4}
            };
            baseAssignments.ForEach(b => context.BaseAssignments.Add(b));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event {ClientId = 1, BaseId = 1, EventDate = DateTime.Parse("2015-05-23")},
                new Event {ClientId = 1, BaseId = 3, EventDate = DateTime.Parse("2015-04-24")}
            };
            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role {RoleId = 1, RoleName = "Admin"},
                new Role {RoleId = 2, RoleName = "CompanyManager"},
                new Role {RoleId = 3, RoleName = "NetworkManager"},
                new Role {RoleId = 4, RoleName = "NetworkDeputyManager"},
                new Role {RoleId = 5, RoleName = "RegionManager"},
                new Role {RoleId = 6, RoleName = "RegionDeputyManager"},
                new Role {RoleId = 7, RoleName = "BranchManager"},
                new Role {RoleId = 8, RoleName = "BranchDeputyManager"},
                new Role {RoleId = 9, RoleName = "Advisor"},
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var users = new List<User>
            {
                new User {UserId = 1, UserFirstName = "Adam", UserSurname = "Głos", UserName = "aglos", Email = "adam.glos@taxcare.pl", Password = "abc123"},
                new User {UserId = 2, UserFirstName = "Grzegorz", UserSurname = "Grodek", UserName = "ggrodek", Email = "grzegorz.grodek@taxcare.pl", Password = "abc123"},
                new User {UserId = 3, UserFirstName = "Jacek", UserSurname = "Birlet", UserName = "jbirlet", Email = "jacek.birlet@taxcare.pl", Password = "abc123"},
                new User {UserId = 4, UserFirstName = "Marcin", UserSurname = "Kononiuk", UserName = "mkononiuk", Email = "marcin.kononiuk@taxcare.pl", Password = "abc123"},
                new User {UserId = 5, UserFirstName = "Piotr", UserSurname = "Jaworski", UserName = "pjaworski", Email = "piotr.jaworski2@taxcare.pl", Password = "abc123"},
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

            var administrations = new List<Administration>
            {
                new Administration {AdministrationId = 1}
            };
            administrations.ForEach(a => context.Administrations.Add(a));
            context.SaveChanges();

            var companies = new List<Company>
            {
                new Company {CompanyId = 1, CompanyName = "Tax Care SA", AdministrationId = 1},
                new Company {CompanyId = 2, CompanyName = "Idea Bank SA", AdministrationId = 1}
            };
            companies.ForEach(c => context.Companies.Add(c));
            context.SaveChanges();

            var networks = new List<Network>
            {
                new Network {NetworkId = 1, NetworkName = "TCS", CompanyId = 1},
                new Network {NetworkId = 2, NetworkName = "TCP", CompanyId = 1},
                new Network {NetworkId = 3, NetworkName = "IBS", CompanyId = 2}
            };
            networks.ForEach(n => context.Networks.Add(n));
            context.SaveChanges();

            var regions = new List<Region>
            {
                new Region {RegionId = 1, RegionName = "Region 1", NetworkId = 1},
                new Region {RegionId = 2, RegionName = "Region 2", NetworkId = 1},
                new Region {RegionId = 3, RegionName = "Region 1", NetworkId = 2},
                new Region {RegionId = 4, RegionName = "Region 2", NetworkId = 2},
                new Region {RegionId = 5, RegionName = "Region 1", NetworkId = 3},
                new Region {RegionId = 6, RegionName = "Region 2", NetworkId = 3},
            };
            regions.ForEach(r => context.Regions.Add(r));
            context.SaveChanges();

            var branches = new List<Branch>
            {
                new Branch {BranchId = 1, BranchName = "TAXBIA1", RegionId = 1},
                new Branch {BranchId = 2, BranchName = "TAXGDA1", RegionId = 1},
                new Branch {BranchId = 3, BranchName = "TAXKRA1", RegionId = 2},
                new Branch {BranchId = 4, BranchName = "TAXSOS1", RegionId = 2},
                new Branch {BranchId = 5, BranchName = "TCPBIA1", RegionId = 3},
                new Branch {BranchId = 6, BranchName = "TCPSUW1", RegionId = 3},
                new Branch {BranchId = 7, BranchName = "TCPWAW1", RegionId = 4},
                new Branch {BranchId = 8, BranchName = "TCPPIA1", RegionId = 4},
                new Branch {BranchId = 9, BranchName = "TCIB WAW1", RegionId = 5},
                new Branch {BranchId = 10, BranchName = "TCIB WAW6", RegionId = 5},
                new Branch {BranchId = 11, BranchName = "TCIB KRA1", RegionId = 6},
                new Branch {BranchId = 12, BranchName = "TCIB WRO2", RegionId = 6}
            };
            branches.ForEach(b => context.Branches.Add(b));
            context.SaveChanges();

            var roleassignments = new List<RoleAssignment>
            {
                new RoleAssignment {RoleAssignmentId = 1, UnitId = 1, RoleId = 2, UserId = 1},
                new RoleAssignment {RoleAssignmentId = 2, UnitId = 1, RoleId = 2, UserId = 2},
                new RoleAssignment {RoleAssignmentId = 3, UnitId = 1, RoleId = 3, UserId = 3},
                new RoleAssignment {RoleAssignmentId = 4, UnitId = 2, RoleId = 3, UserId = 4},
                new RoleAssignment {RoleAssignmentId = 5, UnitId = 1, RoleId = 1, UserId = 5},
                new RoleAssignment {RoleAssignmentId = 6, UnitId = 1, RoleId = 4, UserId = 6},
                new RoleAssignment {RoleAssignmentId = 7, UnitId = 1, RoleId = 4, UserId = 7},
                new RoleAssignment {RoleAssignmentId = 8, UnitId = 2, RoleId = 4, UserId = 8},
                new RoleAssignment {RoleAssignmentId = 9, UnitId = 2, RoleId = 4, UserId = 9},
                new RoleAssignment {RoleAssignmentId = 10, UnitId = 1, RoleId = 5, UserId = 10},
                new RoleAssignment {RoleAssignmentId = 11, UnitId = 1, RoleId = 5, UserId = 11},
                new RoleAssignment {RoleAssignmentId = 12, UnitId = 1, RoleId = 5, UserId = 12},
                new RoleAssignment {RoleAssignmentId = 13, UnitId = 1, RoleId = 6, UserId = 13},
                new RoleAssignment {RoleAssignmentId = 14, UnitId = 1, RoleId = 6, UserId = 14},
                new RoleAssignment {RoleAssignmentId = 15, UnitId = 1, RoleId = 6, UserId = 15},
                new RoleAssignment {RoleAssignmentId = 16, UnitId = 1, RoleId = 7, UserId = 16},
                new RoleAssignment {RoleAssignmentId = 17, UnitId = 1, RoleId = 8, UserId = 17},
                new RoleAssignment {RoleAssignmentId = 18, UnitId = 1, RoleId = 8, UserId = 18},
                new RoleAssignment {RoleAssignmentId = 18, UnitId = 1, RoleId = 9, UserId = 19}
            };
        }
    }
}