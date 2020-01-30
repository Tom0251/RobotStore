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

        public FakeDataAccessLayer()
        {
            users = new List<User>();
        }

        public User GetUser(string login, string password)
        {
            return users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
        }
    }
}
