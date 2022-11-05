using System.ComponentModel.DataAnnotations;

namespace CarsAPI
{
    public class Car
    {
        [Key]
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
        public string Color { get; set; } = string.Empty;
        public int HorsePower { get; set; } = 0;

    }
}
