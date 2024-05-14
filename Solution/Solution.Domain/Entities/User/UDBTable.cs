using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Solution.Domain.Enums;

namespace Solution.Domain.Entities.User
{
    public class UDBTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "UserName")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "UserName cannot be longer than 50 characters")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 characters")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }

        [StringLength(30)]
        public string LastIp { get; set; }

        public UserRole Level { get; set; }
    }
}
