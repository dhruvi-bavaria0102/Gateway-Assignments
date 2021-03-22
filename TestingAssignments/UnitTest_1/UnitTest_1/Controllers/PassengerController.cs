using BusinessEntitites;
using BusinessLogic.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace UnitTest_1.Controllers
{
    public class PassengerController : ApiController
    {
        // GET: Passenger
        private readonly IPassengerManager _passengerManager;

        public PassengerController(IPassengerManager passengerManager)
        {
            _passengerManager = passengerManager;
        }

        // GET: api/Passengers
        public List<PassengerView> GetPassengers()
        {
            return _passengerManager.GetAllPassengers();
        }

        // GET: api/Passengers/5
        public PassengerView GetPassenger(int id)
        {
            return _passengerManager.GetPassenger(id); ;
        }

        // PUT: api/Passengers/5
        public string PutPassenger(int id, PassengerView passenger)
        {
            return _passengerManager.UpdatePassenger(id, passenger);
        }

        // POST: api/Passengers
        public string PostPassenger(PassengerView passenger)
        {
            return _passengerManager.CreateNewPassenger(passenger);
        }

        // DELETE: api/Passengers/5
        public bool DeletePassenger(int id)
        {
            return _passengerManager.DeletePassenger(id);
        }
    }
}