using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.NavigationModule.Models
{
    public class NavItem
    {
        public string Glyph { get; set; }

        public string Label { get; set; }

        public List<NavItem> Items { get; set; }
    }
}
