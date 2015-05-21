using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DAL
{
    public class XSellInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<XSellContext>
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
                new Client{ClientId=10,Owner="Stefan Małolepszy",CompanyName="Stefan Małolepszy"}
            };
            clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();
            var bases = new List<Base>
            {
                new Base{BaseId=1,BaseName="Upsell BKI",BaseStart=DateTime.Parse("2015-05-20"),BaseEnd=DateTime.Parse("2015-06-20")},
                new Base{BaseId=2,BaseName="Odnowienie limitów",BaseStart=DateTime.Parse("2015-04-20"),BaseEnd=DateTime.Parse("2015-05-21")}
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
                new BaseAssignment {ClientId = 10, BaseId = 1}
            };
            baseAssignments.ForEach(b => context.BaseAssignments.Add(b));
            context.SaveChanges();
        }
    }
}