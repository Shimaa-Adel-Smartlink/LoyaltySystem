using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using LoyaltySystem.Business.Entities;
using LoyaltySystem.Business.EntitiesManager;

namespace LoyaltySystem.API
{
    public static class ConfigurationServiceCollectionExtension
    {
        /// <summary>
        /// this is for resolving the services 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Config"></param>
        /// <returns>services</returns>
        public static IServiceCollection AddAppCollection(this IServiceCollection services, IConfiguration Config)
        {
            #region configure the connection string

            //change isLocal to be false if you need to change the connection string of the server.
            bool isLocal = true;


            string localConnection = "localConn";
            string prodConnection = "serverConn";
            string connectionString = isLocal ? localConnection : prodConnection;

            #endregion




            #region resolving the servicess
            services.AddScoped<IUserManager, UserManager>();








            #endregion

            #region resolve the context 
            services.AddDbContext<LoyaltyContext>(options =>
                    options.UseSqlServer(Config.GetConnectionString(connectionString)));
            #endregion

            #region JWT configuration





            #endregion



            #region resolve swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "LoyaltySystem APIs",
                    Description = "LoyaltySystem",
                    Contact = new OpenApiContact
                    {
                        Name = "Shimaa Adel",
                        Email = "sAdelGaber@outlook.com"
                    }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            #endregion

            return services;
        }
    }
}