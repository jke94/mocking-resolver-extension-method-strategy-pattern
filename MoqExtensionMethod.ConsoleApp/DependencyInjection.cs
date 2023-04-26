namespace MoqExtensionMethod.ConsoleApp
{
    #region using

    using Microsoft.Extensions.DependencyInjection;
    using MoqExtensionMethod.ConsoleApp.Strategies;

    #endregion

    public static class DependencyInjection
    {
        public static IServiceCollection AddStrategies(this IServiceCollection services)
        {
            services.AddTransient<BizumStrategy>();
            services.AddTransient<CashStrategy>();
            services.AddTransient<CreditCardStrategy>();
            services.AddTransient<DebitStrategy>();
            services.AddTransient<WireTransferStrategy>();

            return services;
        }
    }
}
