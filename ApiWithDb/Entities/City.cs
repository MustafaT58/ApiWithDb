using System.ComponentModel.DataAnnotations;

namespace ApiWithDb.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string ?CityName { get; set; }
        public ICollection<Personel> ?Personel { get; set; }

    }
}
