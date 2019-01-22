using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public KeepsController(KeepRepository repo)
    {
      _repo = repo;
    }

    // GET api/Keeps
    [HttpGet]
    public IEnumerable<Keep> Get()
    {
      return _repo.GetAll();
    }

    // GET api/Keeps/5
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep keep = _repo.GetById(id);
      if (keep != null)
      {
        return Ok(keep);
      }
      else
      {
        return NotFound();
      }
    }

    // POST api/Keeps
    [HttpPost]
    public ActionResult<string> Post([FromBody] Keep keep)
    {
      keep.UserId = HttpContext.User.Identity.Name;
      if (keep.UserId != null)
        return Ok(_repo.AddKeep(keep));
      return Unauthorized();
    }

    // // PUT api/Burgers/5
    // [HttpPut("{id}")]
    // public ActionResult<Burger> Put(int id, [FromBody] Burger burger)
    // {
    //   return Ok(_burgerRepo.UpdateBurger(id, burger));
    // }

    // DELETE api/Burgers/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteKeep(id, HttpContext.User.Identity.Name)) { return Ok("Successfully Deleted"); }
      return BadRequest("Unable to Delete");
    }

  }
}