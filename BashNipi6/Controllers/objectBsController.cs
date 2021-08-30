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
    public class objectBsController : ControllerBase
    {

            ProjectsContext db;
            public objectBsController(ProjectsContext context)
            {
                db = context;
                if (!db.objectBs.Any())
                {
                    db.SaveChanges();
                }
            }

            [HttpGet]
        public async Task<ActionResult<IEnumerable<objectB>>> Get()
        {
            return await db.objectBs.ToListAsync();

        }
        
           
                [HttpGet("{idGet}")]
                public async Task<ActionResult<IEnumerable<objectB>>> Get(int idGet)
                    {
                        objectB objectb = await db.objectBs.FirstOrDefaultAsync(x => x.Id == idGet);
                        if (objectb == null)
                           return NotFound();
                        return new ObjectResult(objectb);
                    }

                 
                    [HttpPost]
                    public async Task<ActionResult<IEnumerable<objectB>>> Post(objectB objectb)
                    {
                        if (objectb == null)
                        {
                            return BadRequest();
                        }
                        objectb.CreateData = DateTime.Now;
                        db.objectBs.Add(objectb);
             
                        await db.SaveChangesAsync();
                        return Ok(objectb);
                    }
        
                  
                    [HttpPut]
                    public async Task<ActionResult<IEnumerable<objectB>>> Put(objectB objectb)
                    {
                        if (objectb == null)
                        {
                            return BadRequest();
                        }
                        if (!db.objectBs.Any(x => x.Id == objectb.Id))
                        {
                            return NotFound();
                        }
                         Project project = db.Projects.FirstOrDefault(x => x.Id == objectb.ProjectId);
                         project.ChangeData = DateTime.Now;
            db.Update(project);
            db.Update(objectb);
                        await db.SaveChangesAsync();
                        return Ok(objectb);
                    }

                   
                    [HttpDelete("{DeleteID}")]
                    public async Task<ActionResult<IEnumerable<objectB>>> Delete(int DeleteID)
                    {
                        objectB objectb = db.objectBs.FirstOrDefault(x => x.Id == DeleteID);
                        if (objectb == null)
                        {
                            return NotFound();
                        }
                        Project project = db.Projects.FirstOrDefault(x => x.Id == objectb.ProjectId);
                        project.ChangeData = DateTime.Now;
                         db.Update(project);
                         db.objectBs.Remove(objectb);
                        
                        await db.SaveChangesAsync();
                        return Ok(objectb);
                    }
    }
}
