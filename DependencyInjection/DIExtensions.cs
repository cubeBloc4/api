using System;
using Core;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DependencyInjection;

public static class DIExtensions
{
    public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<DatabaseOptions>()
                .Configure(opt =>
                {
                    opt.Server = configuration["DB_SERVER"];
                    opt.Port = configuration["DB_PORT"];
                    opt.Name = configuration["DB_NAME"];
                    opt.User = configuration["DB_USER"];
                    opt.Password = configuration["DB_PASSWORD"];
                    opt.TrustServerCertificate = configuration["SELFSIGNED_CERTS"] == "true";
                });

        services.AddDbContext<StiveDbContext>((serviceProvider, options) =>
                {
                    var dbOpt = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

                    var dataSource = string.IsNullOrWhiteSpace(dbOpt.Port)
                        ? dbOpt.Server
                        : $"{dbOpt.Server},{dbOpt.Port}";

                    var csb = new SqlConnectionStringBuilder
                    {
                        DataSource = dataSource,
                        InitialCatalog = dbOpt.Name,
                        UserID = dbOpt.User,
                        Password = dbOpt.Password,
                        TrustServerCertificate = dbOpt.TrustServerCertificate,
                    };
                    if (!string.IsNullOrWhiteSpace(dbOpt.User))
                    {
                        csb.UserID = dbOpt.User;
                        csb.Password = dbOpt.Password;
                    }
                    else
                    {
                        csb.IntegratedSecurity = true;
                    }

                    options.UseSqlServer(csb.ConnectionString);
                });
        services.AddTransient<IUOMRepository, CustomerRepository>();
        services.AddTransient<ISupplierRepository, SupplierRepository>();
        services.AddTransient<IUnitOfMeasureRepository, UnitOfMeasureRepository>();
    }
}
