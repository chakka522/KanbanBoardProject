using Microsoft.AspNetCore.Mvc;
using KanbanBoard.Models;
using System.Collections.Generic;
using KanbanBoard.Model;

namespace KanbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IRepository<Login> repo = new LoginRepository();
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Login> Get()
        {
            return repo.Get();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Login Get(int id)
        {
            return repo.Show(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] Login value)
        {
            repo.Add(value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Login value)
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