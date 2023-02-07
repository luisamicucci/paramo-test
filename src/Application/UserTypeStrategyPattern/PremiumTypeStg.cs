using Application.Interfaces;
using Domain.Entities;

namespace Application.UserTypeStrategyPattern
{
    public class PremiumTypeStg : IUserTypeStrategy
    {
        public void Execute(User user)
        {
            if (user.Money > 100)
            {
                var gif = user.Money * 2;
                user.Money += gif;
            }
        }
    }
}
