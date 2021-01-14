using HMS.BAL.Interfaces;
using HMS.DAL.Repository.Interfaces;
using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Classes
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public string bookRoom(Booking model)
        {
            return _roomRepository.bookRoom(model);
        }

        public bool checkRoomAvailability(int id, DateTime date)
        {
            return _roomRepository.checkRoomAvailability(id, date);
        }

        public string createRoom(Room model)
        {
            return _roomRepository.createRoom(model);
        }

        public List<Room> searchRoom(string city = null, decimal? pincode = null, int? price = null, string category = null)
        {
            return _roomRepository.searchRoom(city,pincode,price,category);
        }
    }
}
