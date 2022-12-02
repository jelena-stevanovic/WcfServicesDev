using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Birth date")]
        public DateTime BirthDate { get; set; }
    }
}