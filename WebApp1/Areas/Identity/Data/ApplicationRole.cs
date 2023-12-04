using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Identity;
using System;

namespace WebApp1.Areas.Identity.Data
{
    public class ApplicationRole : IdentityRole<Guid>
    {        
        public string Description { get; set; }
    }
}




