using System.Collections.Generic;
using System.Linq;

namespace RobotStore.WebAPI.Models
{
    public interface IDataAccessLayer
    {
        #region User
        User GetUser(string login, string password);

        List<User> GetUsers();

        #endregion

        #region Robot
        IQueryable<Robot> getRobots();
        void AddRobot(Robot robot, User user);
        void RemoveRobot(Robot robot, User user);
        #endregion
    }
}
