using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Domain
{
    public class SalesLeadEntity
    {
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Source { get; set; }

    }
}
