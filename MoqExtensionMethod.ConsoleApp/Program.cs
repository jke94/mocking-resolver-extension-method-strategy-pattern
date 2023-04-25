namespace MoqExtensionMethod.ConsoleApp
{
    #region using

    using Microsoft.Extensions.DependencyInjection;

    #endregion

    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Using depency injection to build strategies.

            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.BuildServiceProvider();
            serviceCollection.AddStrategies();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Select the strategy, to carry out a payment with different strategies.

            try
            {
                IStrategy strategy;

                strategy = serviceProvider.GetPaymentStrategy(StrategyName.Debit);
                await strategy.MakePayment();

                strategy = serviceProvider.GetPaymentStrategy(StrategyName.WireTransfer);
                await strategy.MakePayment();

                strategy = serviceProvider.GetPaymentStrategy(StrategyName.Bizum);
                await strategy.MakePayment();

                strategy = serviceProvider.GetPaymentStrategy(StrategyName.MonopoleyMoney);
                await strategy.MakePayment();

                Console.WriteLine("Payments done!");
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}