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

    internal List<ContractorJobViewModel> GetByCompanyId(int id)
    {
      // coming from company
      string sql = @"
      SELECT j.id AS jobId,
      ct.*,
      ct.id AS id
      FROM jobs j
      JOIN contractors ct ON ct.id = j.contractorId
      WHERE j.companyId = @id
      ";
      return _db.Query<ContractorJobViewModel>(sql, new { id }).ToList();
    }

    internal List<CompanyJobViewModel> GetJobsByContractorId(int id)
    {
      string sql = @"
      SELECT j.id AS jobId,
      cy.*,
      cy.id AS id
      FROM jobs j
      JOIN companies cy ON cy.id = j.companyId
      WHERE j.contractorId = @id
      ";
      return _db.Query<CompanyJobViewModel>(sql, new { id }).ToList();
    }
  }
}