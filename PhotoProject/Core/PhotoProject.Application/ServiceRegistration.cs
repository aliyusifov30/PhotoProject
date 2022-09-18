using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using PhotoProject.Application.Validators.UserValidators;

namespace PhotoProject.Application
{
    public static class ServiceRegistration
    {

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));

            services.AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<UserLoginValidator>());
        }

    }
}
