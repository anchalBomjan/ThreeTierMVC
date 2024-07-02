using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Entities
{
   public  class EnrollmentViewModel
    {
        [Key]
        public int EnrollmentID { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

    }
}
