using BusinessEntitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IPassengerManager
    {
        string CreateNewPassneger(PassengerView model);
        List<PassengerView> GetAllPassengers();
        PassengerView GetPassneger(int? Id);
        string UpdatePassneger(int id, PassengerView model);
        bool DeletePassneger(int? Id);
    }
}
