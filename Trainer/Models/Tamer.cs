using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trainer.Models
{
    public class Tamer
    {
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)] //Validation
        public string Name { get; set; }
		[MaxLength(100)] //Validation
		public string Country { get; set; }
    }
}
