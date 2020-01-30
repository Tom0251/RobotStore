using System;
using System.Collections.Generic;
using System.Text;
using RobotStore.WebService.Models;
using System.Linq;
namespace RobotStore.WebService.Tests.Models
{
    public class FakeDataAccessLayer : IDataAccessLayer
    {
        internal List<User> users;
        internal List<Robot> robots;

        public FakeDataAccessLayer()
        {
            users = new List<User>();
            robots = new List<Robot>();
        }

        public User GetUser(string login, string password)
        {
            return users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public List<Robot> getRobots()
        {
            return robots;
        }

        internal void AddRobot(Robot robot, User user)
        {
            throw new NotImplementedException();
        }
    }
}
