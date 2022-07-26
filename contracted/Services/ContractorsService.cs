using System;
using System.Collections.Generic;
using contracted.Interfaces;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class ContractorsService : IService<Contractor>
  {
    ContractorsRepository _cr;

    public ContractorsService(ContractorsRepository cr)
    {
      _cr = cr;
    }
    public Contractor Create(Contractor contractorData)
    {
      Contractor contractor = _cr.Create(contractorData);
      return contractor;
    }

    public void Delete(int id)
    {
      GetById(id);
      _cr.Delete(id);
    }

    public Contractor Edit(Contractor update, int id)
    {
      Contractor original = GetById(id);
      original.name = update.name ?? original.name;
      _cr.Edit(original);
      return original;
    }

    public Contractor Edit(Contractor contractorData)
    {
      throw new System.NotImplementedException();
    }

    public System.Collections.Generic.List<Contractor> GetAll()
    {
      List<Contractor> all = _cr.GetAll();
      return all;
    }

    public Contractor GetById(int id)
    {
      Contractor found = _cr.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid ID");
      }
      return found;
    }

    public Contractor GetForValidate(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}