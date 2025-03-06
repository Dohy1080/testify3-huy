using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Models
{
     [Table("Teacher")]
     public class Teacher
     {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phonenumber")]
        public string? PhoneNumber { get; set; }   
        [Column("subjectid")]
        public int SubjectId { get; set; }
        [Column("birthdate")]
        public DateTime BirthDate { get; set; }



    }
}
