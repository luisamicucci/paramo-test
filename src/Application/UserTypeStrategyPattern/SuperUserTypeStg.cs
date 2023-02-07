using Application.Interfaces;
using Domain.Entities;
using System;

namespace Application.UserTypeStrategyPattern
{
    public class SuperUserTypeStg : IUserTypeStrategy
    {
        public void Execute(User user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = user.Money * percentage;
                user.Money += gif;
            }
        }
    }
}
