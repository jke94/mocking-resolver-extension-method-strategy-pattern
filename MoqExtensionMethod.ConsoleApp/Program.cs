namespace MoqExtensionMethod.ConsoleApp
{
    #region using

    using Microsoft.Extensions.DependencyInjection;

    #endregion

    public class Program
    {
        public static async Task Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.BuildServiceProvider();
            serviceCollection.AddStrategies();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Select the strategy, for example to carry out a payment with a Debit strategy.

            var paymement = serviceProvider.GetPaymentStrategy(StrategyName.Debit);

            await paymement.MakePayment();

            Console.WriteLine("Hello, World!");
        }
    }
}