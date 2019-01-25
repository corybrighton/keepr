using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using Dapper;
using keepr.Models;
using Keepr.Models;
using Microsoft.AspNetCore.Http;

namespace Keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    // Get Vaults and Keeps in Vaults by user
    public IEnumerable<Vault> GetAllByUser(string userId)
    {
      return _db.Query<Vault>("SELECT * FROM Vaults WHERE userId = @userId;", new { userId });
    }

    public Vault GetById(int id, string userId)
    {
      Vault result = _db.QueryFirstOrDefault<Vault>(@"
      SELECT * FROM vaults WHERE id = @id AND userId = @userId", new { id, userId });
      result.VaultsKeeps = _db.Query<Keep>(@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE(vaultId = @id AND vk.userId = @userId);", new { id, userId });

      return result;
    }

    // Create
    public string AddVault(Vault vault)
    {
      return _db.Execute(@"
    INSERT INTO Vaults (name, description, userId) VALUES (@Name, @Description, @UserId);
    ", vault) != 0 ? "Success" : "Did not add";
    }

    // Add keep to vault
    public string AddKeepToVault(VaultKeep vk)
    {
      int result = _db.Execute(@"
      INSERT INTO vaultkeeps (vaultId, keepId, userId)
      VALUES (@VaultId, @KeepId, @UserId);", vk);
      if (result != 0)
      {
        _db.Execute(@"
        UPDATE keeps SET keeps = keeps + 1 WHERE id = @KeepId", vk);
        return "Successfully Added";
      }
      return "Unable to add";
    }

    //   // Update
    //   public Vault UpdateVault(int id, Vault burger)
    //   {
    //     _db.ExecuteScalar<int>(@"
    // UPDATE Burgers SET 
    //  Name = @Name,
    //  Description = @Description,
    //  Price = @Price
    //  WHERE id = @id; 
    // SELECT LAST_INSERT_ID()", new
    //     {
    //       burger.Name,
    //       burger.Description,
    //       burger.Price,
    //       id
    //     });
    //     burger.id = id;
    //     return burger;
    //   }

    public bool DeleteVault(int id, string userId)
    {
      int exe = _db.Execute($"DELETE FROM vaults WHERE id = @Id AND userId = @UserId", new { id, userId });
      return (exe != 0);
    }

    public bool DeleteVaultKeep(VaultKeep vk)
    {
      _db.Execute("UPDATE keeps SET keeps = keeps - 1 WHERE id = @KeepId", vk);
      int exe = _db.QueryFirstOrDefault<int>("DELETE FROM vaultkeeps WHERE vaultId = @VaultId AND userId = @UserId AND keepId = @KeepId", vk);
      return (exe != 1);
    }

  }
}