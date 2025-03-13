using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoParkService.Entity.Common;

public class SendGridRequest
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
