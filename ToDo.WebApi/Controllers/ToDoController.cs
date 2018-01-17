using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.EfRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext _context;

        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
         public async Task<IActionResult> Get()
        {
            var toDoList = _context.ToDos.ToList();
            return Ok(toDoList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var toDo = _context.ToDos.FirstOrDefault(x => x.Id == id);
            if (toDo != null)
                return Ok(toDo);
            else
                return NotFound();
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.ToDo value)
        {
            if (ModelState.IsValid)
            {
                if (_context.ToDos.Any(x => x.Id == value.Id))
                    return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status409Conflict);  //409 is HTTP Conflict

                _context.ToDos.Add(value);
                _context.SaveChanges();
                //Do something with object
                return Created(new Uri(Request.Host.ToUriComponent() + Request.Path + "/" + value.Id.ToString()) , value);
            } else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Models.ToDo value)
        {
            if (ModelState.IsValid)
            {
                var toDoToUpdate = _context.ToDos.FirstOrDefault(x => x.Id == id);
                if (toDoToUpdate == null)
                    return NotFound(value);

                toDoToUpdate.Description = value.Description;
                toDoToUpdate.IsComplete = value.IsComplete;
                _context.SaveChanges();


                return Ok(value);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDo = _context.ToDos.FirstOrDefault(x => x.Id == id);
            if (toDo == null)             
                return NotFound();

            _context.Remove(toDo);
            _context.SaveChanges();
            return Ok();
        }
    }
}
