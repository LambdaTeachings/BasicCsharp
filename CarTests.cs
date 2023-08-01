using System.Diagnostics;

namespace BasicCsharp_05_ClassesTest
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void TestCarStartAndTurnOff()
        {
            Car car = new Car(2.5f, 2.0f, 120.0f);

            // Initially, the car is turned off
            Assert.IsFalse(car.TurnedOn);

            // Start the car
            car.Start();
            Assert.IsTrue(car.TurnedOn);

            // Try turning off the car while it's moving (CurrentSpeed > 0)
            car.Drive(5);
            car.TurnOff();
            Assert.IsTrue(car.TurnedOn);

            // Turn off the car when it's not moving (CurrentSpeed = 0)
            car.SlowDown(100);
            car.SlowDown(100);
            car.TurnOff();
            Assert.IsFalse(car.TurnedOn);
        }

        [TestMethod]
        public void TestCarDrive()
        {
            Car car = new Car(acceleration: 3.0f, breakPower: 2.5f, maxSpeed: 100.0f);

            // Start the car
            car.Start();

            // Drive the car for 10 seconds
            car.Drive(10);
            var v0 = 0;
            var v = v0 + 3f * 10;
            var t = 10;

            var distance = (((v + v0) / 2) * t) / 1000;

            // Assert that the car's speed is correctly updated
            Assert.AreEqual(30f * 3.6f, car.CurrentSpeed, 0.01f);

            // Assert that the total distance is correctly updated
            Assert.AreEqual(distance, car.TotalDistance, 0.01f);
        }

        [TestMethod]
        public void TestCarSlowDown()
        {
            var acceleration = 10f / 3.6f;
            var maxSpeed = 100f;
            var breakPower = 5 / 3.6f;
            var drive = 5;
            var slow = 5;

            Car car = new Car(acceleration, breakPower, maxSpeed);

            // Start the car
            car.Start();

            car.Drive(drive);
            car.SlowDown(slow);

            // Assert that the car's speed is correctly updated
            Assert.AreEqual(25, car.CurrentSpeed, 0.01f);

            // Assert that the total distance is correctly updated
            float driveDistance = 0.5f * (50 / 3.6f) * drive;
            float slowDistance = (50 / 3.6f) * slow + 0.5f * -breakPower * slow * slow;
            Assert.AreEqual(driveDistance + slowDistance, car.TotalDistance * 1000, 0.01f);
        }

        [TestMethod]
        public void TestCarCruise()
        {
            var acceleration = 10f / 3.6f;
            var maxSpeed = 100f;
            var breakPower = 20f;
            var drive = 5;
            var cruise = 5;

            Car car = new Car(acceleration, breakPower, maxSpeed);

            // Start the car
            car.Start();

            // Drive the car for X seconds
            car.Drive(drive);

            Assert.AreEqual(acceleration * drive, car.CurrentSpeed / 3.6f, 0.01f, "Velocity after drive does not match car speed.");

            // Assert that the total distance is correctly updated
            float driveDistance = 0.5f * (50 / 3.6f) * drive;
            Debug.WriteLine(driveDistance);
            Assert.AreEqual(driveDistance, car.TotalDistance * 1000, 0.01f, "Car distance covered does not match the expected value.");

            // Cruise at the current speed for Y seconds
            car.Cruise(cruise);

            // Assert that the car's speed remains unchanged
            Assert.AreEqual(acceleration * drive, car.CurrentSpeed / 3.6f, 0.01f, "Velocity after cruise does not match car speed.");

            // Assert that the total distance is correctly updated
            float cruiseDistance = (50 / 3.6f) * cruise;
            Debug.WriteLine(cruiseDistance);
            Assert.AreEqual(cruiseDistance + driveDistance, car.TotalDistance * 1000f, 0.01f, "Car distance covered after cruise does not match the expected value.");
        }
    }
}