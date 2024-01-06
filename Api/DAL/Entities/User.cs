using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Identity { get; set; }

        [Required]
        public string Name { get; set; }    
        public string? Mail { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
