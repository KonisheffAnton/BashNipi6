using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BashNipi6.Models
{
    [Table("objectB")]
    public class objectB
    {

        [Key]
        public int Id { get; set; }
        [Required]

        public string objectName { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]

        public DateTime ChangeData { get; set; }

        public DateTime CreateData { get; set; }

        public objectB() {
            
            ChangeData = (DateTime)DateTime.Now;
        }
    }
}
