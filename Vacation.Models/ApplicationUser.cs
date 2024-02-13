using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();

    }
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }
        public ApplicationRole(string roleName) : base(roleName)
        {

        }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUser? User { get; set; }
        public ApplicationRole? Role { get; set; }
    }
    public enum RoleList
    {
        [Display(Name = "Super Admin")]
        SuperAdmin = 1,
        [Display(Name = "Admin")]
        Admin = 2,
        [Display(Name = "Sub Admin")]
        SubAdmin = 3,
    }
}
