using HMS.DAL.Repository.Interfaces;
using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace HMS.DAL.Repository.Classes
{
    public class RoomRepository : IRoomRepository
    {
        enum BookingsStatus
        {
            Optional,
            Definitive,
            Cancelled,
            Deleted
        }
        private readonly Database.HMSEntities _dbContext;
        public RoomRepository()
        {
            _dbContext = new Database.HMSEntities();
        }

        public string bookRoom(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var bookingRecord = _dbContext.Booking_Detail.Where(m => m.RoomId == model.RoomId && DbFunctions.TruncateTime(m.BookingDate) == model.BookingDate).FirstOrDefault(); //TruncateTime remove time from datetime
                    if (bookingRecord == null)
                    {
                        Database.Booking_Detail booking = new Database.Booking_Detail();
                        booking.RoomId = model.RoomId;
                        booking.BookingsStatus = BookingsStatus.Optional.ToString();
                        booking.BookingDate = model.BookingDate;
                        _dbContext.Booking_Detail.Add(booking);
                        _dbContext.SaveChanges();
                        return "Booking of room no " + model.RoomId + " has been confirmed on " + model.BookingDate + " with optional status";
                    }
                    else
                    {
                        return "Room is already booked on " + model.BookingDate;
                    }
                }
                return "ID and date can are required";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool checkRoomAvailability(int id, DateTime date)
        {
            try
            {
                if (id != null && date != null)
                {
                    var bookingRecord = _dbContext.Booking_Detail.Where(m => m.RoomId == id && DbFunctions.TruncateTime(m.BookingDate) == date).FirstOrDefault();
                    if (bookingRecord == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string createRoom(Room entity)
        {
            try
            {
                if (entity != null)
                {
                    Mapper.CreateMap<Room, Database.Room_Details>();
                    Database.Room_Details room = Mapper.Map<Database.Room_Details>(entity);
                    _dbContext.Room_Details.Add(room);
                    _dbContext.SaveChanges();

                    return "Room Successfully Added!!";
                }
                return "Model is null!!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Room> searchRoom(string city = null, decimal? pincode = null, int? price = null, string category = null)
        {

            var entities = _dbContext.Room_Details.ToList();
            List<Room> list = new List<Room>();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Mapper.CreateMap<Database.Room_Details, Room>();
                    Room room = Mapper.Map<Room>(item);
                    list.Add(room);
                }
            }
            return list;


        }
    }
}
