using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoParkService.Entity.DTO;

public record LoginDTO
{
    public string Email { get; set; }
    public string PassWord { get; set; }
}
