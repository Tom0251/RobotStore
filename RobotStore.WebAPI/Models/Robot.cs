using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RobotStore.WebAPI.Models
{
    public class Robot
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Designation { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        public byte[] Image { get; set; }

    }
}
