using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required, StringLength(300),Display(Name ="Department Name")]
        public string? Name { get; set; }
    }
}
