using System.Collections.Generic;

namespace contracted.Interfaces
{
  public interface IRepo<T>
  {
    public List<T> GetAll();
    public T GetById(int id);
    public T Create(T tData);
    public T Edit(T tData);
    public void Delete(int id);
  }
}