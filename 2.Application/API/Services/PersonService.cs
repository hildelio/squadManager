using Common;
using Repository;
using Repository.Entity;

namespace API.Services
{
  public class PersonService
  {
    private readonly PersonRepository _personRepository;

    public PersonService(PersonRepository personRepository)
    {
      _personRepository = personRepository;
    }

    public int AddPerson(PersonModel model)
    {
      PersonEntity entity = new PersonEntity
      {
        Username = model.Username,
        Email = model.Email
      };
      return _personRepository.Add(entity);
    }

    public PersonEntity GetPersonById(int id)
    {
      return _personRepository.GetById(id);
    }

  }
}
