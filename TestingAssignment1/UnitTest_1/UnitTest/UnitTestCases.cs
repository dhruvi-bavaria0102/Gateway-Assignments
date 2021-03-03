using System.Collections.Generic;
using Xunit;
using Moq;
using System.Linq;
using BusinessLogic.Interface;
using BusinessEntitites;
using UnitTest_1.Controllers;

namespace UnitTest
{
    public class PassengerUnitTest
    {
        private readonly Mock<IPassengerManager> mockDtaRepository = new Mock<IPassengerManager>();
        private readonly PassengerController _passengerController;
        public PassengerUnitTest()
        {
            _passengerController = new PassengerController(mockDtaRepository.Object);
        }

        private static List<PassengerView> GetPassenger()
        {
            List<PassengerView> users = new List<PassengerView>()
            {
                new PassengerView() {P_No=1,F_Name="Dhruvi",L_Name="Bavaria",Phone=932730392},
                new PassengerView() {P_No=1,F_Name="Shivangi",L_Name="Gajera",Phone=932730392},
                new PassengerView() {P_No=1,F_Name="Vaishvi",L_Name="Patel",Phone=932730392},

            };
            return users;
        }

        [Fact]
        public void GetAllPassenger1()
        {
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.GetAllPassengers()).Returns(GetPassenger());

            // Act
            var response = _passengerController.GetPassengers();

            // Asert
            Assert.Equal(3, response.Count);

        }

        [Fact]
        public void GetAllPassenger2()
        {
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.GetAllPassengers()).Returns(GetPassenger());

            // Act
            var response = _passengerController.GetPassengers();

            // Asert
            Assert.NotEqual(2, response.Count);

        }

        [Fact]
        public void GetPassengerById1()
        {
            // Arrange
            var passenger = new PassengerView();
            passenger.P_No = 1;
            passenger.F_Name = "Dhruvi";
            passenger.L_Name = "Bavaria";
            passenger.Phone = 90876534;

            // Act
            var responseObj = mockDtaRepository.Setup(x => x.GetPassneger(passenger.P_No)).Returns(passenger);
            var result = _passengerController.GetPassenger(passenger.P_No);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void GetPassengerById2()
        {
            // Arrange
            var passenger = new PassengerView();
            // Act
            var responseObj = mockDtaRepository.Setup(x => x.GetPassneger(4)).Returns(passenger);
            var result = _passengerController.GetPassenger(passenger.P_No);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddPassenger1()
        {
            var newPassenger = new PassengerView();
            newPassenger.P_No = 4;
            newPassenger.F_Name = "Atul";
            newPassenger.L_Name = "Bavaria";
            newPassenger.Phone = 86950498;
            // Act
            var response = mockDtaRepository.Setup(x => x.CreateNewPassneger(newPassenger)).Returns("Added succeffuly");
            var result = _passengerController.PostPassenger(newPassenger);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddPassenger2()
        {
            var newPassenger = new PassengerView();

            // Act
            var response = mockDtaRepository.Setup(x => x.CreateNewPassneger(newPassenger)).Returns("Model is null");
            var result = _passengerController.PostPassenger(newPassenger);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void UpdatePassenger1()
        {
            // Arrange
            var UpdatePassenger = new PassengerView();
            UpdatePassenger.P_No = 4;
            UpdatePassenger.F_Name = "Aryan";
            UpdatePassenger.L_Name = "Bavaria";
            UpdatePassenger.Phone = 8695049;

            // Act
            var resultObj = mockDtaRepository.Setup(x => x.UpdatePassneger(4, UpdatePassenger)).Returns("Passenger updated");
            var response = _passengerController.PutPassenger(4, UpdatePassenger);
            // Assert
            Assert.Equal("Passenger updated", response);
        }
        [Fact]
        public void UpdatePassenger2()
        {
            // Arrange
            var UpdatePassenger = new PassengerView();

            // Act
            var resultObj = mockDtaRepository.Setup(x => x.UpdatePassneger(5, UpdatePassenger)).Returns("Model is null");
            var response = _passengerController.PutPassenger(5, UpdatePassenger);
            // Assert
            Assert.NotEqual("Passenger updated", response);
        }
        [Fact]
        public void DeletePassenger1()
        {
            var passenger = new PassengerView();
            passenger.P_No = 1;
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.DeletePassneger(passenger.P_No)).Returns(true);

            // Act
            var response = _passengerController.DeletePassenger(passenger.P_No);

            //Assert
            Assert.True(response);

        }
        [Fact]
        public void DeletePassenger2()
        {
            var passenger = new PassengerView();
            passenger.P_No = 4;
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.DeletePassneger(passenger.P_No)).Returns(false);

            // Act
            var response = _passengerController.DeletePassenger(passenger.P_No);

            //Assert
            Assert.False(response);

        }
    }
}
