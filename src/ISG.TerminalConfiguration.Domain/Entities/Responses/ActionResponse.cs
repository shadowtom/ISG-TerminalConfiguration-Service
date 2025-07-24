using ISG.TerminalConfiguration.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Entities.Responses
{
    public class ActionResponse
    {
        public OperationEnum Operation { get; set; }
        public string Response { get; set; } = string.Empty;
    }
}
