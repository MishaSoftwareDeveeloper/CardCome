using DAL.Functions;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{

    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Passport is required")]
        [RegularExpression(@"^\d+$",ErrorMessage = "The passport contains only numbers")]
        public string Identity { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            ErrorMessage = "Invalid email")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "The phone contains only numbers")]
        public string? PhoneNumber { get; set; }
    }
}
