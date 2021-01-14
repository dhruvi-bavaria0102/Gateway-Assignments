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
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.WebApiEntities1 _dbContext;
        public HotelRepository()
        {
            _dbContext = new Database.WebApiEntities1();
        }
        public string createHotel(Hotel entity)
        {
            try
            {
                if (entity != null)
                {
                    Mapper.CreateMap<Hotel, Database.Hotel_Details>();
                    Database.Hotel_Details hotel = Mapper.Map<Database.Hotel_Details>(entity);
                    _dbContext.Hotel_Details.Add(hotel);
                    _dbContext.SaveChanges();

                    return "Successfully Added!!";
                }
                return "Model is null!!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Hotel> getAllHolels()
        {
            var entities = _dbContext.Hotel_Details.OrderBy(c => c.HotelName).ToList();
            List<Hotel> list = new List<Hotel>();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Mapper.CreateMap<Database.Hotel_Details,Hotel>();
                    Hotel hotel = Mapper.Map<Hotel>(item);
                    list.Add(hotel);
                }
            }
            return list;
        }


        public Hotel getHotel(int id)
        {
            var entity = _dbContext.Hotel_Details.Where(c=>c.HotelId == id).FirstOrDefault();
            Hotel hotel = new Hotel();
            if (entity != null)
            {
                Mapper.CreateMap<Database.Hotel_Details, Hotel>();
                hotel = Mapper.Map<Hotel>(entity);
            }
            
            return hotel;
        }
    }
}
