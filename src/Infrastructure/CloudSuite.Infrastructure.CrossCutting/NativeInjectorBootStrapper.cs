using CloudSuite.Infrastructure.Data.Cora.Context;
using CloudSuite.Modules.Cora.Application.Services.Contracts;
using CloudSuite.Modules.Cora.Application.Services.Implementations;
using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace CloudSuite.Infrastructure.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterService(IServiceCollection service)
        {
            service.AddScoped<CoraDbContext>();

            service.AddScoped<IPaymentSchedulingRepository>();

            // Application

            service.AddScoped<IPaymentSchedullingAppService, PaymentSchedullingAppService>();


        }
    }
}