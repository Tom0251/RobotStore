using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotStore.WebAPI.Models
{
    public class RobotStoreContext : IdentityDbContext
    {
        public RobotStoreContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<User> ApplicationUsers { get; set; }
        public virtual DbSet<Robot> Robots { get; set; }
    }
}
