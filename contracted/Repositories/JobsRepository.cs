using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Interfaces;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class JobsRepository : IRepo<Job>
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Job Create(Job tData)
    {
      string sql = @"
        INSERT INTO jobs
        (contractorId, companyId)
        VALUES
        (@ContractorId, @CompanyId);
        SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, tData);
      tData.id = id;
      return tData;
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    public Job Edit(Job tData)
    {
      throw new System.NotImplementedException();
    }

    public List<Job> GetAll()
    {
      string sql = @"
      SELECT *
      FROM jobs";
      return _db.Query<Job>(sql).ToList();
    }

    public Job GetById(int id)
    {
      string sql = @"SELECT * FROM jobs WHERE id = @id";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }
  }
}