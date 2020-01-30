﻿using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Xunit;
using RobotStore.WebService.Data;
using RobotStore.WebService.Models;
using System;

namespace RobotStore.WebService.Test.Models
{
    public class DataAccessLayerTest
    {
        private Mock<DbSet<User>> mockUser;
        private Mock<DbSet<Robot>> mockRobot;
        public DataAccessLayerTest() {  }

        [Fact]
        public void CanGetUserFromLoginAndPassword()
        {
            var users = new List<User>
            {
                new User { Id = 1, Login = "test", Password = "testPass" },
            }.AsQueryable();

            CreateMockUser(users);

            Mock<RobotStoreContext> mockContext = CreateMockUserContext();

            IDataAccessLayer dataAccessLayer = new DataAccessLayer(mockContext.Object);

            var userToTest = dataAccessLayer.GetUser("test", "testPass");

            Assert.NotNull(userToTest);
            Assert.Equal(1, userToTest.Id);
            Assert.Equal("test", userToTest.Login);
            Assert.Equal("testPass", userToTest.Password);
        }        

        [Fact]
        public void CanKnowIfUserIsAdmin()
        {
            var users = new List<User>
            {
                new User { Id = 1, Login = "test", Password = "testPass", IsAdmin = true },
            }.AsQueryable();
            CreateMockUser(users);
            Mock<RobotStoreContext> mockContext = CreateMockUserContext();

            IDataAccessLayer dataAccessLayer = new DataAccessLayer(mockContext.Object);
            bool rule = dataAccessLayer.GetUser("test", "testPass").IsAdmin;

            Assert.True(rule);
        }

        [Fact]
        public void CanGetRobotsInStore()
        {
            var robots = new List<Robot>
            {
                new Robot() { Id = 1, Designation = "New Robot", Price = decimal.One },
            }.AsQueryable();
            CreateMockRobot(robots);

            Mock<RobotStoreContext> mockContext = CreateMockRobotContext();

            IDataAccessLayer dataAccessLayer = new DataAccessLayer(mockContext.Object);
            List<Robot> robotsToTest = dataAccessLayer.getRobots();

            Assert.NotNull(robotsToTest);
            Assert.Equal(1, robotsToTest[0].Id);
            Assert.Equal("New Robot", robotsToTest[0].Designation);
            Assert.Equal(decimal.One, robotsToTest[0].Price);
        }        

        [Fact]
        public void ThrownAnExceptionIfStandarUserIntentToAddRobotInStore()
        {
            var robots = new List<Robot>();

            mockRobot = new Mock<DbSet<Robot>>();

            Mock<RobotStoreContext> mockContext = CreateMockRobotContext();

            IDataAccessLayer dataAccessLayer = new DataAccessLayer(mockContext.Object);

            var user = new User() { Id = 1, IsAdmin = false };
            var robot = new Robot() { Id = 2 };

            Assert.Throws<Exception>(() => dataAccessLayer.AddRobot(robot, user));
        }

        [Fact]
        public void AdminUserCanAddRobotInStore()
        {
            var robots = new List<Robot>();

            mockRobot = new Mock<DbSet<Robot>>();

            Mock<RobotStoreContext> mockContext = CreateMockRobotContext();

            IDataAccessLayer dataAccessLayer = new DataAccessLayer(mockContext.Object);

            var user = new User() { Id = 1, IsAdmin = true };
            var robot = new Robot() { Id = 2 };

            dataAccessLayer.AddRobot(robot, user);

            mockRobot.Verify(m => m.Add(It.IsAny<Robot>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void ThrownAnExceptionIfStandarUserIntentToRemoveRobotInStore()
        {
            var robots = new List<Robot>();

            mockRobot = new Mock<DbSet<Robot>>();

            Mock<RobotStoreContext> mockContext = CreateMockRobotContext();

            IDataAccessLayer dataAccessLayer = new DataAccessLayer(mockContext.Object);

            var user = new User() { Id = 1, IsAdmin = false };
            var robot = new Robot() { Id = 2 };

            Assert.Throws<Exception>(() => dataAccessLayer.RemoveRobot(robot, user));
        }

        [Fact]
        public void AdminUserCanRemoveRobotInStore()
        {
            var robots = new List<Robot>();

            mockRobot = new Mock<DbSet<Robot>>();

            Mock<RobotStoreContext> mockContext = CreateMockRobotContext();

            IDataAccessLayer dataAccessLayer = new DataAccessLayer(mockContext.Object);

            var user = new User() { Id = 1, IsAdmin = true };
            var robot = new Robot() { Id = 2 };

            dataAccessLayer.RemoveRobot(robot, user);

            mockRobot.Verify(m => m.Remove(It.IsAny<Robot>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        private void CreateMockUser(IQueryable<User> users)
        {
            mockUser = new Mock<DbSet<User>>();
            mockUser.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockUser.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockUser.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockUser.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());
        }

        private Mock<RobotStoreContext> CreateMockUserContext()
        {
            var mockContext = new Mock<RobotStoreContext>();
            mockContext.Setup(x => x.Users).Returns(mockUser.Object);
            return mockContext;
        }

        private void CreateMockRobot(IQueryable<Robot> robots)
        {
            mockRobot = new Mock<DbSet<Robot>>();
            mockRobot.As<IQueryable<Robot>>().Setup(m => m.Provider).Returns(robots.Provider);
            mockRobot.As<IQueryable<Robot>>().Setup(m => m.Expression).Returns(robots.Expression);
            mockRobot.As<IQueryable<Robot>>().Setup(m => m.ElementType).Returns(robots.ElementType);
            mockRobot.As<IQueryable<Robot>>().Setup(m => m.GetEnumerator()).Returns(robots.GetEnumerator());
        }
        
        private Mock<RobotStoreContext> CreateMockRobotContext()
        {
            var mockContext = new Mock<RobotStoreContext>();
            mockContext.Setup(x => x.Robots).Returns(mockRobot.Object);
            return mockContext;
        }
        //private void AddRobotToStore(Robot robot)
        //{
        //    fakeRobotStoreContext.Robots.Add(robot);
        //}

        //private void AddRobotToStore(Robot robot, User user)
        //{
        //    dataAccessLayer.AddRobot(robot, user);
        //}

        //private void AddUserToUserTable(User user)
        //{
        //    fakeRobotStoreContext.Users.Add(user);
        //}
    }
}
