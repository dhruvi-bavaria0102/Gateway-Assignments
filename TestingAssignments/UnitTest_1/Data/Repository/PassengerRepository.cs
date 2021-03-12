using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntitites;
using Data.Model;
using Data.Repository.Interface;

namespace Data.Repository
{
    public class PassengerRepository : IPassangerRepository
    {
        private readonly SampleEntities db;
        public PassengerRepository()
        {
            db = new SampleEntities();
        }
        public List<PassengerView> GetAllPassengers()
        {
            var entity = db.tbl_Passenger.ToList();
            List<PassengerView> list = new List<PassengerView>();
            if (db != null)
            {
                foreach (var item in entity)
                {
                    PassengerView passenger = new PassengerView();
                    passenger.P_No = item.P_No;
                    passenger.F_Name = item.F_Name;
                    passenger.L_Name = item.L_Name;
                    passenger.Phone = item.Phone;
                    list.Add(passenger);
                }
            }
            return list;
        }
        public string CreateNewPassneger(PassengerView model)
        {
            try
            {
                if (model != null)
                {
                    tbl_Passenger passenger = new tbl_Passenger();
                    passenger.P_No = model.P_No;
                    passenger.F_Name = model.F_Name;
                    passenger.L_Name = model.L_Name;
                    passenger.Phone = model.Phone;
                    db.tbl_Passenger.Add(passenger);
                    db.SaveChanges();
                    return "Added succeffuly";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeletePassneger(int? Id)
        {
            var entity = db.tbl_Passenger.Find(Id);
            if (entity != null)
            {
                db.tbl_Passenger.Remove(entity);
                db.SaveChanges();
                return true;
            }
            return false;

        }
        public string UpdatePassneger(int id, PassengerView model)
        {
            try
            {
                tbl_Passenger entity = db.tbl_Passenger.Find(id);
                if (model != null)
                {
                    entity.P_No = model.P_No;
                    entity.F_Name = model.F_Name;
                    entity.L_Name = model.L_Name;
                    entity.Phone = model.Phone;
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                    return "Passenger updated";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public PassengerView GetPassneger(int? Id)
        {
            try
            {
                var entity = db.tbl_Passenger.Find(Id);
                PassengerView passenger = new PassengerView();
                passenger.P_No = entity.P_No;
                passenger.F_Name = entity.F_Name;
                passenger.L_Name = entity.L_Name;
                passenger.Phone = entity.Phone;
                return passenger;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
