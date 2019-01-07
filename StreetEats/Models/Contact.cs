using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StreetEats.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Please fill in a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide an email address")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Please check your email address e.g. john.smith@mail.com")]
        [DisplayName("Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter a subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage ="Please enter a message")]
        [DisplayName("Your message")]
        public string Message { get; set; }
    }
}