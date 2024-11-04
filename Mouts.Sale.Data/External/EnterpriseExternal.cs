using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouts.Sale.Data.External
{
    public class EnterpriseExternal
    {
        public Guid EnterpriseId { get; set; }
        public string Name { get; set; }

        public string Registration { get; set; }
        public string Description { get; set; }
    }
}
