using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Infrastructure.DTO
{
    [Table("TerminalSettingsInfo")]
    public class TerminalConfigurationDTO
    {
        public TerminalConfigurationDTO()
        {
            
        }
        public Guid Id { get; set; }
        public string clientID { get; set; } = string.Empty;
        public string TerminalId { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string KioskID { get; set; } = string.Empty;
        public int Port { get; set; }
        public bool Enabled { get; set; }
        public virtual TerminalSecurityDTO Security { get; private set; }
    }
}
