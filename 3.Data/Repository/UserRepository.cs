using Repository.Context;
using Repository.Entity;

namespace Repository
{
    public class UserRepository
    {
        private readonly EFContext _dataContext;

        public UserRepository(EFContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(UserEntity entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
