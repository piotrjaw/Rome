using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rome.Models
{
    public class ProductAssignment
    {
        public int ProductId { get; set; }
        public int ProductSetId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductSet ProductSet { get; set; }
    }
}
