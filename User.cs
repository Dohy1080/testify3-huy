using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Models
{
  
        [Table("User")]
        public class User
        {
           
            [Column("username")]
            public string? Username { get; set; }
            [Column("password")]
            public string? Password { get; set; }
          
           
        }
    }


