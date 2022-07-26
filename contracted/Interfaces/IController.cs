using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Interfaces
{
  public interface IController<T>
  {
    public ActionResult<List<T>> GetAll();
    public ActionResult<T> GetById(int id);
    public ActionResult<T> Create([FromBody] T tData);
    public ActionResult<T> Edit([FromBody] T tData, int id);
    public ActionResult<string> Delete(int id);


  }
}