using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotStore.WebService.Data;

namespace RobotStore.WebService.Test.Models
{
    public class FakeRobotStoreContext : RobotStoreContext
    {
        public FakeRobotStoreContext()
        {
            Users = new List<WebService.Models.User>();
        }
        public new virtual List<RobotStore.WebService.Models.User> Users { get; set; }

        public new virtual List<RobotStore.WebService.Models.Robot> Robots { get; set; }

    }
}
