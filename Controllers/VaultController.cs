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
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public VaultsController(VaultRepository repo)
    {
      _repo = repo;
    }

    // GET api/Vaults
    [HttpGet]
    public IEnumerable<Vault> Get()
    {
      return _repo.GetAllByUser(HttpContext.User.Identity.Name);
    }

    // GET api/Vault/5
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      IEnumerable<Keep> vault = null;
      string user = HttpContext.User.Identity.Name;
      if (user != null)
      {
        vault = _repo.GetById(id, user);
      }
      if (vault != null)
      {
        return Ok(vault);
      }
      return NotFound("Not found");
    }

    // POST api/Vaults
    [HttpPost]
    public ActionResult<string> Post([FromBody] Vault vault)
    {
      vault.UserId = HttpContext.User.Identity.Name;
      if (vault.UserId != null)
        return Ok(_repo.AddVault(vault));
      return Unauthorized($"Can not add vault. {vault.Name}");
    }

    // Add Keep to vault
    [HttpPost("{id}")]
    public ActionResult<string> Post([FromBody] VaultKeep vk)
    {
      vk.UserId = HttpContext.User.Identity.Name;
      if (vk.UserId != null)
      {
        return Ok(_repo.AddKeepToVault(vk));
      }
      return Unauthorized($"Can not add keep to vault");
    }

    // // PUT api/Burgers/5
    // [HttpPut("{id}")]
    // public ActionResult<Burger> Put(int id, [FromBody] Burger burger)
    // {
    //   return Ok(_burgerRepo.UpdateBurger(id, burger));
    // }

    // DELETE api/Vault/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteVault(id, HttpContext.User.Identity.Name)) { return Ok("Successfully Deleted vault"); }
      return BadRequest("Unable to Delete Vault");
    }

    // DELETE api/Vault/5
    [HttpDelete]
    public ActionResult<string> Delete([FromBody] VaultKeep vk)
    {
      vk.UserId = HttpContext.User.Identity.Name;
      if (_repo.DeleteVaultKeep(vk)) { return Ok("Successfully Deleted vault"); }
      return BadRequest("Unable to Delete Vault");
    }

  }
}