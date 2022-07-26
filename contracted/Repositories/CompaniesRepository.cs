using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Interfaces;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class CompaniesRepository : IRepo<Company>
  {
    private readonly IDbConnection _db;

    public CompaniesRepository(IDbConnection db)
    {
      _db = db;
    }

    public Company Create(Company tData)
    {
      //   throw new NotImplementedException();
      string sql = @"
        INSERT INTO companies
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
      string sql = "DELETE FROM companies WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    public Company Edit(Company tData)
    {
      string sql = @"
      UPDATE companies
      SET
        name = @name
      WHERE id = @id";
      _db.Execute(sql, tData);
      return tData;
    }

    public List<Company> GetAll()
    {
      string sql = @"
      SELECT *
      FROM companies";
      return _db.Query<Company>(sql).ToList();
    }

    public Company GetById(int id)
    {
      string sql = @"SELECT * FROM companies WHERE id = @id";
      return _db.QueryFirstOrDefault<Company>(sql, new { id });
    }
  }
}