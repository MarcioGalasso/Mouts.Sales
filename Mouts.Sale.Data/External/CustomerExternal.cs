using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouts.Sale.Data.External
{
    public class CustomerExternal
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
    }
}
