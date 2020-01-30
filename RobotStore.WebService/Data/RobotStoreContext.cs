using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RobotStore.WebService.Data
{
    public class RobotStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RobotStoreContext() : base("name=RobotStoreContext")
        {
        }

        public virtual DbSet<RobotStore.WebService.Models.User> Users { get; set; }

        public virtual DbSet<RobotStore.WebService.Models.Robot> Robots { get; set; }
    }
}
