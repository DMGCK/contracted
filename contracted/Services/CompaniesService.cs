using System;
using System.Collections.Generic;
using contracted.Interfaces;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class CompaniesService : IService<Company>
  {

    CompaniesRepository _cr;

    public CompaniesService(CompaniesRepository cr)
    {
      _cr = cr;
    }

    public Company Create(Company companyData)
    {
      Company company = _cr.Create(companyData);
      return company;
    }

    public void Delete(int id)
    {
      GetById(id);
      _cr.Delete(id);
    }

    public Company Edit(Company update, int id)
    {
      Company original = GetById(id);
      original.name = update.name ?? original.name;
      _cr.Edit(original);
      return original;
    }

    public Company Edit(Company tData)
    {
      throw new NotImplementedException();
    }

    public List<Company> GetAll()
    {
      List<Company> all = _cr.GetAll();
      return all;
    }

    public Company GetById(int id)
    {
      Company found = _cr.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid ID");
      }
      return found;
    }

    public Company GetForValidate(int id)
    {
      throw new NotImplementedException();
    }
  }
}