using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RobotStore.WebService.Models
{
    public class Robot
    {
        [Key]
        public int Id { get; set; }
        public string Designation { get; set; }
        public decimal Price { get; set; }
        public byte Image { get; set; }

    }
}
