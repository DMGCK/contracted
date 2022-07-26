using System;
using System.Collections.Generic;
using contracted.Interfaces;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CompanyController : ControllerBase, IController<Company>
  {
    CompaniesService _cs;

    public CompanyController(CompaniesService cs)
    {
      _cs = cs;
    }

    [HttpPost]
    public ActionResult<Company> Create([FromBody] Company companyData)
    {
      try
      {
        Company company = _cs.Create(companyData);
        return Ok(company);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _cs.Delete(id);
        return Ok($"Deleted ID#{id}");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Company> Edit([FromBody] Company companyData, int id)
    {
      try
      {
        Company update = _cs.Edit(companyData, id);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Company>> GetAll()
    {
      try
      {
        List<Company> companies = _cs.GetAll();
        return Ok(companies);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Company> GetById(int id)
    {
      try
      {
        Company company = _cs.GetById(id);
        return Ok(company);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}