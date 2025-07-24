using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Entities
{
    public class Terminal
    {
        public TerminalConfig Configuration { get; set; }
        public TerminalSecurity Security { get; set; }
    }
}
