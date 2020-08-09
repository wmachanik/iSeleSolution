using iSele.Models.Accounts;
using iSele.Models.Customers;
using iSele.Repository.Interfaces;
using iSele.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSele.Services
{
    public static class ApplicationRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //// Address services
            //services.AddScoped<IGenericRepository<InvoiceType>, GenericRepository<InvoiceType>>();

            //// customer repositories
            //services.AddScoped<IGenericRepository<Customer>, GenericRepository<Customer>>();
            //services.AddScoped<IGenericRepository<Address>, GenericRepository<Address>>();
            //services.AddScoped<IGenericRepository<ContactType>, GenericRepository<ContactType>>();
            //services.AddScoped<IGenericRepository<CustomerAccountingOptions>, GenericRepository<CustomerAccountingOptions>>();
            //services.AddScoped<IGenericRepository<CustomerContact>, GenericRepository<CustomerContact>>();
            //services.AddScoped<IGenericRepository<CustomerEquipment>, GenericRepository<CustomerEquipment>>();
            //services.AddScoped<IGenericRepository<CustomerPrefPerType>, GenericRepository<CustomerPrefPerType>>();


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IFancyGenericRepository<>), typeof(FancyGenericRepository<>));

            // services.AddTransient<IUnitOfWork, UnitOfWork>();
            //https://ngohungphuc.wordpress.com/2018/05/01/generic-repository-pattern-in-asp-net-core/
            //            To use in our controller class or service class. We only need to use DI pattern like this

            //private readonly IGenericRepository〈User〉 _userRepository;
            //public AccountController(
            //  IGenericRepository〈User〉 userRepository
            //)
            //        {
            //            _userRepository = userRepository;
            //        }

            //        public async Task GetAllUser()
            //        {
            //            var data = await _userRepository.GetAllAsync();
            //            // reset of code
            //        }

            return services;
        }
    }
}
