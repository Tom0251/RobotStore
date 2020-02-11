using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RobotStore.WebAPI.Models
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
            return context.ApplicationUsers.ToList();
        }

        public User GetUser(string userName, string passwordHash)
        {
            return context.ApplicationUsers.Where(x => x.UserName == userName && x.PasswordHash == passwordHash).FirstOrDefault();
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
                    throw new Exception(string.Format("Unauthorized operation for user {0}.", user.UserName));
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
                    throw new Exception(string.Format("Unauthorized operation for user {0}.", user.UserName));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
