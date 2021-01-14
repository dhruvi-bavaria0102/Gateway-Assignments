using HMS.DAL.Repository.Interfaces;
using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace HMS.DAL.Repository.Classes
{
    public class BookingRepository : IBookingRepository
    {
        enum BookingsStatus
        {
            Optional,
            Definitive,
            Cancelled,
            Deleted
        }
        private readonly Database.WebApiEntities1 _dbContext;
        public BookingRepository()
        {
            _dbContext = new Database.WebApiEntities1();
        }

        public string deleteBooking(Booking model)
        {
            try
            {
                if (model.BookingId != null)
                {
                    Database.Booking_Detail booking = _dbContext.Booking_Detail.Find(model.BookingId);
                    if (booking != null)
                    {
                        booking.BookingsStatus = BookingsStatus.Deleted.ToString();
                        _dbContext.SaveChanges();
                        return "Status of Booking id " + model.BookingId + " has been changed to deleted";
                     }
                    else
                    {
                        return "Booking No "+ model.BookingId + " is not there nothing to delete";
                    }
                }
                return "Booking id is empty";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Booking> getAllBooking()
        {
            var entities = _dbContext.Booking_Detail.ToList();
            List<Booking> list = new List<Booking>();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Mapper.CreateMap<Database.Booking_Detail, Booking>();
                    Booking booking = Mapper.Map<Booking>(item);
                    list.Add(booking);
                }
            }
            return list;
        }

        public string updateBooking(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var bookingRecord = _dbContext.Booking_Detail.Where(m => m.RoomId == model.RoomId).FirstOrDefault();
                    if (bookingRecord != null)
                    {
                        if(bookingRecord.BookingsStatus== BookingsStatus.Optional.ToString() || bookingRecord.BookingsStatus == BookingsStatus.Definitive.ToString())
                        {
                            var oldBookingDate = bookingRecord.BookingDate;
                            bookingRecord.BookingDate = model.BookingDate;
                            _dbContext.SaveChanges();
                            return "Booking of room no " + model.RoomId + " has been changed from "+ oldBookingDate+" to " + model.BookingDate + " with optional status";
                        }
                        return "Booking of room no " + model.RoomId + " has been " + bookingRecord.BookingsStatus + ". So the booking date cannot be modified";
                    }
                    else
                    {
                        return "Room no. "+model.RoomId+ " is not booked! please book first to update your booking";
                    }
                }
                return "Model is empty";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string updateBookingStatus(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var bookingRecord = _dbContext.Booking_Detail.Where(m => m.BookingId == model.BookingId).FirstOrDefault();
                    if (bookingRecord != null)
                    {
                        if (bookingRecord.BookingsStatus == BookingsStatus.Optional.ToString() || bookingRecord.BookingsStatus == BookingsStatus.Definitive.ToString())
                        {
                            bookingRecord.BookingsStatus = model.BookingsStatus;
                            _dbContext.SaveChanges();
                            return "Status of Booking no " + model.BookingId + " has been changed to " + model.BookingsStatus;
                        }
                        return "Booking of room no " + model.BookingId + " has been " + bookingRecord.BookingsStatus + ". So the booking status cannot be modified";
                    }
                    else
                    {
                        return "Booking no. " + model.BookingId + " is not there! please book first to update your booking";
                    }
                }
                return "Model is empty";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
