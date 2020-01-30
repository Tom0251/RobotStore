using System.Collections.Generic;

namespace RobotStore.WebService.Models
{
    public interface IDataAccessLayer
    {
        #region User
        User GetUser(string login, string password);

        List<User> GetUsers();
        List<Robot> getRobots();
        void AddRobot(Robot robot, User user);
        void RemoveRobot(Robot robot, User user);

        #endregion
    }
}
