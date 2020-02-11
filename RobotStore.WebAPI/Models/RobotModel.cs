using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RobotStore.WebAPI.Models
{
    public class RobotModel
    {
        public string Designation { get; set; }

        public string Price { get; set; }

        public List<IFormFile> Image { get; set; }
    }
}
