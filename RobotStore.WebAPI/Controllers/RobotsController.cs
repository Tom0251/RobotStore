using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RobotStore.WebAPI.Models;

namespace RobotStore.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        private readonly RobotStoreContext _context;

        public RobotsController(RobotStoreContext context)
        {
            _context = context;
        }

        // GET: api/Robots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Robot>>> GetRobots()
        {
            return await _context.Robots.ToListAsync();
        }

        // GET: api/Robots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Robot>> GetRobot(Guid id)
        {
            var robot = await _context.Robots.FindAsync(id);

            if (robot == null)
            {
                return NotFound();
            }

            return robot;
        }

        // PUT: api/Robots/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRobot(Guid id, Robot robot)
        {
            if (id != robot.Id)
            {
                return BadRequest();
            }

            _context.Entry(robot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RobotExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Robots/Register
        [HttpPost, DisableRequestSizeLimit]
        [Route("Register")]
        public async Task<Object> PostRobot(string designation, string price, List<IFormFile> files)
        {
            IFormFile file = null;
            MemoryStream str = null;
            byte[] img = null;

            if (files.Count > 0)
            {
                file = files[0];

                using (str = new MemoryStream())
                {
                    file.CopyTo(str);
                }

                img = str.ToArray();
            }
              
            var robot = new Robot()
            {
                Id = Guid.NewGuid(),
                Designation = designation,
                Price = decimal.Parse(price),
                Image = img
            };

            try
            {
                _context.Robots.Add(robot);

                var result = await _context.SaveChangesAsync();
                return CreatedAtAction("GetRobot", new { id = robot.Id }, robot);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<ActionResult<Robot>> PostRobot(Robot robot)
        //{
        //    _context.Robots.Add(robot);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRobot", new { id = robot.Id }, robot);
        //}

        // DELETE: api/Robots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Robot>> DeleteRobot(Guid id)
        {
            var robot = await _context.Robots.FindAsync(id);
            if (robot == null)
            {
                return NotFound();
            }

            _context.Robots.Remove(robot);
            await _context.SaveChangesAsync();

            return robot;
        }

        private bool RobotExists(Guid id)
        {
            return _context.Robots.Any(e => e.Id == id);
        }
    }
}
