using BlazorDesk.Data.Models.Requests;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string FullName { get; set; }

        public IEnumerable<Request> Requests { get; set; }
    }
}
