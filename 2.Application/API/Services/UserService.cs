using Common;
using Repository;
using Repository.Entity;

namespace API.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly PersonService _personService;

        public UserService(UserRepository userRepository, PersonService personService)
        {
            _userRepository = userRepository;
            _personService = personService;
        }

        public void AddUser(UserModel model)
        {
            int personId = model.PersonId;

            var person = _personService.GetPersonById(personId);

            if (person == null)
            {
                throw new ArgumentException($"PersonId {personId} não é válido.");
            }

            UserEntity entity = new UserEntity
            {
                PersonId = personId,
                Password = model.Password,
                Type = EnumType.ADMIN.ToString()
            };

            _userRepository.Add(entity);
        }
    }
}
