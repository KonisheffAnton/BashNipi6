using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BashNipi6.Models
{
    [Table("Project")]
    public class Project
    {
            [Key]
           
            public int Id { get; set; }
        [Required]
            public string ProjectName { get; set; }
            public DateTime CreateData { get; set; }

            public DateTime ChangeData { get; set; }
            public List<objectB> objectBs { get; set; } = new List<objectB>();

        public Project()
        {
            
            ChangeData = (DateTime)DateTime.Now;
        }
    }
}
