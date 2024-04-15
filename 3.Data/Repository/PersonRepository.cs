using Repository.Context;
using Repository.Entity;

namespace Repository
{
  public class PersonRepository
  {
    private readonly EFContext _dataContext;

    public PersonRepository(EFContext dataContext)
    {
      _dataContext = dataContext;
    }

    public int Add(PersonEntity entity)
    {
      _dataContext.Add(entity);
      _dataContext.SaveChanges();
      return entity.Id;
    }

    public PersonEntity GetById(int id)
    {
      return _dataContext.Persons.Find(id);
    }
  }

}
