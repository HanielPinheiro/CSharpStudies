using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Share.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [MaxLength(100, ErrorMessage = "The field {0} can't have more than {1} characters")]
        [Display(Name = "Citie")]
        public string Name { get; set; } = null!;

        public int StateId { get; set; }

        public State? State { get; set; }

    }
}
