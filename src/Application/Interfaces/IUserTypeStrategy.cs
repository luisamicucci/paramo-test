using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserTypeStrategy
    {
        public void Execute(User user);
    }
}
