using ApiWithDb.Data;
using ApiWithDb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithDb.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        MyContext _db;
        Responce _responce;

        public CityController(MyContext db, Responce responce)
        {
            _db = db;
            _responce = responce;
        }

        [HttpGet]
        public List<City> GetCities()
        {
            return _db.Set<City>().ToList();
        }
        [HttpGet("{Id:int}")]
        public City GetCity(int Id)
        {
            return _db.Set<City>().Find(Id);
        }
        [HttpPost]
        public Responce Add(City city)
        {
            try
            {
                _db.Set<City>().Add(city);
                _db.SaveChanges();
                _responce.Error = false;
                _responce.Msg = $"{city.CityName} başarılı şekilde eklendi.";
            }
            catch (Exception ex)
            {
                _responce.Error = true;
                _responce.Msg = ex.Message;

            }
            return _responce;
        }
        [HttpPut]
        public Responce Update(City city)
        {
            try
            {
                _db.Set<City>().Update(city);
                _db.SaveChanges();
                _responce.Error = false;
                _responce.Msg = $"{city.CityName} başarılı şekilde güncellendi.";
            }
            catch (Exception ex)
            {
                _responce.Error = true;
                _responce.Msg = ex.Message;

            }
            return _responce;
        }
        [HttpDelete]
        public Responce Delete(City city)
        {
            try
            {
                _db.Set<City>().Remove(city);
                _db.SaveChanges();
                _responce.Error = false;
                _responce.Msg = $"{city.CityName} Başarılı şekilde silindi.";
            }
            catch (Exception ex)
            {
                _responce.Error = true;
                _responce.Msg = ex.Message;

            }
            return _responce;
        }
        [HttpDelete("{Id:int}")]
        public Responce DeleteById(int Id)
        {
            return Delete(GetCity(Id));
        }
    }
}
