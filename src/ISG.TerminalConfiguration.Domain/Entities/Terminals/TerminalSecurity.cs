using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Entities.Terminals
{
    public class TerminalSecurity
    {
        public Guid id;
        public string token;
        public DateTime expirationDate;

        public string TerminalId { get; set; }
    }
}
