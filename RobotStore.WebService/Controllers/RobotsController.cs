using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RobotStore.WebService.Data;
using RobotStore.WebService.Models;

namespace RobotStore.WebService.Controllers
{
    public class RobotsController : ApiController
    {
        private RobotStoreContext db = new RobotStoreContext();
        private IDataAccessLayer dal;

        public RobotsController()
        {
            dal = new DataAccessLayer(db);
        }

        // GET: api/Robots
        public IQueryable<Robot> GetRobots()
        {
            return dal.getRobots().AsQueryable();
        }

        // GET: api/Robots/5
        [ResponseType(typeof(Robot))]
        public IHttpActionResult GetRobot(int id)
        {
            Robot robot = db.Robots.Find(id);
            if (robot == null)
            {
                return NotFound();
            }

            return Ok(robot);
        }

        // PUT: api/Robots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRobot(int id, Robot robot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != robot.Id)
            {
                return BadRequest();
            }

            db.Entry(robot).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Robots
        [ResponseType(typeof(Robot))]
        public IHttpActionResult PostRobot(Robot robot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Robots.Add(robot);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = robot.Id }, robot);
        }

        // DELETE: api/Robots/5
        [ResponseType(typeof(Robot))]
        public IHttpActionResult DeleteRobot(int id)
        {
            Robot robot = db.Robots.Find(id);
            if (robot == null)
            {
                return NotFound();
            }

            db.Robots.Remove(robot);
            db.SaveChanges();

            return Ok(robot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RobotExists(int id)
        {
            return db.Robots.Count(e => e.Id == id) > 0;
        }
    }
}