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
                new Base{BaseId=2,BaseName="Odnowienie limitów",BaseStart=DateTime.Parse("2015-04-20"),BaseEnd=DateTime.Parse("2015-06-21")},
                new Base{BaseId=3,BaseName="Taniej z Księgowością 2",BaseStart=DateTime.Parse("2015-04-20"),BaseEnd=DateTime.Parse("2015-06-24")},
                new Base{BaseId=3,BaseName="Taniej z Księgowością 1",BaseStart=DateTime.Parse("2015-04-20"),BaseEnd=DateTime.Parse("2015-05-21")}
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
        }
    }
}