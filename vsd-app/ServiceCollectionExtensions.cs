//using Database;
//using Manager;
using Microsoft.Extensions.DependencyInjection;
using Resources;
using Shared.Database;

namespace Gov.Cscp.VictimServices.Public;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        //services.AddTransient<ContractHandlers>();
        //services.AddTransient<IContractRepository, ContractRepository>();

        //services.AddTransient<CurrencyHandlers>();
        //services.AddTransient<ICurrencyRepository, CurrencyRepository>();

        //services.AddTransient<InvoiceHandlers>();
        services.AddTransient<IInvoiceRepository, InvoiceRepository>();

        //services.AddTransient<InvoiceLineDetailHandlers>();
        //services.AddTransient<IInvoiceLineDetailRepository, InvoiceLineDetailRepository>();

        //services.AddTransient<PaymentHandlers>();
        //services.AddTransient<IPaymentRepository, PaymentRepository>();

        services.AddTransient<IPaymentScheduleRepository, PaymentScheduleRepository>();

        services.AddTransient<ITeamRepository, TeamRepository>();

        services.AddTransient<IIncomeSupportParameterRepository, IncomeSupportParameterRepository>();

        return services;
    }

    public static IServiceCollection AddAutoMapperMappings(this IServiceCollection services)
    {
        // NOTE global and shared mapper should be first, since it has the prefix configurations and shared mappings
        var mapperTypes = new[] {
            typeof(GlobalMapper), typeof(SharedMapper), typeof(TeamMapper), typeof(PaymentScheduleMapper), typeof(EntitlementMapper), //typeof(CurrencyRepositoryMapper), typeof(PaymentRepositoryMapper), typeof(ProgramRepositoryMapper), typeof(ContractRepositoryMapper),
            typeof(InvoiceMapper), //typeof(InvoiceLineDetailRepositoryMapper), typeof(ScheduleGRepositoryMapper)
        };
        services.AddAutoMapper(cfg => cfg.ShouldUseConstructor = constructor => constructor.IsPublic, mapperTypes);
        return services;
    }
}
