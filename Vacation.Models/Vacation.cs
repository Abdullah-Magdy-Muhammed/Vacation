using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateTime SubmissionDate { get; set; }
        [Required,Display(Name="Employee Name")]
        public string? EmployeeName { get; set; }
        [Required]
        public string? Title { get; set;}
        [Required]
        public DateTime VacationDateFrom { get; set; }
        [Required]
        public DateTime VacationDateTo { get; set; }
        public DateTime Returning { get; set; }
        public int TotalNumberOfDaysRequested { get; set; }

        public string? Notes { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("EmployeeId")]
        public Department? Department { get; set; }






    }
}
