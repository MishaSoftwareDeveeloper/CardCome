using BL;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserLogic _logic = new UserLogic();
        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserModel>> Get()
        {
            return await _logic.GetAll();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel userModel)
        {
            return Ok(new { isInserted = await _logic.Add(userModel) });
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserModel userModel)
        {
            return Ok(new { isUpdated = await _logic.Update(userModel) });
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(new { isDeleted = await _logic.Delete(id) });
        }
    }
}
