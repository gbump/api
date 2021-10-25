using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860;
namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlannerController : ControllerBase
    {
        public PlannerController()
        {
        }

        [HttpGet]
        public ActionResult<List<Planner>> GetAll() =>
        PlannerService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Planner> Get(int id)
        {
            var planner = PlannerService.Get(id);

            if (planner == null)
                return NotFound();

            return planner;
        }
        [HttpPost]
        public IActionResult Create(Planner planner)
        {
            PlannerService.Add(planner);
            return CreatedAtAction(nameof(Create), new { id = planner.Id }, planner);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Planner planner)
        {
            if (id != planner.Id)
                return BadRequest();
            var existingPlanner = PlannerService.Get(id);
            if (existingPlanner is null)
                return NotFound();

            PlannerService.Update(planner);
            //PlannerService.SaveChanges();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Planner planner)
        {
            var newplanner = PlannerService.Get(id);

            if (id != planner.Id)
                return BadRequest();
            if (newplanner is null)
                return NotFound();
            PlannerService.Patch(planner);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var planner = PlannerService.Get(id);

            if (planner is null)
                return NotFound();

            PlannerService.Delete(id);

            return NoContent();
        }

    }
}
