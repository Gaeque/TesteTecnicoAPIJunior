using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoAPIJunior.Context;
using TesteTecnicoAPIJunior.Entities;

namespace TesteTecnicoAPIJunior.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobContext _jobContext;

        public JobsController(JobContext jobContext)
        {
            _jobContext = jobContext;
        }

        [HttpGet()]
        public ActionResult ViewJobs() {

            var Job = _jobContext.Jobs.ToList();

            return Ok(Job);
        }

        [HttpGet("{id}")]
        public IActionResult ViewJobsById(int id)
        {
            var Job = _jobContext.Jobs.Find(id);

            if(Job != null)
            {
                return Ok(Job);
            } else
            {
                return NotFound();
            }
        }


        [HttpPost()]
        public IActionResult CriateJob(Jobs job)
        {
            _jobContext.Jobs.Add(job);
            _jobContext.SaveChanges();
            return Ok(job);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateJob(int id, Jobs job)
        {
            var jobUpdate = _jobContext.Jobs.Find(id);

            if(jobUpdate == null)
            {
                return BadRequest();
            }

            jobUpdate.Tittle = job.Tittle;
            jobUpdate.Description = job.Description;
            jobUpdate.Location = job.Location;
            jobUpdate.Salary = job.Salary;

            _jobContext.Jobs.Update(jobUpdate);
            _jobContext.SaveChanges();
            return Ok(jobUpdate);
 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var deleteJobs = _jobContext.Jobs.Find(id);

            if(deleteJobs == null)
            {
                return NotFound(id);
            }

            _jobContext.Jobs.Remove(deleteJobs);
            _jobContext.SaveChanges();  
            return Ok(deleteJobs);

        }

    }
}
