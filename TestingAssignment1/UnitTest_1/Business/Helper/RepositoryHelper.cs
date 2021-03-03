using Data.Repository;
using Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace BusinessLogic.Helper
{
    public class PassengerManager : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IPassangerRepository, PassengerRepository>();
        }
    }
}
