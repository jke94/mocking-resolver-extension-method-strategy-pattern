namespace MoqExtensionMethod.ConsoleApp
{
    #region using

    using Microsoft.Extensions.DependencyInjection;
    using MoqExtensionMethod.ConsoleApp.Strategies;

    #endregion

    public static class StrategyResolverExtension
    {
        public static IStrategy GetStrategy(
            this IServiceProvider serviceProvider, string strategy)
        {
            return strategy switch
            {
                StrategyName.Bizum => serviceProvider.GetRequiredService<BizumStrategy>(),
                StrategyName.Cash => serviceProvider.GetRequiredService<CashStrategy>(),
                StrategyName.CreditCard => serviceProvider.GetRequiredService<CreditCardStrategy>(),
                StrategyName.Debit => serviceProvider.GetRequiredService<DebitStrategy>(),
                StrategyName.WireTransfer => serviceProvider.GetRequiredService<WireTransferStrategy>(),

                _ => throw new NotImplementedException($"Strategy {strategy} has not been implemented."),
            };
        }
    }
}
