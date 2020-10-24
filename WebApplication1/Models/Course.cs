using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int CourseCredit { get; set; }
        public string CourseLecturer { get; set; }
        public string CourseGradeType { get; set; }
    }
}
