using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Entities
{
    public class CourseViewModel
    {
        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        [Required]
        public int Credits { get; set; }

    }
}
