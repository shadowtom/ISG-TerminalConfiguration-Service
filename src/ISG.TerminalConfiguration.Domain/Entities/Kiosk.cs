using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Entities
{
    public class Kiosk
    {
        public Guid Id { get; set; }
        public Guid ClientID { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
