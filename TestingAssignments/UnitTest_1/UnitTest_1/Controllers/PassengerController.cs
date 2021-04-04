using BusinessEntitites;
using BusinessLogic.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace UnitTest_1.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IPassengerManager _passengerManager;

        public PassengerController(IPassengerManager passengerManager)
        {
            _passengerManager = passengerManager;
        }

        /// <summary>
        /// Get all customer list from database.
        /// </summary>
        /// <returns>List of Passengers</returns>
        [Route("api/Passengers")]
        [HttpGet]
        public List<PassengerView> GetPassengers()
        {
            return _passengerManager.GetAllPassengers();
        }

        /// <summary>
        /// Get customer with the desired id
        /// </summary>
        /// <returns>Passengers with id</returns>
        [Route("api/Passengers/{id}")]
        [HttpGet]
        public PassengerView GetPassenger(int id)
        {
            return _passengerManager.GetPassenger(id); ;
        }

        /// <summary>
        /// Update customer data by its id.
        /// </summary>
        /// <param name="passenger">Contain all updated data of customer</param>
        /// <param name="id">Contain custoemr id.</param>
        /// <returns>Return true if data updated into database otherwise return false.</returns>
        [Route("api/Passengers/{id}")]
        [HttpPut]
        public string PutPassenger(int id, PassengerView passenger)
        {
            return _passengerManager.UpdatePassenger(id, passenger);
        }

        /// <summary>
        /// Add new customer into database
        /// </summary>
        /// <param name="passenger">Contain new customer data.</param>
        /// <returns></returns>
        [Route("api/Passengers")]
        [HttpPost]
        public string PostPassenger(PassengerView passenger)
        {
            return _passengerManager.CreateNewPassenger(passenger);
        }

        /// <summary>
        /// Delete customer by its id.
        /// </summary>
        /// <param name="id">Contain customer id.</param>
        /// <returns>Return true if custoemr data is deleted otherwose return false.</returns>
        [Route("api/Passengers/{id}")]
        [HttpDelete]
        public bool DeletePassenger(int id)
        {
            return _passengerManager.DeletePassenger(id);
        }
    }
}