using Microsoft.AspNetCore.Mvc;
using KanbanBoard.Models;
using System.Collections.Generic;
using KanbanBoard.Model;

namespace KanbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        IRepository<Tasks> repo = new TasksRepository();
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Tasks> Get()
        {
            return repo.Get();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Tasks Get(int id)
        {
            return repo.Show(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] Tasks value)
        {
            repo.Add(value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tasks value)
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