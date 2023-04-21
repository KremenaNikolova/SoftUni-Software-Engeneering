namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        string robotName = "C-45";
        int maximumBattery = 100;
        int capacity = 2;

        Robot robot;
        RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot(robotName, maximumBattery);
            robotManager = new RobotManager(capacity);
        }

        [Test]
        public void Test_Robot_Constructor()
        {
            Assert.AreEqual(robotName, robot.Name);
            Assert.AreEqual(maximumBattery, robot.MaximumBattery);
        }

        [Test]
        public void Test_RobotManager_Constructor()
        {
            Assert.AreEqual(capacity, robotManager.Capacity);
        }

        [Test]
        public void Test_RobotManager_Capacity_ShouldThrowExceptionWhenIsBelowZero()
        {
            int capacity = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager wrongRobot = new RobotManager(capacity);
            });
        }

        [Test]
        public void Test_RobotManager_Counter()
        {
            robotManager.Add(robot);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, robotManager.Count);
        }

        [Test]
        public void Test_RobotManager_Add_ShouldThrowExceptionIfRobotAlreadyExist()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
            });
        }

        [Test]
        public void Test_RobotManager_Add_ShouldThrowExceptionIfCapacityIsFull()
        {
            Robot oneMoreRobot = new Robot("B-64", 100);

            robotManager.Add(robot);
            robotManager.Add(oneMoreRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Error", 100));
            });

        }

        [Test]
        public void Test_RobotManager_Remove()
        {
            robotManager.Add(robot);

            robotManager.Remove(robotName);

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, robotManager.Count);
        }

        [Test]
        public void Test_RobotManager_Remove_ShouldThrowExceptionIfRobotIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove(robotName);
            });
        }

        [Test]
        public void Test_RobotManager_Work()
        {
            int batteryUsage = 45;
            int expectedBattery = maximumBattery - batteryUsage;

            robotManager.Add(robot);
            robotManager.Work(robotName, "Somethin that we dont neeed", batteryUsage);

            Assert.AreEqual(expectedBattery, robot.Battery);
        }

        [Test]
        public void Test_RobotManager_Work_ShouldThrowExceptionIfRobotIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Error", "Emty words", 3);
            });
        }

        [Test]
        public void Test_RobotManager_Work_ShouldThrowExceptionIfBatteryIsLowerThanBatteryUsage()
        {
            int batteryUsage = 101;
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(robotName, "No need that", batteryUsage);
            });
        }

        [Test]
        public void Test_RobotManager_Charge()
        {
            robotManager.Add(robot);
            robotManager.Work(robotName, "babysitter", 45);

            robotManager.Charge(robotName);

            Assert.AreEqual(maximumBattery, robot.Battery);
        }

        [Test]
        public void Test_RobotManager_Charge_ShouldThrowExceptionIfRobotIsNull()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge(robotName);
            });
        }

    }
}
