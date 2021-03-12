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
        public string CreateNewPassneger(PassengerView model)
        {
            return _PassengerRepository.CreateNewPassneger(model);
        }

        public bool DeletePassneger(int? Id)
        {
            return _PassengerRepository.DeletePassneger(Id);
        }

        public List<PassengerView> GetAllPassengers()
        {
            return _PassengerRepository.GetAllPassengers();
        }

        public PassengerView GetPassneger(int? Id)
        {
            return _PassengerRepository.GetPassneger(Id);
        }

        public string UpdatePassneger(int id, PassengerView model)
        {
            return _PassengerRepository.UpdatePassneger(id,model);
        }
    }
}
