using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Infrastructure.DTO
{
    [Table("TerminalSecurity")]
    public class TerminalSecurityDTO
    {
        public TerminalSecurityDTO()
        {
            
        }
        public Guid id { get; set; }
        public string token { get; set; }
        public Guid TerminalId { get; set; }
        public DateTime expirationDate { get; set; }

        public virtual TerminalConfigurationDTO Configuration { get; private set; }
    }
}
