using Application.Commands.AddNewUser;
using Application.Interfaces;
using Application.UserTypeStrategyPattern;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(new Type[]
            {
              typeof(AddNewUserCommand),
            });
            services.AddScoped<IUserTypeStrategy, NormalTypeStg>();
            services.AddScoped<IUserTypeStrategy, SuperUserTypeStg>();
            services.AddScoped<IUserTypeStrategy, PremiumTypeStg>();
        }
    }
}
