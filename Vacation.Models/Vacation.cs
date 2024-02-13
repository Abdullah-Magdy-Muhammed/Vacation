using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class Vacations
    {
        public int Id { get; set; }
        public DateTime SubmissionDate { get; set; }
        [Required, Display(Name = "Employee Name"), StringLength(200)]
        public string? EmployeeName { get; set; }
        [Required, StringLength(100)]
        public string? Title { get; set; }
        [Required,Display(Name ="Vacation From")]
        public DateTime VacationDateFrom { get; set; }
        [Required, Display(Name = "Vacation To")]
        public DateTime VacationDateTo { get; set; }
        public DateTime Returning { get; set; }
        [Display(Name = "Total Number Of Days Requested")]
        public int TotalNumberOfDaysRequested { get; set; }
        [StringLength(600)]
        public string? Notes { get; set; }
        [Required,Display(Name ="Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

    }
}
