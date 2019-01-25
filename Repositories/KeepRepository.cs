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
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM Keeps WHERE isPrivate = 0;");
    }
    public IEnumerable<Keep> GetUsersKeeps(string user)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @user", new { user });
    }

    public Keep GetById(int id)
    {
      _db.Execute(@"
      UPDATE Keeps SET 
      views = views + 1
      WHERE id = @id;", new { id });
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM Keeps WHERE id = @id;", new { id });
    }

    // Create
    public string AddKeep(Keep keep)
    {
      return _db.ExecuteScalar<int>(@"
    INSERT INTO keeps (name, description, userId, img, isPrivate) VALUES (@Name, @Description, @UserId, @Img, @IsPrivate); 
    SELECT LAST_INSERT_ID()", keep) != 0
        ? "Success" : "Did not add";
    }

    internal string UpdateKeepShares(int id)
    {
      _db.Execute("UPDATE keeps SET shares=shares+1 WHERE id=@id", new { id });
      return "ok";
    }

    //   // Update
    //   public Burger UpdateBurger(int id, Burger burger)
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

    public bool DeleteKeep(int id, string userId)
    {
      int exe = _db.Execute($"DELETE FROM Keeps WHERE id = @id AND userId = @userId", new { id, userId });
      Console.WriteLine(exe);
      return exe != 0;
    }
  }
}