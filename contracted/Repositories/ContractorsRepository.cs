using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Interfaces;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class ContractorsRepository : IRepo<Contractor>
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Contractor Create(Contractor tData)
    {
      string sql = @"
        INSERT INTO contractors
        (name)
        VALUES
        (@Name);
        SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, tData);
      tData.id = id;
      return tData;
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    public Contractor Edit(Contractor tData)
    {
      string sql = @"
      UPDATE contractors
      SET
        name = @name
      WHERE id = @id";
      _db.Execute(sql, tData);
      return tData;
    }

    public List<Contractor> GetAll()
    {
      string sql = @"
      SELECT *
      FROM contractors";
      return _db.Query<Contractor>(sql).ToList();
    }

    public Contractor GetById(int id)
    {
      string sql = @"SELECT * FROM contractors WHERE id = @id";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }
  }
}