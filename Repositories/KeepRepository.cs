using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

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

    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id = @id", new { id });
    }

    //   // Create
    //   public Burger AddBurger(Burger burger)
    //   {
    //     int id = _db.ExecuteScalar<int>(@"
    // INSERT INTO Burgers (name, description, price) VALUES (@Name, @Description, @Price); 
    // SELECT LAST_INSERT_ID()", new
    //     {
    //       burger.Name,
    //       burger.Description,
    //       burger.Price
    //     });
    //     burger.id = id;
    //     return burger;
    //   }

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

    //   public bool DeleteBurger(int id)
    //   {
    //     _db.Query<Burger>($"DELETE FROM Burgers WHERE id = @id", new { id });
    //     return true;
    //   }
  }
}