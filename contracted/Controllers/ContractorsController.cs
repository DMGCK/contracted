using System;
using System.Collections.Generic;
using contracted.Interfaces;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorsController : ControllerBase, IController<Contractor>
  {
    ContractorsService _cs;

    public ContractorsController(ContractorsService cs)
    {
      _cs = cs;
    }

    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor contractorData)
    {
      try
      {
        Contractor contractor = _cs.Create(contractorData);
        return Ok(contractor);
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
    public ActionResult<Contractor> Edit([FromBody] Contractor contractorData, int id)
    {
      try
      {
        Contractor update = _cs.Edit(contractorData, id);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public ActionResult<Contractor> Edit([FromBody] Contractor tData)
    {
      throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult<List<Contractor>> GetAll()
    {
      try
      {
        List<Contractor> contractor = _cs.GetAll();
        return Ok(contractor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]

    public ActionResult<Contractor> GetById(int id)
    {
      try
      {
        Contractor contractor = _cs.GetById(id);
        return Ok(contractor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}