using Microsoft.AspNetCore.Mvc;
using KanbanBoard.Models;
using System.Collections.Generic;
using KanbanBoard.Model;

namespace KanbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IRepository<Project> repo = new ProjectRepository();
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return repo.Get();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            return repo.Show(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] Project value)
        {
            repo.Add(value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Project value)
        {
            repo.UpDate(id, value);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}