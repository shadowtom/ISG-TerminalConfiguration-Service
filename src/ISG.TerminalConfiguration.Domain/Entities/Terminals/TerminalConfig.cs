using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Entities.Terminals
{
    public class TerminalConfig
    {
        public Guid Id { get; set; }
        public string clientID { get; set; }
        public string TerminalId { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public bool Enabled { get; set; }

        public string KioskID { get; set; } = string.Empty;
    }
}
