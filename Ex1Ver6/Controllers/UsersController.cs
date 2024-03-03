using Ex1Ver6.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ex1Ver6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new User().Read();
        }

        // GET api/<UsersController>/5
        [HttpGet("{email}")]
        public User Get(string email)
        {
            return new User().GetUser(email);
        }

        // POST api/<UsersController>
        [HttpPost]
        public int Post([FromBody] User user)
        {
            return user.Insert();
        }

        // POST api/<UsersController>
        [HttpPost("{email}")]
        public User Login(string email, [FromBody] string password )
        {
            return new User().Login(email, password);
        }

        // PUT api/<UsersController>/5
        [HttpPut("Put/firstName/{firstName}/familyName/{familyName}/email/{email}")]
        public int Put(string firstName, string familyName, string email, [FromBody] string password)
        {
            return new User().Update(firstName, familyName, email, password);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
