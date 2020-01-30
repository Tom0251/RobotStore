using Xunit;
using RobotStore.WebService.Models;
using RobotStore.WebService.Tests.Models;

namespace RobotStore.WebService.Tests.Models
{
    public class DataAccessLayerTest
    {
        private readonly FakeDataAccessLayer fakeDataAccessLayer;
        public DataAccessLayerTest()
        {
            fakeDataAccessLayer = new FakeDataAccessLayer();
        }

        [Fact]
        public void CanGetUserFromLoginAndPassword()
        {
            var user = new User() { Id = 1, Login = "test", Password = "testPass" };
            AddUserToUserTable(user);

            var userToTest = fakeDataAccessLayer.GetUser("test", "testPass");

            Assert.NotNull(userToTest);
            Assert.Equal(user, userToTest);
        }

        [Fact]
        public void CanKnowIfUserIsAdmin()
        {
            var user = new User() { Id = 1, Login = "test", Password = "testPass", IsAdmin = true };
            AddUserToUserTable(user);

            bool rule = fakeDataAccessLayer.GetUser("test", "testPass").IsAdmin;

            Assert.True(rule);
        }

        private void AddUserToUserTable(User user)
        {
            fakeDataAccessLayer.users.Add(user);
        }
    }
}
