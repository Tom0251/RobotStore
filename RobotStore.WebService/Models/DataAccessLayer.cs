using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using RobotStore.WebService.Data;

namespace RobotStore.WebService.Models
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private readonly RobotStoreContext context;

        public DataAccessLayer(DbContext context)
        {
            this.context = (RobotStoreContext)context;
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUser(string login, string password)
        {
            return context.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
        }

        public List<Robot> getRobots()
        {
            return context.Robots.ToList();
        }

        public void AddRobot(Robot robot, User user)
        {
            try
            {
                if (user.IsAdmin)
                {
                    context.Robots.Add(robot);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception(string.Format("Unauthorized operation for user {0}.", user.Login));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveRobot(Robot robot, User user)
        {
            try
            {
                if (user.IsAdmin)
                {
                    context.Robots.Remove(robot);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception(string.Format("Unauthorized operation for user {0}.", user.Login));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
