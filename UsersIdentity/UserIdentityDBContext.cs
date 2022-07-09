using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersIdentity
{
    public class UserIdentityDBContext : IdentityDbContext
    {
        public UserIdentityDBContext(DbContextOptions<UserIdentityDBContext> options)
            :base(options)
        {

        }

    }
}
