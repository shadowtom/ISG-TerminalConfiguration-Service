using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Infrastructure.DTO
{
    [Table("KioskSettings")]
    public class KioskDTO
    {
        public Guid Id { get; set; }
        public Guid ClientID { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
