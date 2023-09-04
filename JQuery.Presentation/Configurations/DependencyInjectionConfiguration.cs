using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JQuery.Application.Interfaces;
using JQuery.Application.Services;
using JQuery.Domain.Interfaces.Repositories;
using JQuery.Domain.Interfaces.Services;
using JQuery.Domain.Services;
using JQuery.Infra.Repository.Contexts;
using JQuery.Infra.Repository.Repositories;

namespace JQuery.Presentation.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //capturar a connectionstring do banco de dados (appsettings.json)
            var connectionstring = configuration.GetConnectionString("Conexao");

            //mapear a injeção de dependência para a classe 'SqlServerContext' localizada
            //no projeto Repository (classe que irá fazer a conexão com o banco de dados)
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionstring));

            //mapear a injeção de dependencia das demais classes e interfaces do sistema
            services.AddTransient<IFriendApplicationService, FriendApplicationService>();
            services.AddTransient<IFriendDomainService, FriendDomainService>();
            services.AddTransient<IFriendRepository, FriendRepository>();

            services.AddTransient<IStateApplicationService, StateApplicationService>();
            services.AddTransient<IStateDomainService, StateDomainService>();
            services.AddTransient<IStateRepository, StateRepository>();
        }
    }
}
