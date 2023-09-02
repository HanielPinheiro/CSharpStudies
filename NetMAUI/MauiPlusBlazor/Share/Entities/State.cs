using System.ComponentModel.DataAnnotations;

namespace Share.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [MaxLength(100, ErrorMessage = "The field {0} can't have more than {1} characters")]
        [Display(Name = "State")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }

        public Country? Country { get; set; }

        public ICollection<City>? Cities { get; set; }

        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
