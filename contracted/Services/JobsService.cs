using System;
using System.Collections.Generic;
using contracted.Interfaces;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class JobsService : IService<Job>
  {

    JobsRepository _jr;

    public JobsService(JobsRepository jr)
    {
      _jr = jr;
    }

    public Job Create(Job jobData)
    {
      Job job = _jr.Create(jobData);
      return job;
    }

    public void Delete(int id)
    {
      GetById(id);
      _jr.Delete(id);
    }

    public Job Edit(Job update, int id)
    {
      //   Job original = GetById(id);
      //   original.contractorId = update.contractorId ?? original.contractorId;
      //   original.name = update.name ?? original.name;
      //   _jr.Edit(original);
      //   return original;
      throw new NotImplementedException();
      ///TODO
    }

    public Job Edit(Job jobData)
    {
      throw new NotImplementedException();
    }

    public List<Job> GetAll()
    {
      List<Job> all = _jr.GetAll();
      return all;
    }

    public Job GetById(int id)
    {
      Job found = _jr.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid ID");
      }
      return found;
    }

    public Job GetForValidate(int id)
    {
      Job found = _jr.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid ID");
      }
      return found;
    }
  }
}