using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public int? Credit { get; set; }
        public int? Score { get; set; }
    }
}
