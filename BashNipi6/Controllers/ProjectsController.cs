using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BashNipi6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BashNipi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

            ProjectsContext db;
            public ProjectsController(ProjectsContext context)
            {
                db = context;
                if (!db.Projects.Any())
                {
                    db.SaveChanges();
                }
            }

            [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            return await db.Projects.Include(p=>p.objectBs).ToListAsync();

        }

      
        [HttpGet("{idGet}")]
        public async Task<ActionResult<Project>> Get(int idGet)
            {
                Project project = await db.Projects.FirstOrDefaultAsync(x => x.Id == idGet);
                if (project == null)
                   return NotFound();
                return new ObjectResult(project);
            }
        
          
            [HttpPost]
            public async Task<ActionResult<Project>> Post(Project project)
            {
                if (project == null)
                {
                    return BadRequest();
                }
                project.CreateData = DateTime.Now;
                db.Projects.Add(project);
                await db.SaveChangesAsync();
                return Ok(project);
            }
       
        
            [HttpPut]
            public async Task<ActionResult<Project>> Put(Project project)
            {
                if (project == null)
                {
                    return BadRequest();
                }
                if (!db.Projects.Any(x => x.Id == project.Id))
                {
                    return NotFound();
                }

                db.Update(project);
                await db.SaveChangesAsync();
                return Ok(project);
            }

           
            [HttpDelete("{DeleteID}")]
            public async Task<ActionResult<Project>> Delete(int DeleteID)
            {
                Project projectBash = db.Projects.FirstOrDefault(x => x.Id == DeleteID);
                if (projectBash == null)
                {
                    return NotFound();
                }
                db.Projects.Remove(projectBash);
                await db.SaveChangesAsync();
                return Ok(projectBash);
            }
        }
}
