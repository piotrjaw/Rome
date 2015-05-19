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
            var Clients = new List<Client>
            {
                new Client{ClientId=1,Owner="Jan Kowalski",CompanyName="ABC"},
                new Client{ClientId=2,Owner="Roman Nowak",CompanyName="DEF"},
                new Client{ClientId=3,Owner="Marian Szpak",CompanyName="123"},
                new Client{ClientId=4,Owner="Katarzyna Psztynk",CompanyName="321"},
                new Client{ClientId=5,Owner="Roman Wiśniewski",CompanyName="ZZZ SA"}
            };
            Clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();
            var Bases = new List<Base>
            {
                new Base{BaseId=1,BaseName="Upsell BKI"},
                new Base{BaseId=2,BaseName="Odnowienie limitów"}
            };
            Bases.ForEach(b => context.Bases.Add(b));
            context.SaveChanges();
        }
    }
}