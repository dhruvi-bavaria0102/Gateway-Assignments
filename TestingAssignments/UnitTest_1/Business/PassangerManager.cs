using BusinessEntitites;
using BusinessLogic.Interface;
using Data.Repository;
using Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PassangerManager : IPassengerManager
    {
        private readonly IPassangerRepository _PassengerRepository;
        public PassangerManager(PassengerRepository PassengerRepository)
        {
            _PassengerRepository = PassengerRepository;
        }
        public string CreateNewPassenger(PassengerView model)
        {
            return _PassengerRepository.CreateNewPassenger(model);
        }

        public bool DeletePassenger(int? Id)
        {
            return _PassengerRepository.DeletePassenger(Id);
        }

        public List<PassengerView> GetAllPassengers()
        {
            return _PassengerRepository.GetAllPassengers();
        }

        public PassengerView GetPassenger(int? Id)
        {
            return _PassengerRepository.GetPassenger(Id);
        }

        public string UpdatePassenger(int id, PassengerView model)
        {
            return _PassengerRepository.UpdatePassenger(id,model);
        }
    }
}
