using Microsoft.AspNetCore.Mvc;
using KanbanBoard.Models;
using System.Collections.Generic;
using KanbanBoard.Model;

namespace KanbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IRepository<Users> repo = new UsersRepository();
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return repo.Get();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return repo.Show(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] Users value)
        {
            repo.Add(value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users value)
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