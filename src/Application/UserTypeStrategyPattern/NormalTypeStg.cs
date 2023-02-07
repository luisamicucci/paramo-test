using Application.Interfaces;
using Domain.Entities;
using System;

namespace Application.UserTypeStrategyPattern
{
    public class NormalTypeStg : IUserTypeStrategy
    {
        public void Execute(User user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                var gif = user.Money * percentage;
                user.Money += gif;
            }

            if (user.Money > 10 && user.Money <= 100)
            {
                var percentage = Convert.ToDecimal(0.8);
                var gif = user.Money * percentage;
                user.Money += gif;
            }
        }
    }
}
